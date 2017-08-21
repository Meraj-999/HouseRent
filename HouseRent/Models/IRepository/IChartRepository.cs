using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Models.IRepository
{
    public interface IChartRepository
    {
        object GetTotalBillChart(DateTime fromDate,DateTime toDate);
        object GetBillStatusChartByFlatId(DateTime fromDate, DateTime toDate,long flatId);
    }
}
