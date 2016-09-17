using Newtonsoft.Json;
using System.Collections.Generic;


namespace TestCasa
{
    class Program
    {
        static void Main(string[] args)
        {
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

            WSGestioneChiamate.GestioneChiamateClient client = new WSGestioneChiamate.GestioneChiamateClient();

            WSGestioneChiamate.ResponseInsert response = client.InsertJson(data);

            System.Console.WriteLine("Test Concluso. Premere un tasto per terminare!");
            System.Console.ReadKey();
        }
    }
}
