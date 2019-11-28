# DDD-CQRS-ES Starter Kit

Visual Studio Template for working with DDD, CQRS and Event Sourcing.

## Technology

- .NET Core 3.0
- Entity Framework Core 3.0
- SQL Server
- CosmoDB SQL API
- Kledex 2.3

## Key features

- Write model with event sourcing
- Events stored in CosmosDB
- Commands validated using the read model
- Read model stored in SQL Server
- Complete history shown in UI alongside the read model

## Installing the template

Clone the repository and use the .NET Core CLI:

```
dotnet new -i <PATH_TO_SOLUTION_FOLDER>
```

## Using the template

.NET Core CLI:

```
dotnet new ddd-cqrs-es-starter-kit -n <NAME-OF-YOUR-PROJECT>
```
