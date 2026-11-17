<h1 align="center">📱 Phone Shop POS System</h1>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C# Badge"/>
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET Badge"/>
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt="Visual Studio Badge"/>
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server Badge"/>
</p>

A comprehensive Point of Sale (POS) Windows desktop application built with C# to streamline daily phone shop operations. This application utilizes a Service-Based Database integrated directly within Visual Studio to manage inventory, customers, and daily sales transactions efficiently.

---

## 🚀 Features

* **🔐 User Authentication:** Secure login screen requiring valid username and password credentials before granting system access.
* **🎛️ Centralized Dashboard:** Main navigation interface with quick access to manage categories, phones, customers, billing, and sales history.
* **📂 Category Management:** Add, update, delete, and search for product categories (Category ID, Name, Description).
* **📦 Inventory & Product Control:** Full CRUD operations for store items, tracking Category ID, Unit Price, and active stock quantities.
* **👥 Customer Management:** Maintain a searchable database of customers (Customer ID, Name, Contact No, Address).
* **🛒 Billing & Checkout System:** Complete POS screen to add/remove products, automatically calculate the Grand Total, and finalize transactions.
* **🔄 Automated Stock Updates:** Completing a sale automatically deducts the purchased quantities from the active inventory.
* **📜 Sales History:** Searchable log of all completed transactions, filterable by Bill No and Date.

---

## 🛠️ Technology Stack

* **Language:** C#
* **Framework:** .NET (Windows Forms / WinForms)
* **Database:** Visual Studio Service-Based Database (LocalDB / SQL Server)
* **IDE:** Visual Studio 2022

---

## ⚙️ Setup and Installation

1. Clone the repository to your local machine:
   ```bash
   git clone [https://github.com/RithikaBinu/Phone-Shop-POS-System-C-Deskotop-Application-.git](https://github.com/RithikaBinu/Phone-Shop-POS-System-C-Deskotop-Application-.git)
   ```
2. Open the solution (`.sln`) file in Visual Studio 2022.
3. Ensure the Service-Based Database (`.mdf`) is attached in your Server Explorer.
4. Verify the database connection string in your code matches your local SQL Server instance.
5. Build and run the project (Press `F5` or click **Start**).

---
*Developed by [Rithika Binuwara](https://github.com/RithikaBinu)*
