namespace MASGlobal.Employees.Domain
{
    public sealed class Employee
    {
        public Employee(int employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

        public int EmployeeId { get; }
        public string EmployeeName { get; }
    }
}