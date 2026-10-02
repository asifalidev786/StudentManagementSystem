A beginner-friendly Student Management System desktop application built with VB.NET, Windows Forms, SQL Server, and ADO.NET.

The project demonstrates how to perform complete CRUD (Create, Read, Update, Delete) operations using a Windows Forms interface connected to a SQL Server database.

It is designed as a practical learning project for understanding VB.NET WinForms development, ADO.NET database connectivity, SQL queries, validation, and DataGridView operations.

✨ Features

➕ Add new student records

📋 Display all students in a DataGridView

✏️ Update existing student information

🗑️ Delete students with confirmation

🔍 Search students by name, father name, email, or phone

🧹 Clear/reset input fields

✅ Required-field validation

🔐 Parameterized SQL queries

⚠️ SQL exception handling

🖱️ Select a DataGridView row to edit a student

🔄 Automatically refresh records after CRUD operations

🛠️ Technologies Used

Technology

Purpose

VB.NET

Application programming language

Windows Forms

Desktop user interface

SQL Server

Database

ADO.NET

Database connectivity

Visual Studio 2022+

Development environment

SQL Server Management Studio

Database management

📂 Project Structure

StudentManagementSystem/
│
├── StudentManagementSystem.sln
│
├── README.md
│
├── Database/
│   └── StudentDB.sql
│
└── StudentManagementSystem/
    ├── My Project/
    ├── Form1.vb
    ├── Form1.Designer.vb
    ├── Form1.resx
    └── StudentManagementSystem.vbproj

🗄️ Database Structure

The application uses a SQL Server database named:

StudentDB

with a table named:

Students

Students Table

Column

Data Type

Description

StudentID

INT

Primary Key, Identity

StudentName

NVARCHAR(100)

Student's name

FatherName

NVARCHAR(100)

Father's name

Email

NVARCHAR(150)

Email address

Phone

NVARCHAR(30)

Phone number

Gender

NVARCHAR(20)

Gender

DateOfBirth

DATE

Date of birth

Address

NVARCHAR(250)

Student address

💾 Database Setup

Open SQL Server Management Studio (SSMS) and execute the following SQL:

CREATE DATABASE StudentDB;
GO

USE StudentDB;
GO

CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100) NOT NULL,
    FatherName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NULL,
    Phone NVARCHAR(30) NULL,
    Gender NVARCHAR(20) NULL,
    DateOfBirth DATE NULL,
    Address NVARCHAR(250) NULL
);
GO

INSERT INTO Students
    (StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address)
VALUES
    ('Ali Khan', 'Ahmed Khan', 'ali@example.com', '03001234567', 'Male', '2000-05-15', 'Karachi'),
    ('Sara Ahmed', 'Rashid Ahmed', 'sara@example.com', '03111234567', 'Female', '2001-08-20', 'Lahore'),
    ('Hamza Ali', 'Muhammad Ali', 'hamza@example.com', '03211234567', 'Male', '1999-11-10', 'Islamabad'),
    ('Ayesha Khan', 'Imran Khan', 'ayesha@example.com', '03331234567', 'Female', '2002-03-25', 'Karachi'),
    ('Usman Ahmed', 'Tariq Ahmed', 'usman@example.com', '03451234567', 'Male', '2000-07-12', 'Lahore');
GO

SELECT * FROM Students;
GO

Alternatively, run:

Database/StudentDB.sql

from the repository.

⚙️ Configuration

Before running the application, configure the SQL Server connection string.

Find the connection string in the VB.NET project and replace:

YOUR_SERVER_NAME

with your SQL Server instance.

Example:

Server=YOUR_SERVER_NAME;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;

For SQL Server Express, it may look like:

Server=DESKTOP-ABC123\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;

or:

Server=localhost\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;

Use your actual SQL Server instance name.

You can find it in SQL Server Management Studio when connecting to SQL Server.

🚀 Getting Started

1. Clone the Repository

git clone <YOUR-REPOSITORY-URL>

Move into the project directory:

cd StudentManagementSystem

2. Open the Project

Open:

StudentManagementSystem.sln

using Visual Studio 2022 or later.

3. Create the Database

Open SQL Server Management Studio and execute:

Database/StudentDB.sql

Confirm that the following database and table exist:

StudentDB
└── Tables
    └── dbo.Students

