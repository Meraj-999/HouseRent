using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseRent.Models.CrystalApiModels;
using HouseRent.Models.IRepository;

namespace HouseRent.Models.Repository
{
    public class MonthlyBillRepository : IMonthlyBillRepository
    {
        private HouseRentDBEntities _entities;

        public MonthlyBillRepository()
        {
            this._entities = new HouseRentDBEntities();
        }

        public object GetAllMonthlyBills()
        {
            var data = (from mb in _entities.MonthlyBills
                        join rnt in _entities.Renters on mb.RenterId equals rnt.RenterId
                        join flt in _entities.Flats on rnt.FlatId equals flt.FlatId
                        select new
                        {
                            MonthlyBillId = mb.MonthlyBillId,
                            RenterId = rnt.RenterId,
                            RenterName = rnt.RenterName,
                            FlatId = flt.FlatId,
                            FlatName = flt.FlatName,
                            MonthOfBill = mb.MonthOfBill,
                            HouseRent = mb.HouseRent,
                            CurrentMonthUnit = mb.CurrentMonthUnit,
                            PreviousMonthUnit = mb.PreviousMonthUnit,
                            UnitUsed = mb.UnitUsed,
                            BillPerUnit = mb.BillPerUnit,
                            ElectricityBill = mb.ElectricityBill,
                            GasBill = mb.GasBill,
                            WaterBill = mb.WaterBill,
                            ServiceCharge = mb.ServiceCharge,
                            OthersBill = mb.OthersBill,
                            PaymentStatus = mb.PaymentStatus,
                            Remarks = mb.Remarks,
                            CreatedDate = mb.CreatedDate,
                            UpdatedDate = mb.UpdatedDate,
                            IsActive = mb.IsActive
                        }).Where(r => r.IsActive == true).OrderByDescending(r => r.MonthlyBillId).ToList();

            return data;
        }

        public object GetMonthlyBillReportById(long monthlyBillId)
        {
            try
            {
                string query = "select mb.MonthlyBillId,rt.RenterId,rt.RenterName,f.FlatId,f.FlatName,rt.NidNo,rt.MobileNo, mb.MonthOfBill,mb.HouseRent,mb.CurrentMonthUnit,mb.PreviousMonthUnit,mb.UnitUsed,mb.BillPerUnit, mb.ElectricityBill,mb.GasBill,mb.WaterBill,mb.ServiceCharge,mb.OthersBill,mb.PaymentStatus, mb.Remarks,mb.CreatedDate,mb.UpdatedDate,mb.IsActive from MonthlyBill mb inner join Renter rt on mb.RenterId=rt.RenterId inner join Flat f on rt.FlatId = f.FlatId where mb.MonthlyBillId='"+monthlyBillId+"'";

                var data = _entities.Database.SqlQuery<MonthlyBillReportApiModel>(query).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public MonthlyBill GetMonthlyBillById(long monthlyBillId)
        {
            var data = _entities.MonthlyBills.Find(monthlyBillId);
            return data;
        }

        public bool InsertMonthlyBill(MonthlyBill oMonthlyBill)
        {
            try
            {
                var renterId = oMonthlyBill.RenterId;
                var monthOfBill = oMonthlyBill.MonthOfBill;

                var xxx = _entities.MonthlyBills.FirstOrDefault(m => m.RenterId == renterId && m.MonthOfBill == monthOfBill && m.IsActive == true);

                if (xxx != null)
                {
                    return false;
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
                        PaymentStatus = oMonthlyBill.PaymentStatus,
                        Remarks = oMonthlyBill.Remarks,
                        CreatedDate = oMonthlyBill.CreatedDate,
                        IsActive = oMonthlyBill.IsActive,
                        UpdatedDate = oMonthlyBill.UpdatedDate

                    };
                    _entities.MonthlyBills.Add(newMonthlyBill);
                    _entities.SaveChanges();
                    long lastInsertId = newMonthlyBill.MonthlyBillId;

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMonthlyBill(MonthlyBill oMonthlyBill)
        {
            try
            {

                var monthlyBill = _entities.MonthlyBills.Find(oMonthlyBill.MonthlyBillId);

                monthlyBill.RenterId = oMonthlyBill.RenterId;
                monthlyBill.MonthOfBill = oMonthlyBill.MonthOfBill;
                monthlyBill.HouseRent = oMonthlyBill.HouseRent;
                monthlyBill.CurrentMonthUnit = oMonthlyBill.CurrentMonthUnit;
                monthlyBill.PreviousMonthUnit = oMonthlyBill.PreviousMonthUnit;
                monthlyBill.UnitUsed = oMonthlyBill.UnitUsed;
                monthlyBill.BillPerUnit = oMonthlyBill.BillPerUnit;
                monthlyBill.ElectricityBill = oMonthlyBill.ElectricityBill;
                monthlyBill.GasBill = oMonthlyBill.GasBill;
                monthlyBill.WaterBill = oMonthlyBill.WaterBill;
                monthlyBill.ServiceCharge = oMonthlyBill.ServiceCharge;
                monthlyBill.OthersBill = oMonthlyBill.OthersBill;
                monthlyBill.PaymentStatus = oMonthlyBill.PaymentStatus;
                monthlyBill.Remarks = oMonthlyBill.Remarks;
                monthlyBill.UpdatedDate = oMonthlyBill.UpdatedDate;

                _entities.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMonthlyBill(long monthlyBillId)
        {
            try
            {
                var deleteMonthlyBill = _entities.MonthlyBills.Find(monthlyBillId);

                deleteMonthlyBill.IsActive = false;
                deleteMonthlyBill.UpdatedDate = DateTime.Now;
                _entities.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}