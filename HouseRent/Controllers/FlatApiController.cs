using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMSApi.Models;
using HouseRent.Models;
using HouseRent.Models.IRepository;
using HouseRent.Models.Repository;

namespace HouseRent.Controllers
{
    public class FlatApiController : ApiController
    {
        private IFlatRepository flatRepository;

        public FlatApiController()
        {
            this.flatRepository = new FlatRepository();
        }

        public FlatApiController(IFlatRepository flatRepository)
        {
            this.flatRepository = flatRepository;
        }

        public HttpResponseMessage GetAllFlats()
        {
            var data = flatRepository.GetAllFlats();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Models.Flat oFlat)
        {
            try
            {
                if (flatRepository.CheckDuplicateFlat(oFlat.FlatName))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Flat Already Exists" });
                }
                else
                {
                    Flat insertFlat = new Flat
                    {
                        FlatName = oFlat.FlatName,
                        FlatDescription = oFlat.FlatDescription,
                        FloorName = oFlat.FloorName,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true
                    };
                    bool saveFlat = flatRepository.InsertFlat(insertFlat);
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Flat save successfully", returnvalue = saveFlat });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [System.Web.Http.HttpPut]
        public HttpResponseMessage Put([FromBody] Models.Flat oFlat)
        {
            try
            {
                Flat updateFlat = new Flat
                {
                    FlatId = oFlat.FlatId,
                    FlatName = oFlat.FlatName,
                    FlatDescription = oFlat.FlatDescription,
                    FloorName = oFlat.FloorName,
                    UpdatedDate = DateTime.Now
                };

                flatRepository.UpdateFlat(updateFlat);
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Flat update successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete([FromBody]Models.Flat oFlat)
        {
            try
            {
                bool deleteFlat = flatRepository.DeleteFlat(oFlat.FlatId);
                
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Flat Delete Successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }

        }
    }
}
