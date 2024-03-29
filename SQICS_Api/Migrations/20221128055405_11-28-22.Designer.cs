﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQICS_Api.Model.Context;

namespace SQICS_Api.Migrations
{
    [DbContext(typeof(SQICSContext))]
    [Migration("20221128055405_11-28-22")]
    partial class _112822
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_bom", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_assyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_creatdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<int>("fld_pieceId")
                        .HasColumnType("int");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_bom");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_defect", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_defects");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_inspection_mode", b =>
                {
                    b.Property<int?>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("fld_description")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("fld_value")
                        .HasColumnType("int");

                    b.ToTable("tbl_m_inspection_mode");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_line", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_lotLabelValue")
                        .HasColumnType("int");

                    b.Property<string>("fld_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_lines");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_operator", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_employeeId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("fld_firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_middleName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.HasIndex(new[] { "fld_employeeId" }, "employeeId_unique")
                        .IsUnique();

                    b.ToTable("tbl_m_operator");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_operator_assy", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_assyId")
                        .HasColumnType("int");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_operatorId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_operator_assy");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_operator_station", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_operatorId")
                        .HasColumnType("int");

                    b.Property<int>("fld_stationId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_operator_station");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_part", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("fld_isAssy")
                        .HasColumnType("bit");

                    b.Property<int?>("fld_most")
                        .HasColumnType("int");

                    b.Property<string>("fld_partCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("fld_partName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_remarks")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("fld_spq")
                        .HasColumnType("int");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.HasIndex(new[] { "fld_partCode" }, "partCode_unique")
                        .IsUnique();

                    b.ToTable("tbl_m_parts");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_partcode_color", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fld_Color")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<int?>("fld_CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("fld_UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_partCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("fld_partName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_m_partcode_color");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_station", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_lineId")
                        .HasColumnType("int");

                    b.Property<string>("fld_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_order")
                        .HasColumnType("int");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_userId")
                        .HasColumnType("int");

                    b.HasKey("fld_id");

                    b.HasIndex(new[] { "fld_name" }, "name_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "fld_lineId", "fld_order" }, "uq_yourtablename")
                        .IsUnique();

                    b.ToTable("tbl_m_stations");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_status", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_statusCode")
                        .HasColumnType("int");

                    b.Property<string>("fld_statusName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("fld_id")
                        .HasName("PK__tbl_m_st__5CBC763588198F29");

                    b.ToTable("tbl_m_status");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_m_user", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("fld_active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<bool?>("fld_resetPasswordFlag")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("fld_role")
                        .HasColumnType("int");

                    b.Property<string>("fld_salt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("fld_id");

                    b.HasIndex(new[] { "fld_username" }, "username_Unique")
                        .IsUnique();

                    b.ToTable("tbl_m_users");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_assy_defect", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fld_assyCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("fld_assyLot")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_defectId")
                        .HasColumnType("int");

                    b.Property<string>("fld_pieceCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("fld_pieceLot")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<string>("fld_remarks")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_t_assy_defects");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_lot_inspection", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fld_assyLot")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("fld_defectName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("fld_deleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("fld_deletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_deletedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_inspectedQty")
                        .HasColumnType("int");

                    b.Property<int>("fld_inspectionMode")
                        .HasColumnType("int");

                    b.Property<bool>("fld_judgement")
                        .HasColumnType("bit");

                    b.Property<string>("fld_partCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("fld_partName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("fld_prodDate")
                        .HasColumnType("datetime");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<string>("fld_referenceNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("fld_remarks")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_shiftId")
                        .HasColumnType("int");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<bool?>("fld_updateFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id")
                        .HasName("PK__tbl_t_lo__5CBC763500BF46E1");

                    b.ToTable("tbl_t_lot_inspection");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_lot_label", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_lotNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("fld_modelId")
                        .HasColumnType("int");

                    b.Property<string>("fld_modelName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fld_partCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("fld_partName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("fld_printed")
                        .HasColumnType("bit");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<string>("fld_referenceNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("fld_remarks")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("fld_reprinted")
                        .HasColumnType("bit");

                    b.Property<string>("fld_transactionId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_t_lot_label");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_lot_ongoing", b =>
                {
                    b.Property<Guid>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("fld_count")
                        .HasColumnType("int");

                    b.Property<int>("fld_lineId")
                        .HasColumnType("int");

                    b.Property<string>("fld_lotNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("fld_partCode")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("fld_qty")
                        .HasColumnType("int");

                    b.Property<int>("fld_stationId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_statusId")
                        .HasColumnType("int");

                    b.Property<string>("fld_trans")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("fld_id")
                        .HasName("PK__tbl_t_lo__5CBC763531958C59");

                    b.ToTable("tbl_t_lot_ongoing");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_transaction", b =>
                {
                    b.Property<int>("fld_transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ETimeCompletion")
                        .HasColumnType("datetime2");

                    b.Property<int>("fld_assyId")
                        .HasColumnType("int");

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fld_judgement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("fld_lineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_prodDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<string>("fld_remarks")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_shiftId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_stationId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_statusId")
                        .HasColumnType("int");

                    b.Property<string>("fld_subAssyLotNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_supplierId")
                        .HasColumnType("int");

                    b.Property<string>("fld_transactionNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_transactionId");

                    b.ToTable("tbl_t_transactions");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_transaction_detail", b =>
                {
                    b.Property<int>("fld_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fld_createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("fld_createdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("fld_employeeId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<bool>("fld_judgementFlag")
                        .HasColumnType("bit");

                    b.Property<string>("fld_lotNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("fld_operatorFlag")
                        .HasColumnType("bit");

                    b.Property<int>("fld_pieceId")
                        .HasColumnType("int");

                    b.Property<int>("fld_qty")
                        .HasColumnType("int");

                    b.Property<string>("fld_referenceNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("fld_stationId")
                        .HasColumnType("int");

                    b.Property<int>("fld_transactionId")
                        .HasColumnType("int");

                    b.Property<int?>("fld_updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fld_updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("fld_id");

                    b.ToTable("tbl_t_transaction_details");
                });

            modelBuilder.Entity("SQICS_Api.Model.tbl_t_transaction_header", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("TransNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_t_transaction_header");
                });
#pragma warning restore 612, 618
        }
    }
}
