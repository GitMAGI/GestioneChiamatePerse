using IBLL.DTO;
using IDAL.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using BusinessLogicLayer.Mappers;

namespace BusinessLogicLayer
{
    public partial class BLL
    {
        public List<ChiamataDTO> GetChiamateByRangeDate(DateTime begin, DateTime end)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            List<ChiamataDTO> chiams = null;
            try
            {
                List<ChiamataVO> chiams_ = this.dal.GetChiamateByRangeDate(begin, end);
                log.Info(string.Format("Operation computed for {0} items!", chiams_.Count));
                chiams = ChiamataMapper.VOListToDTOList(chiams_);
                log.Info(string.Format("{0} items of {1} mapped to {2}", chiams.Count, chiams_.First().GetType().ToString(), chiams.First().GetType().ToString()));
                return chiams; 
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }
        }
        
        public int UpdateChiamataByExtPk(ChiamataDTO data, long extidid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                ChiamataVO data_ = ChiamataMapper.DTOToVO(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", 1, data.GetType().ToString(), data_.GetType().ToString()));
                result = this.dal.UpdateChiamataByExtPk(data_, extidid);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result;
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }
        }
        public int UpdateChiamataByPk(ChiamataDTO data, long idid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                ChiamataVO data_ = ChiamataMapper.DTOToVO(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", 1, data.GetType().ToString(), data_.GetType().ToString()));
                result = this.dal.UpdateChiamataByPk(data_, idid);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result; 
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }
            
        }
        
        public int AddChiamata(ChiamataDTO data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                ChiamataVO data_ = ChiamataMapper.DTOToVO(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", 1, data.GetType().ToString(), data_.GetType().ToString()));
                // ----------------------------------------------------------
                // Check if Object with the same ExtIDChiamata already exists
                ChiamataVO got = this.dal.GetChiamataByExtPk(data_.ExtIDChiamata.Value);
                if (got != null)
                {
                    string msg = string.Format("Duplicate Index for {0}: {1}", "ExtIdChiamata", data_.ExtIDChiamata.Value);
                    log.Info("Operation aborted! " + msg);
                    if (errReport == null) 
                        errReport = new List<string>();
                    errReport.Add("Record already in the DB! " + msg);
                    return result;
                }
                // ----------------------------------------------------------
                result = this.dal.AddChiamata(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result;   
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }
        }
        public int AddChiamate(List<ChiamataDTO> data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;
                        
            try
            {
                List<ChiamataVO> data_ = ChiamataMapper.DTOListToVOList(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", data.Count, data.First().GetType().ToString(), data_.First().GetType().ToString()));
                // ----------------------------------------------------------
                // Check if Object with the same ExtIDChiamata already exists
                List<long> extidids = new List<long>();
                foreach(ChiamataVO d in data_)
                {
                    extidids.Add(d.ExtIDChiamata.Value);
                }
                List<ChiamataVO> gots = this.dal.GetChiamateByExtPk(extidids);
                List<long> alreadys = new List<long>();
                if (gots != null)
                {
                    foreach(ChiamataVO g in gots)
                    {
                        long already = g.ExtIDChiamata.Value;
                        alreadys.Add(already);
                        string msg = string.Format("Duplicate Index for {0}: {1}", "ExtIdChiamata", already);                        
                        if (errReport == null)
                            errReport = new List<string>();
                        errReport.Add("Record already in the DB! " + msg);
                    }
                    string msg_ = string.Format("Operation aborted! Duplicate Indexes for {0}: {1}", "ExtIdChiamata", string.Join(", ", alreadys));
                    log.Info(msg_);
                    return result;
                }
                // ----------------------------------------------------------
                result = this.dal.AddChiamate(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result;
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }  
        }
        public int AddChiamate(ChiamataDTO[] data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                List<ChiamataDTO> dataDTO = new List<ChiamataDTO>();
                foreach (ChiamataDTO datum in data)
                {
                    dataDTO.Add(datum);
                }
                log.Info(string.Format("{0} items of Array mapped to {1}", dataDTO.Count, dataDTO.First().GetType().ToString()));

                List<ChiamataVO> data_ = ChiamataMapper.DTOListToVOList(dataDTO);
                log.Info(string.Format("{0} items of {1} mapped to {2}", dataDTO.Count, data_.First().GetType().ToString(), dataDTO.First().GetType().ToString()));

                // ----------------------------------------------------------
                // Check if Object with the same ExtIDChiamata already exists
                List<long> extidids = new List<long>();
                foreach (ChiamataVO d in data_)
                {
                    extidids.Add(d.ExtIDChiamata.Value);
                }
                List<ChiamataVO> gots = this.dal.GetChiamateByExtPk(extidids);
                List<long> alreadys = new List<long>();
                if (gots != null)
                {
                    foreach (ChiamataVO g in gots)
                    {
                        long already = g.ExtIDChiamata.Value;
                        alreadys.Add(already);
                        string msg = string.Format("Duplicate Index for {0}: {1}", "ExtIdChiamata", already);
                        if (errReport == null)
                            errReport = new List<string>();
                        errReport.Add("Record already in the DB! " + msg);
                    }
                    log.Info(string.Format("Operation aborted! Duplicate Indexes for {0}: ", "ExtIdChiamata", string.Join(", ", alreadys.ToArray())));
                    return result;
                }
                // ----------------------------------------------------------

                result = this.dal.AddChiamate(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result;  
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }            
        }

        public int DeleteChiamata(long chiamidid, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                result = this.dal.DeleteChiamata(chiamidid);
                log.Info(string.Format("Operation computed for {0} items!", result));
                return result; 
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
                throw;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }                 
        }
    }
}
