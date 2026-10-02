# Student Management System - Beginner Interview Guide

This guide matches the project in this folder:

```text
StudentManagementSystem/
|
+-- StudentManagementSystem.sln
+-- StudentManagementSystem/
|   +-- StudentManagementSystem.vbproj
|   +-- Program.vb
|   +-- Form1.vb
|   +-- Form1.Designer.vb
|   +-- Form1.resx
+-- Database/
|   +-- StudentDB.sql
+-- docs/
    +-- BeginnerInterviewGuide.md
```

The project uses:

- VB.NET
- Windows Forms
- SQL Server
- ADO.NET
- `System.Data.SqlClient`
- Visual Studio 2022 or later
- .NET Framework 4.8

I chose .NET Framework 4.8 because it is still a very common WinForms interview target and includes `System.Data.SqlClient` without needing a NuGet package. A modern .NET 8 or later WinForms project can also work, but it usually uses `Microsoft.Data.SqlClient` from NuGet.

## STEP 1 - Create The VB.NET WinForms Project

### WHAT WE ARE DOING

We are creating a Visual Basic Windows Forms desktop application named `StudentManagementSystem`.

### WHY WE ARE DOING IT

WinForms gives you a visual desktop UI with TextBoxes, Buttons, ComboBoxes, and a DataGridView. That is perfect for a beginner CRUD interview project.

### HOW TO DO IT

1. Open Visual Studio 2022 or later.
2. Click **Create a new project**.
3. Search for **Windows Forms App (.NET Framework)**.
4. Choose **Visual Basic** as the language.
5. Select **.NET Framework 4.8**.
6. Name the project `StudentManagementSystem`.
7. Create the solution.

This repository already contains the complete solution file:

```text
StudentManagementSystem/StudentManagementSystem.sln
```

Open that file in Visual Studio if you want to use the ready-made version.

### CODE

No NuGet package is required for this version because the project imports:

```vb
Imports System.Data.SqlClient
```

### HOW THE CODE WORKS

`System.Data.SqlClient` contains the ADO.NET SQL Server classes used by this project:

- `SqlConnection`
- `SqlCommand`
- `SqlDataAdapter`
- `SqlException`

### INTERVIEW POINT

You can say: "I used a VB.NET WinForms project with ADO.NET and `System.Data.SqlClient` to connect directly to SQL Server and perform CRUD operations."

## STEP 2 - Create StudentDB

### WHAT WE ARE DOING

We are creating the SQL Server database and `Students` table.

### WHY WE ARE DOING IT

The WinForms app needs a permanent place to store student records. SQL Server stores the records in rows and columns.

### HOW TO DO IT

1. Open SQL Server Management Studio.
2. Connect to your SQL Server instance.
3. Click **New Query**.
4. Open `Database/StudentDB.sql`.
5. Copy the full script into SSMS.
6. Click **Execute**.

### CODE

The complete script is in:

```text
Database/StudentDB.sql
```

It creates:

```sql
StudentDB
dbo.Students
```

It also inserts 5 sample student records and ends with:

```sql
SELECT *
FROM dbo.Students;
```

### HOW THE CODE WORKS

The database stores each student with an auto-generated `StudentID`. The `IDENTITY(1,1)` setting means SQL Server starts at 1 and increases by 1 for each new record.

### INTERVIEW POINT

You can say: "The table has `StudentID` as the primary key, and the application uses that key to update and delete the correct row."

## STEP 3 - Create And Verify Students Table

### WHAT WE ARE DOING

We are checking that SQL Server really created the database and table.

### WHY WE ARE DOING IT

If the table does not exist, the WinForms app will show errors like `Invalid object name 'dbo.Students'`.

### HOW TO DO IT

In SSMS Object Explorer, expand:

```text
Databases
  StudentDB
    Tables
      dbo.Students
```

Then run:

```sql
USE StudentDB;
SELECT * FROM dbo.Students;
```

### CODE

The final `SELECT` statement in the database script verifies the rows.

### HOW THE CODE WORKS

`SELECT * FROM dbo.Students` asks SQL Server to return every column and every row from the table.

### INTERVIEW POINT

Before testing a desktop app, always verify that the database exists and contains data.

## STEP 4 - Configure SQL Server Connection

### WHAT WE ARE DOING

We are telling VB.NET where SQL Server is and which database to use.

### WHY WE ARE DOING IT

