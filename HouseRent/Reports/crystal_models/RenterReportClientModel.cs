using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseRent.Reports.crystal_models
{
    public class RenterReportClientModel
    {
        public long RenterId { get; set; }
        public long FlatId { get; set; }
        public string FlatName { get; set; }
        public string RenterName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string PermanentAddress { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string AcademicQualification { get; set; }
        public string MobileNo { get; set; }
        public string NidNo { get; set; }
        public DateTime RentDate { get; set; }
        public decimal AdvancedPaymet { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}