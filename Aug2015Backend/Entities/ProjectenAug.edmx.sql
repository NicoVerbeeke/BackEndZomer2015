
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2015 18:51:33
-- Generated from EDMX file: C:\Users\Nico\Documents\ProjectenAugustus2015\BackEndZomer2015\Aug2015Backend\Entities\ProjectenAug.edmx
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

IF OBJECT_ID(N'[dbo].[FK_VacationAgeRange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AgeRangeSet] DROP CONSTRAINT [FK_VacationAgeRange];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_VacationComment];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationContactInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactInformationSet] DROP CONSTRAINT [FK_VacationContactInformation];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupAgeRange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_GroupAgeRange];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VacationSet] DROP CONSTRAINT [FK_VacationLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPeriod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PeriodSet] DROP CONSTRAINT [FK_VacationPeriod];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_VacationGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPictureModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PictureSet] DROP CONSTRAINT [FK_VacationPictureModel];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationCoverPicture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PictureSet] DROP CONSTRAINT [FK_VacationCoverPicture];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VacationSet] DROP CONSTRAINT [FK_VacationPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationIncludedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludedItemSet] DROP CONSTRAINT [FK_VacationIncludedItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[VacationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VacationSet];
GO
IF OBJECT_ID(N'[dbo].[AgeRangeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgeRangeSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[ContactInformationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactInformationSet];
GO
IF OBJECT_ID(N'[dbo].[GroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupSet];
GO
IF OBJECT_ID(N'[dbo].[LocationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationSet];
GO
IF OBJECT_ID(N'[dbo].[PeriodSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodSet];
GO
IF OBJECT_ID(N'[dbo].[PictureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PictureSet];
GO
IF OBJECT_ID(N'[dbo].[PriceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceSet];
GO
IF OBJECT_ID(N'[dbo].[IncludedItemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncludedItemSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacationSet'
CREATE TABLE [dbo].[VacationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL,
    [NumberOfParticipants] int  NOT NULL,
    [PromoText] nvarchar(max)  NOT NULL,
    [Location_Id] int  NOT NULL,
    [Cost_Id] int  NOT NULL
);
GO

-- Creating table 'AgeRangeSet'
CREATE TABLE [dbo].[AgeRangeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Min_leeftijd] int  NOT NULL,
    [Max_leeftijd] int  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NULL,
    [Text] nvarchar(max)  NULL,
    [Url] nvarchar(max)  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'ContactInformationSet'
CREATE TABLE [dbo].[ContactInformationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'GroupSet'
CREATE TABLE [dbo].[GroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupNr] int  NOT NULL,
    [AgeRangeId] int  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'LocationSet'
CREATE TABLE [dbo].[LocationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VacationDomain] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PeriodSet'
CREATE TABLE [dbo].[PeriodSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PeriodNr] int  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'PictureSet'
CREATE TABLE [dbo].[PictureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [VacationId] int  NOT NULL,
    [VacationCoverPicture_PictureModel_Id] int  NOT NULL
);
GO

-- Creating table 'PriceSet'
CREATE TABLE [dbo].[PriceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BasePrice] float  NOT NULL,
    [SingleStarPrice] float  NOT NULL,
    [DoubleStarPrice] float  NOT NULL
);
GO

-- Creating table 'IncludedItemSet'
CREATE TABLE [dbo].[IncludedItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Item] nvarchar(max)  NOT NULL,
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

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactInformationSet'
ALTER TABLE [dbo].[ContactInformationSet]
ADD CONSTRAINT [PK_ContactInformationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [PK_GroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationSet'
ALTER TABLE [dbo].[LocationSet]
ADD CONSTRAINT [PK_LocationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodSet'
ALTER TABLE [dbo].[PeriodSet]
ADD CONSTRAINT [PK_PeriodSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [PK_PictureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PriceSet'
ALTER TABLE [dbo].[PriceSet]
ADD CONSTRAINT [PK_PriceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IncludedItemSet'
ALTER TABLE [dbo].[IncludedItemSet]
ADD CONSTRAINT [PK_IncludedItemSet]
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

-- Creating foreign key on [VacationId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_VacationComment]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationComment'
CREATE INDEX [IX_FK_VacationComment]
ON [dbo].[CommentSet]
    ([VacationId]);
GO

-- Creating foreign key on [Vacation_Id] in table 'ContactInformationSet'
ALTER TABLE [dbo].[ContactInformationSet]
ADD CONSTRAINT [FK_VacationContactInformation]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationContactInformation'
CREATE INDEX [IX_FK_VacationContactInformation]
ON [dbo].[ContactInformationSet]
    ([Vacation_Id]);
GO

-- Creating foreign key on [AgeRangeId] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_GroupAgeRange]
    FOREIGN KEY ([AgeRangeId])
    REFERENCES [dbo].[AgeRangeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupAgeRange'
CREATE INDEX [IX_FK_GroupAgeRange]
ON [dbo].[GroupSet]
    ([AgeRangeId]);
GO

-- Creating foreign key on [Location_Id] in table 'VacationSet'
ALTER TABLE [dbo].[VacationSet]
ADD CONSTRAINT [FK_VacationLocation]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[LocationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationLocation'
CREATE INDEX [IX_FK_VacationLocation]
ON [dbo].[VacationSet]
    ([Location_Id]);
GO

-- Creating foreign key on [VacationId] in table 'PeriodSet'
ALTER TABLE [dbo].[PeriodSet]
ADD CONSTRAINT [FK_VacationPeriod]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPeriod'
CREATE INDEX [IX_FK_VacationPeriod]
ON [dbo].[PeriodSet]
    ([VacationId]);
GO

-- Creating foreign key on [VacationId] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_VacationGroup]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationGroup'
CREATE INDEX [IX_FK_VacationGroup]
ON [dbo].[GroupSet]
    ([VacationId]);
GO

-- Creating foreign key on [VacationId] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [FK_VacationPictureModel]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPictureModel'
CREATE INDEX [IX_FK_VacationPictureModel]
ON [dbo].[PictureSet]
    ([VacationId]);
GO

-- Creating foreign key on [VacationCoverPicture_PictureModel_Id] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [FK_VacationCoverPicture]
    FOREIGN KEY ([VacationCoverPicture_PictureModel_Id])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationCoverPicture'
CREATE INDEX [IX_FK_VacationCoverPicture]
ON [dbo].[PictureSet]
    ([VacationCoverPicture_PictureModel_Id]);
GO

-- Creating foreign key on [Cost_Id] in table 'VacationSet'
ALTER TABLE [dbo].[VacationSet]
ADD CONSTRAINT [FK_VacationPrice]
    FOREIGN KEY ([Cost_Id])
    REFERENCES [dbo].[PriceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPrice'
CREATE INDEX [IX_FK_VacationPrice]
ON [dbo].[VacationSet]
    ([Cost_Id]);
GO

-- Creating foreign key on [VacationId] in table 'IncludedItemSet'
ALTER TABLE [dbo].[IncludedItemSet]
ADD CONSTRAINT [FK_VacationIncludedItem]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[VacationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationIncludedItem'
CREATE INDEX [IX_FK_VacationIncludedItem]
ON [dbo].[IncludedItemSet]
    ([VacationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------