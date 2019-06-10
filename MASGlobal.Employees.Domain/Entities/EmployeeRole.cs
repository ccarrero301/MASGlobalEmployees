namespace MASGlobal.Employees.Domain.Entities
{
    public sealed class EmployeeRole
    {
        public EmployeeRole(int employeeRoleId, string employeeRoleName, string employeeRoleDescription)
        {
            EmployeeRoleId = employeeRoleId;
            EmployeeRoleName = employeeRoleName;
            EmployeeRoleDescription = employeeRoleDescription;
        }

        public int EmployeeRoleId { get; }

        public string EmployeeRoleName { get; }

        public string EmployeeRoleDescription { get; }
    }
}