ADO.NET cannot connect unless it knows the SQL Server instance name, database name, and authentication method.

### HOW TO DO IT

Open `Form1.vb` and find:

```vb
Private Function GetConnectionString() As String
    Return "Server=YOUR_SERVER_NAME;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
End Function
```

Replace `YOUR_SERVER_NAME` with your actual SQL Server instance.

Examples:

```text
Server=DESKTOP-ABC123\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;
Server=localhost\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;
Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;
```

These are examples. Use the exact server name shown in SSMS when you connect.

### CODE

```vb
Private Function GetConnectionString() As String
    Return "Server=YOUR_SERVER_NAME;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
End Function
```

### HOW THE CODE WORKS

- `Server` means the SQL Server instance.
- `Database` means the database name.
- `Trusted_Connection=True` means use Windows Authentication.
- `TrustServerCertificate=True` avoids local development certificate trust errors.

### INTERVIEW POINT

You can say: "I keep the connection string in one function so I can update it in one place instead of repeating it across every database method."

## STEP 5 - Design The Windows Form

### WHAT WE ARE DOING

We are building one main form named `Form1` with student input controls, action buttons, a search box, and a DataGridView.

### WHY WE ARE DOING IT

The user needs a clear screen to enter student data, save it, search it, select it, update it, and delete it.

### HOW TO DO IT

The project already contains `Form1.Designer.vb`, which creates the UI in code. In Visual Studio, you can still open `Form1.vb` in the designer and adjust layout if needed.

The layout is:

- Top: `grpStudentInfo`
- Middle left: Save, Update, Delete, Clear buttons
- Middle right: Search box and Search button
- Bottom: `dgvStudents`

### CODE

The form title is set in `Form1.Designer.vb`:

```vb
Me.Text = "Student Management System"
```

### HOW THE CODE WORKS

`InitializeComponent()` creates the controls and sets properties like `Name`, `Text`, `Location`, `Size`, `ReadOnly`, and `SelectionMode`.

### INTERVIEW POINT

You can say: "The form separates data entry from the grid. The grid is read-only, so users edit records through the input controls instead of directly editing table cells."

## STEP 6 - Set Control Names

### WHAT WE ARE DOING

We are using meaningful control names so the code is easy to read.

### WHY WE ARE DOING IT

Interviewers often check whether your names explain intent. `txtStudentName` is much clearer than `TextBox1`.

### HOW TO DO IT

Use this table to verify the form:

| Control Type | Displayed Text | Name Property | Important Properties |
|---|---|---|---|
| GroupBox | Student Information | `grpStudentInfo` | Holds student fields |
| Label | Student ID | `lblStudentID` | Label only |
| TextBox | Student ID | `txtStudentID` | `ReadOnly = True` |
| Label | Student Name | `lblStudentName` | Label only |
| TextBox | Student Name | `txtStudentName` | Required |
| Label | Father Name | `lblFatherName` | Label only |
| TextBox | Father Name | `txtFatherName` | Required |
| Label | Email | `lblEmail` | Optional, simple validation |
| TextBox | Email | `txtEmail` | Optional |
| Label | Phone | `lblPhone` | Optional |
| TextBox | Phone | `txtPhone` | Optional |
| Label | Gender | `lblGender` | Label only |
| ComboBox | Gender | `cmbGender` | `DropDownStyle = DropDownList`, `Male`, `Female` |
| Label | Date of Birth | `lblDateOfBirth` | Label only |
| DateTimePicker | Date of Birth | `dtpDateOfBirth` | `ShowCheckBox = True` |
| Label | Address | `lblAddress` | Label only |
| TextBox | Address | `txtAddress` | `Multiline = True` |
| Button | Save | `btnSave` | Inserts a row |
| Button | Update | `btnUpdate` | Updates selected row |
| Button | Delete | `btnDelete` | Deletes selected row |
| Button | Clear | `btnClear` | Clears controls |
| Label | Search | `lblSearch` | Label only |
| TextBox | Search | `txtSearch` | Partial match text |
| Button | Search | `btnSearch` | Searches grid |
| DataGridView | Students table | `dgvStudents` | `ReadOnly = True`, `FullRowSelect`, `MultiSelect = False`, `AutoSizeColumnsMode = Fill` |

### CODE

All control names are declared at the bottom of `Form1.Designer.vb`.

### HOW THE CODE WORKS

The code-behind file can use controls by name because the designer declares them as fields in the `Form1` class.

