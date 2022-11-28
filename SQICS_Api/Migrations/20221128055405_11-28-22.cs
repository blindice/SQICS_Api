using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class _112822 : Migration
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

            migrationBuilder.CreateTable(
                name: "tbl_m_inspection_mode",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    fld_value = table.Column<int>(type: "int", nullable: true),
                    fld_createdBy = table.Column<int>(type: "int", nullable: true),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_m_lines",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_lotLabelValue = table.Column<int>(type: "int", nullable: false),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_lines", x => x.fld_id);
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
                name: "tbl_m_partcode_color",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_partCode = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_partName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_Color = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    fld_CreatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    fld_UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_partcode_color", x => x.fld_id);
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
                name: "tbl_m_stations",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_lineId = table.Column<int>(type: "int", nullable: false),
                    fld_userId = table.Column<int>(type: "int", nullable: false),
                    fld_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_order = table.Column<int>(type: "int", nullable: false),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_stations", x => x.fld_id);
                });

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
                name: "tbl_m_users",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_username = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_role = table.Column<int>(type: "int", nullable: false),
                    fld_supplierId = table.Column<int>(type: "int", nullable: true),
                    fld_password = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    fld_salt = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_resetPasswordFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_m_users", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_assy_defects",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_pieceCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_pieceLot = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_assyCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_assyLot = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_defectId = table.Column<int>(type: "int", nullable: false),
                    fld_remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_assy_defects", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_lot_inspection",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_partCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_partName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_assyLot = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_referenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_inspectionMode = table.Column<int>(type: "int", nullable: false),
                    fld_inspectedQty = table.Column<int>(type: "int", nullable: false),
                    fld_judgement = table.Column<bool>(type: "bit", nullable: false),
                    fld_defectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_shiftId = table.Column<int>(type: "int", nullable: false),
                    fld_prodDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fld_updateFlag = table.Column<bool>(type: "bit", nullable: true),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    fld_deleteFlag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    fld_deletedBy = table.Column<int>(type: "int", nullable: true),
                    fld_deletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_t_lo__5CBC763500BF46E1", x => x.fld_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_lot_label",
                columns: table => new
                {
                    fld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_transactionId = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    fld_referenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_lotNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fld_partCode = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fld_partName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
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
                    fld_statusId = table.Column<int>(type: "int", nullable: true),
                    fld_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_t_lo__5CBC763531958C59", x => x.fld_id);
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
                name: "tbl_t_transaction_header",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_transaction_header", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_t_transactions",
                columns: table => new
                {
                    fld_transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fld_supplierId = table.Column<int>(type: "int", nullable: false),
                    fld_lineId = table.Column<int>(type: "int", nullable: false),
                    fld_stationId = table.Column<int>(type: "int", nullable: true),
                    fld_transactionNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    fld_subAssyLotNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_prodDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fld_shiftId = table.Column<int>(type: "int", nullable: false),
                    fld_assyId = table.Column<int>(type: "int", nullable: false),
                    fld_qty = table.Column<int>(type: "int", nullable: false),
                    fld_statusId = table.Column<int>(type: "int", nullable: true),
                    fld_judgement = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    fld_remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fld_createdBy = table.Column<int>(type: "int", nullable: false),
                    fld_createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fld_updatedBy = table.Column<int>(type: "int", nullable: true),
                    fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ETimeCompletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_t_transactions", x => x.fld_transactionId);
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

            migrationBuilder.CreateIndex(
                name: "name_unique",
                table: "tbl_m_stations",
                column: "fld_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_yourtablename",
                table: "tbl_m_stations",
                columns: new[] { "fld_lineId", "fld_order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "username_Unique",
                table: "tbl_m_users",
                column: "fld_username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_m_bom");

            migrationBuilder.DropTable(
                name: "tbl_m_defects");

            migrationBuilder.DropTable(
                name: "tbl_m_inspection_mode");

            migrationBuilder.DropTable(
                name: "tbl_m_lines");

            migrationBuilder.DropTable(
                name: "tbl_m_operator");

            migrationBuilder.DropTable(
                name: "tbl_m_operator_assy");

            migrationBuilder.DropTable(
                name: "tbl_m_operator_station");

            migrationBuilder.DropTable(
                name: "tbl_m_partcode_color");

            migrationBuilder.DropTable(
                name: "tbl_m_parts");

            migrationBuilder.DropTable(
                name: "tbl_m_stations");

            migrationBuilder.DropTable(
                name: "tbl_m_status");

            migrationBuilder.DropTable(
                name: "tbl_m_users");

            migrationBuilder.DropTable(
                name: "tbl_t_assy_defects");

            migrationBuilder.DropTable(
                name: "tbl_t_lot_inspection");

            migrationBuilder.DropTable(
                name: "tbl_t_lot_label");

            migrationBuilder.DropTable(
                name: "tbl_t_lot_ongoing");

            migrationBuilder.DropTable(
                name: "tbl_t_transaction_details");

            migrationBuilder.DropTable(
                name: "tbl_t_transaction_header");

            migrationBuilder.DropTable(
                name: "tbl_t_transactions");
        }
    }
}
