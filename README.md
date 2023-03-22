# Web APIs with .NET

## March 20-22 2023

This will be a _monorepo_ for all the code and notes we create for the Web APIs with .NET Course.

The instructor will put all of his code/notes in the `instructor` folder. Each student will _fork_ this repository and put their code in the root of this repository (this will be explained in class).

You can periodically pull the instructor's code into your repo (for reference, copying stuff, etc.) as well as his notes by:

- Asking the instructor to "push" his changes (if he hasn't done so recently)
- Follow the instructions for [syncing your repository](./instructor/notes/00-syncing.md).

We started class. 

Notes: 

Entity Framework
================

Commands to work with migration

[12:19 PM] Jeff Gonzalez
add-migration "Initial"

[12:23 PM] Jeff Gonzalez
update-database

================================
Jimmy Bogard (Automapper) Check him out

script-migration -> Give to DBA to create the tables

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Departments] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(5) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Department] nvarchar(max) NOT NULL,
    [HomePhone] nvarchar(max) NOT NULL,
    [HomeEmail] nvarchar(max) NOT NULL,
    [WorkPhone] nvarchar(max) NOT NULL,
    [WorkEmail] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [HiringRequests] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Note] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ProposedSalary] decimal(18,2) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_HiringRequests] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Departments_Code] ON [Departments] ([Code]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230322204824_HiringRequestFinal', N'7.0.4');
GO

COMMIT;
GO