using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MASGlobal.Employees.Data.Contracts;
using MASGlobal.Employees.Domain.Entities;
using MASGlobal.Employees.Services.Contracts;
using MASGlobal.Employees.Services.Implementations;
using MASGlobal.Employees.WebApi.Mappings;
using NSubstitute;
using NUnit.Framework;
using DataEmployeeDto = MASGlobal.Employees.Shared.DTOs.Data.Employee;

namespace MASGlobal.Employees.UnitTests
{
    [TestFixture]
    internal sealed class CalculateAnnualSalaryTests
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

        private static IEnumerable<DataEmployeeDto> GetTestDataEmployeeDto(EmployeeContractType employeeContractType)
        {
            return new List<DataEmployeeDto>
            {
                new DataEmployeeDto
                {
                    EmployeeId = 1,
                    EmployeeName = "Carlos",
                    EmployeeContractType = employeeContractType.ToString(),
                    EmployeeRoleId = 1,
                    EmployeeRoleName = "Administrator",
                    EmployeeRoleDescription = "This employee is an administrator",
                    EmployeeHourlySalary = 10,
                    EmployeeMonthlySalary = 400
                }
            };
        }

        [Test]
        public async Task CalculateAnnualSalaryTestForHourlySalaryContractEmployee()
        {
            // Arrange
            const double expectedAnnualSalary = 14400;
            var hourlySalaryDataEmployeeDtoList =
                GetTestDataEmployeeDto(EmployeeContractType.HourlySalaryEmployee).ToList();
            var hourlySalaryDataEmployeeDtoId = hourlySalaryDataEmployeeDtoList.FirstOrDefault().EmployeeId;

            _employeeRepositorySubstitute.GetAllEmployeesAsync().ReturnsForAnyArgs(hourlySalaryDataEmployeeDtoList);

            // Act
            var serviceEmployeeDto = await _employeeService.GetSingleEmployeeByIdAsync(hourlySalaryDataEmployeeDtoId)
                .ConfigureAwait(false);

            // Hourly Salary Contract => 120 * HourlySalary * 12
            // In this case => 120 * 10 * 12 = 14400
            //Assert
            Assert.IsTrue(serviceEmployeeDto.AnnualSalary.Equals(expectedAnnualSalary));
        }

        [Test]
        public async Task CalculateAnnualSalaryTestForMonthlySalaryContractEmployee()
        {
            // Arrange
            const double expectedAnnualSalary = 4800;
            var monthlySalaryDataEmployeeDtoList =
                GetTestDataEmployeeDto(EmployeeContractType.MonthlySalaryEmployee).ToList();
            var monthlySalaryDataEmployeeDtoId = monthlySalaryDataEmployeeDtoList.FirstOrDefault().EmployeeId;

            _employeeRepositorySubstitute.GetAllEmployeesAsync().ReturnsForAnyArgs(monthlySalaryDataEmployeeDtoList);

            // Act
            var serviceEmployeeDto = await _employeeService.GetSingleEmployeeByIdAsync(monthlySalaryDataEmployeeDtoId)
                .ConfigureAwait(false);

            // Monthly Salary Contract => MonthlySalary * 12
            // In this case => 400 * 12 = 4800
            //Assert
            Assert.IsTrue(serviceEmployeeDto.AnnualSalary.Equals(expectedAnnualSalary));
        }
    }
}