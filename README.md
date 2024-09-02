# WeatherSolution

Solution contains 3 projects:
- WeatherApp - Angular 18 project with standalone components
- WeatherAPI - Asp.NET 6 API project
- WeatherAPI.DB - entities framewrotk project for DB entities, configurations etc.

## WeatherApp 
Build it with standar `npm install` & `ng serve` command

## WeatherAPI & WeatherAPI.DB
- Open *.sln file in in VS 2022
- Be sure which version of MS SQL Server do you have:
  - MSSQL or MSSQL Developer Edition: leave config string server instance as it is: `Server=.;`
  - MS SQL Express Edition: change config string server instance to: `Server=.\\sqlexpress;`
- Open Package Manager Console
- Switch Default project to WeatherAPI.DB
- Enter command `Update-Database` and press Enter
