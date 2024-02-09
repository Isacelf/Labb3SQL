﻿// <auto-generated />
using System;
using Labb3SQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3SQL.Migrations
{
    [DbContext(typeof(SkolaDbContext))]
    [Migration("20240209174849_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labb3SQL.Models.Befattningar", b =>
                {
                    b.Property<int>("BefattningsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("befattningsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BefattningsId"), 1L, 1);

                    b.Property<string>("Befattningstyp")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("befattningstyp");

                    b.HasKey("BefattningsId")
                        .HasName("PK__Befattni__75F2456BF1E2A8D5");

                    b.ToTable("Befattningar", (string)null);
                });

            modelBuilder.Entity("Labb3SQL.Models.Betyg", b =>
                {
                    b.Property<int>("BetygId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("betygID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BetygId"), 1L, 1);

                    b.Property<int?>("Betyg1")
                        .HasColumnType("int")
                        .HasColumnName("Betyg");

                    b.Property<string>("BetygText")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("date")
                        .HasColumnName("datum");

                    b.Property<int?>("ElevId")
                        .HasColumnType("int")
                        .HasColumnName("ElevID");

                    b.Property<int?>("KursId")
                        .HasColumnType("int")
                        .HasColumnName("KursID");

                    b.Property<int?>("PersonalId")
                        .HasColumnType("int")
                        .HasColumnName("PersonalID");

                    b.HasKey("BetygId");

                    b.HasIndex("ElevId");

                    b.HasIndex("KursId");

                    b.HasIndex("PersonalId");

                    b.ToTable("Betyg", (string)null);
                });

            modelBuilder.Entity("Labb3SQL.Models.Betygssystem", b =>
                {
                    b.Property<int>("BetygId")
                        .HasColumnType("int")
                        .HasColumnName("BetygID");

                    b.Property<string>("BetygText")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("BetygId")
                        .HasName("PK__Betygssy__E90ED048BA825088");

                    b.ToTable("Betygssystem", (string)null);
                });

            modelBuilder.Entity("Labb3SQL.Models.Kur", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KursID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KursId"), 1L, 1);

                    b.Property<string>("Kursnamn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("KursId")
                        .HasName("PK__Kurs__BCCFFF3B75D9DD9D");

                    b.ToTable("Kurs");
                });

            modelBuilder.Entity("Labb3SQL.Models.Personal", b =>
                {
                    b.Property<int>("PersonalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonalID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalId"), 1L, 1);

                    b.Property<int?>("BefattningsId")
                        .HasColumnType("int")
                        .HasColumnName("befattningsID");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Personnummer")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("personnummer");

                    b.HasKey("PersonalId");

                    b.HasIndex("BefattningsId");

                    b.ToTable("Personal", (string)null);
                });

            modelBuilder.Entity("Labb3SQL.Models.Student", b =>
                {
                    b.Property<int>("ElevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ElevID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElevId"), 1L, 1);

                    b.Property<string>("Efternamn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("efternamn");

                    b.Property<string>("Förnamn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("förnamn");

                    b.Property<string>("Klassnamn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("klassnamn");

                    b.Property<string>("Personnummer")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("personnummer");

                    b.HasKey("ElevId")
                        .HasName("PK__Student__4AE80D032FCE6C54");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Labb3SQL.Models.Betyg", b =>
                {
                    b.HasOne("Labb3SQL.Models.Student", "Elev")
                        .WithMany("Betygs")
                        .HasForeignKey("ElevId")
                        .HasConstraintName("FK__Betyg__ElevID__44FF419A");

                    b.HasOne("Labb3SQL.Models.Kur", "Kurs")
                        .WithMany("Betygs")
                        .HasForeignKey("KursId")
                        .HasConstraintName("FK__Betyg__KursID__45F365D3");

                    b.HasOne("Labb3SQL.Models.Personal", "Personal")
                        .WithMany("Betygs")
                        .HasForeignKey("PersonalId")
                        .HasConstraintName("FK__Betyg__PersonalI__46E78A0C");

                    b.Navigation("Elev");

                    b.Navigation("Kurs");

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("Labb3SQL.Models.Personal", b =>
                {
                    b.HasOne("Labb3SQL.Models.Befattningar", "Befattnings")
                        .WithMany("Personals")
                        .HasForeignKey("BefattningsId")
                        .HasConstraintName("FK__Personal__befatt__4222D4EF");

                    b.Navigation("Befattnings");
                });

            modelBuilder.Entity("Labb3SQL.Models.Befattningar", b =>
                {
                    b.Navigation("Personals");
                });

            modelBuilder.Entity("Labb3SQL.Models.Kur", b =>
                {
                    b.Navigation("Betygs");
                });

            modelBuilder.Entity("Labb3SQL.Models.Personal", b =>
                {
                    b.Navigation("Betygs");
                });

            modelBuilder.Entity("Labb3SQL.Models.Student", b =>
                {
                    b.Navigation("Betygs");
                });
#pragma warning restore 612, 618
        }
    }
}
