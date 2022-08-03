using Microsoft.EntityFrameworkCore.Migrations;

namespace SQICS_Api.Migrations
{
    public partial class AddGenerateLotNo_SP : Migration
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
-- Author:		ludz
-- Create date: 08-03-22
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GenerateLotNo -- usp_GenerateLotNo '1', '1'
	-- Add the parameters for the stored procedure here
	@supplierId INT,
	@lineId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @supplierCode VARCHAR(10),
		@line char(2); --get last two char on lineCode

	--get supplierCode by supplierId
	SET @supplierCode = (SELECT [fld_code]
		                 FROM   [tbl_m_suppliers]
		                 WHERE  [fld_id] = @supplierId)

	--get last two char of lineCode
	SET @line = (SELECT RIGHT([fld_name], 2)
				 FROM   [tbl_m_lines]
				 WHERE  [fld_id] = @lineId)


	DECLARE @year char(2) = FORMAT(getdate(), 'yy'), -- get last two digits of current year
			@month VARCHAR(5) = FORMAT(getdate(), 'MM'), -- get last two digits of current month
			@day VARCHAR(5) = FORMAT(getdate(), 'dd'); -- get last two digits of current day

	--if month is greater than 9, then X, Y, Z for 10, 11, 12 respectively
	SET @month = (SELECT CASE 
							WHEN CAST(@month as INT) = 10 THEN 'X'
							WHEN CAST(@month as INT) = 11 THEN 'Y'
							WHEN CAST(@month as INT) = 12 THEN 'Z'
							ELSE RIGHT(@month, 1)
						 END);

	-- get hours from current datetime
	DECLARE @hour INT = CAST(FORMAT(getdate(), 'HH') as INT),
			@shift char(1);

	-- if hours is 7am to before 7pm then it is Dayshift(A) otherwise Nightshift(B)
	SET @shift = (SELECT CASE 
							WHEN @hour >= 7 AND @hour < 19 THEN 'A'
							ELSE 'B'
						 END);

	DECLARE @count INT,
			@lotPrefix VARCHAR(9) = CONCAT(@supplierCode, @year, @month, @day, @shift);

	--get the max value of last 4 digits in lotno on all given 9 char of lotno
	select @count = MAX(convert(int, RIGHT( '000' + convert(varchar, [fld_subAssyLotNo]), 4))) + 1
		from [tbl_t_transactions]
		where LEFT([fld_subAssyLotNo], 9) = @lotPrefix

	IF @count IS NULL set @count = 1

	DECLARE @suffix varchar(4) = RIGHT( '000' + convert(varchar, @count), 4);

	SELECT CONCAT(@lotPrefix, @suffix)

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
