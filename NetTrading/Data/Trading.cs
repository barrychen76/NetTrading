using PyWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.Data
{
    internal class Trading : INotifyPropertyChanged
    {
        #region 属性
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DtBegin { get; set; }
        public DateTime DtEnd { get; set; }
        public string Comment { get; set; }
        public bool Finished { get; set; }

        public double AverageBuyPrice 
        {
            get
            {
                return 0;
                //AverageBuyPrice = this.calcAveragePrice();

                //return AverageBuyPrice;
            }
            private set { }
        }

        private double _currentPrice = 0;
        public double CurrentPrice 
        {
            get { return _currentPrice; }
            set
            {
                _currentPrice = value;

                foreach (var item in SubTradings)
                {
                    item.CurrentPrice = value;
                }

                OnPropertyChanged("CurrentPrice");
            }
        }

        public List<SubTrading> SubTradings { get; set; }
        #endregion

        #region 方法
        public Trading()
        {
            this.DtBegin = DateTime.Now;
            this.Finished = false;
            this.SubTradings = new List<SubTrading>();
        }

        public Trading(string name, string code)
        {
            this.DtBegin = DateTime.Now;
            this.Finished = false;
            this.SubTradings = new List<SubTrading>();

            this.Name = name;
            this.Code = code;
        }

        private int NewID()
        {
            for (int i = 0; i < 1000; i++)
            {
                int iFind = SubTradings.FindIndex(x => x.Id == i);

                if (iFind == -1)
                {
                    return i;
                }
            }

            throw new Exception("SubTrading.NewID 无法被产生。");
        }

        public SubTrading Buy(double price, int count, AccountType accType, String sPolicyName, DateTime dtBuy, string comment)
        {
            SubTrading subTrading = new SubTrading();
            subTrading.Id = NewID();
            subTrading.ParentId = this.Id;

            subTrading.BuyPrice = price;
            subTrading.BuyCount = count;
            subTrading.BuyComment = comment;

            subTrading.AccountType = accType;
            subTrading.PolicyName = sPolicyName;

            subTrading.DtBuy = dtBuy;

            SubTradings.Add(subTrading);

            return subTrading;
        }

        public bool Sell(int id, double price, int count, String comment)
        {
            int index = SubTradings.FindIndex(x => x.Id == id);

            if ( index >= 0)
            {
                SubTrading sub = SubTradings[index];

                if (sub.BuyCount == count)
                {
                    sub.SellPrice = price;
                    sub.DtSell = DateTime.Now;
                    sub.Finished = true;

                    if (allFinished())
                    {
                        this.Finished = true;
                        this.DtEnd = DateTime.Now;
                    }

                    return true;
                }
                else if (sub.BuyCount > count)
                {
                    // 创建两个新的 sub-trading
                    SubTrading sub1 = this.Buy(sub.BuyPrice, count, sub.AccountType, sub.PolicyName, sub.DtBuy, sub.BuyComment);
                    sub1.SellPrice = price;
                    sub1.DtSell = DateTime.Now;
                    sub1.Finished = true;
                    SubTradings.Add(sub1);

                    SubTrading sub2 = this.Buy(sub.BuyPrice, sub.BuyCount - count, sub.AccountType, sub.PolicyName, sub.DtBuy, sub.BuyComment);
                    SubTradings.Add(sub2);

                    SubTradings.RemoveAt(index);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        private bool allFinished()
        {
            foreach (var subTrading in SubTradings)
            {
                if (subTrading.Finished == false)
                {
                    return false;
                }
            }

            return true;
        }

        //public void priceReceived(RT_Code_Price rtCodePrice)
        //{

        //    foreach (var subTrading in SubTradings)
        //    {
        //        subTrading.CurrentPrice = rtCodePrice.Price;
        //    }
        //}

        private double calcAveragePrice()
        {
            double sumAmount = 0;
            int sumCount = 0;

            double finishedSumProfit = 0;

            foreach (var subTrading in SubTradings)
            {
                if (subTrading.Finished)
                {
                    finishedSumProfit += (double)((subTrading.SellPrice - subTrading.BuyPrice) * subTrading.BuyCount);
                }
                else
                {
                    sumAmount += subTrading.BuyPrice * subTrading.BuyCount;
                    sumCount += subTrading.BuyCount;
                }
            }

            return (sumAmount + finishedSumProfit) / sumCount;
        }
        #endregion

        #region INotifyPropertyChanged 接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
