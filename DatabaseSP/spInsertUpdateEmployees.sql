USE [TEST_DB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertUpdateEmployees]    Script Date: 6/21/2024 11:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec [dbo].[spInsertUpdateEmployees] 0,'ANIL','MALE',25,'anil@GMAIL.COM','SSE','DELHI'
ALTER procedure [dbo].[spInsertUpdateEmployees]
(
@Id			Int,
@Name		varchar(100),
@Gender		varchar(100),
@Age		INT, 
@Email		varchar(100),
@Designation  varchar(100),
@City		varchar(100)
)
as
begin
IF (ISNULL(@ID,0)=0)
	INSERT INTO [dbo].[Employees] (Name, Gender,Email,Age,Designation,City)
							values(@Name, @Gender,@Email,@Age,@Designation,@City)
ELSE 
	UPDATE [dbo].[Employees]
			SET Name =  @Name, 
			Gender = @Gender,
			Email	= @Email,
			Age		= @Age,
 			Designation = @Designation,
			City =  @City
			WHERE Id =  @Id
end