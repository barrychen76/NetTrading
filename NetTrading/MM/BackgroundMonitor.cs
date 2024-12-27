using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using System.Threading.Tasks;
using NetTrading;
using PyWrapper;

namespace NetTrading.MM
{
    internal class DataUpdateEventArgs : EventArgs
    {
        public Dictionary<string, StockOHLCV> NewData { get; }
        public DataUpdateEventArgs(Dictionary<string, StockOHLCV> newData) 
        {
            NewData = newData;
        }
    }

    internal class BackgroundMonitor
    {
        private static readonly object lockObj = new object();
        private List<String> lsStocks = new List<String>();
        //private Ts_RT_Agent tsRtAgent;// = new Ts_RT_Agent();

        public MainModel Model { get; set; }
        public event Action<string> OnMessageReceived;
        public event Action<List<RT_Code_Price>> OnPricesReceived;

        private BackgroundWorker _bkWorker;
        private System.Threading.Timer _timer;

        public event EventHandler<DataUpdateEventArgs> DataUpdated;

        //public List<string> StocksCode { get; set; } = new List<string>();

        public void StartUpdatingData(List<string> symbols)
        {
            //tsRtAgent = new Ts_RT_Agent();

            SetMonitorStocks(symbols);

            int intervalSeconds = 10 * 60 * 1000;        // 10分钟调用一次

            _bkWorker = new BackgroundWorker();
            _bkWorker.WorkerReportsProgress = true;
            _bkWorker.WorkerSupportsCancellation = true;
            _bkWorker.DoWork += Bk_DoWork;
            _bkWorker.ProgressChanged += BkWorker_ProgressChanged;
            _bkWorker.RunWorkerCompleted += BkWorker_RunWorkerCompleted;

            _timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private async void TimerCallback(object state)
        {
            try
            {
                // 检查 BackgroundWorker 是否正在运行
                if (!_bkWorker.IsBusy)
                {
                    // 开始后台工作
                    _bkWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void BkWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                OnMessageReceived?.Invoke(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                OnMessageReceived?.Invoke(e.Cancelled.ToString());
            }
            else
            {
                List<RT_Code_Price> lsPrice = e.Result as List<RT_Code_Price>;
                OnPricesReceived?.Invoke(lsPrice);

                String msg = String.Format("Received {0} prices.", lsPrice.Count);

                OnMessageReceived?.Invoke(msg);
            }
        }

        private void BkWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is List<RT_Code_Price> lsPrice)
            {
                // 更新UI内容
            }
        }

        private static int sTime = 1;
        private void Bk_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<String> lsCodes = GetMonitorStocks();
                if (lsCodes.Count > 0)
                {
                    //List<String> ls = new List<String>();
                    //ls.Add("000001.SZ");
                    //ls.Add("000001.SH");
                    //ls.Add("600000.SH");
                    //List<RT_Code_Price> ll = QueryPrice(ls);

                    Ts_RT_Agent tsRtAgent = new Ts_RT_Agent();

                    List<RT_Code_Price> lsPrice = tsRtAgent.QueryPrice(lsCodes);

                    //String message = lsPrice[0].Price.ToString();
                    e.Result = lsPrice;

                    tsRtAgent.Dispose();
                }

                //sTime += 1;
                //e.Result = sTime.ToString();
                //List<RT_Code_Price> lsPrice = tsRtAgent.QueryPrice(lsStocks);

                //e.Result = lsPrice;

                //_bkWorker.ReportProgress(0, lsPrice);
            }
            catch (Exception ex)
            {
                OnMessageReceived(ex.Message);
            }
        }

        public void SetMonitorStocks(List<String> codes)
        {
            lock (lockObj)
            {
                lsStocks = codes;
            }
        }

        private List<String> GetMonitorStocks()
        {
            lock (lockObj)
            {
                return lsStocks;
            }
        }

        public void AddStock(String code)
        {
            lock(lockObj)
            {
                if (lsStocks.IndexOf(code) == -1)
                {
                    lsStocks.Add(code);
                }
            }
        }

        public void AddStock(List<string> ls_code)
        {
            lock(lockObj)
            {
                foreach (string s in ls_code)
                {
                    if (lsStocks.IndexOf(s) <= 0)
                    {
                        lsStocks.Add(s);
                    }
                }
            }
        }
    }
}
