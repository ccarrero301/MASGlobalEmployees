using System.Collections.Generic;
using MASGlobal.Employees.Shared.DTOs.Services;

namespace MASGlobal.Employees.WebApp.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}