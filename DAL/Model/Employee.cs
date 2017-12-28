//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeePromotions = new HashSet<EmployeePromotion>();
            this.Territories = new HashSet<Territory>();
        }
    
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<int> Quota { get; set; }
        public string District { get; set; }
        public Nullable<bool> ManagementFlag { get; set; }
        public Nullable<int> SpanOfControl { get; set; }
        public Nullable<int> ManagementLevelIndicator { get; set; }
        public Nullable<int> CreditScore { get; set; }
        public Nullable<int> CorporateRiskScore { get; set; }
        public string SSN { get; set; }
    
        public virtual ICollection<EmployeePromotion> EmployeePromotions { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
