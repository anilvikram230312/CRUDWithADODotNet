USE [TEST_DB]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployees]    Script Date: 6/21/2024 12:56:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteEmployeesById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
   DELETE FROM DBO.Employees WHERE ID = @ID
END
