﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OlymposAPI.DAL;

namespace OlymposAPI.Migrations
{
    [DbContext(typeof(ContextoDB))]
    partial class ContextoDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HookBasicApp.Models.DB.AperturaDeGavetas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CierreDeGavetasID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDeApertura")
                        .HasColumnType("datetime2");

                    b.Property<int>("FondoDeCaja")
                        .HasColumnType("int");

                    b.Property<int>("GavetasID")
                        .HasColumnType("int");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CierreDeGavetasID");

                    b.HasIndex("GavetasID");

                    b.HasIndex("SucursalesID");

                    b.HasIndex("UsuariosID");

                    b.ToTable("AperturaDeGavetas");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Categorias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaCracion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.ConfigLocal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlAfteBar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAfterDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAfterMesa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAfterParaLlevar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ConfigLocal");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Familias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Gavetas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("FondoDeCaja")
                        .HasColumnType("int");

                    b.Property<bool>("IsHabilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Gavetas");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Grupos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("FamiliasID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FamiliasID");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.LogGavetas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AperturaDeGavetasID")
                        .HasColumnType("int");

                    b.Property<int?>("CierreDeGavetasID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GavetasID")
                        .HasColumnType("int");

                    b.Property<string>("Modulo")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AperturaDeGavetasID");

                    b.HasIndex("CierreDeGavetasID");

                    b.HasIndex("GavetasID");

