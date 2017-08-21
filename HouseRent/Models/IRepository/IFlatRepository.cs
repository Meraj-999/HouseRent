using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Models.IRepository
{
    public interface IFlatRepository
    {
        List<Flat> GetAllFlats();
        bool InsertFlat(Flat oFlat);
        bool UpdateFlat(Flat oFlat);
        bool DeleteFlat(long flatId);
        bool CheckDuplicateFlat(string flatName);
    }
}
