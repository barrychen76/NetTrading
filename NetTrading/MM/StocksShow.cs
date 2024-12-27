using NetTrading.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTrading.MM
{
    internal class StocksShow
    {
        private DBOpera _db;

        public StocksShow()
        {
            _db = DBOpera.GetInstance();
        }

        public List<StockInfo> Query()
        {
            List<StockInfo> stocks = new List<StockInfo>();

            string sql = "select id, ts_code, symbol, name, industry, area, fullname, cnspell, market, list_date from stock_basic where list_status='L';";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _db.Conn))
            {
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StockInfo sInfo = new StockInfo();
                    sInfo.BasicInfo.id = dr.GetInt64(0);// "id");
                    sInfo.BasicInfo.code = dr.GetString(1).Substring(0, 6); // ts_code
                    sInfo.BasicInfo.name = dr.GetString(3);                 // "name"
                    sInfo.BasicInfo.industry = dr.GetString(4);             // industry
                    sInfo.BasicInfo.fullname = dr.GetString(6);             // fullname
                    sInfo.BasicInfo.cnspell = dr.GetString(7);              // cnspell
                    sInfo.BasicInfo.market = dr.GetString(8);               // market
                    sInfo.BasicInfo.dtMarket = dr.GetDateTime(9);           // list_date

                    stocks.Add(sInfo);
                }
                dr.Close();

                return stocks;

                //DataTable dataTable = new DataTable();
                //cmd.CommandText = sql;

                //SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                //adapter.Fill(dataTable);

                //foreach (DataRow row in dataTable.Rows)
                //{
                //    StockInfo sInfo = new StockInfo();
                //    sInfo.BasicInfo.id = reader int(row["id"]);
                //}

                //return dataTable;
            }
        }
    }
}
