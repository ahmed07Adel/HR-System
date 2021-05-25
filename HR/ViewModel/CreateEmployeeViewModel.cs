using HR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.ViewModel
{
    public class CreateEmployeeViewModel
    {
        public IEnumerable<SelectListItem> Gov { get; set; }
        public IEnumerable<SelectListItem> Neighbor { get; set; }
        public IEnumerable<SelectListItem> Careers { get; set; }
        public IEnumerable<SelectListItem> CompanyJobs { get; set; }

        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }

        public Employee Employee { get; set; }
    }
}