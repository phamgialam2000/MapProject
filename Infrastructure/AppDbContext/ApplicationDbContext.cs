using System;
using System.Collections.Generic;
using MapProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastructure.AppDbContext;

public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patient { get; set; }
    public virtual DbSet<Support> Support { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3GADTG1;user id=sa;password=kocopass;Initial Catalog=DiseaseMap;Integrated Security=false;TrustServerCertificate=True;");
    //=> optionsBuilder.UseSqlServer("Server=db12048.databaseasp.net; Database=db12048; User Id=db12048; Password=5Lw#Zr%8t2J@; Encrypt=True; MultipleActiveResultSets=True;Integrated Security=false;TrustServerCertificate=True;");

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Support> Supports => Set<Support>();
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");

        modelBuilder.Entity<Patient>(entity =>
        {
            //entity.HasNoKey();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .HasColumnName("DATE");
            entity.Property(e => e.District).HasColumnName("DISTRICT");
            entity.Property(e => e.Group).HasColumnName("GROUP");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Latitude).HasColumnName("LATITUDE");
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .HasColumnName("LEVEL");
            entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .HasColumnName("NOTE");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("TYPE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
