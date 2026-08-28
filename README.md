# Employee Management System

A full-stack Employee Management System built using Angular and ASP.NET Core Web API with SQL Server.

## Project Overview

This project provides a RESTful backend API for managing employees with secure authentication, CRUD operations, search, sorting, pagination, and employee status management.

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- LINQ
- JWT Authentication
- Angular
- TypeScript
- HTML5
- CSS3
- Bootstrap

## Features

- JWT-based authentication
- Employee CRUD operations
- Employee search
- Sorting
- Pagination
- Employee status management
- Entity Framework Core integration
- Repository Pattern
- Dependency Injection
- SQL Server integration
- DTO-based API design

## Architecture

The API follows a layered architecture:

- Controllers – Handles HTTP requests and API responses
- DTO – Request and response models
- Model – Entity models
- Data – Entity Framework Core DbContext
- Repository – Data access and repository implementation
- Services – Business and authentication-related services

## API

The API provides endpoints for:

- User authentication
- Create employee
- Get employees
- Get employee by ID
- Update employee
- Delete employee
- Search and filter employees
- Employee status management
- Pagination and sorting

## Database

SQL Server is used as the database with Entity Framework Core for database access and ORM functionality.

## How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the SQL Server connection string in `appsettings.json`.
4. Configure the JWT settings.
5. Restore NuGet packages.
6. Build and run the project.
7. Test the API using Swagger or the provided `.http` file.

## Project Structure

```text
EmployeeManagement_API
│
├── Controllers
├── DTO
├── Data
├── Model
├── Repo
├── Services
├── Properties
├── Program.cs
├── appsettings.json
└── EmployeeMgmt_API.csproj
