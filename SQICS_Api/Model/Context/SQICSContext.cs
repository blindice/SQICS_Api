using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SQICS_Api.Model;

#nullable disable

namespace SQICS_Api.Model.Context
{
    public partial class SQICSContext : DbContext
    {
        public SQICSContext()
        {
        }

        public SQICSContext(DbContextOptions<SQICSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbl_m_bom> tbl_m_boms { get; set; }
        public virtual DbSet<tbl_m_defect> tbl_m_defects { get; set; }
        public virtual DbSet<tbl_m_inspection_mode> tbl_m_inspection_modes { get; set; }
        public virtual DbSet<tbl_m_line> tbl_m_lines { get; set; }
        public virtual DbSet<tbl_m_operator> tbl_m_operators { get; set; }
        public virtual DbSet<tbl_m_operator_assy> tbl_m_operator_assies { get; set; }
        public virtual DbSet<tbl_m_operator_station> tbl_m_operator_stations { get; set; }
        public virtual DbSet<tbl_m_part> tbl_m_parts { get; set; }
        public virtual DbSet<tbl_m_partcode_color> tbl_m_partcode_colors { get; set; }
        public virtual DbSet<tbl_m_station> tbl_m_stations { get; set; }
        public virtual DbSet<tbl_m_status> tbl_m_statuses { get; set; }
        public virtual DbSet<tbl_m_user> tbl_m_users { get; set; }
        public virtual DbSet<tbl_t_assy_defect> tbl_t_assy_defects { get; set; }
        public virtual DbSet<tbl_t_lot_inspection> tbl_t_lot_inspections { get; set; }
        public virtual DbSet<tbl_t_lot_label> tbl_t_lot_labels { get; set; }
        public virtual DbSet<tbl_t_lot_ongoing> tbl_t_lot_ongoings { get; set; }
        public virtual DbSet<tbl_t_transaction> tbl_t_transactions { get; set; }
        public virtual DbSet<tbl_t_transaction_detail> tbl_t_transaction_details { get; set; }
        public virtual DbSet<tbl_t_transaction_header> tbl_t_transaction_headers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=SQICSConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<tbl_m_defect>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_name).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_inspection_mode>(entity =>
            {
                entity.Property(e => e.fld_createdDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fld_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<tbl_m_line>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_name).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_operator>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_employeeId).IsUnicode(false);

                entity.Property(e => e.fld_firstName).IsUnicode(false);

                entity.Property(e => e.fld_lastName).IsUnicode(false);

                entity.Property(e => e.fld_middleName).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_part>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_partCode).IsUnicode(false);

                entity.Property(e => e.fld_partName).IsUnicode(false);

                entity.Property(e => e.fld_remarks).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_partcode_color>(entity =>
            {
                entity.Property(e => e.fld_Color).IsUnicode(false);

                entity.Property(e => e.fld_partCode).IsUnicode(false);

                entity.Property(e => e.fld_partName).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_station>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_name).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_status>(entity =>
            {
                entity.HasKey(e => e.fld_id)
                    .HasName("PK__tbl_m_st__5CBC763588198F29");

                entity.Property(e => e.fld_statusName).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_m_user>(entity =>
            {
                entity.Property(e => e.fld_active).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_email).IsUnicode(false);

                entity.Property(e => e.fld_name).IsUnicode(false);

                entity.Property(e => e.fld_password).IsUnicode(false);

                entity.Property(e => e.fld_resetPasswordFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.fld_salt).IsUnicode(false);

                entity.Property(e => e.fld_username).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_assy_defect>(entity =>
            {
                entity.Property(e => e.fld_assyCode).IsUnicode(false);

                entity.Property(e => e.fld_assyLot).IsUnicode(false);

                entity.Property(e => e.fld_pieceCode).IsUnicode(false);

                entity.Property(e => e.fld_pieceLot).IsUnicode(false);

                entity.Property(e => e.fld_remarks).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_lot_inspection>(entity =>
            {
                entity.HasKey(e => e.fld_id)
                    .HasName("PK__tbl_t_lo__5CBC763500BF46E1");

                entity.Property(e => e.fld_assyLot).IsUnicode(false);

                entity.Property(e => e.fld_createdDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fld_defectName).IsUnicode(false);

                entity.Property(e => e.fld_deleteFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.fld_partCode).IsUnicode(false);

                entity.Property(e => e.fld_partName).IsUnicode(false);

                entity.Property(e => e.fld_referenceNo).IsUnicode(false);

                entity.Property(e => e.fld_remarks).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_lot_label>(entity =>
            {
                entity.Property(e => e.fld_lotNo).IsUnicode(false);

                entity.Property(e => e.fld_modelName).IsUnicode(false);

                entity.Property(e => e.fld_partCode).IsUnicode(false);

                entity.Property(e => e.fld_partName).IsUnicode(false);

                entity.Property(e => e.fld_referenceNo).IsUnicode(false);

                entity.Property(e => e.fld_remarks).IsUnicode(false);

                entity.Property(e => e.fld_transactionId).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_lot_ongoing>(entity =>
            {
                entity.HasKey(e => e.fld_id)
                    .HasName("PK__tbl_t_lo__5CBC763531958C59");

                entity.Property(e => e.fld_id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.fld_lotNo).IsUnicode(false);

                entity.Property(e => e.fld_partCode).IsUnicode(false);

                entity.Property(e => e.fld_trans).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_transaction>(entity =>
            {
                entity.Property(e => e.fld_judgement).HasDefaultValueSql("((0))");

                entity.Property(e => e.fld_prodDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fld_remarks).IsUnicode(false);

                entity.Property(e => e.fld_subAssyLotNo).IsUnicode(false);

                entity.Property(e => e.fld_transactionNo).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_transaction_detail>(entity =>
            {
                entity.Property(e => e.fld_employeeId).IsUnicode(false);

                entity.Property(e => e.fld_lotNo).IsUnicode(false);

                entity.Property(e => e.fld_referenceNo).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_transaction_header>(entity =>
            {
                entity.Property(e => e.TransNo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
