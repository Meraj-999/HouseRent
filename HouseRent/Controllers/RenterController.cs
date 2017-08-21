using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HouseRent.Reports.crystal_models;
using Newtonsoft.Json;

namespace HouseRent.Controllers
{
    public class RenterController : Controller
    {
        // GET: Renter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(long renterId)
        {
            ViewBag.renterId = renterId;
            return View();
        }

        public void GetRenterDetailsReportById(long renterId)
        {
            //string httpGetway = "http://localhost:64892/";
            string httpGetway = "http://localhost:8070";

            WebClient wbClient = new WebClient();
            string downloadString = httpGetway + "/api/RenterApi/GetRenterDetailsReportById?renterId=" + renterId;
            string apidata = wbClient.DownloadString(downloadString);
            List<RenterReportClientModel> oDeliAndDis = JsonConvert.DeserializeObject<List<RenterReportClientModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/renterDetailsReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
    }
}