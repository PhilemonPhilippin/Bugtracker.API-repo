CREATE PROCEDURE [dbo].[PPSP_DeleteTicket]
	@Id_Ticket INT
AS
	BEGIN
		DELETE FROM [Ticket] WHERE [Id_Ticket] = @Id_Ticket;
	END
RETURN 0