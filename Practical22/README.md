## Task
* Create one class library for DAL (data access layer)
* Create one service class that will handle all SQL operations (create connection, read, create, update, delete)
* You need to use this service as Deferred Loading
* Create common logger for application which will write log in file with Eager loading

## Note
* Task is implemented in Department and Employee controllers.
* Repository Pattern has been implemented.
* Those repositories work as DAL as told in practical and those repositories are loaded Deferred and Singleton using Lazy<> wrapper inside Unit Of Work.
* Common logger is implemented in Practical22.Infrastructure\Logger\FileLogger.cs and is used inside Services and is loaded eagerly in Dependency Injections configured in Practical22.API\Extension\ServicesCollectionExtensions.cs.