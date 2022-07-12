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

SET IDENTITY_INSERT [Project] ON;
GO

INSERT INTO [Project] ([Id_Project], [Name], [Description], [Manager])
 VALUES (1,'Four in a row', 'A game of Four in which you win after setting 4 coins in a row.', 1),
 (2,'Hangman game', 'A game of Hangman in which you must find a word by guessing letters.', 2),
 (3,'HeroesVsMonster', 'A game of Heroes Vs Monster in which you are a hero and you fight monsters.', 3);

SET IDENTITY_INSERT [Project] OFF;
GO

SET IDENTITY_INSERT [Ticket] ON;
GO

INSERT INTO [Ticket] ([Id_Ticket], [Title], [Status], [Priority], [Type], [Description], [Submit_Time], [Submit_Member], [Assigned_Member], [Project])
 VALUES (1, 'Diagonal error', 1, 1, 'Error in logic', 'When i put 4 coins in a row in a diagonal i dont win', '2022-07-12 11:11:26.057', 1, 1, 1),
(2, 'Displaying hangman error', 2, 2, 'Error in display', 'There is a space too much in the display of the word to guess','2022-07-12 11:11:26.057', 2, 2, 2),
(3, 'Hero never wins', 3, 3, 'Error in game design', 'I face every monster and cant ever kill any of them', '2022-07-12 11:11:26.057', 3, 3, 3);

SET IDENTITY_INSERT [Ticket] OFF;
GO

SET IDENTITY_INSERT [Assign] ON;
GO

INSERT INTO [Assign] ([Id_Assign], [Assign_Time], [Project], [Member])
 VALUES (1, '2022-07-12 11:11:26.057', 1, 1),
 (2, '2022-07-12 11:11:26.057', 2, 2),
 (3, '2022-07-12 11:11:26.057', 3, 3);

SET IDENTITY_INSERT [Assign] OFF;
GO