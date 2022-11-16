﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_ferreteria;

namespace api_ferreteria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api_ferreteria.Entitys.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("numdocumento")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Comprobante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<int>("FormaPagoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("date");

                    b.Property<decimal>("igv")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("subtotal")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(20,2)");

                    b.HasKey("id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("FormaPagoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comprobante");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Detalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComprobanteId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("importe")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(20,2)");

                    b.HasKey("id");

                    b.HasIndex("ComprobanteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Documento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.HasIndex("RolId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.FormaPago", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("FormaPago");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("contraseña")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("pregunta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("respuesta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Comprobante", b =>
                {
                    b.HasOne("api_ferreteria.Entitys.Cliente", null)
                        .WithMany("comprobante")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_ferreteria.Entitys.Documento", null)
                        .WithMany("comprobante")
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_ferreteria.Entitys.FormaPago", null)
                        .WithMany("comprobante")
                        .HasForeignKey("FormaPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_ferreteria.Entitys.Usuario", null)
                        .WithMany("comprobante")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Detalle", b =>
                {
                    b.HasOne("api_ferreteria.Entitys.Comprobante", null)
                        .WithMany("detalle")
                        .HasForeignKey("ComprobanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_ferreteria.Entitys.Producto", null)
                        .WithMany("detalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Empleado", b =>
                {
                    b.HasOne("api_ferreteria.Entitys.Rol", null)
                        .WithMany("empleado")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Producto", b =>
                {
                    b.HasOne("api_ferreteria.Entitys.Categoria", null)
                        .WithMany("producto")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Usuario", b =>
                {
                    b.HasOne("api_ferreteria.Entitys.Empleado", null)
                        .WithOne("usuario")
                        .HasForeignKey("api_ferreteria.Entitys.Usuario", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Categoria", b =>
                {
                    b.Navigation("producto");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Cliente", b =>
                {
                    b.Navigation("comprobante");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Comprobante", b =>
                {
                    b.Navigation("detalle");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Documento", b =>
                {
                    b.Navigation("comprobante");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Empleado", b =>
                {
                    b.Navigation("usuario");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.FormaPago", b =>
                {
                    b.Navigation("comprobante");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Producto", b =>
                {
                    b.Navigation("detalle");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Rol", b =>
                {
                    b.Navigation("empleado");
                });

            modelBuilder.Entity("api_ferreteria.Entitys.Usuario", b =>
                {
                    b.Navigation("comprobante");
                });
#pragma warning restore 612, 618
        }
    }
}
