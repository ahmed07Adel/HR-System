using HR.Models;
using HR.ViewModel;
using System;
using System.Activities.Debugger;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            HREntities context = new HREntities();
            model.Neighbor = context.Neighborhoods.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Gov = context.Governorates.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Careers = context.CareerFields.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.CompanyJobs = context.CompanyJobs.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            return View("CreateEmployee", model);
        }
        [HttpPost]
        public ActionResult CreateEmployee(CreateEmployeeViewModel model)
        {
            HREntities context = new HREntities();
            if (ModelState.IsValid)
            {

                Employee employee = new Employee
                {
                    ID = model.Employee.ID,
                    Name = model.Employee.Name,
                    BirthGovernorateId = model.Employee.BirthGovernorateId,
                    BirthNeighborhoodId = model.Employee.BirthNeighborhoodId,
                    CareerFieldId = model.Employee.CareerFieldId,
                    Address = model.Employee.Address,
                    CompanyJobId = model.Employee.CompanyJobId,
                };
                model.Employee = context.Employees.Add(employee);
                context.SaveChanges();

            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public ActionResult EditEmployee(EditEmployeeViewModel model)
        {
            HREntities context = new HREntities();

            if (ModelState.IsValid)
            {
                Employee employee = context.Employees.FirstOrDefault(x=>x.ID == model.ID);
                employee.Name = model.Employee.Name;
                employee.BirthGovernorateId = model.Employee.BirthGovernorateId;
                employee.BirthNeighborhoodId = model.Employee.BirthNeighborhoodId;
                employee.CareerFieldId = model.Employee.CareerFieldId;
                employee.CompanyJobId = model.Employee.CompanyJobId;
                employee.Address = model.Employee.Address;

                
                context.Employees.Attach(employee);
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View("Index");
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            HREntities context = new HREntities();
            model.Neighbor = context.Neighborhoods.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Gov = context.Governorates.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Careers = context.CareerFields.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.CompanyJobs = context.CompanyJobs.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();

            model.Employee = context.Employees.FirstOrDefault(x => x.ID == id);
 
            return View("EditEmployee", model);
        }

    }
}