using System.Collections.Generic;
using ServiceEmployeeDto = MASGlobal.Employees.Shared.DTOs.Services.Employee;

namespace MASGlobal.Employees.WebApp.Models
{
    public sealed class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public IEnumerable<ServiceEmployeeDto> Employees { get; set; }

        public string ErrorMessage { get; set; }
    }
}