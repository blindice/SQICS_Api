using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddedNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fld_id",
                table: "tbl_t_transactions",
                newName: "fld_transactionId");

            migrationBuilder.AddColumn<string>(
                name: "fld_remarks",
                table: "tbl_t_transactions",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fld_stationId",
                table: "tbl_t_transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fld_statusId",
                table: "tbl_t_transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fld_subAssyLotNo",
                table: "tbl_t_transactions",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fld_transactionId",
                table: "tbl_t_transaction_details",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);

            migrationBuilder.CreateTable(
                name: "tbl_m_status",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_statusCode = table.Column<int>(type: "int", nullable: false),
                    fld_statusName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_m_st__5CBC763588198F29", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_lot_ongoing",
                columns: table => new
                {
                    fld_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    fld_lineId = table.Column<int>(type: "int", nullable: false),
                    fld_stationId = table.Column<int>(type: "int", nullable: false),
                    fld_trans = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_lotNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_partCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_qty = table.Column<int>(type: "int", nullable: true),
                    fld_statusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_t_lo__5CBC763531958C59", x => x.fld_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_m_status");

            migrationBuilder.DropTable(
                name: "tbl_t_lot_ongoing");

            migrationBuilder.DropColumn(
                name: "fld_remarks",
                table: "tbl_t_transactions");

            migrationBuilder.DropColumn(
                name: "fld_stationId",
                table: "tbl_t_transactions");

            migrationBuilder.DropColumn(
                name: "fld_statusId",
                table: "tbl_t_transactions");

            migrationBuilder.DropColumn(
                name: "fld_subAssyLotNo",
                table: "tbl_t_transactions");

            migrationBuilder.RenameColumn(
                name: "fld_transactionId",
                table: "tbl_t_transactions",
                newName: "fld_id");

            migrationBuilder.AlterColumn<string>(
                name: "fld_transactionId",
                table: "tbl_t_transaction_details",
                type: "varchar(12)",
                unicode: false,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