4. Configure the Connection

Update the SQL Server connection string with your SQL Server instance name.

5. Build the Project

In Visual Studio:

Build → Build Solution

Shortcut:

Ctrl + Shift + B

6. Run the Application

Press:

F5

or click the Start button in Visual Studio.

🔄 CRUD Operations

CRUD represents the four basic database operations:

CRUD

SQL

Application Function

Create

INSERT

Add a student

Read

SELECT

Display students

Update

UPDATE

Edit student information

Delete

DELETE

Remove a student

➕ Create Student

Enter the student's information and click:

Save

The application:

User Input
    ↓
Validation
    ↓
Parameterized INSERT Query
    ↓
SQL Server
    ↓
Record Saved
    ↓
DataGridView Refreshed

📋 View Students

When the application starts, all students are loaded automatically.

The records are displayed using a DataGridView.

The application executes a SELECT query and loads the returned data into the grid.

✏️ Update Student

To update a student:

Select the student from the DataGridView.

The student's information is loaded into the form.

Modify the required fields.

Click Update.

The database record is updated.

The DataGridView refreshes automatically.

The update is performed using the student's unique StudentID.

🗑️ Delete Student

To delete a student:

Select the student from the DataGridView.

Click Delete.

Confirm the deletion.

The record is removed from SQL Server.

The DataGridView refreshes.

A confirmation dialog helps prevent accidental deletion.

🔍 Search Students

Students can be searched using:

Student Name

Father Name

Email

Phone

Partial searches are supported using SQL LIKE.

For example:

Ali

may return records containing Ali.

The search uses parameterized SQL instead of directly concatenating user input into the query.

🔐 Security

All database operations use parameterized SQL queries.

Instead of unsafe SQL such as:

"SELECT * FROM Students WHERE StudentName = '" & txtStudentName.Text & "'"

the application uses parameters such as:

command.Parameters.AddWithValue("@StudentName", txtStudentName.Text.Trim())

This makes database operations safer and helps protect against SQL injection.

🔌 ADO.NET

The application uses ADO.NET to communicate with SQL Server.

Important ADO.NET components used in the project include:

SqlConnection

Creates and manages the connection between the application and SQL Server.

SqlCommand

Executes SQL commands such as:

INSERT
SELECT
UPDATE
DELETE

SqlParameter

Passes user input safely to SQL statements.

DataTable

Stores database records in memory so they can be displayed in the DataGridView.

ExecuteNonQuery()

Used for commands that modify database records:

INSERT
UPDATE
DELETE

🧠 Application Flow

The basic architecture of the application is:

User
  ↓
WinForms Controls
  ↓
Button/Event Handler
  ↓
Input Validation
  ↓
ADO.NET
  ↓
SqlConnection
  ↓
SqlCommand
  ↓
SQL Server
  ↓
StudentDB
  ↓
DataTable
  ↓
DataGridView

🖥️ Main Controls

Control

Name

Purpose

TextBox

txtStudentID

Student ID

TextBox

txtStudentName

Student name

TextBox

txtFatherName

Father name

TextBox

txtEmail

Email

TextBox

txtPhone

Phone

ComboBox

cmbGender

Gender

DateTimePicker

dtpDateOfBirth

Date of birth

TextBox

txtAddress

Address

TextBox

txtSearch

Search

Button

btnSave

Add student

Button

btnUpdate

Update student

Button

btnDelete

Delete student

Button

btnClear

Clear form

Button

btnSearch

Search students

DataGridView

dgvStudents

Display records

📌 Main Methods

The project contains methods/events such as:

Form1_Load
btnSave_Click
btnUpdate_Click
btnDelete_Click
btnClear_Click
btnSearch_Click
dgvStudents_CellClick

LoadStudents()
SearchStudents()
ClearFields()
ValidateInputs()
GetConnectionString()

Each method has a specific responsibility, keeping the application easier to understand and maintain.

⚠️ Error Handling

Database operations use Try...Catch blocks to handle errors gracefully.

Example:

Try
    ' Database operation

Catch ex As SqlException
    MessageBox.Show("Database error: " & ex.Message)

Catch ex As Exception
    MessageBox.Show("Error: " & ex.Message)

End Try

This prevents unexpected database errors from crashing the application without explanation.

