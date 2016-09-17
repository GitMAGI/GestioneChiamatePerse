using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WSChiamatePerse;

namespace TestLocale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Avvio test ...");

            List<string> err = null;
            List<string> warn = null;
            List<string> info = null;

            ChiamataSOi testR = new ChiamataSOi();
            testR.CognomeChiamata = "Boriellieri";
            testR.NomeChiamata = "Marcella";
            testR.NumeroChiamata = "44222390";
            testR.MotivoChiamata = "Reclamo!";
            testR.ExtIDChiamata = 153;
            testR.DataOraInizioChiamata = Convert.ToDateTime("2015-11-21 14:07:47");
            testR.DataOraFineChiamata = Convert.ToDateTime("2015-11-21 14:09:14");
            testR.Priorita = 1;
            testR.ExtIDOperatore = 3209;

            List<ChiamataSOi> dat = new List<ChiamataSOi>() { testR };

            WSChiamatePerse.Constraints.ChiamataContraints tbChecker = new WSChiamatePerse.Constraints.ChiamataContraints();
            bool res = tbChecker.CheckAndConstranitsValidation<ChiamataSOi>(dat, ref err, ref warn, ref info);
/*

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

            List<Dictionary<string, object>> dataCNVT = new List<Dictionary<string, object>>();

            List<string> errRep = new List<string>();

            string data = JsonConvert.SerializeObject(data2Conv);
            
            WSChiamatePerse.GestioneChiamate client = new WSChiamatePerse.GestioneChiamate();

            //bool valid = ChiamataTab.Validation(data2Conv, out dataCNVT, out errRep);

            WSChiamatePerse.ResponseInsert response = client.InsertJson(data);
*/
            Console.WriteLine("Test Concluso. Premere un tasto per terminare!");
            Console.ReadKey();
        }
    }
}
