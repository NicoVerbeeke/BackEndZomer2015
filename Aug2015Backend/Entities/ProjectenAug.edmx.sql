
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/21/2015 19:29:18
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

IF OBJECT_ID(N'[dbo].[FK_VacationComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_VacationComment];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationContactInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactInformations] DROP CONSTRAINT [FK_VacationContactInformation];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_VacationLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPeriod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Periods] DROP CONSTRAINT [FK_VacationPeriod];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationCoverPicture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pictures] DROP CONSTRAINT [FK_VacationCoverPicture];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_VacationPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationIncludedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncludedItems] DROP CONSTRAINT [FK_VacationIncludedItem];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationPicture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pictures] DROP CONSTRAINT [FK_VacationPicture];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationSubscription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscriptions] DROP CONSTRAINT [FK_VacationSubscription];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSubscription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscriptions] DROP CONSTRAINT [FK_UserSubscription];
GO
IF OBJECT_ID(N'[dbo].[FK_VacationAgeRange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AgeRanges] DROP CONSTRAINT [FK_VacationAgeRange];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Vacations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vacations];
GO
IF OBJECT_ID(N'[dbo].[AgeRanges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgeRanges];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[ContactInformations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactInformations];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Periods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Periods];
GO
IF OBJECT_ID(N'[dbo].[Pictures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pictures];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[IncludedItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncludedItems];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Subscriptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscriptions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Vacations'
CREATE TABLE [dbo].[Vacations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL,
    [NumberOfParticipants] int  NOT NULL,
    [PromoText] nvarchar(max)  NOT NULL,
    [Tax_Benefit] bit  NOT NULL
);
GO

-- Creating table 'AgeRanges'
CREATE TABLE [dbo].[AgeRanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Min_leeftijd] int  NOT NULL,
    [Max_leeftijd] int  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NULL,
    [Text] nvarchar(max)  NULL,
    [Url] nvarchar(max)  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'ContactInformations'
CREATE TABLE [dbo].[ContactInformations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VacationDomain] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'Periods'
CREATE TABLE [dbo].[Periods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PeriodNr] int  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'Pictures'
CREATE TABLE [dbo].[Pictures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titel] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [VacationId] int  NULL,
    [VacationCoverPicture_PictureModel_Id] int  NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BasePrice] float  NOT NULL,
    [SingleStarPrice] float  NOT NULL,
    [DoubleStarPrice] float  NOT NULL,
    [Vacation_Id] int  NOT NULL
);
GO

-- Creating table 'IncludedItems'
CREATE TABLE [dbo].[IncludedItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Item] nvarchar(max)  NOT NULL,
    [VacationId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RNR] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [HouseNr] nvarchar(max)  NOT NULL,
    [Bus] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [AuthUserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Subscriptions'
CREATE TABLE [dbo].[Subscriptions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VacationId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [RNR] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [HouseNr] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Name_Mother] nvarchar(max)  NOT NULL,
    [Name_Father] nvarchar(max)  NOT NULL,
    [RNR_Mother] nvarchar(max)  NOT NULL,
    [RNR_Father] nvarchar(max)  NOT NULL,
    [TelephoneNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [FacturationAddress] nvarchar(max)  NOT NULL,
    [FacturationName] nvarchar(max)  NOT NULL,
    [Payed] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Vacations'
ALTER TABLE [dbo].[Vacations]
ADD CONSTRAINT [PK_Vacations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AgeRanges'
ALTER TABLE [dbo].[AgeRanges]
ADD CONSTRAINT [PK_AgeRanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactInformations'
ALTER TABLE [dbo].[ContactInformations]
ADD CONSTRAINT [PK_ContactInformations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Periods'
ALTER TABLE [dbo].[Periods]
ADD CONSTRAINT [PK_Periods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [PK_Pictures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IncludedItems'
ALTER TABLE [dbo].[IncludedItems]
ADD CONSTRAINT [PK_IncludedItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [PK_Subscriptions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VacationId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_VacationComment]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationComment'
CREATE INDEX [IX_FK_VacationComment]
ON [dbo].[Comments]
    ([VacationId]);
GO

-- Creating foreign key on [Vacation_Id] in table 'ContactInformations'
ALTER TABLE [dbo].[ContactInformations]
ADD CONSTRAINT [FK_VacationContactInformation]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationContactInformation'
CREATE INDEX [IX_FK_VacationContactInformation]
ON [dbo].[ContactInformations]
    ([Vacation_Id]);
GO

-- Creating foreign key on [Vacation_Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_VacationLocation]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationLocation'
CREATE INDEX [IX_FK_VacationLocation]
ON [dbo].[Locations]
    ([Vacation_Id]);
GO

-- Creating foreign key on [Vacation_Id] in table 'Periods'
ALTER TABLE [dbo].[Periods]
ADD CONSTRAINT [FK_VacationPeriod]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPeriod'
CREATE INDEX [IX_FK_VacationPeriod]
ON [dbo].[Periods]
    ([Vacation_Id]);
GO

-- Creating foreign key on [VacationCoverPicture_PictureModel_Id] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [FK_VacationCoverPicture]
    FOREIGN KEY ([VacationCoverPicture_PictureModel_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationCoverPicture'
CREATE INDEX [IX_FK_VacationCoverPicture]
ON [dbo].[Pictures]
    ([VacationCoverPicture_PictureModel_Id]);
GO

-- Creating foreign key on [Vacation_Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_VacationPrice]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPrice'
CREATE INDEX [IX_FK_VacationPrice]
ON [dbo].[Prices]
    ([Vacation_Id]);
GO

-- Creating foreign key on [VacationId] in table 'IncludedItems'
ALTER TABLE [dbo].[IncludedItems]
ADD CONSTRAINT [FK_VacationIncludedItem]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationIncludedItem'
CREATE INDEX [IX_FK_VacationIncludedItem]
ON [dbo].[IncludedItems]
    ([VacationId]);
GO

-- Creating foreign key on [VacationId] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [FK_VacationPicture]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationPicture'
CREATE INDEX [IX_FK_VacationPicture]
ON [dbo].[Pictures]
    ([VacationId]);
GO

-- Creating foreign key on [VacationId] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [FK_VacationSubscription]
    FOREIGN KEY ([VacationId])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationSubscription'
CREATE INDEX [IX_FK_VacationSubscription]
ON [dbo].[Subscriptions]
    ([VacationId]);
GO

-- Creating foreign key on [UserId] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [FK_UserSubscription]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSubscription'
CREATE INDEX [IX_FK_UserSubscription]
ON [dbo].[Subscriptions]
    ([UserId]);
GO

-- Creating foreign key on [Vacation_Id] in table 'AgeRanges'
ALTER TABLE [dbo].[AgeRanges]
ADD CONSTRAINT [FK_VacationAgeRange]
    FOREIGN KEY ([Vacation_Id])
    REFERENCES [dbo].[Vacations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacationAgeRange'
CREATE INDEX [IX_FK_VacationAgeRange]
ON [dbo].[AgeRanges]
    ([Vacation_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------