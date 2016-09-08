using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace TesteServizio
{
    class Program
    {
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {            
            log.Info("Avvio esecuzione Test ...");

            /*
            string connectionString = "";
            
            string tabName = "Chiamata";
            Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();

            conditions.Add("dataInizio1", new DBSQL.QueryCondition { 
                Key = "DataOraInizioChiamata", 
                Op = DBSQL.Op.GreaterEqual, 
                Conj = DBSQL.Conj.And, 
                Value = "2016-01-23 13:00:10" 
            });
            conditions.Add("dataInizio2", new DBSQL.QueryCondition { 
                Key = "DataOraInizioChiamata",
                Op = DBSQL.Op.LowerEqual,  
                Conj = DBSQL.Conj.None, 
                Value = "2016-01-25 13:00:10" 
            });

            System.Data.DataTable resSel = DBSQL.SelectOperation(connectionString, tabName, conditions);
            int resDel = DBSQL.DeleteOperation(connectionString, tabName, conditions);
            System.Data.DataTable resSel2 = DBSQL.SelectOperation(connectionString, tabName, conditions);
            */

            
            DAL dal = new DAL();
            dal.GetChiamateByRangeDate(Convert.ToDateTime("2012-01-23 13:00:10"), Convert.ToDateTime("2016-01-23 13:00:10"));
            //dal.DeleteChiamata_(17);
            dal.GetChiamateByRangeDate(Convert.ToDateTime("2012-01-23 13:00:10"), Convert.ToDateTime("2016-01-23 13:00:10"));
            

            /*
            IDAL.VO.ChiamataVO C1 = new IDAL.VO.ChiamataVO();
            IDAL.VO.ChiamataVO C2 = new IDAL.VO.ChiamataVO();
            IDAL.VO.ChiamataVO C3 = new IDAL.VO.ChiamataVO();
            IDAL.VO.ChiamataVO C4 = new IDAL.VO.ChiamataVO();
            IDAL.VO.ChiamataVO C5 = new IDAL.VO.ChiamataVO();

            C1.ExtIDChiamata = 21301010;
            C1.NumeroChiamata = "2105040848";
            C1.NomeChiamata = "Tiberio";  
            C1.CognomeChiamata = "Manganelli";
            C1.MotivoChiamata = "Reclamo";
            C1.DataOraInizioChiamata = Convert.ToDateTime("2012-05-19 15:09:12");
            C1.DataOraFineChiamata = Convert.ToDateTime("2012-05-19 15:13:56");
            C1.Priorita = 1;
            C1.Stato = 1;
            C1.InfoChiamata = null;
            C1.IDExtSollecitoChiamata = null;
            C1.DataOraOperazione = DateTime.Now;
            C1.IPOperazione = "192.168.3.200";

            C2.ExtIDChiamata = 8445040;
            C2.NumeroChiamata = "6262654546";
            C2.NomeChiamata = "claudia";
            C2.CognomeChiamata = "Vacri";
            C2.MotivoChiamata = "Informazioni";
            C2.DataOraInizioChiamata = Convert.ToDateTime("2014-11-10 05:19:12");
            C2.DataOraFineChiamata = Convert.ToDateTime("2014-11-10 05:33:32");
            C2.Priorita = 1;
            C2.Stato = 1;
            C2.InfoChiamata = null;
            C2.IDExtSollecitoChiamata = null;
            C2.DataOraOperazione = DateTime.Now;
            C2.IPOperazione = "192.168.3.200";

            C3.ExtIDChiamata = 8854010;
            C3.NumeroChiamata = "55553315";
            C3.NomeChiamata = "Samuele";
            C3.CognomeChiamata = "Patrizi";
            C3.MotivoChiamata = "Reclamo";
            C3.DataOraInizioChiamata = Convert.ToDateTime("2013-04-10 10:19:22");
            C3.DataOraFineChiamata = Convert.ToDateTime("2013-04-10 10:22:45");
            C3.Priorita = 1;
            C3.Stato = 1;
            C3.InfoChiamata = null;
            C3.IDExtSollecitoChiamata = null;
            C3.DataOraOperazione = DateTime.Now;
            C3.IPOperazione = "192.168.3.200";

            C4.ExtIDChiamata = 5605010;
            C4.NumeroChiamata = "09349379332";
            C4.NomeChiamata = "Franco";
            C4.CognomeChiamata = "Giacinti";
            C4.MotivoChiamata = "Informazioni";
            C4.DataOraInizioChiamata = Convert.ToDateTime("2016-12-10 12:19:22");
            C4.DataOraFineChiamata = Convert.ToDateTime("2016-12-10 12:49:20");
            C4.Priorita = 1;
            C4.Stato = 1;
            C4.InfoChiamata = null;
            C4.IDExtSollecitoChiamata = null;
            C4.DataOraOperazione = DateTime.Now;
            C4.IPOperazione = "192.168.3.200";

            C5.ExtIDChiamata = 18070510;
            C5.NumeroChiamata = "6768765856";
            C5.NomeChiamata = "Comunardo";
            C5.CognomeChiamata = "Pregadio";
            C5.MotivoChiamata = "Reclamo";
            C5.DataOraInizioChiamata = Convert.ToDateTime("2011-12-10 02:49:20");
            C5.DataOraFineChiamata = Convert.ToDateTime("2011-12-10 02:49:50");
            C5.Priorita = 1;
            C5.Stato = 1;
            C5.InfoChiamata = null;
            C5.IDExtSollecitoChiamata = null;
            C5.DataOraOperazione = DateTime.Now;
            C5.IPOperazione = "192.168.3.200";

            List<IDAL.VO.ChiamataVO> data = new List<IDAL.VO.ChiamataVO>();
            data.Add(C1);
            data.Add(C2);
            data.Add(C3);
            data.Add(C4);
            data.Add(C5);

            int res = dal.AddChiamate_(data);
            */

            log.Info("Test Terminato!");

            Console.WriteLine("Premere un tasto per terminare ....");
            Console.ReadKey();
        }
    }
}
