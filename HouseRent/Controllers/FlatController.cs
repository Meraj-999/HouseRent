using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseRent.Controllers
{
    public class FlatController : Controller
    {
        // GET: Flat
        public ActionResult Index()
        {
            return View();
        }
    }
}