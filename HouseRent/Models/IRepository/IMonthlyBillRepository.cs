using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Models.IRepository
{
    public interface IMonthlyBillRepository
    {
        object GetAllMonthlyBills();
        object GetMonthlyBillReportById(long monthlyBillId);
        MonthlyBill GetMonthlyBillById(long monthlyBillId);
        bool InsertMonthlyBill(MonthlyBill oMonthlyBill);
        bool UpdateMonthlyBill(MonthlyBill oMonthlyBill);
        bool DeleteMonthlyBill(long monthlyBillId);
    }
}
