using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AlterGetTransactionDetailsByTransNo_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var sp = @"USE [db_SQICS]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTransactionDetailsByTransNo]    Script Date: 7/25/2022 9:04:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ludz
-- Create date: 07/25/22
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetTransactionDetailsByTransNo] 
	-- Add the parameters for the stored procedure here
	@transNo VARCHAR(30)
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
	WHERE td.[fld_transactionId] = @transNo


END
";

			migrationBuilder.Sql(sp);

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
