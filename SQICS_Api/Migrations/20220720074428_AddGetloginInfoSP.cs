using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGetloginInfoSP : Migration
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
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GetLoginInfo 
	-- Add the parameters for the stored procedure here
	@username varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.[fld_username] Username
		   ,u.[fld_name] FullName
		   ,u.[fld_supplierId] SupplierId
		   ,s.[fld_name] SupplierName
		   ,u.[fld_password] [Password]
		   ,u.[fld_salt] Salt
	FROM   [tbl_m_users] u
	JOIN   [tbl_m_suppliers] s
	ON     u.[fld_supplierId] = s.[fld_id]
	WHERE  u.[fld_supplierId] is not null
	AND    u.[fld_username] = @username

END
GO
";

            migrationBuilder.Sql(sp);

            //migrationBuilder.DropColumn(
            //    name: "fld_printFlag",
            //    table: "tbl_t_transactions");

            //migrationBuilder.AlterColumn<string>(
            //    name: "fld_transactionNo",
            //    table: "tbl_t_transactions",
            //    type: "varchar(12)",
            //    unicode: false,
            //    maxLength: 12,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ETimeCompletion",
            //    table: "tbl_t_transactions",
            //    type: "datetime2",
            //    nullable: false,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime");

            //migrationBuilder.AlterColumn<string>(
            //    name: "fld_transactionId",
            //    table: "tbl_t_transaction_details",
            //    type: "varchar(12)",
            //    unicode: false,
            //    maxLength: 12,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "fld_transactionId",
            //    table: "tbl_t_lot_label",
            //    type: "varchar(12)",
            //    unicode: false,
            //    maxLength: 12,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "fld_transactionId",
            //    table: "tbl_t_assy_defects",
            //    type: "varchar(12)",
            //    unicode: false,
            //    maxLength: 12,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.CreateTable(
            //    name: "tbl_m_users",
            //    columns: table => new
            //    {
            //        fld_id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fld_username = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
            //        fld_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        fld_email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        fld_role = table.Column<int>(type: "int", nullable: false),
            //        fld_supplierId = table.Column<int>(type: "int", nullable: true),
            //        fld_password = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
            //        fld_salt = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        fld_resetPasswordFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        fld_active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        fld_createdBy = table.Column<int>(type: "int", nullable: false),
            //        fld_createdDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        fld_updatedBy = table.Column<int>(type: "int", nullable: true),
            //        fld_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_m_users", x => x.fld_id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "transNo_unique",
            //    table: "tbl_t_transactions",
            //    column: "fld_transactionNo",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "username_Unique",
            //    table: "tbl_m_users",
            //    column: "fld_username",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_m_users");

            migrationBuilder.DropIndex(
                name: "transNo_unique",
                table: "tbl_t_transactions");

            migrationBuilder.AlterColumn<int>(
                name: "fld_transactionNo",
                table: "tbl_t_transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ETimeCompletion",
                table: "tbl_t_transactions",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "fld_printFlag",
                table: "tbl_t_transactions",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "fld_transactionId",
                table: "tbl_t_transaction_details",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "fld_transactionId",
                table: "tbl_t_lot_label",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "fld_transactionId",
                table: "tbl_t_assy_defects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldUnicode: false,
                oldMaxLength: 12);
        }
    }
}
