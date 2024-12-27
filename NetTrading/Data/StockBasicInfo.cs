using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.Data
{
    public enum AccountType
    {
        AT_Mine, 
        AT_Wife, 
        AT_Father, 
        AT_Mother,
        AT_HaiMa
    };

    internal class StockBasicInfo
    {
        public long id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string cnspell { get; set; }
        public string industry { get; set; }
        public string market { get; set; }
        public string fullname { get; set; }
        public string area { get; set; }
        public DateTime dtMarket { get; set; }
    }
}
