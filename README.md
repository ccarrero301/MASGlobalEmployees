

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
	
# General Project Graph  
To illustrate the previous section this is the general dependency graph for the entire solution.

![Project Dependency](https://lh3.googleusercontent.com/8k_imFMaf6mgrljhl-GnQbtVHcHdrIx1JNHvRAwNDJl7gneLVkxyVn9QbM_ZsQ9UBFj1iGymAxzS0w)

# Type Dependency Graph
The following images show the type dependency diagram inside of every project.

 - MASGlobal.Employees.Domain

![enter image description here](https://lh3.googleusercontent.com/HWad4n2uf6Xz8mD3qoUfdox1NusS4Y6oV2dUrDpEEWPY1PTmPPEVjfGbjrh-Na_7MgLKSBrpuT5c8g "Domain")

- MASGlobal.Employees.Data

![enter image description here](https://lh3.googleusercontent.com/BjDgTaaRiT2_ZNAajAUYnmKrTAgLIxO_OFO3rpwA8f15hCfP4PGG40Kf2cSxSh6drl7dXO2ZmKhqJw "Data")

- MASGlobal.Employees.Services

![enter image description here](https://lh3.googleusercontent.com/JnmMBw1uZqwH3fP_FwYOQgdsERzJxU38hytllXsl7_K2W0drsYIgNa7xNqtC_4XgRQT7vd4RmaYPfg "Services")

- MASGlobal.Employees.Shared

![enter image description here](https://lh3.googleusercontent.com/bQxtDIhElHDuPMxNfp1X-kh87jYs3YdBDUeG6ZR87SMbm6-OZ0wXyJGcZG9khccW2tevid9sy6lHew "Shared")

- MASGlobal.Employees.UnitTests

![
](https://lh3.googleusercontent.com/BePTXDSrptEk4Jldu7kMuoD3EeEvKMAVc9nDY-2OW4eZglVkWSOsRkEso934xkA2U-sevcg6mETRqw "UnitTests")

- MASGlobal.Employees.WebApi

![
](https://lh3.googleusercontent.com/yfTZlBMHAP_P7kO8tXclKe43zyA962x0BZJOk3RLm8I__3XA7xKklsyqQQUDrnTQq46kXpSqUQuiWQ "WebApi")

- MASGlobal.Employees.WebApp

![enter image description here](https://lh3.googleusercontent.com/dShW-piGs8SvV2RK4bQ5_ru5E5eqOVPyH_iOazsGxOyfzUCnzSd4NIDZWernfrg7j2BDwoZs5iVsVQ "WebApp")


 
