using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddValidatePiecePart_SP : Migration
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
CREATE PROCEDURE usp_ValidatePiecePart 
	-- Add the parameters for the stored procedure here
	@pieceId INT,
	@assyId INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	CASE WHEN EXISTS
		(SELECT 1
		 FROM   [db_SQICS].[dbo].[tbl_m_bom]
		 WHERE  [fld_pieceId] = @pieceId
		 AND    [fld_assyId] = @assyId)
	THEN CAST(1 as BIT)
	ELSE CAST(1 as BIT)
	END

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
