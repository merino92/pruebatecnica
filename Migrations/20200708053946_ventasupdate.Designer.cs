﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prueba.data;

namespace prueba.Migrations
{
    [DbContext(typeof(pruebaContext))]
    [Migration("20200708053946_ventasupdate")]
    partial class ventasupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("prueba.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("prueba.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoriaid")
                        .HasColumnType("int");

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("existencia")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(30, 2)");

                    b.HasKey("Id");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("prueba.Models.Tiendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tiendas");
                });

            modelBuilder.Entity("prueba.Models.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("facturado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idtienda")
                        .HasColumnType("int");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(30, 2)");

                    b.HasKey("Id");

                    b.ToTable("ventas");
                });

            modelBuilder.Entity("prueba.Models.Ventasdetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("idproducto")
                        .HasColumnType("int");

                    b.Property<int>("idventa")
                        .HasColumnType("int");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal>("subtotal")
                        .HasColumnType("decimal(30, 2)");

                    b.HasKey("Id");

                    b.ToTable("ventasdetalles");
                });
#pragma warning restore 612, 618
        }
    }
}