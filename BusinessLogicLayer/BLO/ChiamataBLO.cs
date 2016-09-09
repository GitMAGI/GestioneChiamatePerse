using IBLL.DTO;
using IDAL.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return chiams;        
        }
        
        public int UpdateChiamataByExtPk(ChiamataDTO data, long extidid)
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
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result; 
        }
        public int UpdateChiamataByPk(ChiamataDTO data, long idid)
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
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result; 
        }
        
        public int AddChiamata(ChiamataDTO data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                ChiamataVO data_ = ChiamataMapper.DTOToVO(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", 1, data.GetType().ToString(), data_.GetType().ToString()));
                result = this.dal.AddChiamata(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;   
        }
        public int AddChiamate(List<ChiamataDTO> data)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;
                        
            try
            {
                List<ChiamataVO> data_ = ChiamataMapper.DTOListToVOList(data);
                log.Info(string.Format("{0} items of {1} mapped to {2}", data.Count, data_.First().GetType().ToString(), data.First().GetType().ToString()));
                result = this.dal.AddChiamate(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;   
        }
        public int AddChiamate(ChiamataDTO[] data)
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
                result = this.dal.AddChiamate(data_);
                log.Info(string.Format("Operation computed for {0} items!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;   
        }

        public int DeleteChiamata(long chiamidid)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                result = this.dal.DeleteChiamata(chiamidid);
                log.Info(string.Format("Operation computed for {0} items!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg + "\n" + ex.Message);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result; 
        }
    }
}
