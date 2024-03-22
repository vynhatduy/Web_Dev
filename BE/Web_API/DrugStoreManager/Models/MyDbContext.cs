using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrugStoreManager.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<QuyenNguoiDung> QuyenNguoiDungs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N8FRIF0;Initial Catalog=DrugStoreManager;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHoaDon>(entity =>
            {
                entity.HasKey(e => e.HoaDonId);

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.HoaDonId).ValueGeneratedNever();

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                //entity.HasOne(d => d.HoaDon)
                //    .WithOne(p => p.CTHoaDon)
                //    .HasForeignKey<CTHoaDon>(d => d.HoaDonId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__CTHoaDon__HoaDon__5BE2A6F2");

                //entity.HasOne(d => d.SanPham)
                //    .WithMany(p => p.CTHoaDons)
                //    .HasForeignKey(d => d.SanPhamId)
                //    .HasConstraintName("FK__CTHoaDon__SanPha__0F624AF8");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.ToTable("DanhMuc");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.Sdt)
                    .HasName("PK__GioHang__CA1930A422416DD8");

                entity.ToTable("GioHang");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.TongGia).HasColumnType("decimal(18, 0)");

                //entity.HasOne(d => d.SanPham)
                //    .WithMany(p => p.GioHangs)
                //    .HasForeignKey(d => d.SanPhamId)
                //    .HasConstraintName("FK__GioHang__SanPham__10566F31");

                //entity.HasOne(d => d.SdtNavigation)
                //    .WithOne(p => p.GioHang)
                //    .HasForeignKey<GioHang>(d => d.Sdt)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__GioHang__SDT__49C3F6B7");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.TongGia).HasColumnType("decimal(18, 0)");

                //entity.HasOne(d => d.SdtNavigation)
                //    .WithMany(p => p.HoaDons)
                //    .HasForeignKey(d => d.Sdt)
                //    .HasConstraintName("FK__HoaDon__SDT__440B1D61");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.Sdt)
                    .HasName("PK__NguoiDun__CA1930A4A5042CD5");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Mk)
                    .HasMaxLength(100)
                    .HasColumnName("MK")
                    .IsFixedLength();

                entity.Property(e => e.Ten).HasMaxLength(50);

                //entity.HasOne(d => d.Quen)
                //    .WithMany(p => p.NguoiDungs)
                //    .HasForeignKey(d => d.QuenId)
                //    .HasConstraintName("FK__NguoiDung__QuenI__3D5E1FD2");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<QuyenNguoiDung>(entity =>
            {
                entity.ToTable("QuyenNguoiDung");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.ChiDinh)
                    .HasColumnType("ntext")
                    .HasColumnName("ChiDinh ");

                entity.Property(e => e.CongDung)
                    .HasColumnType("ntext")
                    .HasColumnName("CongDung ");

                entity.Property(e => e.DacDiem)
                    .HasColumnType("ntext")
                    .HasColumnName("DacDiem ");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LieuLuong)
                    .HasColumnType("ntext")
                    .HasColumnName("LieuLuong ");

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.ThanhPhan)
                    .HasColumnType("ntext")
                    .HasColumnName("ThanhPhan ");

                entity.Property(e => e.Url)
                    .HasColumnType("ntext")
                    .HasColumnName("URL ");

                //entity.HasOne(d => d.DanhMuc)
                //    .WithMany(p => p.SanPhams)
                //    .HasForeignKey(d => d.DanhMucId)
                //    .HasConstraintName("FK__SanPham__DanhMuc__0E6E26BF");

                //entity.HasOne(d => d.NhaCungCao)
                //    .WithMany(p => p.SanPhams)
                //    .HasForeignKey(d => d.NhaCungCaoId)
                //    .HasConstraintName("FK__SanPham__NhaCung__0D7A0286");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
