//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EmployeeQualification
    {
        
        public int ID { get; set; }
        public int QualificationId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}