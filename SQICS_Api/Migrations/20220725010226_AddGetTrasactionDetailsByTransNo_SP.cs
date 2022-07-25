using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetTrasactionDetailsByTransNo_SP : Migration
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
CREATE PROCEDURE usp_GetTransactionDetailsByTransNo 
	-- Add the parameters for the stored procedure here
	@p1 int = 0, 
	@p2 int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT td.[fld_id] [Id]
	      ,s.fld_name [StationName]
		  ,o.[fld_employeeId] [EmployeeId]
		  ,p.[fld_partCode] [PiecePartCode]
		  ,p.[fld_partName] [PiecePartName]
		  ,td.[fld_lotNo] [LotNo]
		  ,td.[fld_qty] [Qty]
		  ,td.[fld_judgementFlag] [Judgement]
	FROM  [dbo].[tbl_t_transaction_details] td
	JOIN  [dbo].[tbl_m_operator] o
	ON    td.[fld_employeeId] = o.[fld_id]
	JOIN  [dbo].[tbl_m_parts] p
	ON    td.[fld_pieceId] = p.[fld_id]
	JOIN  [dbo].[tbl_m_stations] s
	ON    td.fld_stationId = s.fld_id

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
