using System;
using DataAccessLayer;
using System.Collections.Generic;

namespace TesteServizio
{
    class Program
    {
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {            
            log.Info("Avvio esecuzione Test ...");

            DataAccessLayer.DAL dal = new DAL();

            string tabName = "Chiamata";
            Dictionary<string, DAL.OpValue> conditions = new Dictionary<string, DAL.OpValue>();
            
            conditions.Add("dataInizio1", new DAL.OpValue { Key = "DataOraInizioChiamata",  Op = " >= ", Conj = "and", Value = "2016-01-23 13:00:10" });
            conditions.Add("dataInizio2", new DAL.OpValue { Key = "DataOraInizioChiamata", Op = " <= ", Conj = "", Value = "2016-01-25 13:00:10" });

            System.Data.DataTable resSel = dal.SelectOperation(tabName, conditions);
            int resDel = dal.DeleteOperation(tabName, conditions);
            System.Data.DataTable resSel2 = dal.SelectOperation(tabName, conditions);

            log.Info("Test Terminato!");

            Console.WriteLine("Premere un tasto per terminare ....");
            Console.ReadKey();
        }
    }
}
