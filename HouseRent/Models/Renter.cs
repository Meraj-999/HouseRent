//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HouseRent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Renter
    {
        public long RenterId { get; set; }
        public Nullable<long> FlatId { get; set; }
        public string RenterName { get; set; }
        public string FatherName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string PermanentAddress { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string AcademicQualification { get; set; }
        public string MobileNo { get; set; }
        public string NidNo { get; set; }
        public Nullable<System.DateTime> RentDate { get; set; }
        public Nullable<decimal> AdvancedPaymet { get; set; }
        public string ImagePath { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
