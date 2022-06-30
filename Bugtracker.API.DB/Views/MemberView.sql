CREATE VIEW [dbo].[MemberView]
	AS 
	SELECT Id_Member, Login, Password_Hash, Email_Address, Firstname, Lastname FROM Member;
