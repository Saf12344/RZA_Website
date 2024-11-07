using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RZA_Website.Models;

public partial class TlS2302050RzaContext : DbContext
{
    public TlS2302050RzaContext()
    {
    }

    public TlS2302050RzaContext(DbContextOptions<TlS2302050RzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attractions");

            entity.Property(e => e.AttractionId).HasColumnName("AttractionID");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "PhoneNumber").IsUnique();

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.Postcode).HasMaxLength(8);
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
