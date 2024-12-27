using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.MM
{
    /*
     * 股票估值：多种估值方法混合使用
     * 1、神奇公式分数排名
     * 2、PE * PB 历史百分比排名
     * 3、
     */
    class StockValue
    {
        public string name { get; set; } = string.Empty;
        public string node { get; set; } = string.Empty;

        public int ROC { get; set; }
        public int EY { get; set; }
        public int FM_Final { get; set; }

        public decimal PE { get; set; }
        public decimal PB { get; set; }
        public decimal PE_PB_Percent { get; set; }

        public int Score { get; set; }  // 最终得分，超过某一分数，UI显示绿色
    }
}
