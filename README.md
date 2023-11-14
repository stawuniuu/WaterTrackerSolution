# WaterTrackerSolution

## A functional project created in .NET 6.0 with REST API implementation and Blazor WebAssembly

This project was designed with repository design pattern to abstract data handling layer. It provides users with basic UI and functionality required to maintain SQL database that contains User and WaterIntake entities.


1. User management functionality includes: 
* fetch a list of users
* create new user
* view user details by ID
* modify user information
* remove user

2. Water intake management functionality includes: 
* obtain a user's water intake records
* add new water intake records for a user
* view specific water intake records by ID
* modify water intake records
* delete water intake records

## Set up and configuration

This paragraph aims on to explain how to set up and configure the project in order to run it.

1. Clone the project.
2. Set up an SQL Server Database
3. Go to WaterTrackerSolution\WaterTracker.API\appsettings.json and in Connection Strings set Server to your SQL server name.
4. Seed database by opening PackageManagerConsole and running following commands:
```
add-migration Name
```
and
```
update-database
```
5. In WaterTrackerSolution\WaterTracker.API\program cs insert your URL in the code configuring HTTP client dependency injection::
```
policy.WithOrigins("yourHttpUrl", "youHttpsrUrl")
```
!remember to NOT include "/" at the end !
6. In WaterTrackerSolution\WaterTracker.API\program cs insert your URL in the following code to set base URL of Blazor component to the same as API component:
```
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("yourHttpsUrl") });
```
!remember to include "/" at the end !

## Known issues
1. When deleting User entry system does not delete corresponding WaterIntake entries. This causes an issue where there is a WaterIntake record that can be viewed, edited or removed throught web UI, it has to be removed manually directly in the database.