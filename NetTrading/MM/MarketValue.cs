using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.MM
{
    class MarketValue
    {
        public decimal Risk_Free_Rate { get; set; } // 十年期国债收益率
        public decimal PE_Percent { get; set; }     // 整体PE
        public decimal PB_Percent { get; set; }     // 整体PB
    }
}
