-- MSSQL

CREATE DATABASE [livecode];


CREATE TABLE [users] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(255) NOT NULL,
    [createdAt] DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [clients] (
    [id] INT IDENTITY(1,1) PRIMARY KEY,
    [name] NVARCHAR(255) NOT NULL,
    [email] NVARCHAR(255) NOT NULL UNIQUE,
    [userId] INT NOT NULL,

    FOREIGN KEY ([userId]) REFERENCES [users]([id])
);