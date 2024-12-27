This project showcases a CLEAN architecture implementation for managing users, books, and other library-related operations. It’s built with ASP.NET Core and integrates modern tools and practices like CQRS Entity Framework, MediatR, AutoMapper, and ASP.NET Identity.

# Installation Instructions
# Step 1: Clone the Repository
```
git clone https://github.com/devgibsonsp/LibraryApp
cd LibraryApp
```
# Step 2: Set Up the Database

Ensure you have SQL Server or SQL Express installed and running.
Create a database (or let the migrations handle it).
Open the Presentation/appsettings.json file and set your connection string:
```
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibraryApp;Trusted_Connection=True;"
}
```
# Step 3: Apply Migrations
Run the following command to apply migrations and set up the database schema:
```
dotnet ef database update --project LibraryApp/Infrastructure --startup-project LibraryApp/Presentation
```
# Step 4: Seed the Database
The app includes a seeding mechanism to populate the database with some fake data for testing.

The seeding happens automatically when the app starts. If you need to reset it, drop the database and rerun migrations.

# Step 5: Run the Application
Navigate to the Presentation folder and start the application:
dotnet run

# Step 6: Test the API

Swagger is enabled for easy testing. Open the Swagger UI at:
```
https://localhost:5001/swagger
```

# CLEAN Architecture:

Application layer is decoupled from domain and infrastructure.
MediatR is used for commands/queries, ensuring extensibility.
What’s Missing

So, here’s the thing—this project is about 80% there, but I ran out of time to complete everything I wanted. Over the past 5 days, working a few hours each day, I’ve focused heavily on building a strong foundation rather than rushing to finish every feature.

# What’s Incomplete:

JWT Authentication:
The groundwork is in place (ASP.NET Identity is configured), but I didn’t finish the login endpoint or fully integrate JWT tokens for securing the API.
Frontend Integration:
The frontend is the weakest. I started building a placeholder with material UI.

# Some Nice-to-Haves:
Better error handling for edge cases.
Comprehensive unit tests (though the structure is designed to make them easy to add).
# Why I Prioritized Design

I wanted this project to reflect my thought process and show how I approach a real-world problem. Even though I didn’t finish everything, I’m proud of how scalable and maintainable the architecture is.

# Future Steps

Complete JWT authentication and secure all routes.
Build a simple React frontend to interact with the backend.
Add robust unit tests to cover critical functionality.
Flesh out additional features, like advanced book search.

A full list of issues can be found here:
https://github.com/devgibsonsp/LibraryApp/issues

The final PR I was working on can be found here:
https://github.com/devgibsonsp/LibraryApp/pull/49
