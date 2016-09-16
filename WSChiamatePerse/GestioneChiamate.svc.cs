using BusinessLogicLayer;
using DataAccessLayer;
using IBLL.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GeneralPurposeLib;
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

        private ChiamataContraints ChiamataTab = new ChiamataContraints();

        public GestioneChiamate()
        {
            DAL dal = new DAL();
            this.dal = dal;
            BLL bll = new BLL(this.dal);
            this.bll = bll;
        }

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

                    List<Dictionary<string, object>> parsed = new List<Dictionary<string, object>>();

                    List<string> errReport_validation = new List<string>();
                    bool validate = ChiamataTab.Validation(records, out parsed, out errReport_validation);
                    if (errReport_validation != null && errReport_validation.Count > 0)
                    {
                        string err = string.Join(" ", errReport_validation.ToArray());
                        errReport.Add(string.Format("DATA VALIDATION ERRORS -> [{0}]", err));
                        errReport_validation = null;
                    }
                    
                    if (!validate)
                    {
                        string msg = "Bad Json Request. Validation failed!";                        
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
                string msg = "INTERNAL ERROR -> An Exception occurred during the request was under computation! The stack is: " + ex.Message;
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





        /*

        public ResponseInsert InserisciChiamateJO(string jsonArray)
        {
            log.Info("Starting procedure...");
            string tmp_ = jsonArray != null ? jsonArray.GetType().ToString() : "Null";
            log.Debug(string.Format("Data passed to the function is {0}", tmp_));
            ResponseInsert response = new ResponseInsert();
            response.success = false;
            response.AffectedRows = -1;

            try
            {
                log.Info("Starting Validation structure ...");
                // Validations of structure, parsing and building of the SOs
                List<ChiamataSOi> sos = Mappers.ChiamataMapper.JsonArrayToSOList(jsonArray);
                log.Info("Validation of contraints Successful!");
                log.Info(string.Format("Mapped {0} items!", sos.Count));
                response = InserisciChiamateLOO(sos);
            }
            catch (AggregateException exs)
            {
                string msg = "Errors Occurred! " + exs.Flatten().Message;
                log.Error(msg);
                response.success = false;
                response.AffectedRows = -1;
            }

            return response;
        }
        public string InserisciChiamateJJ(string jsonArray)
        {
            string jresponse = string.Empty;
            ResponseInsert response = InserisciChiamateJO(jsonArray);
            jresponse = JsonConvert.SerializeObject(response);
            return jresponse;
        }
        public int InserisciChiamateJI(string jsonArray)
        {
            int result = -1;

            try
            {
                // Validations of structure, parsing and building of the SOs
                List<ChiamataSOi> sos = Mappers.ChiamataMapper.JsonArrayToSOList(jsonArray);
                return InserisciChiamateLOO(sos).AffectedRows;
            }
            catch (AggregateException exs)
            {
                string msg = "Errors Occurred! " + exs.Flatten().Message;
                log.Error(msg);
            }

            return result;
        }

        public ResponseInsert InserisciChiamateLOO(List<ChiamataSOi> data)
        {
            ResponseInsert response = new ResponseInsert();
            string tmp_ = data != null ? data.GetType().ToString() : "Null";
            log.Debug(string.Format("Data passed to the function is {0}", tmp_));
            try
            {
                log.Info("Starting Validation of contraints (Not null, max length, ...)");
                // Validations of constraints
                var context = new ValidationContext(data, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(data, context, results))
                {
                    log.Info("Validation of contraints Successful!");
                    List<ChiamataDTO> dtos = Mappers.ChiamataMapper.SOListToDTOList(data);
                    log.Info("Mapping Successful!");
                    response.AffectedRows = bll.AddChiamate(dtos);
                    log.Info("Request completed! Response Object built!");
                    response.success = true;
                }
                else
                {
                    log.Info("Validation of contraints Failed!");
                    int count = 0;
                    string msg = string.Empty;
                    foreach (var validationResult in results)
                    {
                        string tmp = string.Format("Checks validation failure: {0}", validationResult.ErrorMessage);
                        msg += tmp;
                        if (count < results.Count)
                            msg += " ";
                        count++;
                    }

                    response.AddError("Data validation failed! " + msg);
                    response.success = false;
                    response.AffectedRows = -1;
                    log.Error(msg);
                }

            }
            catch (AggregateException exs)
            {
                string msg = "Errors Occurred! " + exs.Flatten().Message;
                response.AddError(msg);
                response.success = false;
                response.AffectedRows = -1;
                log.Error(msg);
            }
            catch (Exception ex)
            {
                string msg = "Errors Occurred! " + ex.Message;
                response.AddError(msg);
                response.success = false;
                response.AffectedRows = -1;
                log.Error(msg);
            }

            return response;
        }
        public string InserisciChiamateLOJ(List<ChiamataSOi> data)
        {
            string jresponse = string.Empty;
            ResponseInsert response = InserisciChiamateLOO(data);
            jresponse = JsonConvert.SerializeObject(response);
            return jresponse;
        }
        public int InserisciChiamateLOI(List<ChiamataSOi> data)
        {
            int iresponse = -1;
            ResponseInsert response = InserisciChiamateLOO(data);
            iresponse = response.AffectedRows;
            return iresponse;
        }

        public ResponseInsert InserisciChiamateAOO(ChiamataSOi[] data)
        {
            List<ChiamataSOi> sos = data.ToList();
            ResponseInsert response = InserisciChiamateLOO(sos);
            return response;
        }
        public string InserisciChiamateAOJ(ChiamataSOi[] data)
        {
            List<ChiamataSOi> sos = data.ToList();
            string jresponse = InserisciChiamateLOJ(sos);
            return jresponse;
        }
        public int InserisciChiamateAOI(ChiamataSOi[] data)
        {
            List<ChiamataSOi> sos = data.ToList();
            int iresponse = InserisciChiamateLOI(sos);
            return iresponse;
        }

        public ResponseInsert InserisciChiamateOO(ChiamataSOi data)
        {
            log.Info("Starting procedure...");
            string tmp_ = data != null ? data.GetType().ToString() : "Null";
            log.Debug(string.Format("Data passed to the function is {0}", tmp_));           
            List<ChiamataSOi> sos = new List<ChiamataSOi>();
            sos.Add(data);
            log.Info("List of data object built!");
            ResponseInsert response = InserisciChiamateLOO(sos);
            log.Info("Procedure completed!");
            return response;
        }
        public string InserisciChiamateOJ(ChiamataSOi data)
        {
            List<ChiamataSOi> sos = new List<ChiamataSOi>();
            sos.Add(data);
            string jresponse = string.Empty;
            ResponseInsert response = InserisciChiamateOO(data);
            jresponse = JsonConvert.SerializeObject(response);
            return jresponse;
        }
        public int InserisciChiamateOI(ChiamataSOi data)
        {
            List<ChiamataSOi> sos = new List<ChiamataSOi>();
            sos.Add(data);
            int iresponse = InserisciChiamateLOI(sos);
            return iresponse;
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
