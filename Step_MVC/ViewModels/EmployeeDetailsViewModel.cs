using Step_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Step_MVC.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int EmployeeId { get; set; }
        public String Name { get; set; }
        public String DepartmentName { get; set; }
        public int DepartmentId { get; set; }

        //public List<Employee> Employees { get; set; }
    }
}