namespace MASGlobal.Employees.Domain.Entities
{
    public class Employee
    {
        public Employee(int employeeId, string employeeName, EmployeeRole employeeRole, EmployeeContractType employeeContractType)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            EmployeeContractType = employeeContractType;
            EmployeeRole = employeeRole;
        }

        public int EmployeeId { get; }
        public string EmployeeName { get; }
        public EmployeeContractType EmployeeContractType { get;}
        public EmployeeRole EmployeeRole { get; }
    }
}