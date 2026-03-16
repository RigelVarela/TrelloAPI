# TrelloAPI

A task management REST API inspired by Trello, built with ASP.NET Core and Entity Framework Core. This project was developed as a practical exercise to apply clean architecture principles, SOLID design patterns, and modern .NET development practices.

---

## 🇪🇸 Español

### Descripción

API REST de gestión de tareas inspirada en Trello. Permite crear tableros, listas y tareas con un sistema de estatus. Desarrollada como proyecto práctico para aplicar arquitectura limpia, principios SOLID y buenas prácticas de desarrollo con .NET.

### Tecnologías

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core** con SQLite
- **Swagger / OpenAPI** para documentación interactiva

### Arquitectura

El proyecto sigue una arquitectura en capas:

```
Controller → Service → Repository → DbContext → Base de datos
```

```
TrelloAPI/
├── Controllers/      → Manejo de HTTP (requests y responses)
├── Services/         → Lógica de negocio
├── Repositories/     → Acceso a datos con EF Core
├── Models/           → Entidades de la base de datos
├── DTOs/             → Objetos de transferencia de datos
└── Data/             → DbContext y configuración de EF Core
```

### Funcionalidades

**Tableros (Boards)**
- Crear, obtener, actualizar y eliminar tableros

**Listas (TaskLists)**
- Crear, obtener, actualizar y eliminar listas dentro de un tablero

**Tareas (TasksItems)**
- Crear, obtener, actualizar y eliminar tareas dentro de una lista
- Cambiar el estatus de una tarea: `Pending`, `InProgress`, `Completed`, `Failed`

### Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Cómo correrlo

```bash
# 1. Clona el repositorio
git clone https://github.com/RigelVarela/TrelloAPI.git
cd TrelloAPI

# 2. Instala las dependencias
dotnet restore

# 3. Aplica las migraciones (crea la base de datos SQLite)
dotnet ef database update

# 4. Corre el proyecto
dotnet run
```

### Documentación

Una vez corriendo, abre Swagger en tu navegador:

```
https://localhost:{puerto}/swagger
```

El puerto lo verás en la terminal cuando el proyecto arranque.

### Endpoints

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/boards` | Obtener todos los tableros |
| GET | `/api/boards/{id}` | Obtener un tablero por ID |
| POST | `/api/boards` | Crear un tablero |
| PUT | `/api/boards/{id}` | Actualizar un tablero |
| DELETE | `/api/boards/{id}` | Eliminar un tablero |
| GET | `/api/tasklists/board/{boardId}` | Obtener listas de un tablero |
| GET | `/api/tasklists/{id}` | Obtener una lista por ID |
| POST | `/api/tasklists` | Crear una lista |
| PUT | `/api/tasklists/{id}` | Actualizar una lista |
| DELETE | `/api/tasklists/{id}` | Eliminar una lista |
| GET | `/api/tasksitems/list/{taskListId}` | Obtener tareas de una lista |
| GET | `/api/tasksitems/{id}` | Obtener una tarea por ID |
| POST | `/api/tasksitems` | Crear una tarea |
| PUT | `/api/tasksitems/{id}` | Actualizar una tarea |
| PATCH | `/api/tasksitems/{id}/status` | Cambiar estatus de una tarea |
| DELETE | `/api/tasksitems/{id}` | Eliminar una tarea |

### Principios aplicados

- **SOLID** — Single Responsibility, Dependency Inversion, Interface Segregation
- **Clean Architecture** — separación clara entre capas
- **Repository Pattern** — acceso a datos desacoplado
- **DTOs** — separación entre modelos internos y datos expuestos
- **Dependency Injection** — todo inyectado por constructor

---

## 🇺🇸 English

### Description

A task management REST API inspired by Trello. Allows creating boards, lists, and tasks with a status system. Built as a hands-on project to apply clean architecture, SOLID principles, and modern .NET best practices.

### Tech Stack

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core** with SQLite
- **Swagger / OpenAPI** for interactive documentation

### Architecture

The project follows a layered architecture:

```
Controller → Service → Repository → DbContext → Database
```

```
TrelloAPI/
├── Controllers/      → HTTP handling (requests and responses)
├── Services/         → Business logic
├── Repositories/     → Data access with EF Core
├── Models/           → Database entities
├── DTOs/             → Data Transfer Objects
└── Data/             → DbContext and EF Core configuration
```

### Features

**Boards**
- Create, read, update and delete boards

**TaskLists**
- Create, read, update and delete lists within a board

**TasksItems**
- Create, read, update and delete tasks within a list
- Change task status: `Pending`, `InProgress`, `Completed`, `Failed`

### Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Getting Started

```bash
# 1. Clone the repository
git clone https://github.com/RigelVarela/TrelloAPI.git
cd TrelloAPI

# 2. Restore dependencies
dotnet restore

# 3. Apply migrations (creates the SQLite database)
dotnet ef database update

# 4. Run the project
dotnet run
```

### Documentation

Once running, open Swagger in your browser:

```
https://localhost:{port}/swagger
```

The port will be displayed in the terminal when the project starts.

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/boards` | Get all boards |
| GET | `/api/boards/{id}` | Get board by ID |
| POST | `/api/boards` | Create a board |
| PUT | `/api/boards/{id}` | Update a board |
| DELETE | `/api/boards/{id}` | Delete a board |
| GET | `/api/tasklists/board/{boardId}` | Get lists by board |
| GET | `/api/tasklists/{id}` | Get list by ID |
| POST | `/api/tasklists` | Create a list |
| PUT | `/api/tasklists/{id}` | Update a list |
| DELETE | `/api/tasklists/{id}` | Delete a list |
| GET | `/api/tasksitems/list/{taskListId}` | Get tasks by list |
| GET | `/api/tasksitems/{id}` | Get task by ID |
| POST | `/api/tasksitems` | Create a task |
| PUT | `/api/tasksitems/{id}` | Update a task |
| PATCH | `/api/tasksitems/{id}/status` | Change task status |
| DELETE | `/api/tasksitems/{id}` | Delete a task |

### Principles Applied

- **SOLID** — Single Responsibility, Dependency Inversion, Interface Segregation
- **Clean Architecture** — clear separation of concerns
- **Repository Pattern** — decoupled data access
- **DTOs** — separation between internal models and exposed data
- **Dependency Injection** — constructor injection throughout

---

## Author

**Rigel Varela** — Software Engineer  
[GitHub](https://github.com/RigelVarela)
