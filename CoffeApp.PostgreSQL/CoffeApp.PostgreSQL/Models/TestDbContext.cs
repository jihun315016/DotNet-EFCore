using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeApp.PostgreSQL.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coffee> Coffees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TestDB;Username=postgres;Password=12345678");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Category_pkey");

            entity.ToTable("Category", "CoffeeApp");

            entity.Property(e => e.Code).HasMaxLength(2);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Coffee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Coffee_pkey");

            entity.ToTable("Coffee", "CoffeeApp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(2);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
