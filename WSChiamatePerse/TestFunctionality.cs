using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WSChiamatePerse
{
    public class Response
    {        
        protected List<string> Infos;
        protected List<string> Warnings;
        protected List<string> Errors;
        public bool success;

        public void AddInfos(List<string> infos)
        {
            List<string> data = this.Infos;
            data.AddRange(infos);
        }
        public void AddWarnings(List<string> warnings)
        {
            List<string> data = this.Warnings;
            data.AddRange(warnings);
        }
        public void AddErrors(List<string> errors)
        {
            List<string> data = this.Errors;
            data.AddRange(errors);
        }
        public void AddInfo(string info)
        {
            List<string> data = this.Infos;
            data.Add(info);
        }
        public void AddWarning(string warning)
        {
            List<string> data = this.Warnings;
            data.Add(warning);
        }
        public void AddError(string error)
        {
            List<string> data = this.Errors;
            data.Add(error);
        }
        public List<string> GetInfos()
        {
            return this.Infos;
        }
        public List<string> GetWarnings()
        {
            return this.Warnings;
        }
        public List<string> GetErrors()
        {
            return this.Errors;
        }
    }

    public class ResponseData : Response
    {
        public List<ChiamataDTO> Data { get; set; }
    }

    public class ResponseInsert : Response
    {
        public int AffectedRows { get; set; }
    }

    /*
    * STRUTTUTA JSON DI UN PACCHETTO DI RISPOSTA DEL SERVIZIO
    * success: true/false,
    * data: numberOfRecords OPPURE [{obj1}, {obj2}, ... {objN}]
    * infos: [str1, str2, ... strN],
    * warnings: [str1, str2, ... strN],
    * errors: [str1, str2, ... strN],
    */

    /*
    * STRUTTURA JSON DI UN PACCHETTO DI INVIO DATI
    * [{obj1}, {obj2}, ... {objN}]
    */


    public class TestFunctionality
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly OperationStatusNotifier.Notifier globalNotfier = OperationStatusNotifier.Notifier.GetNotifier();

        private BLL bll;

        public TestFunctionality()
        {
            DAL dal = new DAL();
            BLL bll = new BLL(dal);
            this.bll = bll;
        }

        public string AddChiamateJSONJSON(string jsonData)
        {
            string jsonResult = null;

            List<ChiamataDTO> dataToWrite = Mappers.ChiamataMapper.JsonArrayToDTOList(jsonData);
            int affectedRows = this.bll.AddChiamate(dataToWrite);

            ResponseInsert result = new ResponseInsert();

            result.AffectedRows = affectedRows;
            result.AddInfos(globalNotfier.GetInfos());
            result.AddWarnings(globalNotfier.GetWarnings());
            result.AddErrors(globalNotfier.GetErrors());
            result.success = result.GetErrors().Count == 0 || result.GetErrors() == null ? true : false;

            // Map ResponseInsert To JSON

            return jsonResult;
        }
        public ResponseInsert AddChiamateDTOListResponse(List<ChiamataDTO> dataToWrite)
        {
            ResponseInsert response = new ResponseInsert();

            int affectedRows = this.bll.AddChiamate(dataToWrite);

            response.AffectedRows = affectedRows;
            response.AddInfos(globalNotfier.GetInfos());
            response.AddWarnings(globalNotfier.GetWarnings());
            response.AddErrors(globalNotfier.GetErrors());
            response.success = response.GetErrors().Count == 0 || response.GetErrors() == null ? true : false;

            return response;
        }
        public ResponseInsert AddChiamateDTOArrayResponse(ChiamataDTO[] dataToWrite)
        {
            ResponseInsert response = new ResponseInsert();

            List<ChiamataDTO> data = dataToWrite.OfType<ChiamataDTO>().ToList();

            int affectedRows = this.bll.AddChiamate(data);

            response.AffectedRows = affectedRows;            
            response.AddInfos(globalNotfier.GetInfos());
            response.AddWarnings(globalNotfier.GetWarnings());
            response.AddErrors(globalNotfier.GetErrors());
            response.success = response.GetErrors().Count == 0 || response.GetErrors() == null ? true : false;

            return response;
        }
        public string AddChiamateDTOListJSON(List<ChiamataDTO> dataToWrite)
        {
            string response = null;

            int affectedRows = this.bll.AddChiamate(dataToWrite);

            ResponseInsert result = new ResponseInsert();

            result.AffectedRows = affectedRows;
            result.AddInfos(globalNotfier.GetInfos());
            result.AddWarnings(globalNotfier.GetWarnings());
            result.AddErrors(globalNotfier.GetErrors());
            result.success = result.GetErrors().Count == 0 || result.GetErrors() == null ? true : false;

            // MAP ResponseInsert To JSON

            return response;
        }
        public string AddChiamateDTOArrayJSON(ChiamataDTO[] dataToWrite)
        {
            string response = null;

            List<ChiamataDTO> data = dataToWrite.OfType<ChiamataDTO>().ToList();

            int affectedRows = this.bll.AddChiamate(data);

            ResponseInsert result = new ResponseInsert();

            result.AffectedRows = affectedRows;
            result.AddInfos(globalNotfier.GetInfos());
            result.AddWarnings(globalNotfier.GetWarnings());
            result.AddErrors(globalNotfier.GetErrors());
            result.success = result.GetErrors().Count == 0 || result.GetErrors() == null ? true : false;

            // MAP ResponseInsert To JSON

            return response;
        }

        public int AddChiamate(string jsonData)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting ...");

            int result = -1;

            try
            {
                // Validate JSON Structure

                List<ChiamataDTO> dataDTO = Mappers.ChiamataMapper.JsonArrayToDTOList(jsonData);
                log.Info(string.Format("{0} JSON items mapped to {1}", dataDTO.Count, dataDTO.First().GetType().ToString()));                
                result = this.bll.AddChiamate(dataDTO);
                log.Info(string.Format("Operation computed for {0} items!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                log.Error(msg, ex);
            }

            tw.Stop();

            log.Info(string.Format("Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return result;   
        }
        public int AddChiamate(List<ChiamataDTO> dtoData)
        {
            int result = -1;

            return result;
        }
        public int AddChiamate(ChiamataDTO[] dtoData)
        {
            int result = -1;

            return result;
        }


    }
}