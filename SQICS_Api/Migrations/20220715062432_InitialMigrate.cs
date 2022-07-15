using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_m_bom",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_assyId = table.Column<int>(type: "int", nullable: false),
                    fld_pieceId = table.Column<int>(type: "int", nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_creatdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_bom", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_m_operator",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_employeeId = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_lastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_firstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_middleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_operator", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_m_operator_assy",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_operatorId = table.Column<int>(type: "int", nullable: false),
                    fld_assyId = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_operator_assy", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_m_operator_station",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_operatorId = table.Column<int>(type: "int", nullable: false),
                    fld_stationId = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_operator_station", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_m_parts",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_partCode = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_partName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_spq = table.Column<int>(type: "int", nullable: true),
                    fld_most = table.Column<int>(type: "int", nullable: true),
                    fld_remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_isAssy = table.Column<bool>(type: "bit", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_parts", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_assy_defects",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_transactionId = table.Column<int>(type: "int", nullable: false),
                    fld_defectId = table.Column<int>(type: "int", nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_assy_defects", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_lot_label",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_transactionId = table.Column<int>(type: "int", nullable: false),
                    fld_referenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_lotNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_partCode = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_partName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_modelId = table.Column<int>(type: "int", nullable: true),
                    fld_modelName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fld_printed = table.Column<bool>(type: "bit", nullable: false),
                    fld_reprinted = table.Column<bool>(type: "bit", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_lot_label", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_transaction_details",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_transactionId = table.Column<int>(type: "int", nullable: false),
                    fld_stationId = table.Column<int>(type: "int", nullable: false),
                    fld_employeeId = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_pieceId = table.Column<int>(type: "int", nullable: false),
                    fld_lotNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_referenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_operatorFlag = table.Column<bool>(type: "bit", nullable: false),
                    fld_judgementFlag = table.Column<bool>(type: "bit", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_transaction_details", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_transactions",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_lineId = table.Column<int>(type: "int", nullable: false),
                    fld_transactionNo = table.Column<int>(type: "int", nullable: false),
                    fld_assyId = table.Column<int>(type: "int", nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ETimeCompletion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_printFlag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_transactions", x => x.fld_id);
                });

            migrationBuilder.CreateIndex(
                name: "employeeId_unique",
                table: "tbl_m_operator",
                column: "fld_employeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "partCode_unique",
                table: "tbl_m_parts",
                column: "fld_partCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_m_bom");

            migrationBuilder.DropTable(
                name: "tbl_m_operator");

            migrationBuilder.DropTable(
                name: "tbl_m_operator_assy");

            migrationBuilder.DropTable(
                name: "tbl_m_operator_station");

            migrationBuilder.DropTable(
                name: "tbl_m_parts");

            migrationBuilder.DropTable(
                name: "tbl_t_assy_defects");

            migrationBuilder.DropTable(
                name: "tbl_t_lot_label");

            migrationBuilder.DropTable(
                name: "tbl_t_transaction_details");

            migrationBuilder.DropTable(
                name: "tbl_t_transactions");
        }
    }
}
