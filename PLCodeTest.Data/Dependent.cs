//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLCodeTest.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dependent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BenefitCostPerYear { get; set; }
        public System.DateTime DOB { get; set; }
        public string SSN { get; set; }
        public int Emp_Id { get; set; }
        public Nullable<decimal> PerPayPeriodDeduction { get; set; }
        public bool GetsDiscount { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
