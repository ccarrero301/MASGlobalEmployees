
# MASGlobal Consulting Employees Portal

Hi there,

This repository is intended as the primary source for the new Employees Portal. In the portal, you will be able to search for **MASGlobal Consulting** Employees information.

The current release supports the information retrieval for all employees or just a single employee by Employee Id.

# Try it Yourself
You can try the portal by yourself [here](https://masglobalemployeesapp.azurewebsites.net/).   If you want to take a look at the code, just clone or download this repository.


# Solution Structure

The portal was built using Visual Studio 2019 with ASP.NET CORE 2.2.

It consists of the following seven projects:
- **MASGlobal.Employees.WebApp** .
	> This is the Web Application. The end user will interact with the application to search for employee data. 
- **MASGlobal.Employees.WebApi** .
	> This is the entry point for the Web Application. Meaning the web application will send HTTP requests to this web api.
	You can check it out [here](https://masglobalemployeesapi.azurewebsites.net) .
- **MASGlobal.Employees.Shared** .
	> Contains some shared functionality some of the other projects use. 
- **MASGlobal.Employees.Domain** .
	> Contains the business domain entites related to the Employees.
- **MASGlobal.Employees.Data** .
	> Is the data access layer. It implements the repository pattern. The current implementation retrieves the employee data from an external api : [Employee external API](http://masglobaltestapi.azurewebsites.net/swagger/)
- **MASGlobal.Employees.Services** .
	> Represents the domain business services.
	In this project is where the annual salary calculation takes place. The code retrieves the data calling the data access layer, transform that data into business entities, and performs the calculation. It returns a DTO (data transfer object) with the desired data. 

- **MASGlobal.Employees.UnitTests** .
	> Contains unit tests to guarantee the correct function of the portal most important functionalities.