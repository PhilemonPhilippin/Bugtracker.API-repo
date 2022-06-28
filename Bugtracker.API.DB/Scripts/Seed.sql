USE [Bugtracker]
GO

SET IDENTITY_INSERT [Member] ON;
GO

INSERT INTO [Member] ([Id_Member], [Login], [Password_Hash], [Email_Address], [Firstname], [Lastname])
 VALUES (1, 'Phil', 'passwordtest', 'philo@devteam.be', 'Philomène', 'Philipov'),
 (2, 'Corentintin', 'passwordtest2', 'corentin@gmail.com', 'Corentin', 'De Coning');

SET IDENTITY_INSERT [Member] OFF;
GO