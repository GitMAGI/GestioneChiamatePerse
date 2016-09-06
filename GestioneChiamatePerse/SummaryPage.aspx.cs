using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCPData;

namespace GestioneChiamatePerse
{
    public partial class SummaryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChiamataDTO[] data = (ChiamataDTO[])GCPData.GCPBLL.GetChiamate();

            string html = "";

            html += "<table class=\"table table-condensed table-sm\" style=\"font-size:10px;\">";
            html += "<thead>";
            html += "<tr>";
            html += "<th>#</th>";
            foreach (var prop in typeof(ChiamataDTO).GetProperties())
            {
                html += "<th>" + prop.Name + "</th>";
            }
            html += "</tr>";
            html += "</thead>";

            html += "<tbody>";
            int t = 1;

            if (data != null)
            {
                foreach (ChiamataDTO c in data)
                {
                    html += "<tr>";
                    html += "<td>" + t + "</td>";
                    foreach (var prop in c.GetType().GetProperties())
                    {
                        html += "<td>" + prop.GetValue(c, null) + "</td>";
                    }
                    html += "</tr>";
                    t++;
                }
            }
            else
            {
                int colspan_ = typeof(ChiamataDTO).GetProperties().Length + 1;
                string m_ = "No Data stored!";
                html += "<tr>";
                html += "<td colspan=\"" + colspan_ + "\">" + m_ + "</td>";
            }
            html += "</tbody>";
            html += "</table>";

            TableContainer.InnerHtml = html;
            
        }
    }
}