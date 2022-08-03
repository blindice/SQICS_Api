using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetCurrentPlano_SP : Migration
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
-- Create date: 08-03-22
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GetCurrentPlan 
	-- Add the parameters for the stored procedure here
	@lineId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.[fld_subAssyLotNo] [LotNo], 
		   t.[fld_qty] [Qty],
		   s.[fld_partCode] [PartCode],
		   s.[fld_partName] [PartName],
		   st.[fld_statusName] [Status]
	FROM   [tbl_t_transactions] t
	JOIN   [tbl_m_parts] s
	ON     t.[fld_assyId] = s.[fld_id]
	JOIN   [tbl_m_status] st
	ON     t.[fld_statusID] = st.[fld_statusCode]
	WHERE  t.[fld_lineId] = @lineId


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
