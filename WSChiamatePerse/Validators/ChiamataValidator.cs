using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSChiamatePerse.Validators
{
    public class ChiamataValidator
    {
        private static readonly log4net.ILog log =
          log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly OperationStatusNotifier.Notifier globalNotfier = OperationStatusNotifier.Notifier.GetNotifier();

        public static bool IsJsonArrayValid(string jsonArray)
        {
            bool valid = false;
            try
            {
                JArray jArray = JArray.Parse(jsonArray);
                valid = true;
            }
            catch (Exception ex)
            {
                string msg = "Bad JSON Data! Input JSON data must be an array of object: \"[{obj1}{obj2}...{objN}]\"";
                log.Error(msg, ex);
                globalNotfier.AddError(msg);
            }
            return valid;
        }

        public static bool IsJsonObjectValid(JToken jObject)
        {
            bool valid = true;

            DateTime trash;

            if (jObject["CognomeChiamata"] != null)
            {

            }
            if (jObject["DataOraInizioChiamata"] != null) {
                if(!DateTime.TryParse((string)jObject["DataOraInizioChiamata"], out trash))
                {

                }
            }
            if (jObject["DataOraFineChiamata"] != null)
            {

            }
            if (jObject["ExtIDChiamata"] != null)
            {

            } //? long.Parse((string)jObject["ExtIDChiamata"]) : (long?)null;
            if (jObject["ExtIDOperatore"] != null)
            {

            } //? long.Parse((string)jObject["ExtIDOperatore"]) : (long?)null;
            if (jObject["IDChiamata"] != null)
            {

            } //? long.Parse((string)jObject["IDChiamata"]) : (long?)null;
            if (jObject["IDExtSollecitoChiamata"] != null)
            {

            } // ? long.Parse((string)jObject["IDExtSollecitoChiamata"]) : (long?)null;
            if (jObject["InfoChiamata"] != null)
            {

            } // ? (string)jObject["InfoChiamata"] : null;
            if (jObject["IPOperazione"] != null)
            {

            } // ? (string)jObject["IPOperazione"] : null;
            if (jObject["MotivoChiamata"] != null)
            {

            } // ? (string)jObject["MotivoChiamata"] : null;
            if (jObject["NomeChiamata"] != null)
            {

            } // ? (string)jObject["NomeChiamata"] : null;
            if (jObject["NumeroChiamata"] != null)
            {

            } // ? (string)jObject["NumeroChiamata"] : null;
            if (jObject["Priorita"] != null)
            {

            } // ? int.Parse((string)jObject["Priorita"]) : (int?)null;
            if (jObject["Stato"] != null)
            {

            } // ? int.Parse((string)jObject["Stato"]) : (int?)null;

            return valid;
        }
    }
}