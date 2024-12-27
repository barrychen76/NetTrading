using NetTrading.MM;
using Python.Runtime;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace NetTrading
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //PyWrapper.Ts_RT_Agent rt = new PyWrapper.Ts_RT_Agent();
            //List<String> ls = new List<String>();
            //ls.Add("000001.SZ");
            //ls.Add("000001.SH");
            //ls.Add("600000.SH");
            //List<PyWrapper.RT_Code_Price> ll = rt.QueryPrice(ls);

            //foreach (var record in ll)
            //{
            //    Console.WriteLine($"Code: {record.Code}, ts_code: {record.Price}");
            //}

            //Init();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());

            //Exit();
        }

        //private static dynamic _ts;

        //static void Init()
        //{
        //    string PathToVirtualEnv = "C:\\ProgramData\\anaconda3\\envs\\python39";
        //    string PathToScript = "C:\\Users\\thelo\\.emgm3\\projects\\EmptyProject\\NetTrading\\NetTrading";

        //    Runtime.PythonDLL = Path.Combine(PathToVirtualEnv, "python39.dll");
        //    PythonEngine.PythonHome = Path.Combine(PathToVirtualEnv, "python.exe");
        //    PythonEngine.PythonPath = $"{PathToVirtualEnv}\\Lib\\site-packages;{PathToVirtualEnv}\\Lib;{PathToVirtualEnv}\\Dlls;{PathToScript}";

        //    PythonEngine.Initialize();

        //    //_ts = Py.Import("ts_runtime_agent");

        //    Ts_RT_Agent rt = new Ts_RT_Agent();
        //    List<String> ls = new List<String>();
        //    ls.Add("000001.SZ");
        //    ls.Add("000001.SH");
        //    ls.Add("600000.SH");
        //    List<RT_Code_Price> ll = QueryPrice(ls);
        //    //Console.WriteLine(ll.Count);
        //}

        //static void Exit()
        //{
        //    PythonEngine.Shutdown();
        //}

        //public static List<RT_Code_Price> QueryPrice(List<String> ls_codes)
        //{
        //    try
        //    {
        //        const int MAX_LEN = 50;

        //        List<RT_Code_Price> ls_rt = new List<RT_Code_Price>();
        //        List<Dictionary<string, object>> lsPrices = new List<Dictionary<string, object>>();

        //        List<List<String>> chunks = new List<List<String>>();
        //        for (int i = 0; i < ls_codes.Count; i += MAX_LEN)
        //        {
        //            int count = Math.Min(MAX_LEN, ls_codes.Count - i);

        //            List<String> ls = ls_codes.GetRange(i, count);

        //            String codes = String.Join(",", ls);

        //            List<Dictionary<string, object>> ret = doQuery(codes);

        //            // ∆¥Ω”∑µªÿ÷µ
        //            //foreach (var rec in ret)
        //            //{
        //            //    RT_Code_Price code_price = new RT_Code_Price();
        //            //    code_price.Code = rec["TS_CODE"].ToString();
        //            //    string sPrice = rec["PRICE"].ToString();
        //            //    code_price.Price = (float)Math.Round(Convert.ToSingle(sPrice), 2);

        //            //    ls_rt.Add(code_price);
        //            //}
        //        }

        //        return ls_rt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //    return null;
        //}

        //public static List<Dictionary<string, object>> doQuery(string codes)
        //{
        //    //System.Threading.Tasks.Task.Run(() =>
        //    //{
        //        try
        //        {
        //            Console.WriteLine("zzz");
        //            using (Py.GIL())
        //            {
        //                Console.WriteLine("aaa");
        //                dynamic _ts = Py.Import("ts_runtime_agent");
        //                Console.WriteLine("bbb");

        //                dynamic df = _ts.query_price(codes);// "600000.SH,000001.SZ,000001.SH");

        //                Console.WriteLine("ccc");

        //                string json_str = df.to_json(orient: "records");

        //                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //                List<Dictionary<string, object>> records = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json_str, options);

        //                return records;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //            throw new Exception(ex.Message);
        //        }
        //    //});

        //    return null;
        //}

    }
}