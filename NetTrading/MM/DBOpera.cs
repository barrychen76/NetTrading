using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace NetTrading.MM
{
    internal class DBOpera
    {
        private static DBOpera _dbOpera = null;
        public static DBOpera GetInstance()
        {
            if (_dbOpera == null)
            {
                _dbOpera = new DBOpera();
            }

            return _dbOpera;
        }

        private string db_path = "D:\\temp\\tushare.db";
        private SQLiteConnection _conn = null;
        public SQLiteConnection Conn { get { return _conn; } }

        public DBOpera()
        {
            //string conn_str = string.Format("Data Source = {0}", db_path);
            //_conn = new SQLiteConnection(conn_str);
            //_conn.Open();
        }

        ~DBOpera()
        {
            if ( _conn != null )
            {
                _conn.Close();
            }
        }
    }
}
