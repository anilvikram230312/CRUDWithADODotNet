USE [TEST_DB]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 6/21/2024 11:48:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<ANIL VIKRAM>
-- Create date: <21-06-2024>
-- Description:	<getallemployees>
-- =============================================
ALTER PROCEDURE [dbo].[spGetAllEmployees]
AS
BEGIN
	SET NOCOUNT ON;
	Select ISNULL(AGE,0) AS Age,* from Employees
END
