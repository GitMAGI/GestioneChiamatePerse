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

        struct OpValue
        {
            public string Op;
            public object Value;
            public string Conj;
        }
        public DataTable SelectOperation(string tabName, Dictionary<string, OpValue> conditions) 
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            DataTable data = null;

            try
            {
                string connectionString = this.GCPConnectionString;

                string query = "SELECT * " + tabName + " WHERE " +
                    string.Join(" ", conditions.Select(x => x.Key + x.Value.Op + "@" + x.Key + " " + x.Value.Conj + " ").ToArray());
                Dictionary<string, object> pars = new Dictionary<string, object>();
                foreach (KeyValuePair<string, OpValue> entry in conditions)
                {
                    pars[entry.Key] = entry.Value.Value;
                }

                log.Info(string.Format("Query: {0}", query));
                log.Info(string.Format("Params: {0}", string.Join(";", pars.Select(x => x.Key + "=" + x.Value).ToArray())));

                data = DataAccessLayer.DBSQL.ExecuteQueryWithParams(connectionString, query, pars);

                log.Info(string.Format("Query Executed! Retrieved {0} records!", data.Rows.Count));                             
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return data;
        }
        public int InsertOperation(string tabName, object dataVO)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;

                Dictionary<string, object> pars = new Dictionary<string, object>();

                foreach (var prop in dataVO.GetType().GetProperties())
                {
                    if (prop.GetValue(dataVO, null) != null)
                    {
                        pars[prop.Name] = prop.GetValue(dataVO, null);
                        //Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(chiamata, null));
                    }
                }

                string query = "INSERT INTO " + tabName + " (" +
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
        public int DeleteOperation(string tabName, Dictionary<string, OpValue> conditions) 
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;

                string query = "DELETE FROM " + tabName + " WHERE " +
                    string.Join(" ", conditions.Select(x => x.Key + x.Value.Op + "@" + x.Key + " " + x.Value.Conj + " ").ToArray());
                Dictionary<string, object> pars = new Dictionary<string, object>();
                foreach (KeyValuePair<string, OpValue> entry in conditions)
                {
                    pars[entry.Key] = entry.Value.Value;                       
                }

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
        public int UpdateOperation(string tabName, object dataVO, Dictionary<string, OpValue> conditions)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            int result = -1;

            try
            {
                string connectionString = this.GCPConnectionString;

                Dictionary<string, object> data = new Dictionary<string, object>();
                foreach (var prop in dataVO.GetType().GetProperties())
                {
                    if (prop.GetValue(dataVO, null) != null)
                    {
                        data[prop.Name + "_toSet"] = prop.GetValue(dataVO, null);                        
                    }
                }

                string query = "UPDATE " + tabName + 
                    " SET " +
                    string.Join(", ", data.Select(x => x.Key + " = " + "@" + x.Key + "_toSet").ToArray()) + 
                    " WHERE " +
                    string.Join(" ", conditions.Select(x => x.Key + x.Value.Op + "@" + x.Key + " " + x.Value.Conj + " ").ToArray());
                    //string.Join(" and ", conditions.Select(x => x.Key + x.Value.Op + "@" + x.Key).ToArray());
                Dictionary<string, object> conditions_ = new Dictionary<string, object>();
                foreach (KeyValuePair<string, OpValue> entry in conditions)
                {
                    conditions_[entry.Key] = entry.Value.Value;

                }

                Dictionary<string, object> pars = data.Concat(conditions_).ToDictionary(x => x.Key, x => x.Value);

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
    }
}
