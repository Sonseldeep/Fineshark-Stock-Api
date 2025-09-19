# Stock API 📈

![.NET](https://img.shields.io/badge/.NET-8-blue.svg)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A comprehensive Stock Portfolio API built with .NET 8 and Entity Framework Core. This API allows users to manage their stock portfolios, track stocks, and engage in discussions through comments. It features JWT-based authentication for secure access to user-specific data.

## 📚 Table of Contents

- [Features](#-features)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [API Endpoints](#-api-endpoints)
  - [Account](#account)
  - [Stocks](#stocks)
  - [Comments](#comments)
  - [Portfolio](#portfolio)
- [Authentication](#-authentication)
- [Dependencies](#-dependencies)
- [Contributing](#-contributing)
- [License](#-license)


## ✨ Features

*   **User Authentication**: Secure user registration and login using JWT tokens.
*   **Stock Management**: CRUD operations for stocks.
*   **Portfolio Management**: Users can add and remove stocks from their personal portfolios.
*   **Commenting System**: Users can comment on stocks.
*   **Data Persistence**: Utilizes Entity Framework Core with SQL Server for robust data storage.
*   **Swagger Documentation**: Interactive API documentation for easy testing and exploration.

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
*   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/) or [VS Code](https://code.visualstudio.com/)

### Installation

1.  **Clone the repository**
    ```sh
    git clone https://github.com/Sonseldeep/Fineshark-Stock-Api.git
    
    # or using SSH
    
    git clone git@github.com:Sonseldeep/Fineshark-Stock-Api.git
    ```
2.  **Navigate to the project directory**
    ```sh
    cd Stock.API
    ```
3.  **Configure the database connection**

    Open `Stock.API/appsettings.json` and update the `DefaultConnection` string with your SQL Server credentials.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
    }
    ```
4.  **Apply database migrations**
    ```sh
    dotnet ef database update -p Stock.API
    ```
5.  **Run the application**
    ```sh
    dotnet run --project Stock.API
    ```
The API will be available at `https://localhost:5001` or `http://localhost:5000`. Navigate to `https://localhost:5001/swagger` to view the API documentation.

## 📦 Dependencies

The project relies on the following NuGet packages:

*   `Microsoft.AspNetCore.Authentication.JwtBearer`
*   `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
*   `Microsoft.AspNetCore.Mvc.NewtonsoftJson`
*   `Microsoft.EntityFrameworkCore.SqlServer`
*   `Microsoft.EntityFrameworkCore.Design`
*   `Swashbuckle.AspNetCore`

All dependencies will be restored automatically when you build the project.

## Endpoints

Here is a list of the available API endpoints:

### Account

*   `POST /api/accounts/register`: Register a new user.
*   `POST /api/accounts/login`: Log in and receive a JWT token.

### Stocks

*   `GET /api/stocks`: Get a list of all stocks.
*   `GET /api/stocks/{id}`: Get a specific stock by ID.
*   `POST /api/stocks`: Create a new stock (Admin).
*   `PUT /api/stocks/{id}`: Update an existing stock (Admin).
*   `DELETE /api/stocks/{id}`: Delete a stock (Admin).

### Comments

*   `GET /api/comments`: Get all comments.
*   `GET /api/comments/{id}`: Get a specific comment by ID.
*   `POST /api/comments/{stockId}`: Add a comment to a stock.
*   `PUT /api/comments/{id}`: Update a comment.
*   `DELETE /api/comments/{id}`: Delete a comment.

### Portfolio

*   `GET /api/portfolio/me`: Get the portfolio of the currently logged-in user.
*   `POST /api/portfolio/{stockId}`: Add a stock to the user's portfolio.
*   `DELETE /api/portfolio/{stockId}`: Remove a stock from the user's portfolio.

## 🔐 Authentication

This API uses JSON Web Tokens (JWT) for authentication. To access protected endpoints, you need to include the JWT in the `Authorization` header of your request with the `Bearer` scheme.

**Example:**

```
Authorization: Bearer <your-jwt-token>
```

You can obtain a token by registering a new user or logging in with an existing one.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a pull request.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
