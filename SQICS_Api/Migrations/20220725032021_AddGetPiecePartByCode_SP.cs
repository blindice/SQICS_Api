using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetPiecePartByCode_SP : Migration
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
CREATE PROCEDURE usp_GetPiecePartByCode 
	-- Add the parameters for the stored procedure here
	@pieceCode VARCHAR(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	/****** Script for SelectTopNRows command from SSMS  ******/
	SELECT [fld_id]
		  ,[fld_supplierId]
		  ,[fld_partCode]
		  ,[fld_partName]
		  ,[fld_spq]
		  ,[fld_most]
		  ,[fld_remarks]
		  ,[fld_active]
		  ,[fld_isAssy]
		  ,[fld_createdBy]
		  ,[fld_createdDate]
		  ,[fld_updatedBy]
		  ,[fld_updatedDate]
	FROM   [db_SQICS].[dbo].[tbl_m_parts]
	WHERE  [fld_isAssy] = 0
	AND    [fld_active] = 1
	AND    [fld_partCode] = @pieceCode

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
