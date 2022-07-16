CREATE PROCEDURE [dbo].[PPSP_TicketTitleExistWithId]
	@Title NVARCHAR(250),
	@Id_Ticket INT
AS
	SELECT COUNT([Title]) FROM [Ticket] WHERE [Title] = @Title AND [Id_Ticket] != @Id_Ticket;
RETURN 0