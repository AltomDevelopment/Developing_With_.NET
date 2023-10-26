# ASP.NET Core MVC Code First Database Approach
---

Included in this repository are short samples of everything that you need to add to your MVC Core Project, 
in order to create a database using the Code First approach so that you can handle data from within your application.

## Packages to Include 

Install the following Packages from Nuget Package Manager 
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer

There may be other packages that you need to install for Entity Framework to Work but Intellisense will let you know

## Make Sure You have the Following Added to Your Project

1. DomainContext (Used to work with the data within your database, make sure your DbSets are Added)
2. DbOptions
   - The Options Class with the properties that will be used to configure your database 
   - The Setup Class where you will setup your connection string and configuration
3. The Connection String Added in the appsettings.json file
4. The Configuration and DomainContext Registered as Services in the program class with dboptions configured
5. A Model to work with 

## Creating the Database 

From there you should be able to run the following commands in the package manager terminal to create your database

- **EntityFrameworkCore/Add-Migration "Migration Name"**
- **EntityFrameworkCore/Update-Database** 

## Other Notes 

Let me know if you tried these methods and ran into any issues. You shouldn't have any problems.
Common issues are:
1. Incorrectly Formatted Connection String
2. Missing Services within your program class
3. Missing Packages or the commands for entity framework not being typed properly in the terminal. 



