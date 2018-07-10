
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/10/2018 14:21:40
-- Generated from EDMX file: C:\Users\bulya\source\repos\Lanit32\Lanit3.Model\dbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Lanit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_personcar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[carSet] DROP CONSTRAINT [FK_personcar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[personSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[personSet];
GO
IF OBJECT_ID(N'[dbo].[carSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[carSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'personSet'
CREATE TABLE [dbo].[personSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [birthdate] datetime  NOT NULL
);
GO

-- Creating table 'carSet'
CREATE TABLE [dbo].[carSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [model] nvarchar(max)  NOT NULL,
    [horsepower] int  NOT NULL,
    [person_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'personSet'
ALTER TABLE [dbo].[personSet]
ADD CONSTRAINT [PK_personSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'carSet'
ALTER TABLE [dbo].[carSet]
ADD CONSTRAINT [PK_carSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [person_Id] in table 'carSet'
ALTER TABLE [dbo].[carSet]
ADD CONSTRAINT [FK_personcar]
    FOREIGN KEY ([person_Id])
    REFERENCES [dbo].[personSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_personcar'
CREATE INDEX [IX_FK_personcar]
ON [dbo].[carSet]
    ([person_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------