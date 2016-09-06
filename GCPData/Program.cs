using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GCPData
{
    class Program
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            /*
            GCPDAL dal = new GCPDAL();

            
            ChiamataDTO c = (ChiamataDTO)dal.GetChiamataById(1);


            ChiamataDTO d = new ChiamataDTO{
                CognomeChiamata = "Sandrelli",
                ExtIDChiamata = 35435,
                DataOraOperazione = DateTime.Now.ToString("yyyy-MM-ddTH:mm:ss.fff")
            };            

            int result = dal.AddChiamata(d);
            

            Dictionary<string, object> test = new Dictionary<string, object>();
            test["CognomeChiamata"] = "Cucciopompelimini";
            test["ExtIDChiamata"] = 67888445435;
            test["DataOraOperazione"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            int result = (int)GCPBLL.AddChiamata(test);

            System.Console.WriteLine("{0} is the value returned!", result);

            //System.Console.WriteLine(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss.fff"));
            
            dal = null;
            

            Dictionary<string, object> test = new Dictionary<string, object>();
            test["NomeChiamata"] = "SWTestNome";
            test["CognomeChiamata"] = "SWTestCognome";
            test["NumeroChiamata"] = "+39 085 7581245";
            test["DataOraChiamata"] = "2016-07-29T05:20:00.000";
            test["ExtIDChiamata"] = 14253700008888;
            test["DataOraOperazione"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            string postData_ = string.Join("&", test.Select(x => x.Key + "=" + x.Value).ToArray());
            //System.Console.WriteLine(postData_);

            try
            {
                WebRequest req = WebRequest.Create("http://phone.seminabit.com");
                //string postData = "item1=11111&item2=22222&Item3=33333";
                string postData = postData_;

                byte[] send = Encoding.Default.GetBytes(postData);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = send.Length;

                Stream sout = req.GetRequestStream();
                sout.Write(send, 0, send.Length);
                sout.Flush();
                sout.Close();

                WebResponse res = req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                string returnvalue = sr.ReadToEnd();

                System.Console.WriteLine("Risposta Server: {0}", returnvalue);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Si è verificato un errore.\n{0}", ex.Message);
            }
            

            string msg = "Messaggio di test per il log!";

            log.Info(msg);
            log.Debug(msg);
            log.Warn(msg);
            log.Error(msg);
            log.Fatal(msg);
            */

            Type type = typeof(UInt32);
            string data = "2015438549685496854";

            //System.Console.WriteLine(TypeValidator(data, type));

            System.Console.WriteLine("Premere un tasto per continuare ...");
            System.Console.ReadKey();
                       
        }

        
    }
}
