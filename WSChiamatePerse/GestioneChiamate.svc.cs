using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using WSChiamatePerse.Constraints;

namespace WSChiamatePerse
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare Service1.svc o Service1.svc.cs in Esplora soluzioni e avviare il debug.
    public class GestioneChiamate : IGestioneChiamate
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BLL bll;
        private DAL dal;

        private ChiamataContraints ChiamataTabStruct = new ChiamataContraints();

        public GestioneChiamate()
        {
            DAL dal = new DAL();
            this.dal = dal;
            BLL bll = new BLL(this.dal);
            this.bll = bll;            
        }

        public Response GenericCall(object input)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting procedure...");

            List<string> errReport = new List<string>();
            List<string> warnReport = new List<string>();
            List<string> infoReport = new List<string>();

            Response response = new Response();
            response.success = true;

            try
            {





            }
            catch (Exception ex)
            {
                string msg = "INTERNAL ERROR -> An Exception occurred during the request that was under computation! The stack is: " + ex.Message;
                errReport.Add(msg);
                log.Error(msg);
                response.success = false;
            }

            response.AddErrors(errReport);
            response.AddWarnings(warnReport);
            response.AddInfos(infoReport);

            errReport = null;
            warnReport = null;
            infoReport = null;

            tw.Stop();
            log.Info(string.Format("Procedure Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return response;
        }

        public ResponseInsert InsertObjList_obj(List<ChiamataSOi> sos)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting procedure...");

            List<string> errReport = new List<string>();
            List<string> warnReport = new List<string>();
            List<string> infoReport = new List<string>();

            ResponseInsert response = new ResponseInsert();
            response.success = true;

            try
            {

                // 1. Validate the Object
                bool validChecks = ChiamataTabStruct.CheckAndConstranitsValidation<ChiamataSOi>(sos, ref errReport, ref warnReport, ref infoReport);
                if (validChecks)
                {
                    // 2. Make the real service call
                    int rows = AddChiamate(sos, ref errReport, ref warnReport, ref infoReport);
                    response.AffectedRows = rows;
                    if (errReport != null && errReport.Count > 0)
                        response.success = false;
                }
                else
                {
                    response.success = false;
                }  

            }
            catch (Exception ex)
            {
                string msg = "INTERNAL ERROR -> An Exception occurred during the request that was under computation! The stack is: " + ex.Message;
                errReport.Add(msg);
                log.Error(msg);
                response.success = false;
            }

            response.AddErrors(errReport);
            response.AddWarnings(warnReport);
            response.AddInfos(infoReport);

            errReport = null;
            warnReport = null;
            infoReport = null;

            tw.Stop();
            log.Info(string.Format("Procedure Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return response;
        }
        
        public ResponseInsert InsertJson_obj(string jsonArray)
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting procedure...");

            List<string> errReport = new List<string>();
            List<string> warnReport = new List<string>();
            List<string> infoReport = new List<string>();

            ResponseInsert response = new ResponseInsert();
            response.success = true;
            response.AffectedRows = -1;

            try
            {
                // 1. Get List of dictionary from the input JSON
                List<Dictionary<string, string>> data = GeneralPurposeLib.JsonUtilities.JsonArrayToDictionaryList(jsonArray);
                // 2. Parse and Validate Types
                List<Dictionary<string, object>> dataConverted = null;
                bool validType = ChiamataTabStruct.ParsingValidation(data, ref dataConverted, ref errReport, ref warnReport, ref infoReport);
                if (validType)
                {
                    // 3. Map to SOi
                    List<ChiamataSOi> sos = Mappers.ChiamataMapper.DictionaryListToSOList(dataConverted);
                    // 4. Validate the Object
                    bool validChecks = ChiamataTabStruct.CheckAndConstranitsValidation<ChiamataSOi>(sos, ref errReport, ref warnReport, ref infoReport);
                    if(validChecks)
                    {
                        // 5. Make the real service call
                        int rows = AddChiamate(sos, ref errReport, ref warnReport, ref infoReport);
                        response.AffectedRows = rows;
                        if (errReport != null && errReport.Count > 0)
                            response.success = false;
                    }
                    else
                    {
                        response.success = false;
                    }                 
                }
                else
                {
                    response.success = false;
                }
            }
            catch(Exception ex)
            {
                string msg = "INTERNAL ERROR -> An Exception occurred during the request that was under computation! The stack is: " + ex.Message;
                if (errReport == null)
                    errReport = new List<string>();
                errReport.Add(msg);
                log.Error(msg);
                response.success = false;
            }

            response.AddErrors(errReport);
            response.AddWarnings(warnReport);
            response.AddInfos(infoReport);

            errReport = null;
            warnReport = null;
            infoReport = null;

            tw.Stop();
            log.Info(string.Format("Procedure Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return response;
        }

        public string InsertJson_json(string jsonArray)
        {
            string result = null;

            result = JsonConvert.SerializeObject(InsertJson_obj(jsonArray));

            return result;
        }

        public ResponseData GetAll_obj()
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info("Starting procedure...");

            List<string> errReport = new List<string>();
            List<string> warnReport = new List<string>();
            List<string> infoReport = new List<string>();

            ResponseData response = new ResponseData();
            response.success = true;

            try
            {
                List<ChiamataSOo> data = null;
                int result = GetChiamate(ref data, ref errReport, ref warnReport, ref infoReport);
                response.Data = data;
            }
            catch (Exception ex)
            {
                string msg = "INTERNAL ERROR -> An Exception occurred during the request that was under computation! The stack is: " + ex.Message;
                if (errReport == null)
                    errReport = new List<string>();
                errReport.Add(msg);
                log.Error(msg);
                response.success = false;
            }

            response.AddErrors(errReport);
            response.AddWarnings(warnReport);
            response.AddInfos(infoReport);

            errReport = null;
            warnReport = null;
            infoReport = null;

            tw.Stop();
            log.Info(string.Format("Procedure Completed! Elapsed time {0}", GeneralPurposeLib.LibString.TimeSpanToTimeHmsms(tw.Elapsed)));

            return response;
        }

        private int AddChiamate(List<ChiamataSOi> data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            int result = -1;

            List<ChiamataDTO> dtos = Mappers.ChiamataMapper.SOListToDTOList(data);
            result = this.bll.AddChiamate(dtos, ref errReport, ref warnReport, ref infoReport);

            return result;
        }

        private int GetChiamate(ref List<ChiamataSOo> data, ref List<string> errReport, ref List<string> warnReport, ref List<string> infoReport)
        {
            int result = -1;

            List<ChiamataDTO> dtos = this.bll.GetChiamateAll();
            data = Mappers.ChiamataMapper.DTOListToSOList(dtos);
            result = data.Count;

            return result;
        }

        public void Exposer(ChiamataSOi soi, ChiamataSOo soo, ResponseData rd, ResponseInsert ri)
        {
            soo = null;
            soi = null;
            rd = null;
            ri = null;
        }
    }
}
