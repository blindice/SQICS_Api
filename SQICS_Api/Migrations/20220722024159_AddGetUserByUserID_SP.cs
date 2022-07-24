using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetUserByUserID_SP : Migration
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
-- Create date: 07/22/22
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GetUserByUserId 
	-- Add the parameters for the stored procedure here
	@userId INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.[fld_id] Id 
		   ,u.[fld_username] Username
		   ,u.[fld_name] FullName
		   ,u.[fld_supplierId] SupplierId
		   ,s.[fld_name] SupplierName
		   ,u.[fld_password] [Password]
		   ,u.[fld_salt] Salt
	FROM   [tbl_m_users] u
	JOIN   [tbl_m_suppliers] s
	ON     u.[fld_supplierId] = s.[fld_id]
	WHERE  u.[fld_supplierId] is not null
	AND    u.[fld_id] = @userId

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
