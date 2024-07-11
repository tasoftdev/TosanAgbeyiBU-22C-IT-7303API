The School Schedule API is designed to manage courses, instructors, 
and students in a school setting. It allows users to perform CRUD operations on courses, 
instructors, and students, including retrieving all records, retrieving a single record by ID,
creating new records, updating existing records, and deleting records.

## Entities
- **Course**
  - Id: int
  - Name: string
  - Credits: int
  - InstructorId: int (foreign key)
  - Room: string
  - Schedule: string

- **Instructor**
  - Id: int
  - FirstName: string
  - LastName: string
  - Email: string
  - Department: string

- **Student**
  - Id: int
  - FirstName: string
  - LastName: string
  - Age: int
  - Email: string
