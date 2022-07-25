using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetOperatorByEmpId_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var sp = @"-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ludz
-- Create date: 07/25/22
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GetOperatorByEmpId 
	-- Add the parameters for the stored procedure here
	@empId VARCHAR(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [fld_id]
		   ,[fld_supplierId]
		   ,[fld_employeeId]
		   ,[fld_lastName]
		   ,[fld_firstName]
		   ,[fld_middleName]
		   ,[fld_active]
		   ,[fld_createdBy]
		   ,[fld_createdDate]
		   ,[fld_updatedBy]
		   ,[fld_updatedDate]
	FROM   [db_SQICS].[dbo].[tbl_m_operator]
	WHERE  [fld_employeeId] = @empId

END
GO
";
			migrationBuilder.Sql(sp);

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