                    b.ToTable("LogGavetas");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.MediosDePago", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IndiceOrden")
                        .HasColumnType("int");

                    b.Property<bool>("IsCupon")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEfectivo")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHabilitado")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTarjeta")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NombreImagen")
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("MediosDePago");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.MediosPorOrden", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MediosDePagoID")
                        .HasColumnType("int");

                    b.Property<int>("MontoPagado")
                        .HasColumnType("int");

                    b.Property<int>("MontoPagadoReal")
                        .HasColumnType("int");

                    b.Property<int>("OrdenID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MediosDePagoID");

                    b.HasIndex("OrdenID");

                    b.ToTable("MediosPorOrden");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Orden", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AperturaDeGavetasID")
                        .HasColumnType("int");

                    b.Property<int?>("CierreDeGavetasID")
                        .HasColumnType("int");

                    b.Property<double>("DescuentoTotal")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("getDate()");

                    b.Property<bool>("IsAnulada")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPagada")
                        .HasColumnType("bit");

                    b.Property<double>("MontoExactoDescuento")
                        .HasColumnType("float");

                    b.Property<int>("MontoPropina")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDeOrden")
                        .HasColumnType("int");

                    b.Property<double>("PorcentajeDescuento")
                        .HasColumnType("float");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.Property<int>("TipoPedidoID")
                        .HasColumnType("int");

                    b.Property<int?>("TiposDocumentoID")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("UsuariosID")
                        .HasColumnType("int");

                    b.Property<double>("Vuelto")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("AperturaDeGavetasID");

                    b.HasIndex("CierreDeGavetasID");

                    b.HasIndex("SucursalesID");

                    b.HasIndex("TipoPedidoID");

                    b.HasIndex("TiposDocumentoID");

                    b.HasIndex("UsuariosID");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Productos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriasID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCracion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("PrecioBar")
                        .HasColumnType("int");

                    b.Property<int>("PrecioDelivery")
                        .HasColumnType("int");

                    b.Property<int>("PrecioMesa")
                        .HasColumnType("int");

                    b.Property<int>("PrecioParaLlevar")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoriasID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.ProductosPorOrden", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("MontoDescuento")
                        .HasColumnType("int");

                    b.Property<int>("OrdenID")
                        .HasColumnType("int");

                    b.Property<int>("PorcentajeDeDescuento")
                        .HasColumnType("int");

                    b.Property<int>("ProductosID")
                        .HasColumnType("int");

                    b.Property<double>("TotalDescontado")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("OrdenID");

                    b.HasIndex("ProductosID");

                    b.ToTable("ProductosPorOrden");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Sucursales", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigLocalID")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("ConfigLocalID");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.SucursalesCategoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriasID")
                        .HasColumnType("int");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoriasID");

                    b.HasIndex("SucursalesID");

                    b.ToTable("SucursalesCategoria");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.SucursalesProducto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductosID")
                        .HasColumnType("int");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductosID");

                    b.HasIndex("SucursalesID");

                    b.ToTable("SucursalesProducto");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.TipoPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("TiposPedidos");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.TiposDocumento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHabilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiiID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TiposDocumento");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Usuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("EstacionesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("getDate()");

                    b.Property<DateTime>("FechaModificacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("getDate()");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("SucursalesID")
                        .HasColumnType("int");

                    b.Property<int>("TiposUsuariosID")
                        .HasColumnType("int");

                    b.Property<string>("pin")
                        .HasColumnType("varchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("EstacionesID");

                    b.HasIndex("SucursalesID");

                    b.HasIndex("TiposUsuariosID");

                    b.HasIndex("pin")
                        .IsUnique()
                        .HasFilter("[pin] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("OlymPOS.Models.DB.CierreDeGavetas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GavetasID")
                        .HasColumnType("int");

                    b.Property<bool>("IsCierreCiego")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("GavetasID");

                    b.ToTable("CierreDeGaveta");
                });

            modelBuilder.Entity("OlymPOS.Models.DB.Descuentos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Descuentos");
                });

            modelBuilder.Entity("OlymPOS.Models.DB.Estaciones", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Estaciones");
                });

            modelBuilder.Entity("OlymPOS.Models.DB.TiposUsuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TiposUsuarios");
                });

            modelBuilder.Entity("OlymposAPI.Models.DB.LogErrores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Modulo")
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("LogErrores");
                });

            modelBuilder.Entity("OlymposAPI.Models.DB.MediosPorCierre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CierreDeGavetasID")
                        .HasColumnType("int");

                    b.Property<int>("MediosDePagoID")
                        .HasColumnType("int");

                    b.Property<long>("Monto")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("CierreDeGavetasID");

                    b.HasIndex("MediosDePagoID");

                    b.ToTable("MediosPorCierre");
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.AperturaDeGavetas", b =>
                {
                    b.HasOne("OlymPOS.Models.DB.CierreDeGavetas", "CierreDeGaveta")
                        .WithMany()
                        .HasForeignKey("CierreDeGavetasID");

                    b.HasOne("HookBasicApp.Models.DB.Gavetas", "Gaveta")
                        .WithMany()
                        .HasForeignKey("GavetasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Sucursales", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuariosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Grupos", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Familias", "Familias")
                        .WithMany()
                        .HasForeignKey("FamiliasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.LogGavetas", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.AperturaDeGavetas", "AperturaDeGavetas")
                        .WithMany()
                        .HasForeignKey("AperturaDeGavetasID");

                    b.HasOne("OlymPOS.Models.DB.CierreDeGavetas", "CierreDeGaveta")
                        .WithMany()
                        .HasForeignKey("CierreDeGavetasID");

                    b.HasOne("HookBasicApp.Models.DB.Gavetas", "Gaveta")
                        .WithMany("LogGavetas")
                        .HasForeignKey("GavetasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.MediosPorOrden", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.MediosDePago", "MediosDePago")
                        .WithMany()
                        .HasForeignKey("MediosDePagoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Orden", null)
                        .WithMany("MediosPorOrden")
                        .HasForeignKey("OrdenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Orden", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.AperturaDeGavetas", "AperturaDeGaveta")
                        .WithMany()
                        .HasForeignKey("AperturaDeGavetasID");

                    b.HasOne("OlymPOS.Models.DB.CierreDeGavetas", "CierreDeGaveta")
                        .WithMany()
                        .HasForeignKey("CierreDeGavetasID");

                    b.HasOne("HookBasicApp.Models.DB.Sucursales", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.TipoPedido", "TipoPedido")
                        .WithMany()
                        .HasForeignKey("TipoPedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.TiposDocumento", "TiposDocumento")
                        .WithMany()
                        .HasForeignKey("TiposDocumentoID");

                    b.HasOne("HookBasicApp.Models.DB.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Productos", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Categorias", "Categorias")
                        .WithMany()
                        .HasForeignKey("CategoriasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.ProductosPorOrden", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Orden", null)
                        .WithMany("ProductosPorOrden")
                        .HasForeignKey("OrdenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Sucursales", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.ConfigLocal", "ConfigLocal")
                        .WithMany()
                        .HasForeignKey("ConfigLocalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.SucursalesCategoria", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Categorias", "Categorias")
                        .WithMany("SucursalesCategoria")
                        .HasForeignKey("CategoriasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Sucursales", "Sucursales")
                        .WithMany()
                        .HasForeignKey("SucursalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.SucursalesProducto", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Productos", "Productos")
                        .WithMany("SucursalesAsociadas")
                        .HasForeignKey("ProductosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Sucursales", "Sucursales")
                        .WithMany()
                        .HasForeignKey("SucursalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HookBasicApp.Models.DB.Usuarios", b =>
                {
                    b.HasOne("OlymPOS.Models.DB.Estaciones", "Estacion")
                        .WithMany()
                        .HasForeignKey("EstacionesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HookBasicApp.Models.DB.Sucursales", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlymPOS.Models.DB.TiposUsuarios", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TiposUsuariosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OlymPOS.Models.DB.CierreDeGavetas", b =>
                {
                    b.HasOne("HookBasicApp.Models.DB.Gavetas", "Gavetas")
                        .WithMany()
                        .HasForeignKey("GavetasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OlymposAPI.Models.DB.MediosPorCierre", b =>
                {
                    b.HasOne("OlymPOS.Models.DB.CierreDeGavetas", null)
                        .WithMany("MediosPorCierre")
                        .HasForeignKey("CierreDeGavetasID");

                    b.HasOne("HookBasicApp.Models.DB.MediosDePago", "MediosDePago")
                        .WithMany()
                        .HasForeignKey("MediosDePagoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
