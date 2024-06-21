
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spGetEmployeesById 
	@Id Int
AS
BEGIN
	SELECT * FROM DBO.Employees WHERE ID = @ID
END
GO
