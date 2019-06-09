using System.Threading.Tasks;
using AutoMapper;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Contracts;
using MASGlobal.Employees.Services.Implementations;
using MASGlobal.Employees.WebApi.Mappings;
using NSubstitute;
using NUnit.Framework;
using DomainEmployee = MASGlobal.Employees.Domain.Entities.Employee;

namespace MASGlobal.Employees.UnitTests
{
    [TestFixture]
    public class CalculateAnnualSalaryTests
    {
        [SetUp]
        public void Setup()
        {
            _employeeRepositorySubstitute = Substitute.For<IEmployeeRepository>();
            _mapper = MappingConfiguration.Configure();

            _employeeService = new EmployeeService(_employeeRepositorySubstitute, _mapper);
        }

        private IEmployeeRepository _employeeRepositorySubstitute;
        private IMapper _mapper;
        private IEmployeeService _employeeService;

        private static DomainEmployee GetDomainTestEmployee(EmployeeContractType employeeContractType)
        {
            var employeeRole = new EmployeeRole(1, "Administrator", "This employee is an administrator");

            return new DomainEmployee(1, "Carlos", employeeRole, employeeContractType, 10, 400);
        }

        [Test]
        public async Task CalculateAnnualSalaryTestForHourlySalaryContractEmployee()
        {
            // Arrange
            const double expectedAnnualSalary = 14400;

            _employeeRepositorySubstitute.GetEmployeesByIdAsync(default)
                .ReturnsForAnyArgs(GetDomainTestEmployee(EmployeeContractType.HourlySalaryEmployee));

            // Act
            var serviceDtoEmployee = await _employeeService.GetEmployeeByIdAsync(default).ConfigureAwait(false);


            // Hourly Salary Contract => 120 * HourlySalary * 12
            // In this case => 120 * 10 * 12 = 14400
            //Assert
            Assert.IsTrue(serviceDtoEmployee.AnnualSalary.Equals(expectedAnnualSalary));
        }

        [Test]
        public async Task CalculateAnnualSalaryTestForMonthlySalaryContractEmployee()
        {
            // Arrange
            const double expectedAnnualSalary = 4800;

            _employeeRepositorySubstitute.GetEmployeesByIdAsync(default)
                .ReturnsForAnyArgs(GetDomainTestEmployee(EmployeeContractType.MonthlySalaryEmployee));

            // Act
            var serviceDtoEmployee = await _employeeService.GetEmployeeByIdAsync(default).ConfigureAwait(false);

            // Monthly Salary Contract => MonthlySalary * 12
            // In this case => 400 * 12 = 4800
            //Assert
            Assert.IsTrue(serviceDtoEmployee.AnnualSalary.Equals(expectedAnnualSalary));
        }
    }
}