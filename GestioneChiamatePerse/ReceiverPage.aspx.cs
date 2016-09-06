using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneChiamatePerse
{
    public partial class RecieverPage : System.Web.UI.Page
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        // --------------
        // DEV da gestire
        // --------------
        protected static bool TypeValidator(string value, Type type)
        {
            if (type == typeof(String))
            {
                return true;
            }
            else if (type == typeof(Boolean))
            {
                Boolean b;
                return Boolean.TryParse(value, out b);
            }
            else if (type == typeof(Int64))
            {
                Int64 l;
                return Int64.TryParse(value, out l);
            }
            else if (type == typeof(Int32))
            {
                Int32 i;
                return Int32.TryParse(value, out i);
            }
            else if (type == typeof(Int16))
            {
                Int16 i_;
                return Int16.TryParse(value, out i_);
            }
            else if (type == typeof(UInt64))
            {
                UInt64 ul;
                return UInt64.TryParse(value, out ul);
            }
            else if (type == typeof(UInt32))
            {
                UInt32 ui;
                return UInt32.TryParse(value, out ui);
            }
            else if (type == typeof(UInt16))
            {
                UInt16 ui_;
                return UInt16.TryParse(value, out ui_);
            }
            else if (type == typeof(Byte))
            {
                Byte b;
                return Byte.TryParse(value, out b);
            }
            else if (type == typeof(SByte))
            {
                SByte sb;
                return SByte.TryParse(value, out sb);
            }
            else if (type == typeof(Single))
            {
                Single s_;
                return Single.TryParse(value, out s_);
            }
            else if (type == typeof(Double))
            {
                Double d_;
                return Double.TryParse(value, out d_);
            }
            else if (type == typeof(Decimal))
            {
                Decimal d;
                return Decimal.TryParse(value, out d);
            }
            else if (type == typeof(Char))
            {
                Char c;
                return Char.TryParse(value, out c);
            }
            else if (type == typeof(DateTime))
            {
                DateTime dt;
                return DateTime.TryParse(value, out dt);
            }
            // similar code to check all other types 
            // (Enum)            
            else
                throw new ArgumentException("Invalid type evaluation");

        }

        protected object AddChiamataFromRequest()
        {
            int result = -1;

            string[] usefuls = new string[] {"ExtIDChiamata", "NumeroChiamata", "NomeChiamata", "CognomeChiamata", "MotivoChiamata", 
                "DataOraChiamata", "InfoChiamata", "DataOraOperazione", "IPOperazione"};
            Dictionary<string, Type> types = new Dictionary<string, Type>()
            {
                {"ExtIDChiamata", typeof(UInt64)},
                {"NumeroChiamata", typeof(string)},
                {"NomeChiamata", typeof(string)},
                {"CognomeChiamata", typeof(string)},
                {"MotivoChiamata", typeof(string)},
                {"DataOraChiamata", typeof(DateTime)},
                {"InfoChiamata", typeof(string)},
                {"DataOraOperazione", typeof(DateTime)},
                {"IPOperazione", typeof(UInt64)},
            };
            string[] mandatories = new string[] {"ExtIdChiamata", "DataOraOperazione"};

            Dictionary<string, object> data = new Dictionary<string, object>();

            // BuildDictionaryDataByRequest(ref data, usefuls);
            // ValidateTypes(data, types);
            // CheckMandatories(data, mandatories);

            return result;
        }

        protected void BuildDictionaryDataByRequest(ref Dictionary<string, object> data, string[] usefuls)
        {

        }
        // --------------


        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> test = new Dictionary<string, object>();

            bool err = false;
            string errMsg = string.Empty;
            int result = -1;

            try
            {
                test["IPOperazione"] = GetUser_IP();
                test["DataOraOperazione"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

                if (Request.Form["ExtIDChiamata"] == null)
                {                    
                    err = true;
                    errMsg = "ExtIdChiamata is missing!\n";
                }
                else
                {
                    foreach (string key in Request.Form.Keys)
                    {
                        log.Info(string.Format("{0} => {1}", key, Request.Form[key]));
                        if (Request.Form[key] != string.Empty)
                        {
                            if (key == "DataOraChiamata")
                            {
                                if (Request.Form["DataOraChiamata"] != null)
                                {
                                    DateTime tmp;
                                    string takeALook = Request.Form["DataOraChiamata"];
                                    if (DateTime.TryParse(Request.Form["DataOraChiamata"], out tmp))
                                    {
                                        test[key] = tmp.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                                    }
                                    else
                                    {
                                        err = true;
                                        errMsg = "DataOraChiamata (" + Request.Form["DataOraChiamata"] + ") is not valid!\n";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                test[key] = Request.Form[key];
                            }
                        }
                    }

                    log.Info("ChiamataDTO composed as follows: ");
                    foreach (KeyValuePair<string, object> entry in test)
                    {
                        log.Info(string.Format("{0} => {1}", entry.Key, entry.Value));
                    }

                    if (err)
                    {
                        log.Error("An Error Occured! MSG: " + errMsg);
                    }
                    else
                    {
                        log.Info("All Fields are ok!");
                        result = (int)GCPData.GCPBLL.AddChiamata(test);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("An Exception Occurred! " + ex.Message);
                result = -2;
            }

            log.Info(string.Format("Making and Sending Respose: {0}", result));

            //string dat_ = "{\"result\":"+result+"}";
            string dat_ = string.Format("{0}", result);
            Response.Clear();
            //Response.ContentType = "application/json; charset=utf-8";
            Response.ContentType = "text/plain";
            Response.Write(dat_);
            Response.End();

            Response.Write(result);
        }

        protected static string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }            

            return VisitorsIPAddr;
        }
    }
}