### INTERVIEW POINT

You can say: "I used clear naming conventions: `txt` for TextBox, `btn` for Button, `cmb` for ComboBox, and `dgv` for DataGridView."

## STEP 7 - Add VB.NET Code

### WHAT WE ARE DOING

We are adding the actual CRUD logic in `Form1.vb`.

### WHY WE ARE DOING IT

The UI only displays controls. The code-behind decides what happens when the user clicks Save, Update, Delete, Clear, Search, or a grid row.

### HOW TO DO IT

Open:

```text
StudentManagementSystem/Form1.vb
```

The complete code is already there. The required methods/events are implemented:

- `Form1_Load`
- `btnSave_Click`
- `btnUpdate_Click`
- `btnDelete_Click`
- `btnClear_Click`
- `btnSearch_Click`
- `dgvStudents_CellClick`
- `LoadStudents()`
- `ClearFields()`
- `SearchStudents()`
- `ValidateInputs()`
- `GetConnectionString()`

### CODE

Example Save flow:

```vb
If Not ValidateInputs() Then
    Return
End If

Using connection As New SqlConnection(GetConnectionString())
    Using command As New SqlCommand(sql, connection)
        AddStudentParameters(command)
        connection.Open()
        command.ExecuteNonQuery()
    End Using
End Using
```

### HOW THE CODE WORKS

The `Using` blocks automatically dispose the connection and command. `connection.Open()` opens the database connection. `ExecuteNonQuery()` executes an INSERT, UPDATE, or DELETE command that does not return a result table.

### INTERVIEW POINT

You can say: "Every operation that receives user input uses parameters, not string concatenation, so the application is safer and handles quotes correctly."

## STEP 8 - Run The Application

### WHAT WE ARE DOING

We are building and starting the WinForms app.

### WHY WE ARE DOING IT

Running the app proves the UI, connection string, SQL table, and CRUD code are working together.

### HOW TO DO IT

1. Open `StudentManagementSystem.sln`.
2. Replace `YOUR_SERVER_NAME` in `GetConnectionString()`.
3. Build the solution.
4. Press `F5`.

### CODE

The startup code is in `Program.vb`:

```vb
Application.Run(New Form1())
```

### HOW THE CODE WORKS

`Application.Run` starts the WinForms message loop and opens `Form1`.

### INTERVIEW POINT

You can say: "When the form loads, `Form1_Load` calls `LoadStudents()` so existing records appear immediately."

## STEP 9 - Test CREATE

### WHAT WE ARE DOING

We are inserting a new student.

### WHY WE ARE DOING IT

This tests the Create part of CRUD, which maps to SQL `INSERT`.

### HOW TO DO IT

Enter:

```text
Student Name: Bilal Ahmed
Father Name: Rashid Ahmed
Email: bilal.ahmed@gmail.com
Phone: 0300-7778899
Gender: Male
Date of Birth: check the date box and choose 2004-09-10
Address: Johar Town, Lahore
```

Click **Save**.

### CODE

`btnSave_Click` uses:

```sql
INSERT INTO dbo.Students
(StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address)
VALUES
(@StudentName, @FatherName, @Email, @Phone, @Gender, @DateOfBirth, @Address)
```

### HOW THE CODE WORKS

Validation runs first. Then a parameterized INSERT command sends values to SQL Server. The grid refreshes after the save.

### INTERVIEW POINT

`ExecuteNonQuery()` is used because INSERT changes data but does not return a table.

## STEP 10 - Test READ

### WHAT WE ARE DOING

We are loading rows from SQL Server into `dgvStudents`.

### WHY WE ARE DOING IT

Users need to see existing data before they can update, delete, or search.

### HOW TO DO IT

Start the application. Records should appear automatically.

### CODE

`LoadStudents()` uses:

```vb
Dim table As New DataTable()
adapter.Fill(table)
dgvStudents.DataSource = table
```

### HOW THE CODE WORKS

`SqlDataAdapter` runs the SELECT query and fills a `DataTable`. The `DataGridView` displays the `DataTable`.

### INTERVIEW POINT

A `DataTable` is an in-memory table. It has rows and columns like a database table, but it exists inside your running application.

## STEP 11 - Test UPDATE

### WHAT WE ARE DOING

We are editing an existing student.

### WHY WE ARE DOING IT

This tests the Update part of CRUD, which maps to SQL `UPDATE`.

