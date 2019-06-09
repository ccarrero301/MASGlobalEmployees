using System.Collections.Generic;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;

namespace MASGlobal.Employees.WebApp.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public IEnumerable<ServiceEmployeeDto> Employees { get; set; }
    }
}