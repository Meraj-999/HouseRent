using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseRent.Models.CrystalApiModels;
using HouseRent.Models.IRepository;

namespace HouseRent.Models.Repository
{
    public class RenterRepository : IRenterRepository
    {
        private HouseRentDBEntities _entities;

        public RenterRepository()
        {
            this._entities = new HouseRentDBEntities();
        }

        public object GetAllRenters()
        {
            var data = (from rnt in _entities.Renters
                            join flt in _entities.Flats on rnt.FlatId equals flt.FlatId
                            select new
                            {
                                RenterId = rnt.RenterId,
                                RenterName = rnt.RenterName,
                                RenterFlat= flt.FlatName+"-"+ rnt.RenterName,
                                FatherName = rnt.FatherName,
                                DateOfBirth = rnt.DateOfBirth,
                                MaritalStatus = rnt.MaritalStatus,
                                PermanentAddress = rnt.PermanentAddress,
                                FlatId = flt.FlatId,
                                FlatName = flt.FlatName,
                                Occupation = rnt.Occupation,
                                Religion = rnt.Religion,
                                AcademicQualification = rnt.AcademicQualification,
                                MobileNo = rnt.MobileNo,
                                NidNo = rnt.NidNo,
                                RentDate = rnt.RentDate,
                                AdvancedPaymet = rnt.AdvancedPaymet,
                                CreatedDate = rnt.CreatedDate,
                                UpdatedDate = rnt.UpdatedDate,
                                IsActive = rnt.IsActive
                            }).Where(r => r.IsActive == true).OrderBy(r => r.FlatId).ToList();

            return data;
        }

        public object GetRenterDetailsReportById(long renterId)
        {
            try
            {
                string query = "select r.RenterId,r.RenterName,r.FatherName,r.DateOfBirth,r.MaritalStatus,r.PermanentAddress,r.Occupation, r.Religion,r.AcademicQualification,r.MobileNo,r.NidNo,r.RentDate,r.AdvancedPaymet,r.CreatedDate, r.UpdatedDate,r.IsActive,f.FlatId,f.FlatName from Renter r inner join Flat f on r.FlatId =f.FlatId where RenterId='" + renterId + "'";

                var data = _entities.Database.SqlQuery<RenterReportApiModel>(query).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Renter GetRenterById(long renterId)
        {
            var data = _entities.Renters.Find(renterId);
            return data;
        }

        public bool InsertRenter(Renter oRenter)
        {
            try
            {
                var flatId = oRenter.FlatId;
                var xxx = _entities.Renters.FirstOrDefault(r => r.FlatId == flatId && r.IsActive == true);

                if (xxx != null)
                {
                    return false;
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
                        CreatedDate = oRenter.CreatedDate,
                        UpdatedDate = oRenter.UpdatedDate,
                        IsActive = oRenter.IsActive

                    };
                    _entities.Renters.Add(newRenter);
                    _entities.SaveChanges();
                    long lastInsertId = newRenter.RenterId;

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRenter(Renter oRenter)
        {
            try
            {
                var flatId = oRenter.FlatId;
                var renterId = oRenter.RenterId;
                var xxx = _entities.Renters.FirstOrDefault(r => r.FlatId == flatId && r.RenterId != renterId && r.IsActive == true);

                if (xxx != null)
                {
                    return false;
                }
                else
                {
                    var renter = _entities.Renters.Find(renterId);

                    renter.RenterName = oRenter.RenterName;
                    renter.FatherName = oRenter.FatherName;
                    renter.DateOfBirth = oRenter.DateOfBirth;
                    renter.MaritalStatus = oRenter.MaritalStatus;
                    renter.PermanentAddress = oRenter.PermanentAddress;
                    renter.FlatId = oRenter.FlatId;
                    renter.Occupation = oRenter.Occupation;
                    renter.Religion = oRenter.Religion;
                    renter.AcademicQualification = oRenter.AcademicQualification;
                    renter.MobileNo = oRenter.MobileNo;
                    renter.NidNo = oRenter.NidNo;
                    renter.RentDate = oRenter.RentDate;
                    renter.AdvancedPaymet = oRenter.AdvancedPaymet;
                    renter.UpdatedDate = oRenter.UpdatedDate;
                    renter.IsActive = oRenter.IsActive;
                    _entities.SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRenter(long renterId)
        {
            try
            {
                var deleteRenter = _entities.Renters.Find(renterId);

                deleteRenter.IsActive = false;
                deleteRenter.UpdatedDate = DateTime.Now;
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