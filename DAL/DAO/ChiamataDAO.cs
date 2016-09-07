using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.VO;
using System.Diagnostics;
using System.Data;
using GeneralPurposeLib;
using DAL;

namespace DAL
{
    public partial class DAL
    {
        public List<ChiamataVO> GetChiamateByRangeDate(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }
        public ChiamataVO GetChiamataByPk(long idid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            IDAL.VO.ChiamataVO chiam = null;
            try
            {
                string connectionString = this.GCPConnectionString;

                string query = "SELECT * FROM Episodi WHERE IDChiamata = @IDChiamata";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["IDChiamata"] = idid;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DAL.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null && data.Rows.Count == 1)
                {
                    DataRow row = data.Rows[0];

                    //chiam = EpisodioMapper.EpisMapper(row);

                    log.Info(string.Format("Record mapped to {0}", chiam.GetType().ToString()));
                }
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return chiam;
        }
        public ChiamataVO GetChiamataByExtPk(long extidid)
        {
            throw new NotImplementedException();
        }
        public List<ChiamataVO> GetChiamateByStato(int stato)
        {
            throw new NotImplementedException();
        }
        public int UpdateChiamataByExtPk(ChiamataVO data, long extidid)
        {
            throw new NotImplementedException();
        }
        public int UpdateChiamataByPk(ChiamataVO data, long idid)
        {
            throw new NotImplementedException();
        }
        public int AddChiamata(ChiamataVO data)
        {
            throw new NotImplementedException();
        }
        public int DeleteChiamata(string esamidid)
        {
            throw new NotImplementedException();
        }
    }
}
