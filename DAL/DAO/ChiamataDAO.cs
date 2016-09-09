using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.VO;
using System.Diagnostics;
using System.Data;
using GeneralPurposeLib;

namespace DataAccessLayer
{
    public partial class DAL
    {             
        public List<ChiamataVO> GetChiamateByRangeDate(DateTime begin, DateTime end)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            List<IDAL.VO.ChiamataVO> chiams = null;
            try
            {
                string connectionString = this.GCPConnectionString;

                string tabName = "[Chiamata]";
                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                conditions.Add("dataInizio1", new DBSQL.QueryCondition
                {
                    Key = "DataOraInizioChiamata",
                    Op = DBSQL.Op.GreaterEqual,
                    Conj = DBSQL.Conj.And,
                    Value = begin
                });
                conditions.Add("dataInizio2", new DBSQL.QueryCondition
                {
                    Key = "DataOraInizioChiamata",
                    Op = DBSQL.Op.LowerEqual,
                    Conj = DBSQL.Conj.None,
                    Value = end
                });

                DataTable data = DataAccessLayer.DBSQL.SelectOperation(connectionString, tabName, conditions);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null)
                {
                    chiams = Mappers.ChiamataMapper.DataRowToVO(data.Rows);

                    log.Info(string.Format("{0} Records mapped to {1}", chiams.Count, chiams.First().GetType().ToString()));
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

            return chiams;           
        }
        public ChiamataVO GetChiamataByPk(long idid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            IDAL.VO.ChiamataVO chiam = null;
            try
            {
                string connectionString = this.GCPConnectionString;
                string tabName = "[Chiamata]";                
                
                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                conditions.Add("IDChiamata", new DBSQL.QueryCondition
                {
                    Key = "IDChiamata",
                    Op = DBSQL.Op.LowerEqual,
                    Conj = DBSQL.Conj.None,
                    Value = idid
                });

                DataTable data = DataAccessLayer.DBSQL.SelectOperation(connectionString, tabName, conditions);
                  
                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null && data.Rows.Count == 1)
                {
                    DataRow row = data.Rows[0];

                    chiam = Mappers.ChiamataMapper.DataRowToVO(row);

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
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            IDAL.VO.ChiamataVO chiam = null;
            try
            {
                string connectionString = this.GCPConnectionString;
                string tabName = "[Chiamata]";

                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                conditions.Add("ExtIDChiamata", new DBSQL.QueryCondition
                {
                    Key = "ExtIDChiamata",
                    Op = DBSQL.Op.LowerEqual,
                    Conj = DBSQL.Conj.None,
                    Value = extidid
                });

                DataTable data = DataAccessLayer.DBSQL.SelectOperation(connectionString, tabName, conditions);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null && data.Rows.Count == 1)
                {
                    DataRow row = data.Rows[0];

                    chiam = Mappers.ChiamataMapper.DataRowToVO(row);

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
        public List<ChiamataVO> GetChiamateByStato(int stato)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            List<IDAL.VO.ChiamataVO> chiams = null;
            try
            {
                string connectionString = this.GCPConnectionString;

                string tabName = "[Chiamata]";
                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();                
                conditions.Add("stato", new DBSQL.QueryCondition
                {
                    Key = "Stato",
                    Op = DBSQL.Op.LowerEqual,
                    Conj = DBSQL.Conj.None,
                    Value = stato
                });

                DataTable data = DBSQL.SelectOperation(connectionString, tabName, conditions);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));

                if (data != null)
                {
                    chiams = Mappers.ChiamataMapper.DataRowToVO(data.Rows);

                    log.Info(string.Format("{0} Records mapped to {1}", chiams.Count, chiams.First().GetType().ToString()));
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

            return chiams;
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
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;
                string tabName = "[Chiamata]";
                result = DBSQL.InsertOperation(connectionString, tabName, data);

                log.Info(string.Format("Query Executed! Inserted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int AddChiamate(List<ChiamataVO> data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;
                string tabName = "[Chiamata]";

                result = DBSQL.MultiInsertOperation(connectionString, tabName, data.Cast<object>().ToList());

                log.Info(string.Format("Query Executed! Inserted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }
        public int DeleteChiamata(long chiamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;
                string tabName = "[Chiamata]";
                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                conditions.Add("IDChiamata", new DBSQL.QueryCondition
                {
                    Key = "IDChiamata",
                    Op = DBSQL.Op.Equal,
                    Conj = DBSQL.Conj.None,
                    Value = chiamidid
                });

                result = DBSQL.DeleteOperation(connectionString, tabName, conditions);

                log.Info(string.Format("Query Executed! Deleted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;
        }  
    }
}
