using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddedDefectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fld_prodDate",
                table: "tbl_t_transactions",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<int>(
                name: "fld_shiftId",
                table: "tbl_t_transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_m_defects",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_defects", x => x.fld_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_m_defects");

            migrationBuilder.DropColumn(
                name: "fld_prodDate",
                table: "tbl_t_transactions");

            migrationBuilder.DropColumn(
                name: "fld_shiftId",
                table: "tbl_t_transactions");
        }
    }
}
