# Library-Management-System

This is a simple Library Management System application that allows users to manage books, borrow and lend books, and search for books based on various criteria. The application is built using DotNet-Angular and MSSQL for the database.

## Features

### Add Book:

  - Logged-in users can add books that can be borrowed by others.
<img width="899" alt="add book" src="https://github.com/Gaurav2119/Library-Management-System/assets/65570469/a9b3a276-7fed-4bcb-87d6-c165265d0288">

### Borrow Book:

  - Users can borrow available books based on user and book ratings.
  - Users must have at least 1 token available to borrow a book.
  - 1 token is added to the user lending the book, and 1 token is deducted from the user borrowing the book.

### Search for a Book:

  - Users can search for a book by its name, author name, or genre.
<img width="917" alt="dashboard" src="https://github.com/Gaurav2119/Library-Management-System/assets/65570469/9eb23ea7-e047-4883-a712-657a5dd7228d">

### Book Details:

  - Users can view details of a book, including its name, author, genre, lender name, and rating.

### List All Books:

  - Users can see a list of all books added by other users.
<img width="919" alt="loggedin dashboard" src="https://github.com/Gaurav2119/Library-Management-System/assets/65570469/989a621d-d6ba-4f06-849b-69ec693cd123">

### List User's Books:

  - Users can list all books added or borrowed by them.
<img width="919" alt="my borrowed books" src="https://github.com/Gaurav2119/Library-Management-System/assets/65570469/2f1f65f5-def3-444d-9b1a-0b37b739a678">
<img width="914" alt="my books" src="https://github.com/Gaurav2119/Library-Management-System/assets/65570469/6d594cf8-5e9e-47e8-bc03-671dc53347e5">

## Prerequisites

- Visual Studio 2022
- Visual Studio Code
- SQL Server 
- .NET Core 6.0 SDK or above
- Node.Js V12.0 or above

## Steps to run the app

1. Clone the Repo.
2. Run 'update-database' in the package manager console to Scaffold the database.
3. Build and launch the application from Visual Studio.
4. Run 'ng-serve' from Visual Studio Code Terminal.
