using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyVT.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BAO_TRI> BAO_TRI { get; set; }
        public virtual DbSet<BENH_VIEN> BENH_VIEN { get; set; }
        public virtual DbSet<DVT> DVTs { get; set; }
        public virtual DbSet<GOI_THAU> GOI_THAU { get; set; }
        public virtual DbSet<HOP_DONG> HOP_DONG { get; set; }
        public virtual DbSet<LINH_KIEN> LINH_KIEN { get; set; }
        public virtual DbSet<NGUOI_DUNG> NGUOI_DUNG { get; set; }
        public virtual DbSet<NGUOI_PHU_TRACH> NGUOI_PHU_TRACH { get; set; }
        public virtual DbSet<NHAN_VIEN_KY_THUAT> NHAN_VIEN_KY_THUAT { get; set; }
        public virtual DbSet<PHAN_QUYEN> PHAN_QUYEN { get; set; }
        public virtual DbSet<SUA_CHUA> SUA_CHUA { get; set; }
        public virtual DbSet<THIET_BI> THIET_BI { get; set; }
        public virtual DbSet<TINH_TRANG> TINH_TRANG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAO_TRI>()
                .Property(e => e.Ma_Bao_Tri)
                .IsFixedLength();

            modelBuilder.Entity<BENH_VIEN>()
                .Property(e => e.Ma_BV)
                .IsFixedLength();

            modelBuilder.Entity<BENH_VIEN>()
                .HasMany(e => e.HOP_DONG)
                .WithRequired(e => e.BENH_VIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BENH_VIEN>()
                .HasMany(e => e.THIET_BI)
                .WithRequired(e => e.BENH_VIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DVT>()
                .Property(e => e.Ma_DVT)
                .IsFixedLength();

            modelBuilder.Entity<DVT>()
                .HasMany(e => e.LINH_KIEN)
                .WithRequired(e => e.DVT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GOI_THAU>()
                .Property(e => e.Ma_Goi_Thau)
                .IsFixedLength();

            modelBuilder.Entity<GOI_THAU>()
                .HasMany(e => e.THIET_BI)
                .WithRequired(e => e.GOI_THAU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOP_DONG>()
                .Property(e => e.Ma_HD)
                .IsFixedLength();

            modelBuilder.Entity<HOP_DONG>()
                .Property(e => e.Ghi_Chu)
                .IsFixedLength();

            modelBuilder.Entity<HOP_DONG>()
                .HasMany(e => e.BAO_TRI)
                .WithRequired(e => e.HOP_DONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOP_DONG>()
                .HasMany(e => e.SUA_CHUA)
                .WithRequired(e => e.HOP_DONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LINH_KIEN>()
                .Property(e => e.Ma_So_LK)
                .IsFixedLength();

            modelBuilder.Entity<LINH_KIEN>()
                .Property(e => e.Nam_SX)
                .IsFixedLength();

            modelBuilder.Entity<LINH_KIEN>()
                .HasMany(e => e.THIET_BI)
                .WithRequired(e => e.LINH_KIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOI_DUNG>()
                .Property(e => e.Ma_Nguoi_Dung)
                .IsFixedLength();

            modelBuilder.Entity<NGUOI_PHU_TRACH>()
                .Property(e => e.Ma_Nguoi_Phu_Trach)
                .IsFixedLength();

            modelBuilder.Entity<NGUOI_PHU_TRACH>()
                .Property(e => e.Ma_BV)
                .IsFixedLength();

            modelBuilder.Entity<NGUOI_PHU_TRACH>()
                .HasMany(e => e.HOP_DONG)
                .WithRequired(e => e.NGUOI_PHU_TRACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAN_VIEN_KY_THUAT>()
                .Property(e => e.Ma_NV_KT)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN_KY_THUAT>()
                .HasMany(e => e.HOP_DONG)
                .WithRequired(e => e.NHAN_VIEN_KY_THUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHAN_QUYEN>()
                .HasMany(e => e.NGUOI_DUNG)
                .WithRequired(e => e.PHAN_QUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUA_CHUA>()
                .Property(e => e.Ma_Sua_Chua)
                .IsFixedLength();

            modelBuilder.Entity<THIET_BI>()
                .Property(e => e.Ma_TB)
                .IsFixedLength();

            modelBuilder.Entity<THIET_BI>()
                .HasMany(e => e.BAO_TRI)
                .WithRequired(e => e.THIET_BI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THIET_BI>()
                .HasMany(e => e.HOP_DONG)
                .WithRequired(e => e.THIET_BI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THIET_BI>()
                .HasMany(e => e.SUA_CHUA)
                .WithRequired(e => e.THIET_BI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINH_TRANG>()
                .Property(e => e.Ma_TT_LK)
                .IsFixedLength();

            modelBuilder.Entity<TINH_TRANG>()
                .HasMany(e => e.LINH_KIEN)
                .WithRequired(e => e.TINH_TRANG)
                .HasForeignKey(e => e.ID_TINH_TRANG)
                .WillCascadeOnDelete(false);
        }
    }
}
