USE [Bugtracker]
GO

SET IDENTITY_INSERT [Member] ON;
GO

INSERT INTO [Member] ([Id_Member], [Pseudo], [Email], [Pswd_Hash], [Firstname], [Lastname])
 VALUES (1, 'Phil', 'test', 'philo@devteam.be', 'Philomène', 'Philipov'),
 (2, 'Corentintin', 'test2', 'corentin@gmail.com', 'Corentin', 'De Coning');

SET IDENTITY_INSERT [Member] OFF;
GO