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
            var employeeDetails = (from emp in _myEmployeeContext.Employee
                                   join dept in _myEmployeeContext.Department
                                   on emp.DepartmentId equals dept.DepartmentId
                                   orderby dept.DepartmentName
                                   select new EmployeeDetailsViewModel
                                   {
                                       Name = emp.Name,
                                       DepartmentName = dept.DepartmentName
                                   }).ToList();


            EmployeeDepartmentDetailsViewModel employeeDepartmentDetails = new EmployeeDepartmentDetailsViewModel
            {
                Employees = employeeDetails
            };
            return View(employeeDepartmentDetails);
        }
    }
}