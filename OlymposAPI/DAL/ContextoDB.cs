using HookBasicApp.Models.DB;
using Microsoft.EntityFrameworkCore;
using OlymPOS.Models.DB;
using OlymposAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlymposAPI.DAL
{
    public class ContextoDB: DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {

        }

        public ContextoDB()
        {

        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<ConfigLocal> ConfigLocal { get; set; }
        public DbSet<Familias> Familias { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<TipoPedido> TiposPedidos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<MediosPorOrden> MediosPorOrden { get; set; }
        public DbSet<ProductosPorOrden> ProductosPorOrden { get; set; }
        public DbSet<AperturaDeGavetas> AperturaDeGavetas { get; set; }
        public DbSet<Gavetas> Gavetas { get; set; }
        public DbSet<LogGavetas> LogGavetas { get; set; }
        public DbSet<CierreDeGavetas> CierreDeGaveta { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<MediosPorCierre> MediosPorCierre { get; set; }
        public DbSet<LogErrores> LogErrores { get; set; }
        public DbSet<MensajesCocina> MensajesCocina { get; set; }
        public DbSet<MensajesProductos> MensajesProductos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .Property(p => p.FechaCreacion)
                .HasComputedColumnSql("getDate()");

            modelBuilder.Entity<Usuarios>()
                .Property(p => p.FechaModificacion)
                .HasComputedColumnSql("getDate()");



            modelBuilder.Entity<Orden>()
              .Property(p => p.FechaModificacion)
              .HasComputedColumnSql("getDate()");

            modelBuilder.Entity<AperturaDeGavetas>().HasOne(e => e.Gaveta).WithMany();

            modelBuilder.Entity<Usuarios>()
            .HasIndex(u => u.pin)
            .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=DESKTOP-H3TI05U\\SQLEXPRESS;Database=POS;User Id=SA;Password=1234;");
        }

        public DbSet<HookBasicApp.Models.DB.MediosDePago> MediosDePago { get; set; }

        public DbSet<HookBasicApp.Models.DB.TiposDocumento> TiposDocumento { get; set; }

    }
}
