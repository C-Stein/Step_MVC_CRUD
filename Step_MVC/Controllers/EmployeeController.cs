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
                                       EmployeeId = emp.EmployeeId,
                                       DepartmentName = dept.DepartmentName
                                   }).ToList();


            EmployeeDepartmentDetailsViewModel employeeDepartmentDetails = new EmployeeDepartmentDetailsViewModel
            {
                Employees = employeeDetails
            };
            return View(employeeDepartmentDetails);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeDetailsViewModel employeeDetails)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                if(ModelState.IsValid)
                {
                    Employee employee = new Employee
                    {
                        Name = employeeDetails.Name,
                        DepartmentId = employeeDetails.DepartmentId
                    };
                    _context.Employee.Add(employee);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(employeeDetails);
            }
        }
        //GET
        public ActionResult Edit (int employeeId)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                var employeeDetails = (from emp in _context.Employee
                                       where emp.EmployeeId == employeeId
                                       select new EmployeeDetailsViewModel
                                       {
                                           Name = emp.Name,
                                           EmployeeId = emp.EmployeeId
                                       }).ToList();

                EmployeeDepartmentDetailsViewModel employeeModel = new EmployeeDepartmentDetailsViewModel
                {
                    Name = employeeDetails.Select(a => a.Name).FirstOrDefault(),
                };
                return View(employeeModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDepartmentDetailsViewModel employeeDetails)
        {
            using (DataStoreContext _context = new DataStoreContext())
            {
                var employee = _context.Employee.Find(employeeDetails.EmployeeId);
                var department = _context.Department;
                if (ModelState.IsValid)
                {
                    employee.Name = employeeDetails.Name;
                    //employee.DepartmentName = employeeDetails.DepartmentName;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(employeeDetails);
            }
        }

        public ActionResult Delete(int employeeId)
        {
            if (employeeId != 0)
            {
                using (DataStoreContext _context = new DataStoreContext())
                {
                    Employee employee = _context.Employee.Find(employeeId);

                    _context.Employee.Remove(employee);
                    _context.SaveChanges();

                }
            }
            else
            {
                ViewBag.Title = "There was a problem";
            }
            return RedirectToAction("Index");
        }
    }
}