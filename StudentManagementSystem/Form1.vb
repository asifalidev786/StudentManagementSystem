Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
        ClearFields()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Const sql As String =
            "INSERT INTO dbo.Students " &
            "(StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address) " &
            "VALUES (@StudentName, @FatherName, @Email, @Phone, @Gender, @DateOfBirth, @Address);"

        Try
            Using connection As New SqlConnection(GetConnectionString())
                Using command As New SqlCommand(sql, connection)
                    AddStudentParameters(command)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Student saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadStudents()
            ClearFields()
        Catch ex As SqlException
            MessageBox.Show("A SQL Server error occurred while saving the student:" & Environment.NewLine & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while saving the student:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MessageBox.Show("Please select a student from the table before updating.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateInputs() Then
            Return
        End If

        Const sql As String =
            "UPDATE dbo.Students SET " &
            "StudentName = @StudentName, " &
            "FatherName = @FatherName, " &
            "Email = @Email, " &
            "Phone = @Phone, " &
            "Gender = @Gender, " &
            "DateOfBirth = @DateOfBirth, " &
            "Address = @Address " &
            "WHERE StudentID = @StudentID;"

        Try
            Using connection As New SqlConnection(GetConnectionString())
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(txtStudentID.Text)
                    AddStudentParameters(command)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        MessageBox.Show("No student was updated. The selected student may no longer exist.",
                                        "Update Not Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using
            End Using

            MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadStudents()
            ClearFields()
        Catch ex As SqlException
            MessageBox.Show("A SQL Server error occurred while updating the student:" & Environment.NewLine & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while updating the student:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MessageBox.Show("Please select a student from the table before deleting.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this student?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        Const sql As String = "DELETE FROM dbo.Students WHERE StudentID = @StudentID;"

        Try
            Using connection As New SqlConnection(GetConnectionString())
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(txtStudentID.Text)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        MessageBox.Show("No student was deleted. The selected student may no longer exist.",
                                        "Delete Not Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using
            End Using

            MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadStudents()
            ClearFields()
        Catch ex As SqlException
            MessageBox.Show("A SQL Server error occurred while deleting the student:" & Environment.NewLine & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while deleting the student:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
        LoadStudents()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchStudents()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchStudents()
        End If
    End Sub

    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvStudents.Rows(e.RowIndex)

        txtStudentID.Text = GetCellText(row, "StudentID")
        txtStudentName.Text = GetCellText(row, "StudentName")
        txtFatherName.Text = GetCellText(row, "FatherName")
        txtEmail.Text = GetCellText(row, "Email")
        txtPhone.Text = GetCellText(row, "Phone")
        txtAddress.Text = GetCellText(row, "Address")

        Dim gender As String = GetCellText(row, "Gender")
        If String.IsNullOrWhiteSpace(gender) Then
            cmbGender.SelectedIndex = -1
        Else
            cmbGender.SelectedItem = gender
        End If

        Dim dateValue As Object = row.Cells("DateOfBirth").Value
        If dateValue Is Nothing OrElse dateValue Is DBNull.Value Then
            dtpDateOfBirth.Checked = False
            dtpDateOfBirth.Value = Date.Today
        Else
            dtpDateOfBirth.Checked = True
            dtpDateOfBirth.Value = Convert.ToDateTime(dateValue)
        End If
    End Sub

    Private Sub LoadStudents()
        Const sql As String =
            "SELECT StudentID, StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address " &
            "FROM dbo.Students " &
            "ORDER BY StudentID;"

        Try
            Using connection As New SqlConnection(GetConnectionString())
                Using adapter As New SqlDataAdapter(sql, connection)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvStudents.DataSource = table
                End Using
            End Using

            FormatStudentGrid()
        Catch ex As SqlException
            MessageBox.Show("A SQL Server error occurred while loading students:" & Environment.NewLine & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while loading students:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchStudents()
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadStudents()
            Return
        End If

        Const sql As String =
            "SELECT StudentID, StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address " &
            "FROM dbo.Students " &
            "WHERE StudentName LIKE @Search " &
            "OR FatherName LIKE @Search " &
            "OR Email LIKE @Search " &
            "OR Phone LIKE @Search " &
            "ORDER BY StudentID;"

        Try
            Using connection As New SqlConnection(GetConnectionString())
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.Add("@Search", SqlDbType.NVarChar, 150).Value =
                        "%" & txtSearch.Text.Trim() & "%"

                    Using adapter As New SqlDataAdapter(command)
                        Dim table As New DataTable()
                        adapter.Fill(table)
                        dgvStudents.DataSource = table
                    End Using
                End Using
            End Using

            FormatStudentGrid()
        Catch ex As SqlException
            MessageBox.Show("A SQL Server error occurred while searching students:" & Environment.NewLine & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while searching students:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtStudentID.Clear()
        txtStudentName.Clear()
        txtFatherName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        cmbGender.SelectedIndex = -1
        dtpDateOfBirth.Value = Date.Today
        dtpDateOfBirth.Checked = False
        txtSearch.Clear()

        If dgvStudents.DataSource IsNot Nothing Then
            dgvStudents.ClearSelection()
        End If

        txtStudentName.Focus()
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtStudentName.Text) Then
            MessageBox.Show("Student Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFatherName.Text) Then
            MessageBox.Show("Father Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFatherName.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso Not IsValidSimpleEmail(txtEmail.Text.Trim()) Then
            MessageBox.Show("Please enter a valid email address, for example ali.raza@gmail.com.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function GetConnectionString() As String
        Return "Server=localhost\SQLEXPRESS01;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
    End Function

    Private Sub AddStudentParameters(command As SqlCommand)
        command.Parameters.Add("@StudentName", SqlDbType.NVarChar, 100).Value = txtStudentName.Text.Trim()
        command.Parameters.Add("@FatherName", SqlDbType.NVarChar, 100).Value = txtFatherName.Text.Trim()
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = GetNullableText(txtEmail.Text)
        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 30).Value = GetNullableText(txtPhone.Text)
        command.Parameters.Add("@Gender", SqlDbType.NVarChar, 20).Value = GetNullableText(If(cmbGender.SelectedItem Is Nothing, "", cmbGender.SelectedItem.ToString()))
        command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = GetNullableDate()
        command.Parameters.Add("@Address", SqlDbType.NVarChar, 250).Value = GetNullableText(txtAddress.Text)
    End Sub

    Private Function GetNullableText(value As String) As Object
        If String.IsNullOrWhiteSpace(value) Then
            Return DBNull.Value
        End If

        Return value.Trim()
    End Function

    Private Function GetNullableDate() As Object
        If Not dtpDateOfBirth.Checked Then
            Return DBNull.Value
        End If

        Return dtpDateOfBirth.Value.Date
    End Function

    Private Function GetCellText(row As DataGridViewRow, columnName As String) As String
        Dim value As Object = row.Cells(columnName).Value

        If value Is Nothing OrElse value Is DBNull.Value Then
            Return String.Empty
        End If

        Return value.ToString()
    End Function

    Private Function IsValidSimpleEmail(email As String) As Boolean
        Dim atIndex As Integer = email.IndexOf("@"c)
        Dim lastDotIndex As Integer = email.LastIndexOf("."c)

        Return atIndex > 0 AndAlso lastDotIndex > atIndex + 1 AndAlso lastDotIndex < email.Length - 1
    End Function

    Private Sub FormatStudentGrid()
        If dgvStudents.Columns.Contains("StudentID") Then
            dgvStudents.Columns("StudentID").HeaderText = "Student ID"
            dgvStudents.Columns("StudentID").Width = 80
        End If

        If dgvStudents.Columns.Contains("StudentName") Then
            dgvStudents.Columns("StudentName").HeaderText = "Student Name"
        End If

        If dgvStudents.Columns.Contains("FatherName") Then
            dgvStudents.Columns("FatherName").HeaderText = "Father Name"
        End If

        If dgvStudents.Columns.Contains("DateOfBirth") Then
            dgvStudents.Columns("DateOfBirth").HeaderText = "Date of Birth"
            dgvStudents.Columns("DateOfBirth").DefaultCellStyle.Format = "yyyy-MM-dd"
        End If

        dgvStudents.ClearSelection()
    End Sub
End Class
