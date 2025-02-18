A simple RESTful API for "BookNest" using C# with ASP.NET Core. 
The API will include CRUD operations for managing books in the store's catalog. 
Here’s what I’ll provide:

// ENDPOINTS:
GET /api/books → Get all books
GET /api/books/{id} → Get a book by ID
POST /api/books → Add a new book
PUT /api/books/{id} → Update a book
DELETE /api/books/{id} → Remove a book



// TECH STACK USED:
1. Backend: ASP.NET Core Web API
2. Database: In-Memory Database (for simplicity, but can be switched to SQL Server)
3. Authentication: None (for now)



// TO ACCESS THE PROJECT:
1. Install .NET 7 or later
2. Clone the repository:
   ```sh
   git clone https://github.com/your-username/BookNest.git
3. Navigate to the project:
   ```sh
   cd BookNest
4. Run the application:
   ```sh
   dotnet run
