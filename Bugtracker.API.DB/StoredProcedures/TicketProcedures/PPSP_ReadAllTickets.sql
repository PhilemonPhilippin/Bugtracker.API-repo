CREATE PROCEDURE [dbo].[PPSP_ReadAllTickets]
AS
	BEGIN
		SELECT [Id_Ticket], [Title], [Status], [Priority], [Type], [Description], [Submit_Time], [Submit_Member], [Assigned_Member], [Project] FROM [Ticket];
	END
RETURN 0
