using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseRent.Models.CrystalApiModels
{
    public class MonthlyBillReportApiModel
    {
        public long? MonthlyBillId { get; set; }
        public long? RenterId { get; set; }
        public string RenterName { get; set; }
        public long? FlatId { get; set; }
        public string FlatName { get; set; }
        public string FatherName { get; set; }
        public string NidNo { get; set; }
        public string MobileNo { get; set; }
        public string MonthOfBill { get; set; }
        public decimal? HouseRent { get; set; }
        public decimal? CurrentMonthUnit { get; set; }
        public decimal? PreviousMonthUnit { get; set; }
        public decimal? UnitUsed { get; set; }
        public decimal? BillPerUnit { get; set; }
        public decimal? ElectricityBill { get; set; }
        public decimal? GasBill { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? OthersBill { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}