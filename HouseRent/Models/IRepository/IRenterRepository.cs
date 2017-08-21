using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Models.IRepository
{
    public interface IRenterRepository
    {
        object GetAllRenters();
        object GetRenterDetailsReportById(long renterId);
        Renter GetRenterById(long renterId);
        bool InsertRenter(Renter oRenter);
        bool UpdateRenter(Renter oRenter);
        bool DeleteRenter(long renterId);
    }
}
