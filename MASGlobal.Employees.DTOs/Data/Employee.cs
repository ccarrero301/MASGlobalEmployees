﻿using Newtonsoft.Json;

namespace MASGlobal.Employees.DTOs.Data
{
    public class Employee
    {
        [JsonProperty("id")] public int EmployeeId { get; set; }

        [JsonProperty("name")] public string EmployeeName { get; set; }

        [JsonProperty("contractTypeName")] public string EmployeeContractType { get; set; }

        [JsonProperty("roleId")] public int EmployeeRoleId { get; set; }

        [JsonProperty("roleName")] public string EmployeeRoleName { get; set; }

        [JsonProperty("roleDescription")] public string EmployeeRoleDescription { get; set; }

        [JsonProperty("hourlySalary")] public string EmployeeHourlySalary { get; set; }

        [JsonProperty("monthlySalary")] public string EmployeeMonthlySalary { get; set; }
    }
}