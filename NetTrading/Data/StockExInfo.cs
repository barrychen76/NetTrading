using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.Data
{
    enum StockIndexes
    {
        hs300, zz500
    }

    internal class StockExInfo
    {
        public StockIndexes BelongIndex { get; set; }
    }
}
