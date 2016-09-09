using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WSChiamatePerse.PO;

namespace WSChiamatePerse
{
    public class TestFunctionality
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IBLL.IBLL bll;

        public TestFunctionality()
        {
            DAL dal = new DAL();
            BLL bll = new BLL(dal);
            this.bll = bll;
        }

        public int AddChiamate(string jsonData)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                List<ChiamataDTO> dataDTO = Mappers.ChiamataMapper.JsonArrayToDTOList(jsonData);
                log.Info(string.Format("{0} JSON items mapped to {1}", dataDTO.Count, dataDTO.First().GetType().ToString()));                
                result = this.bll.AddChiamate(dataDTO);
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