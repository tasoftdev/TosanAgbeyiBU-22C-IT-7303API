# School Schedule API

Description
School Schedule API is an ASP.NET Core application that provides CRUD operations for managing courses and students in a school environment. It uses an in-memory database for simplicity.

Project Structure
- **Controllers**: Contains API controllers (`CoursesController.cs`, `StudentsController.cs`) for handling HTTP requests.
- **Models**: Defines data models (`Course.cs`, `Student.cs`) used in the application.
- **Data**: Configures `SchoolContext.cs` for database operations and data seeding.
- **Startup.cs**: Configures services and middleware for the ASP.NET Core application.

Dependencies
- Entity Framework Core: Version X.X.X
- Microsoft.AspNetCore.Mvc: Version X.X.X

Usage
API Endpoints
- **GET** `/api/courses`: Retrieves all courses.
- **POST** `/api/courses`: Creates a new course.
- **PUT** `/api/courses/{id}`: Updates an existing course.
- **DELETE** `/api/courses/{id}`: Deletes a course by ID.
- Similar endpoints exist for `/api/students`.


