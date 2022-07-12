CREATE PROCEDURE [dbo].[PPSP_UpdateTicket]
	@Id_Ticket INT,
	@Title NVARCHAR(250),
	@Status INT,
	@Priority INT,
	@Type NVARCHAR(250),
	@Description NVARCHAR(750),
	@Submit_Time DATETIME,
	@Submit_Member INT,
	@Assigned_Member INT,
	@Project INT
AS
	BEGIN
		UPDATE [Ticket]
			SET [Title] = @Title, [Status] = @Status, [Priority] = @Priority, [Type] = @Type, [Description] = @Description, [Submit_Time] = @Submit_Time, [Submit_Member] = @Submit_Member, [Assigned_Member]= @Assigned_Member, [Project]= @Project
			WHERE Id_Ticket = @Id_Ticket;
	END
RETURN 0
