using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AlterValidateOperator_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var sp = @"USE [db_SQICS]
GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateOperator]    Script Date: 7/25/2022 1:20:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ludz
-- Create date: 07/25/22
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[usp_ValidateOperator] 
	-- Add the parameters for the stored procedure here
	@operatorId INT,
	@subAssyId INT,
	@stationId INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT 1
				  FROM   [db_SQICS].[dbo].[tbl_m_operator_assy]
				  WHERE  [fld_operatorId] = @operatorId
				  AND     [fld_assyId] = @subAssyId)
		BEGIN
			IF EXISTS(SELECT 1
						FROM   [db_SQICS].[dbo].[tbl_m_operator_station]
						WHERE  [fld_operatorId] = @operatorId
						AND    [fld_stationId] = @stationId)
				BEGIN
					SELECT CAST(1 as BIT)
				END
			ELSE
				BEGIN
					SELECT CAST(0 as BIT)
				END
		END
	ELSE
			BEGIN
				SELECT CAST(0 as BIT)
			END
END
";
			migrationBuilder.Sql(sp);

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
