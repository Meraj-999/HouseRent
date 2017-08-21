using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseRent.Models.IRepository;
using HouseRent.Models.Repository;

namespace HouseRent.Controllers
{
    public class ChartApiController : ApiController
    {
        private IChartRepository chartRepository;

        public ChartApiController()
        {
            this.chartRepository = new ChartRepository();
        }

        public ChartApiController(IChartRepository chartRepository)
        {
            this.chartRepository = chartRepository;
        }

        [HttpGet]
        [ActionName("GetTotalBillChart")]
        public HttpResponseMessage GetTotalBillChart(DateTime fromDate, DateTime toDate)
        {
            var data = chartRepository.GetTotalBillChart(fromDate,toDate);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [ActionName("GetBillStatusChartByFlatId")]
        public HttpResponseMessage GetBillStatusChartByFlatId(DateTime fromDate, DateTime toDate, long flatId)
        {
            var data = chartRepository.GetBillStatusChartByFlatId(fromDate, toDate, flatId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
