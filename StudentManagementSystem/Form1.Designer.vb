Option Strict On
Option Explicit On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpStudentInfo = New System.Windows.Forms.GroupBox()
        Me.lblStudentID = New System.Windows.Forms.Label()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.txtStudentName = New System.Windows.Forms.TextBox()
        Me.lblFatherName = New System.Windows.Forms.Label()
        Me.txtFatherName = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.lblDateOfBirth = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvStudents = New System.Windows.Forms.DataGridView()
        Me.grpStudentInfo.SuspendLayout()
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpStudentInfo
        '
        Me.grpStudentInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStudentInfo.Controls.Add(Me.lblStudentID)
        Me.grpStudentInfo.Controls.Add(Me.txtStudentID)
        Me.grpStudentInfo.Controls.Add(Me.lblStudentName)
        Me.grpStudentInfo.Controls.Add(Me.txtStudentName)
        Me.grpStudentInfo.Controls.Add(Me.lblFatherName)
        Me.grpStudentInfo.Controls.Add(Me.txtFatherName)
        Me.grpStudentInfo.Controls.Add(Me.lblEmail)
        Me.grpStudentInfo.Controls.Add(Me.txtEmail)
        Me.grpStudentInfo.Controls.Add(Me.lblPhone)
        Me.grpStudentInfo.Controls.Add(Me.txtPhone)
        Me.grpStudentInfo.Controls.Add(Me.lblGender)
        Me.grpStudentInfo.Controls.Add(Me.cmbGender)
        Me.grpStudentInfo.Controls.Add(Me.lblDateOfBirth)
        Me.grpStudentInfo.Controls.Add(Me.dtpDateOfBirth)
        Me.grpStudentInfo.Controls.Add(Me.lblAddress)
        Me.grpStudentInfo.Controls.Add(Me.txtAddress)
        Me.grpStudentInfo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpStudentInfo.Location = New System.Drawing.Point(18, 16)
        Me.grpStudentInfo.Name = "grpStudentInfo"
        Me.grpStudentInfo.Size = New System.Drawing.Size(1048, 210)
        Me.grpStudentInfo.TabIndex = 0
        Me.grpStudentInfo.TabStop = False
        Me.grpStudentInfo.Text = "Student Information"
        '
        'lblStudentID
        '
        Me.lblStudentID.AutoSize = True
        Me.lblStudentID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStudentID.Location = New System.Drawing.Point(18, 36)
        Me.lblStudentID.Name = "lblStudentID"
        Me.lblStudentID.Size = New System.Drawing.Size(64, 15)
        Me.lblStudentID.TabIndex = 0
        Me.lblStudentID.Text = "Student ID"
        '
        'txtStudentID
        '
        Me.txtStudentID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStudentID.Location = New System.Drawing.Point(118, 32)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.ReadOnly = True
        Me.txtStudentID.Size = New System.Drawing.Size(180, 23)
        Me.txtStudentID.TabIndex = 1
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStudentName.Location = New System.Drawing.Point(18, 75)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(82, 15)
        Me.lblStudentName.TabIndex = 2
        Me.lblStudentName.Text = "Student Name"
        '
        'txtStudentName
        '
        Me.txtStudentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStudentName.Location = New System.Drawing.Point(118, 71)
        Me.txtStudentName.Name = "txtStudentName"
        Me.txtStudentName.Size = New System.Drawing.Size(180, 23)
        Me.txtStudentName.TabIndex = 3
        '
        'lblFatherName
        '
        Me.lblFatherName.AutoSize = True
        Me.lblFatherName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFatherName.Location = New System.Drawing.Point(18, 114)
        Me.lblFatherName.Name = "lblFatherName"
        Me.lblFatherName.Size = New System.Drawing.Size(78, 15)
        Me.lblFatherName.TabIndex = 4
        Me.lblFatherName.Text = "Father Name"
        '
        'txtFatherName
        '
        Me.txtFatherName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFatherName.Location = New System.Drawing.Point(118, 110)
        Me.txtFatherName.Name = "txtFatherName"
        Me.txtFatherName.Size = New System.Drawing.Size(180, 23)
        Me.txtFatherName.TabIndex = 5
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmail.Location = New System.Drawing.Point(18, 153)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(36, 15)
        Me.lblEmail.TabIndex = 6
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(118, 149)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(180, 23)
        Me.txtEmail.TabIndex = 7
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPhone.Location = New System.Drawing.Point(333, 36)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(41, 15)
        Me.lblPhone.TabIndex = 8
        Me.lblPhone.Text = "Phone"
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPhone.Location = New System.Drawing.Point(432, 32)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(180, 23)
        Me.txtPhone.TabIndex = 9
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblGender.Location = New System.Drawing.Point(333, 75)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(45, 15)
        Me.lblGender.TabIndex = 10
        Me.lblGender.Text = "Gender"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(432, 71)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(180, 23)
        Me.cmbGender.TabIndex = 11
        '
        'lblDateOfBirth
        '
        Me.lblDateOfBirth.AutoSize = True
        Me.lblDateOfBirth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDateOfBirth.Location = New System.Drawing.Point(333, 114)
        Me.lblDateOfBirth.Name = "lblDateOfBirth"
        Me.lblDateOfBirth.Size = New System.Drawing.Size(75, 15)
        Me.lblDateOfBirth.TabIndex = 12
        Me.lblDateOfBirth.Text = "Date of Birth"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Checked = False
        Me.dtpDateOfBirth.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(432, 110)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.ShowCheckBox = True
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(180, 23)
        Me.dtpDateOfBirth.TabIndex = 13
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAddress.Location = New System.Drawing.Point(647, 36)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(49, 15)
        Me.lblAddress.TabIndex = 14
        Me.lblAddress.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAddress.Location = New System.Drawing.Point(721, 32)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(305, 140)
        Me.txtAddress.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(18, 244)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 34)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(126, 244)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(96, 34)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(234, 244)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 34)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(342, 244)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(96, 34)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearch.Location = New System.Drawing.Point(718, 254)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(42, 15)
        Me.lblSearch.TabIndex = 5
        Me.lblSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(772, 250)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(194, 23)
        Me.txtSearch.TabIndex = 6
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(976, 244)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 34)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'dgvStudents
        '
        Me.dgvStudents.AllowUserToAddRows = False
        Me.dgvStudents.AllowUserToDeleteRows = False
        Me.dgvStudents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStudents.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudents.Location = New System.Drawing.Point(18, 298)
        Me.dgvStudents.MultiSelect = False
        Me.dgvStudents.Name = "dgvStudents"
        Me.dgvStudents.ReadOnly = True
        Me.dgvStudents.RowHeadersVisible = False
        Me.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudents.Size = New System.Drawing.Size(1048, 374)
        Me.dgvStudents.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1084, 691)
        Me.Controls.Add(Me.dgvStudents)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpStudentInfo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(950, 650)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Management System"
        Me.grpStudentInfo.ResumeLayout(False)
        Me.grpStudentInfo.PerformLayout()
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents grpStudentInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblStudentID As System.Windows.Forms.Label
    Friend WithEvents txtStudentID As System.Windows.Forms.TextBox
    Friend WithEvents lblStudentName As System.Windows.Forms.Label
    Friend WithEvents txtStudentName As System.Windows.Forms.TextBox
    Friend WithEvents lblFatherName As System.Windows.Forms.Label
    Friend WithEvents txtFatherName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateOfBirth As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvStudents As System.Windows.Forms.DataGridView
End Class
