
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/11/2018 17:33:11
-- Generated from EDMX file: C:\c#\Lanit3\Lanit3.Model\dbModel.edmx
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
    [IdP] bigint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [birthdate] datetime  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'carSet'
CREATE TABLE [dbo].[carSet] (
    [IdC] bigint IDENTITY(1,1) NOT NULL,
    [model] nvarchar(max)  NOT NULL,
    [horsepower] int  NOT NULL,
    [Id] bigint  NOT NULL,
    [person_IdP] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdP] in table 'personSet'
ALTER TABLE [dbo].[personSet]
ADD CONSTRAINT [PK_personSet]
    PRIMARY KEY CLUSTERED ([IdP] ASC);
GO

-- Creating primary key on [IdC] in table 'carSet'
ALTER TABLE [dbo].[carSet]
ADD CONSTRAINT [PK_carSet]
    PRIMARY KEY CLUSTERED ([IdC] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [person_IdP] in table 'carSet'
ALTER TABLE [dbo].[carSet]
ADD CONSTRAINT [FK_personcar]
    FOREIGN KEY ([person_IdP])
    REFERENCES [dbo].[personSet]
        ([IdP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_personcar'
CREATE INDEX [IX_FK_personcar]
ON [dbo].[carSet]
    ([person_IdP]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------