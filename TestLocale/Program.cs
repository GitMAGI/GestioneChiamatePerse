using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSChiamatePerse;

namespace TestLocale
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Avvio test ...");

            /*

            ChiamataSOi testR = new ChiamataSOi();
            testR.CognomeChiamata = "Boriellieri";
            testR.NomeChiamata = "Marcella";
            testR.NumeroChiamata = "44222390";
            testR.MotivoChiamata = "Reclamo!";
            testR.ExtIDChiamata = null;
            testR.DataOraInizioChiamata = Convert.ToDateTime("2015-11-21 14:07:47");
            testR.DataOraFineChiamata = Convert.ToDateTime("2015-1-21 14:13:14");
            testR.Priorita = 1;
            testR.ExtIDOperatore = 3209;

            GestioneChiamate client = new GestioneChiamate();

            ResponseInsert rsp = client.InserisciChiamateOO(testR);

            */

            WSChiamatePerse.Constraints.ChiamataContraints ChiamataTab = new WSChiamatePerse.Constraints.ChiamataContraints();
            /*
            long obj;
            bool res1 = ChiamataTab.ValidationDataTypeAndParsing<long>("ExtIDChiamata", null, out obj);            
            bool res2 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraInizioChiamata", "2015/05/03 12:12:45", out trash__);
            bool res3 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraFineChiamata", "02/05/2016 22:15:45", out trash__);
            bool res4 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraFineChiamata", "02/25/2016 22:15:45", out trash__);
            bool res5 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraInizioChiamata", "2015-05-03 12:12:45", out trash__);
            bool res6 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraFineChiamata", "02-05-2016 22:15:45", out trash__); 
            DateTime trash__;
            bool res7 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraFineChiamata", null, out trash__);
            bool res8 = ChiamataTab.ValidationDataTypeAndParsing<DateTime>("DataOraFineChiamata", "25-02-2016 22:15:45", out trash__);
            */

            Dictionary<string, string> data2Conv = new Dictionary<string, string>()
            {
                {"CognomeChiamata", "Boriellieri"},
                {"NomeChiamata", null},
                {"NumeroChiamata", "44222390"},
                {"MotivoChiamata", "Reclamo!"},
                {"ExtIDChiamata", null},
                {"DataOraInizioChiamata", "2015-1p-21 14:07:47"},
                {"DataOraFineChiamata", "2015-1-21 14:13:14"},
                {"Priorita", "1"},
                {"ExtIDOperatore", "yt09"},
            };

            Dictionary<string, object> dataCNVT = new Dictionary<string, object>();

            List<string> errRep = new List<string>();

            bool valid = ChiamataTab.ValidationRow(data2Conv, ref dataCNVT, ref errRep);


            System.Console.WriteLine("Test Concluso. Premere un tasto per terminare!");
            System.Console.ReadKey();
        }
    }
}
