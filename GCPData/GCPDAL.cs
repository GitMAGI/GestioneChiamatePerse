using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCPData
{
    class GCPDAL
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object GetChiamataById(long idchiamata)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GCP_test"].ConnectionString;
            ChiamataDTO chiamata = null;

            string query = "SELECT * FROM Chiamata WHERE IDChiamata = @IDChiamata";
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars["IDChiamata"] = idchiamata;

            log.Info(string.Format("Query: {0}", query));
            log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

            DataTable data = DBSQLLayer.ExecuteQueryWithParams(connectionString, query, pars);

            log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

            if (data != null && data.Rows.Count == 1)
            {
                DataRow row = data.Rows[0];

                chiamata = ChiamataMapper(row);

                log.Info("Record mapped to ChiamataDTO");
            }

            return chiamata;
        }

        public object[] GetChiamataAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GCP_test"].ConnectionString;
            ChiamataDTO[] chiamate = null;

            string query = "SELECT * FROM Chiamata";

            log.Info(string.Format("Query: {0}", query));

            DataTable data = DBSQLLayer.ExecuteQuery(connectionString, query);

            log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));
            
            if (data.Rows.Count > 0)
            {
                chiamate = new ChiamataDTO[data.Rows.Count];
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow row = data.Rows[i];
                    ChiamataDTO tmp = ChiamataMapper(row);
                    log.Info("Record mapped to ChiamataDTO");
                    chiamate[i] = tmp;
                    log.Info("Record mapped added To ChiamataDTO[]");
                }
            }

            return chiamate;
        }
        
        public int AddChiamata(ChiamataDTO chiamata)
        {            
            int result = -1;

            string conn = ConfigurationManager.ConnectionStrings["GCP_test"].ConnectionString;

            Dictionary<string, object> pars = new Dictionary<string, object>();

            foreach (var prop in chiamata.GetType().GetProperties())
            {
                if (prop.GetValue(chiamata, null) != null)
                {
                    pars[prop.Name] = prop.GetValue(chiamata, null);
                    //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(chiamata, null));
                }

            }

            string query = "INSERT INTO [dbo].[Chiamata] (" +
                string.Join(", ", pars.Select(x => x.Key).ToArray()) +
                ") VALUES (" +
                string.Join(", ", pars.Select(x => "@" + x.Key).ToArray()) +
                ")";

            log.Info(string.Format("Query: {0}", query));
            log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

            result = DBSQLLayer.ExecuteNonQueryWithParams(conn, query, pars);

            log.Info(string.Format("Query Executed! Inserted {0} records!", result));

            return result;
        }

        public static ChiamataDTO ChiamataMapper(DataRow row)
        {
            ChiamataDTO chiamata = new ChiamataDTO();
            /*
            chiamata.IDChiamata = row["IDChiamata"] != DBNull.Value ? (long)row["IDChiamata"] : 0;
            chiamata.ExtIDChiamata = row["ExtIDChiamata"] != DBNull.Value ? (long)row["ExtIDChiamata"] : 0;
            chiamata.NumeroChiamata = row["NumeroChiamata"] != DBNull.Value ? (string)row["NumeroChiamata"] : null;
            chiamata.NomeChiamata = row["NomeChiamata"] != DBNull.Value ? (string)row["NomeChiamata"] : null;
            chiamata.CognomeChiamata = row["CognomeChiamata"] != DBNull.Value ? (string)row["CognomeChiamata"] : null;
            chiamata.MotivoChiamata = row["MotivoChiamata"] != DBNull.Value ? (string)row["MotivoChiamata"] : null;
            chiamata.DataOraChiamata = row["DataOraChiamata"] != DBNull.Value ? (string)row["DataOraChiamata"].ToString() : null;
            chiamata.InfoChiamata = row["InfoChiamata"] != DBNull.Value ? (string)row["InfoChiamata"] : null;
            chiamata.DataOraOperazione = row["DataOraOperazione"] != DBNull.Value ? (string)row["DataOraOperazione"].ToString() : null;
            chiamata.IPOperazione = row["IPOperazione"] != DBNull.Value ? (string)row["IPOperazione"] : null;
            */
            return chiamata;
        }
    }
}
