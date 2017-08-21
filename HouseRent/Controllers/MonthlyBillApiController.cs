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
    public class MonthlyBillApiController : ApiController
    {
        private IMonthlyBillRepository monthlyBillRepository;

        public MonthlyBillApiController()
        {
            this.monthlyBillRepository = new MonthlyBillRepository();
        }

        public MonthlyBillApiController(IMonthlyBillRepository monthlyBillRepository)
        {
            this.monthlyBillRepository = monthlyBillRepository;
        }

        [HttpGet]
        [ActionName("GetAllMonthlyBills")]
        public HttpResponseMessage GetAllMonthlyBills()
        {
            var data = monthlyBillRepository.GetAllMonthlyBills();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [ActionName("GetMonthlyBillById")]
        public HttpResponseMessage GetMonthlyBillById(long monthlyBillId)
        {
            var data = monthlyBillRepository.GetMonthlyBillById(monthlyBillId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }

        [HttpGet]
        [ActionName("GetMonthlyBillReportById")]
        public object GetMonthlyBillReportById(long monthlyBillId)
        {
            var data = monthlyBillRepository.GetMonthlyBillReportById(monthlyBillId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Models.MonthlyBill oMonthlyBill)
        {
            try
            {
                if (string.IsNullOrEmpty(oMonthlyBill.RenterId.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Renter !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.MonthOfBill))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Month Of Bill !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.HouseRent.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "House Rent is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.PreviousMonthUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Previous Month Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.CurrentMonthUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Current Month Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.BillPerUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Bill Per Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.GasBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Gas Bill is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.WaterBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Water Bill is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.ServiceCharge.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Service Charge is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.OthersBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Others Bill is empty !!" });
                }
                else
                {
                    MonthlyBill newMonthlyBill = new MonthlyBill
                    {
                        RenterId = oMonthlyBill.RenterId,
                        MonthOfBill = oMonthlyBill.MonthOfBill,
                        HouseRent = oMonthlyBill.HouseRent,
                        CurrentMonthUnit = oMonthlyBill.CurrentMonthUnit,
                        PreviousMonthUnit = oMonthlyBill.PreviousMonthUnit,
                        UnitUsed = oMonthlyBill.UnitUsed,
                        BillPerUnit = oMonthlyBill.BillPerUnit,
                        ElectricityBill = oMonthlyBill.ElectricityBill,
                        GasBill = oMonthlyBill.GasBill,
                        WaterBill = oMonthlyBill.WaterBill,
                        ServiceCharge = oMonthlyBill.ServiceCharge,
                        OthersBill = oMonthlyBill.OthersBill,
                        PaymentStatus = "Due",
                        Remarks = oMonthlyBill.Remarks,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true

                    };
                    bool saveMonthlyBill = monthlyBillRepository.InsertMonthlyBill(newMonthlyBill);

                    if (saveMonthlyBill)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Bill generated successfully", returnvalue = true });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "errot", msg = "Bill already generated for "+ oMonthlyBill.MonthOfBill + "  !!" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Models.MonthlyBill oMonthlyBill)
        {
            try
            {
                if (string.IsNullOrEmpty(oMonthlyBill.RenterId.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Renter !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.MonthOfBill))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Please Select Month Of Bill !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.HouseRent.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "House Rent is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.PreviousMonthUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Previous Month Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.CurrentMonthUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Current Month Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.BillPerUnit.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Bill Per Unit is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.GasBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Gas Bill is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.WaterBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Water Bill is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.ServiceCharge.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Service Charge is empty !!" });
                }
                if (string.IsNullOrEmpty(oMonthlyBill.OthersBill.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Others Bill is empty !!" });
                }
                else
                {
                    
                    MonthlyBill updateMonthlyBill = new MonthlyBill
                    {
                        MonthlyBillId = oMonthlyBill.MonthlyBillId,
                        RenterId = oMonthlyBill.RenterId,
                        MonthOfBill = oMonthlyBill.MonthOfBill,
                        HouseRent = oMonthlyBill.HouseRent,
                        CurrentMonthUnit = oMonthlyBill.CurrentMonthUnit,
                        PreviousMonthUnit = oMonthlyBill.PreviousMonthUnit,
                        UnitUsed = oMonthlyBill.UnitUsed,
                        BillPerUnit = oMonthlyBill.BillPerUnit,
                        ElectricityBill = oMonthlyBill.ElectricityBill,
                        GasBill = oMonthlyBill.GasBill,
                        WaterBill = oMonthlyBill.WaterBill,
                        ServiceCharge = oMonthlyBill.ServiceCharge,
                        OthersBill = oMonthlyBill.OthersBill,
                        PaymentStatus = oMonthlyBill.PaymentStatus,
                        Remarks = oMonthlyBill.Remarks,
                        UpdatedDate = DateTime.Now

                    };
                    bool updateBill = monthlyBillRepository.UpdateMonthlyBill(updateMonthlyBill);

                    if (updateBill)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Bill updated successfully", returnvalue = true });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "errot", msg = "Bill Update Error !!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Models.MonthlyBill oMonthlyBill)
        {
            try
            {
                var deleteMonthlyBill = monthlyBillRepository.DeleteMonthlyBill(oMonthlyBill.MonthlyBillId);

                if (deleteMonthlyBill)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Bill Delete successfully", returnvalue = true });

                }
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Bill Delete Failed !!", returnvalue = false });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = ex.ToString() });
            }
        }
    }
}
