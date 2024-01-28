using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3SQL.Models
{
    public partial class SkolaDbContext : DbContext
    {
        public SkolaDbContext()
        {
        }

        public SkolaDbContext(DbContextOptions<SkolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Befattningar> Befattningars { get; set; } = null!;
        public virtual DbSet<Betyg> Betygs { get; set; } = null!;
        public virtual DbSet<Betygssystem> Betygssystems { get; set; } = null!;
        public virtual DbSet<Kur> Kurs { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source = DESKTOP-330DSTL;Initial Catalog = gymnasieskola;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Befattningar>(entity =>
            {
                entity.HasKey(e => e.BefattningsId)
                    .HasName("PK__Befattni__75F2456BF1E2A8D5");

                entity.ToTable("Befattningar");

                entity.Property(e => e.BefattningsId).HasColumnName("befattningsID");

                entity.Property(e => e.Befattningstyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("befattningstyp");
            });

            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.ToTable("Betyg");

                entity.Property(e => e.BetygId).HasColumnName("betygID");

                entity.Property(e => e.Betyg1).HasColumnName("Betyg");

                entity.Property(e => e.BetygText)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.HasOne(d => d.Elev)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK__Betyg__ElevID__44FF419A");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK__Betyg__KursID__45F365D3");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK__Betyg__PersonalI__46E78A0C");
            });

            modelBuilder.Entity<Betygssystem>(entity =>
            {
                entity.HasKey(e => e.BetygId)
                    .HasName("PK__Betygssy__E90ED048BA825088");

                entity.ToTable("Betygssystem");

                entity.Property(e => e.BetygId)
                    .ValueGeneratedNever()
                    .HasColumnName("BetygID");

                entity.Property(e => e.BetygText)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kur>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Kurs__BCCFFF3B75D9DD9D");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.Kursnamn)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.BefattningsId).HasColumnName("befattningsID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("personnummer");

                entity.HasOne(d => d.Befattnings)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.BefattningsId)
                    .HasConstraintName("FK__Personal__befatt__4222D4EF");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.ElevId)
                    .HasName("PK__Student__4AE80D032FCE6C54");

                entity.ToTable("Student");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efternamn");

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("förnamn");

                entity.Property(e => e.Klassnamn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("klassnamn");

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("personnummer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
