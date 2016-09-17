using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralPurposeLib
{
    public class JsonUtilities
    {
        public static bool JObjToDictionaryObj(JObject jObject, ref Dictionary<string, string> parsed, ref List<string> errReport)
        {
            bool success = true;

            if (errReport == null)
                errReport = new List<string>();

            try
            {                
                if (parsed == null)
                    parsed = new Dictionary<string, string>();

                parsed = jObject.Properties().Select(p => p).ToDictionary(p => p.Name.ToString(), p => p.Value.ToString());                
            }
            catch (Exception)
            {
                if (errReport == null)
                    errReport = new List<string>();

                string msg = "Error during JSON Object items extraction! Check on the structure of the JSON!";
                errReport.Add(msg);
                success = false;
                throw;
            }
            finally
            {
                if (errReport != null && errReport.Count == 0)
                    errReport = null;
            }

            return success;        
        }

        public static bool JStringToDictionaryObj(string jsonObj, ref Dictionary<string, string> parsed, ref List<string> errReport)
        {
            bool success = true;

            if (errReport == null)
                errReport = new List<string>();

            try
            {
                if (jsonObj != null && jsonObj != string.Empty)
                {
                    JObject jObject = JObject.Parse(jsonObj);
                    success = JObjToDictionaryObj(jObject, ref parsed, ref errReport);
                }
                else
                {
                    string msg = "Error! JSON string passed is empty or null!";                    
                    errReport.Add(msg);
                    success = false;
                }
            }
            catch (Exception)
            {
                string msg = "Error during the parsing of an JSON Object from string! Check on the structure of the JSON!";
                errReport.Add(msg);
                success = false;
                throw;
            }
            finally
            {
                if (errReport != null && errReport.Count == 0)
                    errReport = null;
            }

            return success;
        }
    }
}
