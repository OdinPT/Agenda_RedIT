﻿// <auto-generated />
using System;
using Agenda.APi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agenda.APi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200522131813_phototonotes")]
    partial class phototonotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Agenda.APi.Models.Contact", b =>
                {
                    b.Property<int>("IdContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataAniversarioContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailContact")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroContact")
                        .HasColumnType("TEXT");

                    b.HasKey("IdContact");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("Agenda.APi.Models.Employee", b =>
                {
                    b.Property<int>("IdEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactNumEmp")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailEmp")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordEmp")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHashEmp")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSaltEmp")
                        .HasColumnType("BLOB");

                    b.Property<string>("UsernameEmp")
                        .HasColumnType("TEXT");

                    b.HasKey("IdEmp");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Agenda.APi.Models.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactIdContact")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDownFoto")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescFoto")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NotaIdNota")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlFoto")
                        .HasColumnType("TEXT");

                    b.HasKey("IdFoto");

                    b.HasIndex("ContactIdContact");

                    b.HasIndex("NotaIdNota");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("Agenda.APi.Models.Nota", b =>
                {
                    b.Property<int>("IdNota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescNota")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id_Func")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TituloNota")
                        .HasColumnType("TEXT");

                    b.HasKey("IdNota");

                    b.ToTable("Notacoes");
                });

            modelBuilder.Entity("Agenda.APi.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("values");
                });

            modelBuilder.Entity("Agenda.APi.Models.Foto", b =>
                {
                    b.HasOne("Agenda.APi.Models.Contact", null)
                        .WithMany("Photos")
                        .HasForeignKey("ContactIdContact");

                    b.HasOne("Agenda.APi.Models.Nota", null)
                        .WithMany("Photos")
                        .HasForeignKey("NotaIdNota");
                });
#pragma warning restore 612, 618
        }
    }
}
