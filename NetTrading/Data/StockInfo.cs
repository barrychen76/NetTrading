using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.Data
{
    internal class StockInfo
    {
        public StockBasicInfo BasicInfo { get; set; } = new StockBasicInfo();
        public StockExInfo ExInfo { get; set; } = new StockExInfo();
    }
}
