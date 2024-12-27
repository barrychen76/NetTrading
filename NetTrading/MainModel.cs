using NetTrading.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NetTrading.MM;
using System.Threading;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using PyWrapper;

namespace NetTrading
{
    public delegate void MessageHandler(String message);
    public delegate void PriceReceivedHandler(List<RT_Code_Price> lsPrices);

    internal class MainModel : INotifyPropertyChanged//, IDisposable
    {
        #region 单件模式, 创建实例
        private static MainModel mainModel;

        public static MainModel Instance()
        {
            mainModel = new MainModel();

            return mainModel;
        }
        #endregion

        private MessageHandler messageHandler;
        private PriceReceivedHandler priceReceivedHandler;

        ~MainModel() 
        {
            Exit();
        }

        private DBOpera _dbOpera = DBOpera.GetInstance();
        public SQLiteConnection Conn { get { return _dbOpera.Conn; } }

        public BackgroundMonitor BkMonitor { get; private set; }

        public List<Trading> Tradings = new List<Trading>();
        //public Dictionary<string, Trading> Tradings = new Dictionary<string, Trading>();

        public void Init()
        {
            LoadTradings();
        }

        private bool _exitSuccess = false;
        public void Exit()
        {
            if (_exitSuccess == false)
            {
                SaveTradings();
                _exitSuccess = true;
            }
        }

        public void Buy(string name, string code, double price, int count, AccountType accType, String sPolicyName, DateTime dtBuy, string comment)
        {
            Trading t = Tradings.Find(x => x.Name == name);

            if (t is null)
            {
                //t = Tradings[index];

                // 该标的还没有被建仓
                // 创建交易
                t = new Trading(name, code);
                t.Code = code;
                t.Name = name;
                t.DtBegin = dtBuy;
                t.Comment = comment;
                t.Finished = false;

                //Tradings[name] = t;
                Tradings.Add(t);
            }

            t.Buy(price, count, accType, sPolicyName, dtBuy, comment);
        }

        public void Sell(string name, int id, double price, int count, String comment)
        {
            Trading trading = Tradings.Find(x => x.Name == name);
            //Trading trading = Tradings[name];

            if (trading != null)
            {
                trading.Sell(id, price, count, comment);
            }
        }

        // 输入股票代码，输出估值
        public void SearchValue(string name)
        {

        }

        private void ReCalcTrading(string name)
        {
            
        }

        public void StartBkMonitor()
        {
            List<String> lsCode = new List<String>();

            foreach (Trading trading in Tradings)
            {
                String code = trading.Code;
                if (trading.Code.Length == 6)
                {
                    if (trading.Code.Substring(0, 1) == "6" || trading.Code.Substring(0, 3) == "788")
                    {
                        code = trading.Code + ".SH";
                    }
                    else
                    {
                        code = trading.Code + ".SZ";
                    }
                }

                lsCode.Add(code);
            }
            //List<String> ll = new List<string>();
            //ll.Add("SZ.000651");
            BkMonitor = new BackgroundMonitor();
            BkMonitor.Model = this;
            BkMonitor.OnMessageReceived += BkMonitor_OnMessageReceived;
            BkMonitor.OnPricesReceived += BkMonitor_OnPricesReceived;
            BkMonitor.StartUpdatingData(lsCode);
        }

        private void BkMonitor_OnMessageReceived(string obj)
        {
            messageHandler?.Invoke(obj);
        }

        private void BkMonitor_OnPricesReceived(List<RT_Code_Price> lsPrice)
        {
            //foreach (RT_Code_Price item in lsPrice)
            //{
            //    String code = item.Code;
            //    double price = item.Price;

            //    Trading? trading = Tradings.Find(x => x.Code == code);

            //    if (trading != null)
            //    {
            //        trading.CurrentPrice = price;
            //        //trading.priceReceived(item);
            //    }
            //}

            priceReceivedHandler?.Invoke(lsPrice);
        }

        public void LoadTradings()
        {
            string filepath = "d:\\a.json";
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                JArray jsonArray = JArray.Parse(json);

                this.Tradings = jsonArray.ToObject<List<Trading>>();

                //foreach (var item in tradingItems)
                //{
                //    Console.WriteLine($"ID: {item.Id}, Code: {item.Code}, Name: {item.Name}, Begin: {item.DtBegin}, End: {item.DtEnd}");
                //    foreach (var sub in item.SubTradings)
                //    {
                //        Console.WriteLine($"\tSub ID: {sub.Id}, BuyPrice: {sub.BuyPrice}, BuyCount: {sub.BuyCount}, PolicyName: {sub.PolicyName}, DtBuy: {sub.DtBuy}");
                //    }
                //}
                //JObject jsonObj = JObject.Parse(json);
                //Tradings = jsonObj.ToObject<Dictionary<string, Trading>>();
            }
            else
            {
                //Tradings = new Dictionary<string, Trading>();
            }

            //BkMonitor.AddStock()
        }

        public void SaveTradings()
        {
            string filepath = "d:\\a.json";
            string json = JsonConvert.SerializeObject(Tradings, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        public void SetMessageHandler(MessageHandler handler)
        {
            messageHandler = handler;
        }

        public void SetPriceReceivedHandler(PriceReceivedHandler handler)
        {
            priceReceivedHandler = handler;
        }

        //public void WriteMessage(String message)
        //{
        //    messageHandler?.Invoke(message);
        //}

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)mainModel).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)mainModel).PropertyChanged -= value;
            }
        }

        private int NewID()
        {
            for (int i = 0; i < 1000; i++)
            {
                int iFind = Tradings.FindIndex(x => x.Id == i);

                if (iFind == -1)
                {
                    return i;
                }
            }

            throw new Exception("Trading.NewID 无法被产生。");
        }

        //public event EventHandler<DataFetchedEventArgs> DataFetched;
        //protected virtual void OnDataFetched(DataFetchedEventArgs e)
        //{
        //    DataFetched?.Invoke(this, e);
        //}

        //public void Dispose()
        //{

        //}
    }

    public class DataFetchedEventArgs : EventArgs
    {
        public List<DataRow> Data { get; }

        public DataFetchedEventArgs(List<DataRow> data)
        {
            Data = data;
        }
    }
}
