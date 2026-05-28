## Task
* Mediator pattern
* Need to create one web API project with .net core
* You need to create a different employee handler as per its request and response. 
* Implement fluent validation while calling the handle method of each handler.

## Note
* Task is impletemented for Department and Employee entity.
* Mediator pattern is implemented using the MediatR library and used inside controllers.
* Practical25.BAL\Commands directory includes all commands for all entities implementing IRequest for commands and IRequestHandler for handlers.
* Practical25.BAL\Queries directory includes all queries for all entities implementing IRequest for queries and IRequestHandler for handlers.
* Practical25.DAL\Repositories directory includes all separate repository for read and write operations.