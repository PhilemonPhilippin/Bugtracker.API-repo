CREATE PROCEDURE [dbo].[PPSP_UpdateMemberPswd]
	@Id_Member INT,
	@Pswd_Hash NVARCHAR(100)
AS
	BEGIN
		UPDATE [Member]
			SET [Pswd_Hash] = @Pswd_Hash
			 WHERE Id_Member = @Id_Member;
	END
RETURN 0
