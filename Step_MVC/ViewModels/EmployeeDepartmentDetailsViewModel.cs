using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Step_MVC.ViewModels
{
    public class EmployeeDepartmentDetailsViewModel
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public List<EmployeeDetailsViewModel> Employees { get; set; }

    }
}