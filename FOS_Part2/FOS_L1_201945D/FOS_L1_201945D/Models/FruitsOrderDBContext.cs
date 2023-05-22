using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FOS_L1_201945D.Models
{
    public partial class FruitsOrderDBContext : DbContext
    {
        public FruitsOrderDBContext()
        {
        }

        public FruitsOrderDBContext(DbContextOptions<FruitsOrderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fruit> Fruit { get; set; }
        public virtual DbSet<FruitCategory> FruitCategory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FruitsOrderDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("Country ")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.UnitOfMeasurement)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.FruitCategory)
                    .WithMany(p => p.Fruit)
                    .HasForeignKey(d => d.FruitCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fruit_ToTable");
            });

            modelBuilder.Entity<FruitCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.SubTotal).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Fruit)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.FruitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_ToFruit");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_ToOrder");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
