
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/04/2015 13:17:24
-- Generated from EDMX file: C:\Users\Nico\documents\visual studio 2013\Projects\Aug2015Backend\Aug2015Backend\Entities\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectAug];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacationSet'
CREATE TABLE [dbo].[VacationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AgeRangeSet'
CREATE TABLE [dbo].[AgeRangeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Min_leeftijd] nvarchar(max)  NOT NULL,
    [Max_leeftijd] nvarchar(max)  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VacationSet'
ALTER TABLE [dbo].[VacationSet]
ADD CONSTRAINT [PK_VacationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AgeRangeSet'
ALTER TABLE [dbo].[AgeRangeSet]
ADD CONSTRAINT [PK_AgeRangeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VacationId] in table 'AgeRangeSet'
ALTER TABLE [dbo].[AgeRangeSet]
ADD CONSTRAINT [FK_VacationAgeRange]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationAgeRange'
CREATE INDEX [IX_FK_VacationAgeRange]
ON [dbo].[AgeRangeSet]
    ([VacationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------