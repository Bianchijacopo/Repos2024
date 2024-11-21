﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaVerifica3.Data;

#nullable disable

namespace ProvaVerifica3.Migrations
{
    [DbContext(typeof(UtilizziContext))]
    partial class UtilizziContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ProvaVerifica3.Model.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Classi");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Collocazione")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modello")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Studente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClasseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Utilizza", b =>
                {
                    b.Property<int>("StudenteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataOraInizioUtilizzo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataOraFineUtilizzo")
                        .HasColumnType("TEXT");

                    b.HasKey("StudenteId", "ComputerId", "DataOraInizioUtilizzo");

                    b.HasIndex("ComputerId");

                    b.ToTable("Utilizzi");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Studente", b =>
                {
                    b.HasOne("ProvaVerifica3.Model.Classe", "Classe")
                        .WithMany("Studenti")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Utilizza", b =>
                {
                    b.HasOne("ProvaVerifica3.Model.Computer", "Computer")
                        .WithMany("Utilizzi")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProvaVerifica3.Model.Studente", "Studente")
                        .WithMany("Utilizzi")
                        .HasForeignKey("StudenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");

                    b.Navigation("Studente");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Classe", b =>
                {
                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Computer", b =>
                {
                    b.Navigation("Utilizzi");
                });

            modelBuilder.Entity("ProvaVerifica3.Model.Studente", b =>
                {
                    b.Navigation("Utilizzi");
                });
#pragma warning restore 612, 618
        }
    }
}