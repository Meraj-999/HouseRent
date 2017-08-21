using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseRent.Models.IRepository;

namespace HouseRent.Models.Repository
{
    public class ChartRepository : IChartRepository
    {
        private HouseRentDBEntities _entities;

        public ChartRepository()
        {
            this._entities = new HouseRentDBEntities();
        }

        public object GetTotalBillChart(DateTime fromDate, DateTime toDate)
        {
            DateTime perfectToDate = toDate.AddDays(1);
            string query = "select mb.MonthOfBill,SUM(mb.HouseRent)+SUM(mb.ElectricityBill) +SUM(mb.GasBill)+SUM(mb.WaterBill)+SUM(mb.ServiceCharge)+SUM(mb.OthersBill) as TotalAmount, SUM(mb.HouseRent) as TotalHouseRent,SUM(mb.ElectricityBill) as TotalElectricityBill,SUM(mb.GasBill) as TotalGasBill, SUM(mb.WaterBill) as TotalWaterBill,SUM(mb.ServiceCharge) as TotalServiceCharge,SUM(mb.OthersBill) as TotalOthersBill from MonthlyBill mb LEFT JOIN Renter r ON mb.RenterId = r.RenterId LEFT JOIN Flat f ON r.FlatId = f.FlatId where mb.CreatedDate between '" + fromDate + "' and '" + perfectToDate + "' GROUP BY mb.MonthOfBill ORDER BY CONVERT (DATETIME, '01 ' + mb.MonthOfBill, 104)";
            var data = _entities.Database.SqlQuery<TotalBill>(query).ToList();
            return data;
        }

        public object GetBillStatusChartByFlatId(DateTime fromDate, DateTime toDate, long flatId)
        {
            DateTime perfectToDate = toDate.AddDays(1);
            string query = "select f.FlatName,r.RenterName,mb.MonthOfBill,mb.HouseRent,mb.ElectricityBill,mb.UnitUsed, mb.GasBill,mb.WaterBill,mb.ServiceCharge,mb.OthersBill, mb.HouseRent+mb.ElectricityBill+mb.GasBill+mb.WaterBill+mb.ServiceCharge+mb.OthersBill as Amount from MonthlyBill mb LEFT JOIN Renter r ON mb.RenterId = r.RenterId LEFT JOIN Flat f ON r.FlatId = f.FlatId where mb.CreatedDate between '"+fromDate+"' and '"+perfectToDate+"' and f.FlatId='"+flatId+"' ORDER BY CONVERT (DATETIME, '01 ' + mb.MonthOfBill, 104)";
            var data = _entities.Database.SqlQuery<BillStatus>(query).ToList();
            return data;
        }

        public class TotalBill
        {
            public string MonthOfBill { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal TotalHouseRent { get; set; }
            public decimal TotalElectricityBill { get; set; }
            public decimal TotalGasBill { get; set; }
            public decimal TotalWaterBill { get; set; }
            public decimal ServiceCharge { get; set; }
            public decimal OthersBill { get; set; }
        }

        public class BillStatus
        {
            public string MonthOfBill { get; set; }
            public decimal Amount { get; set; }
            public decimal HouseRent { get; set; }
            public decimal ElectricityBill { get; set; }
            public decimal UnitUsed { get; set; }
            public decimal GasBill { get; set; }
            public decimal WaterBill { get; set; }
            public decimal ServiceCharge { get; set; }
            public decimal OthersBill { get; set; }
        }
    }
}