using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseRent.Models.IRepository;

namespace HouseRent.Models.Repository
{
    public class FlatRepository : IFlatRepository
    {
        private HouseRentDBEntities _entities;

        public FlatRepository()
        {
            this._entities = new HouseRentDBEntities();
        }

        public List<Flat> GetAllFlats()
        {
            List<Flat> data = _entities.Flats.Where(f => f.IsActive == true).OrderByDescending(f => f.FlatId).ToList();
            return data;
        }

        public bool InsertFlat(Flat oFlat)
        {
            try
            {
                Flat newFlat = new Flat
                {
                    FlatName = oFlat.FlatName,
                    FlatDescription = oFlat.FlatDescription,
                    FloorName = oFlat.FloorName,
                    CreatedDate = oFlat.CreatedDate,
                    UpdatedDate = oFlat.UpdatedDate,
                    IsActive = oFlat.IsActive
                };
                _entities.Flats.Add(newFlat);
                _entities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFlat(Flat oFlat)
        {
            try
            {
                Flat data = _entities.Flats.Find(oFlat.FlatId);
                data.FlatName = oFlat.FlatName;
                data.FlatDescription = oFlat.FlatDescription;
                data.FloorName = oFlat.FloorName;
                data.UpdatedDate = oFlat.UpdatedDate;

                _entities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFlat(long flatId)
        {
            try
            {
                Flat oFlat = _entities.Flats.Find(flatId);
                oFlat.IsActive = false;

                _entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckDuplicateFlat(string flatName)
        {
            var checkDuplicateBrands = _entities.Flats.FirstOrDefault(f => f.FlatName== flatName && f.IsActive==true);
            bool returnType = checkDuplicateBrands != null;
            return returnType;
        }
    }
}