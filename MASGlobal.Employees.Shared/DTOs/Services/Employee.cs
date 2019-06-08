namespace MASGlobal.Employees.Shared.DTOs.Services
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeContractType { get; set; }

        public int EmployeeRoleId { get; set; }

        public string EmployeeRoleName { get; set; }

        public string EmployeeRoleDescription { get; set; }

        public double EmployeeHourlySalary { get; set; }

        public double EmployeeMonthlySalary { get; set; }

        public double AnnualSalary { get; set; }
    }
}