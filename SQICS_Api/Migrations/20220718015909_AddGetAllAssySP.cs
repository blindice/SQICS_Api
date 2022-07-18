using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetAllAssySP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[usp_GetAllSubAssy]

AS
BEGIN

    SELECT [fld_id]
          ,[fld_supplierId]
          ,[fld_partCode]
          ,[fld_partName]
    FROM [dbo].[tbl_m_parts] WITH(NOLOCK)
    WHERE [fld_isAssy] = 1
    AND [fld_active] = 1

END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
