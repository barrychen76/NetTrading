using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Python.Runtime;

namespace NetTrading.MM
{
    public class RT_Code_Price
    {
        public string Code { get; set; } = String.Empty;
        public float Price { get; set; } = 0;
    }

    internal class Ts_RT_Agent
    {
        //public string PathToVirtualEnv { get; set; } = "C:\\ProgramData\\anaconda3\\envs\\python39";
        //public string PathToScript { get; set; } = "D:\\Work\\NetTrading\\NetTradingForm\\MM";

        //private dynamic _ts;
        public Ts_RT_Agent()
        {
            //Runtime.PythonDLL = Path.Combine(PathToVirtualEnv, "python39.dll");
            //PythonEngine.PythonHome = Path.Combine(PathToVirtualEnv, "python.exe");
            //PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";

            try
            {
                //string PathToVirtualEnv = "C:\\ProgramData\\anaconda3\\envs\\python39";

                //Runtime.PythonDLL = Path.Combine(PathToVirtualEnv, "python39.dll");
                //String path = Path.Combine(PathToVirtualEnv, "python.exe");
                //PythonEngine.PythonHome = path;// Path.Combine(PathToVirtualEnv, "python.exe");
                //PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";

                //PythonEngine.PythonHome = Path.Combine(PathToVirtualEnv, "python.exe");
                ////PythonEngine.PythonHome = PathToVirtualEnv;
                //PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";
                //PythonEngine.
                //PythonEngine.Prefix = @"C:\Path\To\Python";

                //PythonEngine.Initialize();

                //                _ts = Py.Import("ts_runtime_agent");
                Init();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ~Ts_RT_Agent()
        {
            //PythonEngine.Shutdown();
        }

        void Init()
        {
            string PathToVirtualEnv = "C:\\ProgramData\\anaconda3\\envs\\python39";
            string PathToScript = "C:\\Users\\thelo\\.emgm3\\projects\\EmptyProject\\NetTrading\\NetTrading";

            Runtime.PythonDLL = Path.Combine(PathToVirtualEnv, "python39.dll");
            PythonEngine.PythonHome = Path.Combine(PathToVirtualEnv, "python.exe");
            PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";

            //PythonEngine.Initialize();

            //_ts = Py.Import("ts_runtime_agent");
        }

        public List<RT_Code_Price> QueryPrice(List<string> ls_codes)
        {
            try
            {
                const int MAX_LEN = 50;

                List<RT_Code_Price> ls_rt = new List<RT_Code_Price>();
                List<Dictionary<string, object>> lsPrices = new List<Dictionary<string, object>>();

                List<List<string>> chunks = new List<List<string>>();
                for (int i = 0; i < ls_codes.Count; i += MAX_LEN)
                {
                    int count = Math.Min(MAX_LEN, ls_codes.Count - i);

                    List<string> ls = ls_codes.GetRange(i, count);

                    string codes = string.Join(",", ls);

                    List<Dictionary<string, object>> retPrices = doQuery(codes);

                    // 拼接返回值
                    foreach (var rec in retPrices)
                    {
                        string sPrice = rec["PRICE"].ToString();

                        RT_Code_Price code_price = new RT_Code_Price()
                        {
                            Code = rec["TS_CODE"].ToString(),
                            Price = (float)Math.Round(Convert.ToSingle(sPrice), 2)
                        };

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
            try
            {
                PythonEngine.Initialize();

                dynamic _ts = Py.Import("ts_runtime_agent");

                using (Py.GIL())
                {
                    dynamic df = _ts.query_price(codes);// "600000.SH,000001.SZ,000001.SH");

                    if (df != null)
                    {
                        string json_str = df.to_json(orient: "records");

                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        List<Dictionary<string, object>> records = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json_str, options);

                        PythonEngine.Shutdown();
                        return records;
                    }

                    throw new Exception("新浪接口错误");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            throw new Exception("新浪接口错误");
        }

        //static float ConvertToFloat(object obj)
        //{
        //    Type t = obj.GetType();
        //    string ss = obj.ToString();
        //    return Convert.ToSingle(ss);
        //    if (obj is float)
        //    {
        //        return (float)obj;
        //    }
        //    else if (obj is double)
        //    {
        //        return (float)(double)obj;
        //    }
        //    else if (obj is int)
        //    {
        //        return (float)(int)obj;
        //    }
        //    else if (obj is string)
        //    {
        //        if (float.TryParse((string)obj, out float result))
        //        {
        //            return result;
        //        }
        //    }

        //    throw new InvalidCastException($"Cannot convert {obj} to float.");
        //}
    }
}
