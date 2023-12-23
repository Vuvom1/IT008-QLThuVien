using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Library_Management_App.Model
{
    public partial class QLTV : DbContext
    {
        public QLTV()
            : base("name=QLTV")
        {
        }

        public virtual DbSet<CTPM> CTPMs { get; set; }
        public virtual DbSet<CTPN> CTPNs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUTHU> PHIEUTHUs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTPM>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<CTPN>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.TENDG)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.DCHI)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TENND)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.GIOITINH)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.USERNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.PASS)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.AVA)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.PHIEUTHUs)
                .WithRequired(e => e.NGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.TENNXB)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.PHIEUTHUs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CTPNs)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTHU>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<ROLE>()
                .Property(e => e.TENROLE)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TENSACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TRIGIA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTPNs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.TENTL)
                .IsUnicode(false);
        }
    }
}
