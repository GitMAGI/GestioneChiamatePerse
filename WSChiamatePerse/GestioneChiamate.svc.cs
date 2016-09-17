using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

            log.Info("Procedure complete!");

            return response;
        }

        public ResponseInsert InsertJson(string jsonArray)
        {
            log.Info("Starting procedure...");

            List<string> errReport = new List<string>();
            List<string> warnReport = new List<string>();
            List<string> infoReport = new List<string>();

            ResponseInsert response = new ResponseInsert();
            response.success = true;
            response.AffectedRows = -1;

            try
            {





            }
            catch(Exception ex)
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

            log.Info("Procedure complete!");

            return response;
        }

        /*
        public ResponseInsert InsertJson(string jsonArray)
        {
            List<string> errReport = new List<string>();

            log.Info("Starting procedure...");
            
            ResponseInsert response = new ResponseInsert();
            response.success = true;
            response.AffectedRows = -1;

            try
            {
                if (jsonArray == null && jsonArray == string.Empty)
                {
                    string msg = "Bad Json Request. Void or Null has been passed to the Web Service!";
                    errReport.Add("JSON PARSING ERRORS ->");
                    errReport.Add(msg);
                    log.Error(msg);
                    response.success = false;
                }
                else
                {
                    JArray jArray = JArray.Parse(jsonArray);
                    List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();
                    foreach (JToken jRecord in jArray)
                    {
                        Dictionary<string, string> record = new Dictionary<string, string>();
                        foreach (JProperty prop in jRecord.Children())
                        {
                            string n = prop.Name;
                            string v = null;
                            if(prop.Value.Type != JTokenType.Null)
                                v = prop.Value.ToString();                            
                            record[n] = v;
                        }
                        records.Add(record);
                    }

                    List<Dictionary<string, object>> parsed = null;
                    List<string> errReport_validation = null;
                    List<string> warnReport_validation = null;
                    List<string> infoReport_validation = null;
                    bool validate = ChiamataTabStruct.ParsingValidation(records, ref parsed, ref errReport_validation, ref warnReport_validation, ref infoReport_validation);
                    if (errReport_validation != null && errReport_validation.Count > 0)
                    {
                        string err = string.Join(" ", errReport_validation.ToArray());
                        errReport.Add(string.Format("DATA VALIDATION ERRORS -> {0}", err));
                        errReport_validation = null;
                    }
                    
                    if (!validate)
                    {
                        string msg = "Bad Json Request. ParsingValidation failed!";                        
                        log.Error(msg);
                        response.success = false;
                    }
                    else
                    {
                        log.Info(string.Format("Starting Mapping! {0} items to evaluate ...", parsed.Count));                        
                        List<ChiamataSOi> data = Mappers.ChiamataMapper.DictionaryListToSOList(parsed);
                        log.Info(string.Format("Mapping completed! {0} objects mapped!", data.Count));

                        log.Info(string.Format("Starting Insert Operation..."));
                        int result = AddChiamate(data);
                        if (result == -1)
                        {
                            log.Info(string.Format("Insert Operation failed!"));
                            response.success = false;
                        }
                        else
                        {
                            log.Info(string.Format("Insert Operation completed! Has been written {0} items!", result));
                            response.success = true;                            
                        }
                        response.AffectedRows = result;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "INTERNAL ERROR -> An Exception occurred during the request that was under computation! The stack is: " + ex.Message;
                errReport.Add(msg);
                log.Error(msg);
                response.success = false;
            }

            if (errReport.Count == 0)
                errReport = null;

            response.AddErrors(errReport);
            log.Info("Procedure completed!");

            return response;
        }
        */

        private int AddChiamate(List<ChiamataSOi> data)
        {
            int result = -1;

            List<ChiamataDTO> dtos = Mappers.ChiamataMapper.SOListToDTOList(data);
            result = this.bll.AddChiamate(dtos);

            return result;
        }    
    }
}
