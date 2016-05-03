using Step_MVC.Models;
using Step_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Step_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            DataStoreContext _myEmployeeContext = new DataStoreContext();

            //LINQ to bring in Department Table
            List<Employee> employee = _myEmployeeContext.Employee.OrderBy(a => a.Name).ToList();

            EmployeeDetailsViewModel employeeDetails = new EmployeeDetailsViewModel
            {
                Employees = employee
            };

            
            return View(employeeDetails);
        }
    }
}