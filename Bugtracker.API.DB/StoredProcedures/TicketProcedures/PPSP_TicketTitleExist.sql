CREATE PROCEDURE [dbo].[PPSP_TicketTitleExist]
	@Title NVARCHAR(250)
AS
	SELECT COUNT([Title]) FROM [Ticket] WHERE [Title] = @Title;
RETURN 0