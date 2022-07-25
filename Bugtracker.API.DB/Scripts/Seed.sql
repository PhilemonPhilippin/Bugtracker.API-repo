USE [Bugtracker]
GO

SET IDENTITY_INSERT [Member] ON;
GO

INSERT INTO [Member] ([Id_Member], [Pseudo], [Email], [Pswd_Hash], [Firstname], [Lastname], [Activated])
 VALUES (1, 'Phil', 'phil@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$rKUgopRwzGsKcA5HQsMIog$FDH6HYrHkQUr7VLuIWoDGL7xxwKrma3kOoSC4m43lAY', 'Philemon', 'Philippin', 1),
 (2, 'Corentintin', 'corentintin@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$VXXJDG1IozK6m1XnHeovGg$orS9JdKlVUsWHtk48wp8ml+hzm1h3AqpIgU/ql2wXUo', 'Corentin', 'De Conninck', 1),
 (3, 'Dom', 'dom@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Dominique', 'Lafitte', 1),
 (4, 'Vins', 'vins@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Vincent', 'Gadé', 1),
 (5, 'Wass', 'wass@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Wassime', 'Akachar', 1),
 (6, 'Avet', 'avet@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Avet', 'Avetyan', 1),
 (7, 'Tanguy', 'tanguy@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Tanguy', 'Verhaegen', 1),
 (8, 'Anto', 'anto@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Antoine', 'Lallemand', 1),
 (9, 'Santiago', 'santiago@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Santiago', 'Astete', 1),
 (10, 'Laet', 'laet@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Laetitia', 'Hardman', 1),
 (11, 'Gucci', 'gucci@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$HWC1LJss5d4OG1ceSAavYA$4mDHICxlCZg70M8AkpLfL2W2Jhsrp+9ExPe3WpLieN0', 'Gauthier', 'Pladet', 1);

SET IDENTITY_INSERT [Member] OFF;
GO

SET IDENTITY_INSERT [Project] ON;
GO

INSERT INTO [Project] ([Id_Project], [Name], [Description], [Manager])
 VALUES (1,'Four in a row', 'A game of Four in which you win after setting 4 coins in a row.', 1),
 (2,'Hangman game', 'A game of Hangman in which you must find a word by guessing letters.', 1),
 (3,'HeroesVsMonster', 'A game of Heroes Vs Monster in which you are a hero and you fight monsters.', 1),
 (4,'TripCompanion', 'An application to organize trips.', 2),
 (5,'TicketTroc', 'Website to re-sell train tickets.', 3),
 (6,'BookXchange', 'An application to exchange books.', 4),
 (7,'HolydayBooks', 'Website to register children books reservations during holidays.', 5),
 (8,'Carfinder', 'An application to help choosing the car you really want to buy.', 6),
 (9,'Futurotheque', 'An web app to reservate and manage books.', 7),
 (10,'ProjetHotel', 'An application to book hostel reservations.', 8),
 (11,'GreenEnergyAI', 'A marketplace website for renewable energie.', 9),
 (12,'Brussels Relaxation Garden', 'A market web application themed on relaxation products and services.', 10),
 (13,'MoviesWorld', 'A social network themed on movies.', 11),
 (14,'Bugtracker', 'An application to track bugs.', 1);

SET IDENTITY_INSERT [Project] OFF;
GO

SET IDENTITY_INSERT [Ticket] ON;
GO

INSERT INTO [Ticket] ([Id_Ticket], [Title], [Status], [Priority], [Type], [Description], [Submit_Time], [Submit_Member], [Assigned_Member], [Project])
 VALUES (1, 'Diagonal error', 1, 1, 'Error in logic', 'When i put 4 coins in a row in a diagonal i dont win.', '2022-07-12 11:11:26.057', 1, 1, 1),
(2, 'Displaying hangman error', 2, 2, 'Error in display', 'There is a space too much in the display of the word to guess.','2022-07-12 11:11:26.057', 2, 2, 2),
(3, 'Hero never wins', 3, 3, 'Error in game design', 'I face every monster and cant ever kill any of them.', '2022-07-12 11:11:26.057', 3, 3, 3),
(4, 'Book not registered', 1, 1, 'Error in logic', 'When i register a new book it doesnt work.', '2022-07-12 11:11:26.057', 2, 4, 6),
(5, 'Trip impossible in Italy', 2, 1, 'Error in structure', 'I cannot book a second trip in Italiy.', '2022-07-12 11:11:26.057', 2, 2, 4),
(6, 'Train ticket is null', 4, 3, 'Error in mapping', 'My train ticket is null when i insert one in DB.', '2022-07-12 11:11:26.057', 7, 3, 5),
(7, 'Sql object not found', 4, 1, 'Error in DB', 'My table is not recognized as existing.', '2022-07-12 11:11:26.057', 10, 5, 7),
(8, 'Book is null', 4, 1, 'Error in C#', 'My book is null in my BLL.', '2022-07-12 11:11:26.057', 8, 5, 7),
(9, 'Member not authorized', 3, 1, 'Error in authentication', 'Member authentication doesnt work.', '2022-07-12 11:11:26.057', 3, 5, 7),
(10, 'Can not find car', 2, 1, 'Error in cars', 'My app doesnt find any car to suit the needs of my user.', '2022-07-12 11:11:26.057', 5, 6, 8),
(11, 'Can not book a book', 3, 3, 'Error in C#', 'My book is not displayed as booked.', '2022-07-12 11:11:26.057', 2, 7, 9),
(12, 'Can not book a hostel room', 1, 1, 'Error in hostel', 'My hostel room is not booked.', '2022-07-12 11:11:26.057', 2, 8, 10),
(13, 'Energy not green', 1, 1, 'Error in energy', 'My energy is not marked as renewable in my display-energies.', '2022-07-12 11:11:26.057', 6, 9, 11),
(14, 'Not relaxed', 2, 3, 'Error in relaxation', 'My relaxation products are not marked as relaxing in my DB.', '2022-07-12 11:11:26.057', 6, 10, 12),
(15, 'No LOTR', 3, 1, 'Error in movie taste', 'Lord of the Rings is not well rated on this website.', '2022-07-12 11:11:26.057', 6, 11, 13);

SET IDENTITY_INSERT [Ticket] OFF;
GO

SET IDENTITY_INSERT [Assign] ON;
GO

INSERT INTO [Assign] ([Id_Assign], [Assign_Time], [Project], [Member])
 VALUES (1, '2022-07-12 11:11:26.057', 1, 1),
 (2, '2022-07-12 11:11:26.057', 2, 2),
 (3, '2022-07-12 11:11:26.057', 3, 3),
 (4, '2022-07-12 11:11:26.057', 6, 4),
 (5, '2022-07-12 11:11:26.057', 4, 2),
 (6, '2022-07-12 11:11:26.057', 5, 3),
 (7, '2022-07-12 11:11:26.057', 7, 5),
 (8, '2022-07-12 11:11:26.057', 8, 6),
 (9, '2022-07-12 11:11:26.057', 9, 7),
 (10, '2022-07-12 11:11:26.057', 10, 8),
 (11, '2022-07-12 11:11:26.057',11, 9),
 (12, '2022-07-12 11:11:26.057', 12, 10),
 (13, '2022-07-12 11:11:26.057', 13, 11);

SET IDENTITY_INSERT [Assign] OFF;
GO