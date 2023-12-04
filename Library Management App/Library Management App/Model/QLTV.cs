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

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<GIANGDAY> GIANGDAYs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<HOCTAP> HOCTAPs { get; set; }
        public virtual DbSet<KETQUA> KETQUAs { get; set; }
        public virtual DbSet<KHOI> KHOIs { get; set; }
        public virtual DbSet<LOAIDIEM> LOAIDIEMs { get; set; }
        public virtual DbSet<LOGIN> LOGINs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<NHANXET> NHANXETs { get; set; }
        public virtual DbSet<PHUHUYNH> PHUHUYNHs { get; set; }
        public virtual DbSet<TBMON> TBMONs { get; set; }
        public virtual DbSet<THANHTICH> THANHTICHes { get; set; }
        public virtual DbSet<THI> THIs { get; set; }
        public virtual DbSet<TO1> TO1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.AVA)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.AVA)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.GIANGDAYs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.LOPs)
                .WithOptional(e => e.GIAOVIEN)
                .HasForeignKey(e => e.GVCN);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.TO11)
                .WithOptional(e => e.GIAOVIEN)
                .HasForeignKey(e => e.TOTRUONG);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.SOHIEU)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.NIENKHOA)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.AVA)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.LOPs)
                .WithOptional(e => e.HOCSINH)
                .HasForeignKey(e => e.LOPTRUONG);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.NHANXETs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasOptional(e => e.PHUHUYNH)
                .WithRequired(e => e.HOCSINH);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.TBMONs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.DTB)
                .HasPrecision(3, 1);

            modelBuilder.Entity<LOGIN>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<LOGIN>()
                .Property(e => e.USERPASS)
                .IsUnicode(false);

            modelBuilder.Entity<LOGIN>()
                .HasMany(e => e.ADMINs)
                .WithOptional(e => e.LOGIN)
                .HasForeignKey(e => e.MALOGIN);

            modelBuilder.Entity<LOGIN>()
                .HasMany(e => e.GIAOVIENs)
                .WithOptional(e => e.LOGIN)
                .HasForeignKey(e => e.MALOGIN);

            modelBuilder.Entity<LOGIN>()
                .HasMany(e => e.HOCSINHs)
                .WithOptional(e => e.LOGIN)
                .HasForeignKey(e => e.MALOGIN);

            modelBuilder.Entity<LOP>()
                .Property(e => e.TENLOP)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .Property(e => e.NAMHOC)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.GIANGDAYs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.NHANXETs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.TBMONs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.GIANGDAYs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.TBMONs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUHUYNH>()
                .Property(e => e.SDTBO)
                .IsUnicode(false);

            modelBuilder.Entity<PHUHUYNH>()
                .Property(e => e.SDTME)
                .IsUnicode(false);

            modelBuilder.Entity<TBMON>()
                .Property(e => e.DTB)
                .IsUnicode(false);

            modelBuilder.Entity<THI>()
                .Property(e => e.DIEM)
                .IsUnicode(false);

            modelBuilder.Entity<TO1>()
                .HasMany(e => e.GIAOVIENs)
                .WithOptional(e => e.TO1)
                .HasForeignKey(e => e.MATO);
        }
    }
}