### HOW TO DO IT

1. Click the row for `Ali Raza`.
2. Change phone to `0300-9999999`.
3. Click **Update**.

### CODE

`btnUpdate_Click` uses:

```sql
WHERE StudentID = @StudentID
```

### HOW THE CODE WORKS

The selected row loads into the controls. The hidden key for the operation is `txtStudentID`. SQL Server updates the row with that exact primary key.

### INTERVIEW POINT

Updating by primary key is important because names are not guaranteed to be unique, but `StudentID` is unique.

## STEP 12 - Test DELETE

### WHAT WE ARE DOING

We are deleting a selected student.

### WHY WE ARE DOING IT

This tests the Delete part of CRUD, which maps to SQL `DELETE`.

### HOW TO DO IT

1. Select a student from the grid.
2. Click **Delete**.
3. Confirm **Yes** in the dialog.

### CODE

```vb
MessageBox.Show("Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
```

### HOW THE CODE WORKS

The app checks that a student is selected, asks for confirmation, then deletes by `StudentID`.

### INTERVIEW POINT

The confirmation dialog prevents accidental deletion.

## STEP 13 - Test SEARCH

### WHAT WE ARE DOING

We are filtering records by partial text.

### WHY WE ARE DOING IT

Users rarely know the full exact value, so partial search is more useful.

### HOW TO DO IT

Try searches like:

```text
Ali
@gmail.com
0300
Khan
```

Click **Search** or press Enter in the search box.

### CODE

```sql
WHERE StudentName LIKE @Search
   OR FatherName LIKE @Search
   OR Email LIKE @Search
   OR Phone LIKE @Search
```

The parameter value is:

```vb
"%" & txtSearch.Text.Trim() & "%"
```

### HOW THE CODE WORKS

`LIKE` performs pattern matching. `%` means any number of characters. Searching `%Ali%` finds values that contain `Ali` anywhere.

### INTERVIEW POINT

Even search uses parameters. The code does not concatenate user text directly into SQL.

## Complete Data Flow

```text
User
 ↓
WinForms Controls
 ↓
Button Click Event
 ↓
Validation
 ↓
SqlConnection
 ↓
SqlCommand
 ↓
SQL Server
 ↓
Database Result
 ↓
DataTable
 ↓
DataGridView
```

When you click **Save**, the app validates required fields, creates a SQL INSERT command, adds parameters, opens the connection, executes the command, reloads the grid, and clears the form.

When you select a DataGridView row, `dgvStudents_CellClick` reads values from the selected row and places them into the input controls.

When you click **Update**, the app validates the input and sends a SQL UPDATE command using `StudentID` in the `WHERE` clause.

When you click **Delete**, the app confirms the action and sends a SQL DELETE command using `StudentID`.

When you search, the app sends a SELECT query with `LIKE @Search`, fills a `DataTable`, and displays matching records in the grid.

## Important Code Explained

```vb
Using connection As New SqlConnection(GetConnectionString())
```

This creates a SQL Server connection object. The connection is not open yet. The `Using` block guarantees disposal even if an error happens.

```vb
connection.Open()
```

This opens the physical connection to SQL Server.

```vb
Using command As New SqlCommand(sql, connection)
```

This creates a command object. It contains the SQL statement and knows which connection to use.

```vb
command.Parameters.Add("@StudentName", SqlDbType.NVarChar, 100).Value = txtStudentName.Text.Trim()
```

This sends a value separately from the SQL text. It prevents SQL injection and avoids quote-related errors.

```vb
command.ExecuteNonQuery()
```

This runs INSERT, UPDATE, or DELETE. It returns the number of rows affected.

```vb
adapter.Fill(table)
dgvStudents.DataSource = table
```

The adapter fills a `DataTable` from SQL Server. The grid displays that table.

Unsafe code would look like this:

```vb
"SELECT * FROM Students WHERE StudentName = '" & txtStudentName.Text & "'"
```

This is unsafe because user input becomes part of the SQL command text. A malicious or accidental quote can break the query or change its meaning.

## ADO.NET Concepts For Interview

