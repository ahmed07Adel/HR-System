using HR.Models;
using HR.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class HomeController : Controller
    {
      
        [Route("Home/Delete/{id?}")]
        public ActionResult Delete(int ID)
        {
            HREntities context = new HREntities();
            Employee employee = context.Employees.Include(a=>a.EmployeeQualifications).FirstOrDefault(x => x.ID == ID);
            if (employee != null)
            {
                context.EmployeeQualifications.RemoveRange(employee.EmployeeQualifications);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            //CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            ListEmployeeViewModel model = new ListEmployeeViewModel();
            List<Employee> e = new List<Employee>();
            HREntities context = new HREntities();
            context.Configuration.ProxyCreationEnabled = false;

            List<Governorate> governorates = new List<Governorate>();
            List<Neighborhood> neighborhoods = new List<Neighborhood>();
            List<CareerField> careerFields = new List<CareerField>();
            List<CompanyJob> jobs = new List<CompanyJob>();
            model.gov = governorates;
            model.Jobs = jobs;
            model.Careers = careerFields;
            model.Neighborhoods = neighborhoods;
            model.Employees = e;

            model.gov = context.Governorates.ToList();
            model.Jobs = context.CompanyJobs.ToList();
            model.Careers = context.CareerFields.ToList();
            model.Neighborhoods = context.Neighborhoods.ToList();
          model.Employees =  context.Employees.ToList();

            return View(model);
        }
        [HttpGet]
        public ViewResult CreateEmployee()
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            HREntities context = new HREntities();
            model.Neighbor = context.Neighborhoods.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Gov = context.Governorates.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.Careers = context.CareerFields.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();
            model.CompanyJobs = context.CompanyJobs.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList();

            return View(model);
        }

    }
}