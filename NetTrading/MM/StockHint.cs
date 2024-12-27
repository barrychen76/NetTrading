using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.MM
{
    internal class StockHint
    {
        List<string> lstAbbr = new List<string>();
        List<string> lstName = new List<string>();
        List<string> lstCode = new List<string>();

        public enum HintType { EmAbbr, EmName, EmCode };

        public List<string> GetStockHint(string str, HintType hType)
        {
            List<string> retList = new List<string>() { "000651", "000275", "000217" };

            if (hType == HintType.EmAbbr)
            {
                retList = lstAbbr.Where(it => it.StartsWith(str)).ToList();
            }
            else if (hType == HintType.EmName)
            {
                retList = lstName.Where(it => it.StartsWith(str)).ToList();
            }
            if (hType == HintType.EmCode)
            {
                retList = lstCode.Where(it => it.StartsWith(str)).ToList();
            }

            return retList;
        }
    }
}
