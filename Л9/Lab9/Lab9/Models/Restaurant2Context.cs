using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab9.Models;

public partial class Restaurant2Context : DbContext
{
    public Restaurant2Context()
    {
    }

    public Restaurant2Context(DbContextOptions<Restaurant2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<MealComposition> MealCompositions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAIGE\\SQLEXPRESS;Database=Restaurant_2;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.ToTable("Bill");

            entity.Property(e => e.BillId).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Bills)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bill_Employee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.BirthPlace).HasMaxLength(250);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MiddleName).HasMaxLength(250);
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.Pib)
                .HasMaxLength(752)
                .HasComputedColumnSql("(concat([LastName],' ',[FirstName],' ',[MiddleName]))", false)
                .HasColumnName("PIB");
            entity.Property(e => e.Total).HasComputedColumnSql("([Salary]+[Bonus])", false);

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Position");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.ToTable("Meal");

            entity.Property(e => e.MealId).ValueGeneratedNever();
            entity.Property(e => e.Measure).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<MealComposition>(entity =>
        {
            entity.ToTable("MealComposition");

            entity.Property(e => e.MealCompositionId).ValueGeneratedNever();
            entity.Property(e => e.Measure).HasMaxLength(50);

            entity.HasOne(d => d.Meal).WithMany(p => p.MealCompositions)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MealComposition_Meal");

            entity.HasOne(d => d.Product).WithMany(p => p.MealCompositions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MealComposition_Product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Bill).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Bill");

            entity.HasOne(d => d.Meal).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MealId)
                .HasConstraintName("FK_Order_Meal");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
