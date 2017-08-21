using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using DMSApi.Models;
using HouseRent.Models;
using HouseRent.Models.IRepository;
using HouseRent.Models.Repository;

namespace HouseRent.Controllers
{
    public class RenterApiController : ApiController
    {
        private IRenterRepository renterRepository;

        public RenterApiController()
        {
            this.renterRepository = new RenterRepository();
        }

        public RenterApiController(IRenterRepository renterRepository)
        {
            this.renterRepository = renterRepository;
        }

        [HttpGet]
        [ActionName("GetAllRenters")]
        public HttpResponseMessage GetAllRenters()
        {
            var data = renterRepository.GetAllRenters();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [ActionName("GetRenterDetailsReportById")]
        public object GetRenterDetailsReportById(long renterId)
        {
            var data = renterRepository.GetRenterDetailsReportById(renterId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [ActionName("GetRenterById")]
        public HttpResponseMessage GetRenterById(long renterId)
        {
            var data = renterRepository.GetRenterById(renterId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Models.Renter oRenter)
        {
            try
            {
                if (string.IsNullOrEmpty(oRenter.RenterName))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Renter Name is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.MaritalStatus))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Marital Status !!" });
                }
                if (string.IsNullOrEmpty(oRenter.MobileNo))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Mobile No is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.FlatId.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Flat !!" });
                }
                if (string.IsNullOrEmpty(oRenter.NidNo))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Nid No is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.RentDate.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Rent Date is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.AdvancedPaymet.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Advanced Paymet is empty !!" });
                }
                else
                {
                    Renter newRenter = new Renter
                    {
                        RenterName = oRenter.RenterName,
                        FatherName = oRenter.FatherName,
                        DateOfBirth = oRenter.DateOfBirth,
                        MaritalStatus = oRenter.MaritalStatus,
                        PermanentAddress = oRenter.PermanentAddress,
                        FlatId = oRenter.FlatId,
                        Occupation = oRenter.Occupation,
                        Religion = oRenter.Religion,
                        AcademicQualification = oRenter.AcademicQualification,
                        MobileNo = oRenter.MobileNo,
                        NidNo = oRenter.NidNo,
                        RentDate = oRenter.RentDate,
                        AdvancedPaymet = oRenter.AdvancedPaymet,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true

                    };
                    bool saveRenter = renterRepository.InsertRenter(newRenter);

                    if (saveRenter)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Renter save successfully", returnvalue = true });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "errot", msg = "Selected Flat already have an active renter please inactive or delete that renter first !!" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Models.Renter oRenter)
        {
            try
            {
                if (string.IsNullOrEmpty(oRenter.RenterName))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Renter Name is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.MaritalStatus))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Marital Status !!" });
                }
                if (string.IsNullOrEmpty(oRenter.MobileNo))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Mobile No is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.FlatId.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Flat !!" });
                }
                if (string.IsNullOrEmpty(oRenter.NidNo))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Nid No is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.RentDate.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Rent Date is empty !!" });
                }
                if (string.IsNullOrEmpty(oRenter.AdvancedPaymet.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Advanced Paymet is empty !!" });
                }
                else
                {
                    Renter newRenter = new Renter
                    {
                        RenterId = oRenter.RenterId,
                        RenterName = oRenter.RenterName,
                        FatherName = oRenter.FatherName,
                        DateOfBirth = oRenter.DateOfBirth,
                        MaritalStatus = oRenter.MaritalStatus,
                        PermanentAddress = oRenter.PermanentAddress,
                        FlatId = oRenter.FlatId,
                        Occupation = oRenter.Occupation,
                        Religion = oRenter.Religion,
                        AcademicQualification = oRenter.AcademicQualification,
                        MobileNo = oRenter.MobileNo,
                        NidNo = oRenter.NidNo,
                        RentDate = oRenter.RentDate,
                        AdvancedPaymet = oRenter.AdvancedPaymet,
                        UpdatedDate = DateTime.Now,
                        IsActive = oRenter.IsActive

                    };

                    bool updateRenter = renterRepository.UpdateRenter(newRenter);

                    if (updateRenter)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Renter Update successfully", returnvalue = true });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "errot", msg = "Selected Flat already have an active renter please inactive or delete that renter first !!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Models.Renter oRenter)
        {
            try
            {
                var deleteRenter = renterRepository.DeleteRenter(oRenter.RenterId);

                if (deleteRenter)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Renter Delete successfully", returnvalue = true });

                }
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Renter Delete Failed !!", returnvalue = false });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }
    }
}
