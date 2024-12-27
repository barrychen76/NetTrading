using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace NetTrading.MM
{
    public class StockOHLCV
    {
        public DateTime day { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
    }

    public class QueryStockPrice
    {
        Dictionary<string, StockOHLCV> Prices = new Dictionary<string, StockOHLCV>();

        public Dictionary<string, StockOHLCV> Query(List<string> stocksCode)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Prices.Clear();

            foreach (string stockCode in stocksCode)
            {
                Prices[stockCode] = Query(stockCode);

                // 调用间隔5秒钟
                Thread.Sleep(5000);
            }

            return Prices;
        }

        public StockOHLCV Query(string stockCode)
        {
            int scale = 15;     // 15分钟
            string ma = "no";   // 不含有均线信息
            int datalen = 1;    // 返回1条记录

            var uri_fmt = "http://money.finance.sina.com.cn/quotes_service/api/json_v2.php/CN_MarketData.getKLineData?symbol=" +
                          "{0}&scale={1}&ma={2}&datalen={3}";
            string uri = string.Format(uri_fmt, stockCode, scale, ma, datalen);

            StockOHLCV data = ProcessDataAsync(uri).Result;

            return data;
        }

        private async Task<StockOHLCV> ProcessDataAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string ret  = await client.GetStringAsync(uri);
                    return ParseJson(ret);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
            }
        }

        private StockOHLCV ParseJson(string json)
        {
            JArray stockDataArray = JArray.Parse(json);

            if (stockDataArray.Count > 0)
            {
                JObject jObj = (JObject)stockDataArray[0];
                StockOHLCV stockPrice = new StockOHLCV();
                DateTime day;
                DateTime.TryParseExact((string)jObj["day"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out day);
                stockPrice.day = day;
                stockPrice.open = float.Parse((string)jObj["open"]);
                stockPrice.close = float.Parse((string)jObj["close"]);
                stockPrice.high = float.Parse((string)jObj["high"]);
                stockPrice.low = float.Parse((string)jObj["low"]);
                stockPrice.volume = int.Parse((string)jObj["volume"]);

                return stockPrice;
            }

            return null;
        }
    }
}
