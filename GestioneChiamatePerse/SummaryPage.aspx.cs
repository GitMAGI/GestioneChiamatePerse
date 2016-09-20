using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneChiamatePerse
{
    public partial class SummaryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (WSGestioneChiamate.GestioneChiamateClient client = new WSGestioneChiamate.GestioneChiamateClient())
            {   
                WSGestioneChiamate.ResponseData response = client.GetAll_obj();
                List<string> visibleCols = new List<string>()
                {
                    "IDChiamata",
                    "ExtIDChiamata",
                    "NumeroChiamata",
                    "NomeChiamata",
                    "CognomeChiamata",
                    "MotivoChiamata",
                    "DataOraInizioChiamata",
                    "DataOraFineChiamata",
                    "Priorita",
                    "Stato",
                    "InfoChiamata",
                    "IDExtSollecitoChiamata",
                    "DataOraOperazione",
                    "IPOperazione",
                    "ExtIDOperatore",
                };
                if (response.success)
                {
                    if (response.Data != null) 
                    {
                        List<WSGestioneChiamate.ChiamataSOo> data = response.Data.ToList();

                        string html = "";

                        html += "<table class=\"table table-condensed table-sm\" style=\"font-size:10px;\">";
                        html += "<thead>";
                        html += "<tr>";
                        html += "<th>#</th>";
                        foreach (var prop in typeof(WSGestioneChiamate.ChiamataSOo).GetProperties())
                        {
                            if (visibleCols.Contains(prop.Name))
                                html += "<th>" + prop.Name + "</th>";
                        }
                        html += "</tr>";
                        html += "</thead>";

                        html += "<tbody>";
                        int t = 1;

                        if (data != null)
                        {
                            foreach (WSGestioneChiamate.ChiamataSOo c in data)
                            {
                                html += "<tr>";
                                html += "<td>" + t + "</td>";
                                foreach (var prop in c.GetType().GetProperties())
                                {
                                    if(visibleCols.Contains(prop.Name))
                                        html += "<td>" + prop.GetValue(c, null) + "</td>";
                                }
                                html += "</tr>";
                                t++;
                            }
                        }
                        else
                        {
                            int colspan_ = typeof(WSGestioneChiamate.ChiamataSOo).GetProperties().Length + 1;
                            string m_ = "No Data stored!";
                            html += "<tr>";
                            html += "<td colspan=\"" + colspan_ + "\">" + m_ + "</td>";
                        }
                        html += "</tbody>";
                        html += "</table>";

                        TableContainer.InnerHtml = html;

                    }                    
                }
                else
                {
                    TableContainer.InnerHtml = "Error!";
                }
                
            }
        }
    }
}