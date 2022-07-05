USE [Bugtracker]
GO

SET IDENTITY_INSERT [Member] ON;
GO

INSERT INTO [Member] ([Id_Member], [Pseudo], [Email], [Pswd_Hash], [Firstname], [Lastname])
 VALUES (1, 'Phil', 'philo@devteam.be', 'test12', 'Philomène', 'Philipov'),
 (2, 'Corentintin', 'corentin@gmail.com', 'test34', 'Corentin', 'De Conninck'),
 (3, 'Dom', 'dom@gmail.com', 'test56', 'Dominique', 'Lafitte');

SET IDENTITY_INSERT [Member] OFF;
GO