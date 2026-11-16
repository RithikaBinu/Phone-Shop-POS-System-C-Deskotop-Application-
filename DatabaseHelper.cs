using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class DatabaseHelper
{

    public static string HashPassword(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }


    // Name of the SQLite database file for I CARE POS
    private static string connectionString = "Data Source=ICarePOS.db;Version=3;";

    public static void InitializeDatabase()
    {
        // 1. Create the database file if it does not already exist
        if (!File.Exists("ICarePOS.db"))
        {
            SQLiteConnection.CreateFile("ICarePOS.db");
        }

        // 2. Open connection and create all tables
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string createTablesQuery = @"
               -- Users Table for Login/Registration
               CREATE TABLE IF NOT EXISTS Users (
                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT UNIQUE NOT NULL,
                PasswordHash TEXT NOT NULL,
                Role TEXT DEFAULT 'Cashier'
                  );

                -- 1. Categories Table (e.g., Smartphones, Cables, Audio)
                CREATE TABLE IF NOT EXISTS Categories (
                    CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CategoryName TEXT NOT NULL,
                    Description TEXT
                );

                -- 2. Products Table (e.g., Phone models, chargers, accessories)
                CREATE TABLE IF NOT EXISTS Products (
                    ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductName TEXT NOT NULL,
                    CategoryID INTEGER,
                    UnitPrice REAL NOT NULL,
                    StockQuantity INTEGER NOT NULL,
                    FOREIGN KEY(CategoryID) REFERENCES Categories(CategoryID)
                );

                -- 3. Customers Table
                CREATE TABLE IF NOT EXISTS Customers (
                    CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CustomerName TEXT NOT NULL,
                    ContactNumber TEXT,
                    Address TEXT
                );

                -- 4. Sales Table (Completed transactions)
                CREATE TABLE IF NOT EXISTS Sales (
                    SaleID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SaleDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                    CustomerID INTEGER,
                    TotalAmount REAL NOT NULL,
                    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
                );

                -- 5. Sale Items Table (Individual cart line items per bill)
                CREATE TABLE IF NOT EXISTS SaleItems (
                    SaleItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SaleID INTEGER,
                    ProductID INTEGER,
                    Quantity INTEGER NOT NULL,
                    UnitPrice REAL NOT NULL,
                    LineTotal REAL NOT NULL,
                    FOREIGN KEY(SaleID) REFERENCES Sales(SaleID),
                    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
                );";

            using (var command = new SQLiteCommand(createTablesQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    // Call this method whenever you need to perform INSERT, UPDATE, SELECT, or DELETE operations
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(connectionString);
    }
}