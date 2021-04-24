
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2021 12:29:02
-- Generated from EDMX file: C:\Users\annem\OneDrive\Dokumenter\cshar\Lektioner\Dag9\ModelFirstEFStudentsGrades\ModelFirstEFStudentsGrades\Model\StudentsGradesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentsGradesModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentsGrades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradesSet] DROP CONSTRAINT [FK_StudentsGrades];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsSet];
GO
IF OBJECT_ID(N'[dbo].[GradesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GradesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentsSet'
CREATE TABLE [dbo].[StudentsSet] (
    [StudentsId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GradesSet'
CREATE TABLE [dbo].[GradesSet] (
    [GradesId] int IDENTITY(1,1) NOT NULL,
    [Grade] int  NOT NULL,
    [Course] nvarchar(max)  NOT NULL,
    [test] nvarchar(max)  NOT NULL,
    [StudentsId_StudentsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [StudentsId] in table 'StudentsSet'
ALTER TABLE [dbo].[StudentsSet]
ADD CONSTRAINT [PK_StudentsSet]
    PRIMARY KEY CLUSTERED ([StudentsId] ASC);
GO

-- Creating primary key on [GradesId] in table 'GradesSet'
ALTER TABLE [dbo].[GradesSet]
ADD CONSTRAINT [PK_GradesSet]
    PRIMARY KEY CLUSTERED ([GradesId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StudentsId_StudentsId] in table 'GradesSet'
ALTER TABLE [dbo].[GradesSet]
ADD CONSTRAINT [FK_StudentsGrades]
    FOREIGN KEY ([StudentsId_StudentsId])
    REFERENCES [dbo].[StudentsSet]
        ([StudentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsGrades'
CREATE INDEX [IX_FK_StudentsGrades]
ON [dbo].[GradesSet]
    ([StudentsId_StudentsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------