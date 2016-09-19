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

        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("Starting computing....");
            log.Info(string.Format("Request from IP: {0}", GetUserIP()));

            string response = null;

            try
            {
                string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();

                log.Info(string.Format("Request incoming: {0}", data));

                using (WSGestioneChiamate.GestioneChiamateClient client = new WSGestioneChiamate.GestioneChiamateClient())
                {                    
                    response = client.InsertJson_json(data);
                }                
            }
            catch (Exception)
            {
                response = "Error! Internal error!";
            }

            log.Info("Completed!");

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(response);
            Response.End();
        }

        protected static string GetUserIP()
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