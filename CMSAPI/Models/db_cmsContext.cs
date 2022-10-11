using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMSAPI.Models
{
    public partial class db_cmsContext : DbContext
    {
        public db_cmsContext()
        {
        }

        public db_cmsContext(DbContextOptions<db_cmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Evouncher> Evouncher { get; set; }
        public virtual DbSet<EvouncherCustomer> EvouncherCustomer { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PromoCustomer> PromoCustomer { get; set; }
        public virtual DbSet<Promocode> Promocode { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=1234;database=db_cms");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.LoginId)
                    .HasName("LoginID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.GiftedBy).HasMaxLength(45);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Evouncher>(entity =>
            {
                entity.ToTable("evouncher");

                entity.HasIndex(e => e.AddedBy)
                    .HasName("AddedBy_idx");

                entity.HasIndex(e => e.EVouncherId)
                    .HasName("VouncherID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.EVouncherId).HasColumnName("eVouncherID");

                entity.Property(e => e.ActiveStatus).HasColumnType("tinyint");

                entity.Property(e => e.Amount).HasMaxLength(45);

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(45);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Evouncher)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AddedBy");
            });

            modelBuilder.Entity<EvouncherCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("evouncher_customer");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerID_idx");

                entity.HasIndex(e => e.EVouncherId)
                    .HasName("eVouncherID_idx");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EVouncherId).HasColumnName("eVouncherID");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CustomerID2");

                entity.HasOne(d => d.EVouncher)
                    .WithMany()
                    .HasForeignKey(d => d.EVouncherId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("eVouncherID2");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerID_idx");

                entity.HasIndex(e => e.PaymentId)
                    .HasName("PaymentID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.VouncherId)
                    .HasName("VouncherID3_idx");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CardNumber).HasMaxLength(45);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DiscountPercentage).HasMaxLength(45);

                entity.Property(e => e.PaymentMethod).HasMaxLength(45);

                entity.Property(e => e.VouncherId).HasColumnName("VouncherID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CustomerID3");

                entity.HasOne(d => d.Vouncher)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.VouncherId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("VouncherID3");
            });

            modelBuilder.Entity<PromoCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("promo_customer");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerID_idx");

                entity.HasIndex(e => e.PromoCodeId)
                    .HasName("PromoCodeID_idx");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PromoCodeId).HasColumnName("PromoCodeID");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CustomerID");

                entity.HasOne(d => d.PromoCode)
                    .WithMany()
                    .HasForeignKey(d => d.PromoCodeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PromoCodeID");
            });

            modelBuilder.Entity<Promocode>(entity =>
            {
                entity.ToTable("promocode");

                entity.HasIndex(e => e.PromocodeId)
                    .HasName("PromocodeID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.VouncherId)
                    .HasName("VouncherID_idx");

                entity.Property(e => e.PromocodeId).HasColumnName("PromocodeID");

                entity.Property(e => e.PromoCode1)
                    .HasColumnName("PromoCode")
                    .HasMaxLength(45);

                entity.Property(e => e.Qr)
                    .HasColumnName("QR")
                    .HasColumnType("blob");

                entity.Property(e => e.VouncherId).HasColumnName("VouncherID");

                entity.HasOne(d => d.Vouncher)
                    .WithMany(p => p.Promocode)
                    .HasForeignKey(d => d.VouncherId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("VouncherID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.LoginId)
                    .HasName("LoginID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("Phone_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
