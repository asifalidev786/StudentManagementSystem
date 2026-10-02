USE master;
GO

IF DB_ID(N'StudentDB') IS NULL
BEGIN
    CREATE DATABASE StudentDB;
END;
GO

USE StudentDB;
GO

IF OBJECT_ID(N'dbo.Students', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Students;
END;
GO

CREATE TABLE dbo.Students
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

INSERT INTO dbo.Students
    (StudentName, FatherName, Email, Phone, Gender, DateOfBirth, Address)
VALUES
    (N'Ali Raza', N'Muhammad Raza', N'ali.raza@gmail.com', N'0300-1234567', N'Male', '2004-03-14', N'House 12, Model Town, Lahore'),
    (N'Sarah Khan', N'Imran Khan', N'sarah.khan@hotmail.com', N'0312-9876543', N'Female', '2003-08-22', N'Gulshan-e-Iqbal, Karachi'),
    (N'Ahmed Hassan', N'Hassan Mahmood', N'ahmed.hassan@outlook.com', N'0333-7654321', N'Male', '2005-01-09', N'Satellite Town, Rawalpindi'),
    (N'Ayesha Malik', N'Tariq Malik', N'ayesha.malik@gmail.com', N'0345-2223344', N'Female', '2002-11-30', N'University Road, Peshawar'),
    (N'Usman Farooq', N'Farooq Ahmed', N'usman.farooq@yahoo.com', N'0301-5557788', N'Male', '2004-06-18', N'Cantt Area, Multan');
GO

SELECT *
FROM dbo.Students;
GO
