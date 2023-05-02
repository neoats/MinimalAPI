CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LasttName nvarchar(50)
AS
begin
	update dbo.[User] 
	set FirstName=@FirstName,LastName=@LasttName
	where Id=@Id;
end