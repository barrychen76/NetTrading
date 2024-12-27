using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetTrading.Data
{
    internal class SubTrading : INotifyPropertyChanged
    {
        private double TARGET = 0.05;

        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool Finished { get; set; } = false;             // 交易是否结束
                                                                // public bool trigger { get; set; } = false;           // 触发器？是否被使用？

        #region 买入相关属性
        private double _buyPrice;
        public double BuyPrice                                   // 买入价格
        {
            get { return _buyPrice; }
            set
            {
                _buyPrice = value;
                DtBuy = DateTime.Now;

                TargetBuyPrice = (double)(value * (1 - TARGET));
                TargetSellPrice = (double)(value * (1 + TARGET * 1.5));
            }
        }
        public int BuyCount { get; set; }
        public AccountType AccountType { get; set; }            // 账户类型，我的、老婆的...
        public String PolicyName { get; set; }                  // 策略名：现在计划使用的策略有，
                                                                // 1、神奇公式
                                                                // 2、铁牛策略
                                                                // 3、买菜策略
                                                                // 4、买菜区间
                                                                // 5、可转债轮动
        public DateTime DtBuy { get; set; } = DateTime.Now;
        public double TargetBuyPrice { get; private set; }
        public double TargetSellPrice { get; private set; }
        public string BuyComment { get; set; } = string.Empty; // 详细描述
        #endregion

        #region 卖出相关属性
        private double _sellPrice = 0;
        public double SellPrice
        {
            get { return _sellPrice; }
            set
            {
                _sellPrice = value;
                DtSell = DateTime.Now;
            }
        }
        public DateTime? DtSell { get; set; }

        #endregion

        public int HoldingDays                  // 持仓天数
        {
            get 
            {
                TimeSpan ts = DateTime.Now - DtBuy;
                return ts.Days;
            } 
        }
        private double _currentPrice = 0;
        public double CurrentPrice 
        { 
            get { return _currentPrice; }
            set
            {
                _currentPrice = value;

                IsProfit = _currentPrice > BuyPrice;
                Profit = (_currentPrice - BuyPrice) * BuyCount;
                ProfitPercent = (_currentPrice - BuyPrice) / BuyPrice;

                OnPropertyChanged("CurrentPrice");
                OnPropertyChanged("IsProfit");
                OnPropertyChanged("Profit");
                OnPropertyChanged("ProfitPercent");

                if (ProfitPercent > TARGET * 1.5)
                {
                    // 达到止盈价位
                }
                else if ((1-ProfitPercent) < TARGET)
                {
                    // 达到止损价位
                }
            } 
        }
        public bool IsProfit { get; private set; }
        public double Profit { get; private set; }
        public double ProfitPercent { get; private set; }

        public SubTrading()
        {
            DtBuy = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