| Concept | Interview explanation |
|---|---|
| `SqlConnection` | Represents a connection to SQL Server. It should be opened late, closed early, and disposed with `Using`. |
| `SqlCommand` | Sends a SQL statement or stored procedure to SQL Server. |
| `SqlParameter` | Sends user values safely without merging them into SQL text. |
| `DataTable` | Stores tabular data in memory using rows and columns. |
| `SqlDataAdapter` | Runs a SELECT command and fills a `DataTable`. |
| `ExecuteNonQuery` | Runs commands that change data, such as INSERT, UPDATE, DELETE. Returns affected row count. |
| `ExecuteScalar` | Returns a single value, such as `SELECT COUNT(*) FROM Students`. |
| `ExecuteReader` | Returns a forward-only stream of rows. Useful for fast reading when you do not need a `DataTable`. |

Command comparison:

| Method | Returns | Common use |
|---|---|---|
| `ExecuteNonQuery()` | Number of rows affected | INSERT, UPDATE, DELETE |
| `ExecuteScalar()` | First column of first row | COUNT, SUM, generated ID |
| `ExecuteReader()` | `SqlDataReader` | Reading rows one by one |

Example `ExecuteScalar`:

```vb
Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
```

Example query:

```sql
SELECT COUNT(*) FROM dbo.Students;
```

## CRUD To SQL Mapping

| CRUD | SQL | Project method |
|---|---|---|
| Create | INSERT | `btnSave_Click` |
| Read | SELECT | `LoadStudents` |
| Update | UPDATE | `btnUpdate_Click` |
| Delete | DELETE | `btnDelete_Click` |
| Search | SELECT with WHERE LIKE | `SearchStudents` |

## NULL, DBNull, Nothing, And Empty String

| Term | Meaning in this project |
|---|---|
| SQL `NULL` | Missing value in SQL Server, such as no email or no date of birth. |
| `DBNull.Value` | VB.NET/ADO.NET object used to send or receive SQL NULL. |
| `Nothing` | VB.NET object variable has no object reference. |
| Empty string | A real string with no characters: `""`. It is not the same as SQL NULL. |

Optional fields use `DBNull.Value` when the user leaves them empty.

## SqlException Vs Exception

`SqlException` means SQL Server or the database provider reported an error. Examples include login failure, invalid table name, timeout, or connection failure.

`Exception` is the broader base type for many other runtime errors. Catching both lets the app show a more specific database message when possible and still handle unexpected errors.

## Interview Questions And Answers

1. **What is CRUD?**  
CRUD means Create, Read, Update, and Delete. These are the four basic operations used to manage data.

2. **What is ADO.NET?**  
ADO.NET is the .NET data access technology used to connect to databases, run commands, and read results.

3. **What is `SqlConnection`?**  
It represents a connection from the application to SQL Server.

4. **What is `SqlCommand`?**  
It represents a SQL statement that will be executed against SQL Server.

5. **What does `connection.Open()` do?**  
It opens the actual database connection so commands can be executed.

6. **Why use `Using` blocks?**  
They automatically dispose database objects and release resources, even if an error happens.

7. **What is a parameterized query?**  
It is a SQL command where user values are passed as parameters like `@StudentName` instead of being concatenated into the SQL string.

8. **How do parameters help prevent SQL injection?**  
Parameters keep user input separate from SQL command text, so input is treated as data, not executable SQL.

9. **What does `ExecuteNonQuery()` return?**  
It returns the number of rows affected by commands like INSERT, UPDATE, and DELETE.

10. **What is a `DataTable`?**  
A `DataTable` is an in-memory table of rows and columns.

11. **What is a `DataGridView`?**  
It is a WinForms control used to display tabular data on the form.

12. **How do you load a selected DataGridView row into TextBoxes?**  
Handle the grid's `CellClick` event, read the selected row's cell values, and assign them to the TextBoxes.

13. **What is a primary key?**  
A primary key uniquely identifies each row in a table.

14. **What does `IDENTITY(1,1)` mean?**  
SQL Server starts the number at 1 and increases it by 1 for each new row.

15. **What is the difference between NULL, `DBNull.Value`, `Nothing`, and empty string?**  
SQL NULL is a missing database value, `DBNull.Value` represents that SQL NULL in .NET, `Nothing` means no object reference, and empty string means text with zero characters.

16. **What is the difference between `ExecuteReader`, `ExecuteScalar`, and `ExecuteNonQuery`?**  
`ExecuteReader` reads rows, `ExecuteScalar` returns one value, and `ExecuteNonQuery` runs commands that do not return a result table.

17. **Why use `StudentID` in UPDATE and DELETE WHERE clauses?**  
Because `StudentID` is unique, so the app updates or deletes exactly one intended row.

