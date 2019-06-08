namespace MASGlobal.Employees.Domain.Entities
{
    public class Employee
    {
        public Employee(int employeeId, string employeeName, EmployeeRole employeeRole,
            EmployeeContractType employeeContractType, double hourlySalary, double monthlySalary)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            EmployeeContractType = employeeContractType;
            EmployeeRole = employeeRole;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }

        public int EmployeeId { get; }

        public string EmployeeName { get; }

        public EmployeeContractType EmployeeContractType { get; }

        public EmployeeRole EmployeeRole { get; }

        public double HourlySalary { get; }

        public double MonthlySalary { get; }
    }
}