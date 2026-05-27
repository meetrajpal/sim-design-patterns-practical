## Task
* Create one class library for DAL (data access layer)
* Create two Repository for Employee with interface implementation 
* Command Repository for Create, Update and delete
* Query Repository for Get
* You need to identify two models for command and query

## Note
* Task is impletemented for Department and Employee entity.
* CQRS pattern is implemented in the Practical26.BAL directory.
* Practical26.BAL\Commands directory includes all commands for all entities.
* Practical26.BAL\Queries directory includes all queries for all entities.
* Practical26.DAL\Repositories directory includes all separate repository for read and write operations.