using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SQICS_Api.Model;

#nullable disable

namespace SQICS_Api.Model.Context
{
    public partial class SQICSContext : DbContext
    {
        public SQICSContext(DbContextOptions<SQICSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbl_m_bom> tbl_m_boms { get; set; }
        public virtual DbSet<tbl_m_operator> tbl_m_operators { get; set; }
        public virtual DbSet<tbl_m_operator_assy> tbl_m_operator_assies { get; set; }
        public virtual DbSet<tbl_m_operator_station> tbl_m_operator_stations { get; set; }
        public virtual DbSet<tbl_m_part> tbl_m_parts { get; set; }
        public virtual DbSet<tbl_m_user> tbl_m_users { get; set; }
        public virtual DbSet<tbl_t_assy_defect> tbl_t_assy_defects { get; set; }
        public virtual DbSet<tbl_t_lot_label> tbl_t_lot_labels { get; set; }
        public virtual DbSet<tbl_t_transaction> tbl_t_transactions { get; set; }
        public virtual DbSet<tbl_t_transaction_detail> tbl_t_transaction_details { get; set; }

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
                entity.Property(e => e.fld_transactionId).IsUnicode(false);
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

            modelBuilder.Entity<tbl_t_transaction>(entity =>
            {
                entity.Property(e => e.fld_prodDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fld_transactionNo).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_t_transaction_detail>(entity =>
            {
                entity.Property(e => e.fld_employeeId).IsUnicode(false);

                entity.Property(e => e.fld_lotNo).IsUnicode(false);

                entity.Property(e => e.fld_referenceNo).IsUnicode(false);

                entity.Property(e => e.fld_transactionId).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
