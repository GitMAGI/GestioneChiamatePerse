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

                string query = "SELECT * FROM [dbo].[Chiamata] WHERE DataOraInizioChiamata >= @inizioC and DataOraInizioChiamata <= @fineC";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["inizioC"] = begin;
                pars["fineC"] = end;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DataAccessLayer.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

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

                string query = "SELECT * FROM [dbo].[Chiamata] WHERE IDChiamata = @IDChiamata";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["IDChiamata"] = idid;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DataAccessLayer.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

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

                string query = "SELECT * FROM [dbo].[Chiamata] WHERE ExtIDChiamata = @ExtIDChiamata";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["ExtIDChiamata"] = extidid;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DataAccessLayer.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

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

                string query = "SELECT * FROM [dbo].[Chiamata] WHERE Stato = @Stato";
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars["Stato"] = stato;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                DataTable data = DataAccessLayer.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

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

                Dictionary<string, object> pars = new Dictionary<string, object>();
                foreach (var prop in data.GetType().GetProperties())
                {
                    if (prop.GetValue(data, null) != null)
                    {
                        pars[prop.Name] = prop.GetValue(data, null);
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

                result = DBSQL.ExecuteNonQueryWithParams(connectionString, query, pars);

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
            throw new NotImplementedException();
        }
        public int DeleteChiamata(string esamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;

                string query = "DELETE FROM [dbo].[Chiamata] WHERE IDChiamata = @IDChiamata";
                Dictionary<string, object> pars = new Dictionary<string, object>();                                
                pars["IDChiamata"] = esamidid;

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                result = DBSQL.ExecuteNonQueryWithParams(connectionString, query, pars);

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
        
        public List<ChiamataVO> GetChiamateByRangeDate_(string begin, string end)
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
        public ChiamataVO GetChiamataByPk_(long idid)
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
        public ChiamataVO GetChiamataByExtPk_(long extidid)
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
        public List<ChiamataVO> GetChiamateByStato_(int stato)
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
        public int UpdateChiamataByExtPk_(ChiamataVO data, long extidid)
        {
            throw new NotImplementedException();
        }
        public int UpdateChiamataByPk_(ChiamataVO data, long idid)
        {
            throw new NotImplementedException();
        } 
        public int AddChiamata_(ChiamataVO data)
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
        public int AddChiamate_(List<ChiamataVO> data)
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
        public int DeleteChiamata_(long esamidid)
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
                    Value = esamidid
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
