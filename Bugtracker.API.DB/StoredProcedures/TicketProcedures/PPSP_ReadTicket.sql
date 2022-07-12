CREATE PROCEDURE [dbo].[PPSP_ReadTicket]
	@Id_Ticket INT
AS
	BEGIN
		SELECT [Title], [Status], [Priority], [Type], [Description], [Submit_Time], [Submit_Member], [Assigned_Member], [Project] FROM [Ticket] WHERE [Id_Ticket] = @Id_Ticket;
	END
RETURN 0
