using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using Data.Models;

namespace GUI.Chart
{
    public partial class Chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetChartData()
        {
            List<t_flightmatching> data = new List<t_flightmatching>();
            //Here MyDatabaseEntities  is our dbContext
          //  medtravdbContext db = new medtravdbContext();
            using (medtravdbContext dc = new medtravdbContext())
            {
                data = dc.t_flightmatching.ToList();
            }

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                    "Airline",
                    "Number of sits"
                };
            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.airline, i.numberOfSits };
            }

            return chartData;
        }

    }
}