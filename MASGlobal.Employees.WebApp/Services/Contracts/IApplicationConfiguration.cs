namespace MASGlobal.Employees.WebApp.Services.Contracts
{
    public interface IApplicationConfiguration
    {
        string EmployeesApiBaseUri { get; }

        string EmployeesApiAllEmployeesResource { get; }

        string EmployeesApiSingleEmployeeResource { get; }
    }
}