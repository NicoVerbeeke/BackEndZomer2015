SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectAug];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

Insert into Vacations([Titel], [NumberOfParticipants], [PromoText], [Tax_Benefit]) values ('kinderboerderij', 30, 'Op deze kinderboerderijvakantie verblijf je echt tussen de dieren.
Samen met de vele vriendjes en onze monitoren leer je op een plezante manier het leven op een echte boerderij kennen.
Zo staan het voederen van de dieren, een ritje met de pony, het bakken van je eigen broodjes en nog zoveel meer op het programma.
Alle dieren op de boerderij wachten vol ongeduld op jouw knuffels en goede zorgen.
Wees er dus als de kippen bij en schrijf je snel in voor deze superweek!', 1);

Insert into AgeRanges([Min_leeftijd], [Max_leeftijd], [Vacation_Id]) values(4, 6, 1);

Insert into Locations([VacationDomain], [City], [Vacation_Id]) values ('Diggie vzw', 'Brakel', 1);

Insert into Periods([PeriodNr], [DateStart], [DateEnd], [Vacation_Id]) values (1, '2014-08-12T04:31:20', '2014-08-12T04:31:20', 1);

Insert into Prices([BasePrice], [SingleStarPrice], [DoubleStarPrice], [Vacation_Id]) values (190, 160, 130, 1);

Insert into IncludedItems([Item], [VacationId]) values ('Heenreis per autocar', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Terugreis met eigen vervoer', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Verblijf in volpension, drank bij de maaltijden', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Dagelijks vieruurtje', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Begeleiding door ervaren, gebrevetteerde monitoren', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Volledig animatiepakket incl. spelmateriaal', 1);
Insert into IncludedItems([Item], [VacationId]) values ('Ongevallenverzekering', 1);

Insert into ContactInformations([Tel], [Email], [Vacation_Id]) values ('056/27.47.00', 'joetz.west@joetz.be', 1);
Insert into Comments([Titel], [Text], [Url], [VacationId]) values ('Algemene voorwaarden', 'Lees de algemene voorwaarden achteraan in deze brochure', 'http://www.joetz.be/vakanties/pages/algemene-voorwaarden.aspx', 1);

Insert into Pictures([Titel], [Description], [Url], [VacationId], [VacationCoverPicture_PictureModel_Id]) values ('Look mom', 'look mom', 'https://dl.dropboxusercontent.com/u/33161611/HoGent/joetz/md/Kinderboerderij.jpg', 1, null);
Insert into Pictures([Titel], [Description], [Url], [VacationId], [VacationCoverPicture_PictureModel_Id]) values ('No Hands', 'no hands', 'http://www.tomesiaingram.com/wp-content/uploads/2011/06/NoHands1.jpg', 1, null);
Insert into Pictures([Titel], [Description], [Url], [VacationId], [VacationCoverPicture_PictureModel_Id]) values ('Kinderboerderij', 'kinderboerderij', 'Kinderboerderij.jpg', null, 1);


