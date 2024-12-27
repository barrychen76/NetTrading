using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Python.Runtime;

namespace PyWrapper
{
    public class RT_Code_Price
    {
        public String Code { get; set; }
        public double Price { get; set; }
    }

    public class Ts_RT_Agent : IDisposable
    {
        private bool disposed = false;

        private IntPtr nativeResource = Marshal.AllocHGlobal(100); // 示例：分配未托管资源
        private string managedResource = "Managed Resource";

        public Ts_RT_Agent()
        {
            Init();
        }

        ~Ts_RT_Agent()
        {
            //Exit();
            Dispose(false);
        }

        public void Dispose()
        {
            Exit();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // 释放托管资源
                    managedResource = null;
                }

                // 释放未托管资源
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;

                disposed = true;
            }
        }

        public void Init()
        {
            try
            {
                string PathToVirtualEnv = "C:\\ProgramData\\anaconda3\\envs\\python39";
                string PathToScript = "D:\\Work\\NetTrading\\PyWrapper";

                Runtime.PythonDLL = Path.Combine(PathToVirtualEnv, "python39.dll");
                PythonEngine.PythonHome = Path.Combine(PathToVirtualEnv, "python.exe");
                PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";

                PythonEngine.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Exit()
        {
            PythonEngine.Shutdown();
        }

        public List<RT_Code_Price> QueryPrice(List<String> ls_codes)
        {
            try
            {
                const int MAX_LEN = 50;

                List<RT_Code_Price> ls_rt = new List<RT_Code_Price>();
                List<Dictionary<string, object>> lsPrices = new List<Dictionary<string, object>>();

                List<List<String>> chunks = new List<List<String>>();
                for (int i = 0; i < ls_codes.Count; i += MAX_LEN)
                {
                    int count = Math.Min(MAX_LEN, ls_codes.Count - i);

                    List<String> ls = ls_codes.GetRange(i, count);

                    String codes = String.Join(",", ls);

                    List<Dictionary<string, object>> ret = doQuery(codes);

                    // 拼接返回值
                    foreach (var rec in ret)
                    {
                        RT_Code_Price code_price = new RT_Code_Price();
                        code_price.Code = rec["TS_CODE"].ToString();
                        string sPrice = rec["PRICE"].ToString();
                        code_price.Price = (float)Math.Round(Convert.ToSingle(sPrice), 2);

                        ls_rt.Add(code_price);
                    }
                }

                return ls_rt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            throw new Exception("Error");
        }

        public List<Dictionary<string, object>> doQuery(string codes)
        {
            using (Py.GIL())
            {
                dynamic ts = Py.Import("ts_runtime_agent");

                dynamic dfRet = ts.query_price(codes);// "600000.SH,000001.SZ,000001.SH");

                string json_str = dfRet.to_json(orient: "records");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Dictionary<string, object>> records = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json_str, options);

                return records;
            }
        }

        static float ConvertToFloat(object obj)
        {
            Type t = obj.GetType();
            string ss = obj.ToString();
            return Convert.ToSingle(ss);
            if (obj is float)
            {
                return (float)obj;
            }
            else if (obj is double)
            {
                return (float)(double)obj;
            }
            else if (obj is int)
            {
                return (float)(int)obj;
            }
            else if (obj is string)
            {
                if (float.TryParse((string)obj, out float result))
                {
                    return result;
                }
            }

            throw new InvalidCastException($"Cannot convert {obj} to float.");
        }
    }
}
