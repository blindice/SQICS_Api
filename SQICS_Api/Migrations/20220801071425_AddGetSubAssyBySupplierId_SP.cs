using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetSubAssyBySupplierId_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var sp = @"USE [db_SQICS]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSubAssyByCode]    Script Date: 8/1/2022 3:13:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ludz
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetSubAssyBySupplierId]
	-- Add the parameters for the stored procedure here
	@supplierId INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  [fld_id]
		    ,[fld_supplierId]
		    ,[fld_partCode]
		    ,[fld_partName]
		    ,[fld_spq]
		    ,[fld_most]
	  FROM  [db_SQICS].[dbo].[tbl_m_parts]
	  WHERE [fld_isAssy] = 1
	  AND   [fld_active] = 1
	  AND   [fld_supplierId] = @supplierId

END
";
			migrationBuilder.Sql(sp);

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
