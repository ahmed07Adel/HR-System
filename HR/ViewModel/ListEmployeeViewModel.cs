using HR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.ViewModel
{
    public class ListEmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Governorate> gov { get; set; }
        public IEnumerable<Neighborhood> Neighborhoods { get; set; }
        public IEnumerable<CareerField> Careers { get; set; }
        public IEnumerable<CompanyJob> Jobs { get; set; }
    }
}