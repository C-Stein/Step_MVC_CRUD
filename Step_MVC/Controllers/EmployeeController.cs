using Step_MVC.Models;
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
            var query = from c in _myEmployeeContext.Employee

                        select c;

            return View(query.ToList());
        }
    }
}