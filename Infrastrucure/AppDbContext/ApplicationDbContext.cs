using System;
using System.Collections.Generic;
using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastrucure.AppDbContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Support> Support { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3GADTG1;user id=sa;password=kocopass;Initial Catalog=DiseaseMap;Integrated Security=false;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");

        modelBuilder.Entity<Support>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IsScomplete).HasColumnName("IsSComplete");
            entity.Property(e => e.Scontent).HasColumnName("SContent");
            entity.Property(e => e.Semail)
                .HasMaxLength(50)
                .HasColumnName("SEmail");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.Sname).HasColumnName("SName");
            entity.Property(e => e.Sphone)
                .HasMaxLength(50)
                .HasColumnName("SPhone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
