﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RzeczyDoOddaniaV2.Data;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220604182311_UserOferty")]
    partial class UserOferty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Kod_Pocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_domu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfertaId")
                        .IsUnique();

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oferty");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.OfertaKategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.HasIndex("OfertaId");

                    b.ToTable("OfertaKategorie");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Zdjecie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<string>("ZdjeciePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfertaId");

                    b.ToTable("Zdjecia");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Adres", b =>
                {
                    b.HasOne("RzeczyDoOddaniaV2.Models.Oferta", "Oferta")
                        .WithOne("Adres")
                        .HasForeignKey("RzeczyDoOddaniaV2.Models.Adres", "OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.OfertaKategoria", b =>
                {
                    b.HasOne("RzeczyDoOddaniaV2.Models.Kategoria", "Kategoria")
                        .WithMany("OfertaKategorie")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RzeczyDoOddaniaV2.Models.Oferta", "Oferta")
                        .WithMany("OfertaKategorie")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Zdjecie", b =>
                {
                    b.HasOne("RzeczyDoOddaniaV2.Models.Oferta", "Oferta")
                        .WithMany("Zdjecia")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Kategoria", b =>
                {
                    b.Navigation("OfertaKategorie");
                });

            modelBuilder.Entity("RzeczyDoOddaniaV2.Models.Oferta", b =>
                {
                    b.Navigation("Adres");

                    b.Navigation("OfertaKategorie");

                    b.Navigation("Zdjecia");
                });
#pragma warning restore 612, 618
        }
    }
}
