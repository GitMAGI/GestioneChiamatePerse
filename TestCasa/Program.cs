using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            System.Console.WriteLine("Avvio test ...");

            Dictionary<string, string> data2Conv1 = new Dictionary<string, string>()
            {
                {"CognomeChiamata", "Boriellieri"},
                {"NomeChiamata", "Bombiero"},
                {"NumeroChiamata", "44222390"},
                {"MotivoChiamata", "Reclamo!"},
                {"ExtIDChiamata", "13452"},
                {"DataOraInizioChiamata", "2015-1-21 14:07:50"},
                {"DataOraFineChiamata", "2015-1-21 14:07:54"},
                {"Priorita", "1"},
                {"ExtIDOperatore", "2309"},
            };
            Dictionary<string, string> data2Conv2 = new Dictionary<string, string>()
            {
                {"CognomeChiamata", "Giorgelli"},
                {"NomeChiamata", "Topello"},
                {"NumeroChiamata", "123322390"},
                {"MotivoChiamata", "Intercettazione"},
                {"ExtIDChiamata", "3445"},
                {"DataOraInizioChiamata", "2011-10-1 11:07:47"},
                {"DataOraFineChiamata", "2011-10-1 11:07:54"},
                {"Priorita", "1"},
                {"ExtIDOperatore", "112"},
            };

            List<Dictionary<string, string>> data2Conv = new List<Dictionary<string, string>>()
            {
                data2Conv1,
                data2Conv2
            };

            string data = JsonConvert.SerializeObject(data2Conv);

            WSGestioneChiamate.ChiamataSOi input = new WSGestioneChiamate.ChiamataSOi();
            input.NomeChiamata = "Michael";
            input.CognomeChiamata = "Gerson";
            input.NumeroChiamata = "123343432";
            input.MotivoChiamata = "Lusso";
            input.ExtIDChiamata = 1000011;
            input.DataOraInizioChiamata = System.Convert.ToDateTime("2011-10-1 11:07:47");
            input.DataOraFineChiamata = System.Convert.ToDateTime("2011-10-1 11:07:54"); ;
            input.Priorita = 1;
            input.ExtIDOperatore = 311;
            //input.IDExtSollecitoChiamata = "";
            //input.InfoChiamata = "";


            WSGestioneChiamate.ChiamataSOi[] inputs = new WSGestioneChiamate.ChiamataSOi[1] { input };
            List<WSGestioneChiamate.ChiamataSOi> inputs_ = new List<WSGestioneChiamate.ChiamataSOi>() { input };


            WSGestioneChiamate.GestioneChiamateClient client = new WSGestioneChiamate.GestioneChiamateClient();

            //WSGestioneChiamate.ResponseInsert response = client.InsertJson_obj(data);

            WSGestioneChiamate.ResponseInsert response = client.InsertObjList_obj(inputs);

            tw.Stop();
            System.Console.WriteLine(string.Format("Procedure Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            System.Console.WriteLine("Test Concluso. Premere un tasto per terminare!");
            System.Console.ReadKey();
        }
    }
}
