# InnoClinic - Distributed Micro-services System

**InnoClinic** is a modular healthcare platform built with .NET 9 and clean architecture principles.
Each service runs independently, communicating over HTTP and secured via centralized JWT authorization.

---

## System Overview

| Micro-service | Responsibility | Tech Stack | Architecture | Database |
|---------------|----------------|------------|--------------|----------|
| **AuthService** | Centralized authentication & token validation | ASP.NET Core, MediatR, JWT | CQRS + Onion | SQL Server (EF Core) |
| **AccountService** | Manages user accounts (patients, doctors, receptionists) | ASP.NET Core, MediatR | CQRS + Onion | SQL Server (EF Core) |
| **PatientService** | Patient data CRUD | ASP.NET Core | Onion | SQL Server (EF Core) |
| **DoctorService** | Doctor profiles and schedules | ASP.NET Core, MediatR | CQRS + Onion | SQL Server (EF Core) |
| **ReceptionistService** | Appointment and reception management | ASP.NET Core | N-Layer | SQL Server (Dapper) |
| **ResultsService** | Medical test results storage | ASP.NET Core | CQRS + Onion | MongoDB Atlas |

---

## Architecture Summary

Each service is **independent**, following **Clean Architecture principles**:

| Layer | Content |
|-------|---------|
| Presentation | API Controllers |
| Application | CQRS Commands, Queries, DTOs, MediatR |
| Domain | Entities, Interfaces |
| Infrastructure | Repositories, DB Contexts, Config |

### Principles Used
- **CQRS + MediatR** (Command/Query separation)
- **Onion & N-Layer architecture**
- **Repository patients**
- **Dependency Injection**
- **Fluent API configuration**
- **AutoMapper**
- **JWT centralized authorization**
- **MongoDB for non-relational storage**

---

## Authentication Flow

All services delegate JWT validation to **AuthService**.

```plaintext
[Client] -> [PatientService] -> [AuthMiddleware -> AuthService.ValidateToken()]
                                      |
                                      |-> [AuthService verifies JWT signature, audience, issuer]
                                                |
                                                |-> HTTP 200 OK -> request proceeds
```

### Token Validation Middleware

Each micro-service includes middleware that:
1. Extracts JWT from 
```plaintext
Authorization: Bearer ...
```
2. Sends it to
```plaintext
AuthService /api/auth/validate
```
3. Blocks or forwards the request accordingly

