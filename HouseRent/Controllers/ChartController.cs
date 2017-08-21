using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseRent.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult TotalBillChart()
        {
            return View();
        }

        public ActionResult BillStatusChart()
        {
            return View();
        }
    }
}