18. **What is the purpose of `Try...Catch`?**  
It handles runtime errors gracefully and lets the app show understandable messages instead of crashing.

19. **What is `SqlException`?**  
It is an exception type for SQL Server related errors.

20. **What happens from Save click until the record appears in the grid?**  
The click event validates input, creates a parameterized INSERT command, opens SQL Server connection, executes the command, reloads the records into a `DataTable`, binds the table to the DataGridView, and clears the form.

## Practical Interview Modifications

| Interview task | What to modify |
|---|---|
| Add a Course field | Add `Course NVARCHAR(100)` to SQL table, add Label/TextBox to designer, add parameter in INSERT and UPDATE, include column in SELECT and CellClick. |
| Search by StudentID | Add `StudentID = @StudentID` logic when the search text is numeric, or convert StudentID to text in the WHERE clause. |
| Prevent duplicate emails | Add a unique index in SQL or check with `SELECT COUNT(*)` before INSERT. |
| Sort students by name | Change `ORDER BY StudentID` to `ORDER BY StudentName`. |
| Show total number of students | Add a Label and use `SELECT COUNT(*) FROM dbo.Students` with `ExecuteScalar()`. |

## Common Errors And Troubleshooting

| Error | Likely cause | Diagnose | Fix |
|---|---|---|---|
| Login failed for user | Wrong authentication or permissions | Try connecting in SSMS with same account | Use Windows Authentication or grant database access |
| Server/instance not found | Wrong server name | Check SSMS server name | Replace `YOUR_SERVER_NAME` with actual instance |
| Cannot open database StudentDB | Database not created or no permission | Run `SELECT DB_ID('StudentDB')` | Run `StudentDB.sql` or fix permissions |
| Invalid object name 'Students' | Wrong database or table missing | Expand `StudentDB > Tables` in SSMS | Run the create table script |
| SQL connection timeout | SQL Server service unavailable or blocked | Test connection in SSMS | Start SQL Server service and verify instance |
| Certificate/trust error | Local SQL certificate not trusted | Read exception message | Keep `TrustServerCertificate=True` for local dev |
| NuGet SQL client package missing | Happens in modern .NET if using `Microsoft.Data.SqlClient` | Check imports and references | This project uses `System.Data.SqlClient`, so no NuGet package is needed |
| `SqlConnection` type not defined | Missing import or reference | Check top of `Form1.vb` | Add `Imports System.Data.SqlClient` and reference `System.Data` |
| Control name does not exist | Designer name mismatch | Check `Form1.Designer.vb` declarations | Rename control or update code |
| DataGridView not refreshing | Forgot to call `LoadStudents()` | Test after Save/Update/Delete | Call `LoadStudents()` after changes |
| DBNull conversion errors | Code assumes optional SQL value is not NULL | Check selected row data | Use `DBNull.Value` checks like `GetCellText()` |
| Events not firing | Handler not connected | Check `Handles btnSave.Click` | Ensure control is declared `WithEvents` and handler has `Handles` |

## Final 60-90 Second Interview Answer

"I built a Student Management System using VB.NET, WinForms, SQL Server, and ADO.NET. The form contains input controls for student details, buttons for Save, Update, Delete, Clear, and Search, and a DataGridView to display records. On form load, the application uses a SQL SELECT query with a `SqlDataAdapter` to fill a `DataTable`, and that table is bound to the DataGridView. For Create, Update, and Delete, I use `SqlConnection` and `SqlCommand` with parameterized queries, so the code avoids SQL injection and handles special characters correctly. I validate required fields like Student Name and Father Name before saving, and I handle optional fields using `DBNull.Value`. I also use `Try...Catch` blocks to show clear error messages for SQL errors and unexpected errors. The application updates and deletes records by `StudentID`, which is the primary key, so each operation targets the correct row. Overall, it is a complete CRUD desktop application that connects the UI, ADO.NET logic, and SQL Server database."

## Final Checklist

```text
[ ] Visual Studio project created
[ ] SQL Server database created
[ ] Students table created
[ ] Sample records inserted
[ ] Connection string configured
[ ] Form designed
[ ] Save works
[ ] Read/load works
[ ] Update works
[ ] Delete works
[ ] Search works
[ ] Clear works
[ ] Validation works
[ ] Parameterized queries used
[ ] Exception handling works
[ ] DataGridView refreshes correctly
```
