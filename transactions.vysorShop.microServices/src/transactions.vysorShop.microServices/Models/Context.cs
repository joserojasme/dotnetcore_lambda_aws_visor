using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace transactions.vysorShop.microServices.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodegas> Bodegas { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ClientesListaPrecios> ClientesListaPrecios { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<ListaPrecios> ListaPrecios { get; set; }
        public virtual DbSet<Motivos> Motivos { get; set; }
        public virtual DbSet<MovimientoDetalleInventario> MovimientoDetalleInventario { get; set; }
        public virtual DbSet<MovimientoEncabezadoInventario> MovimientoEncabezadoInventario { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosBodegas> ProductosBodegas { get; set; }
        public virtual DbSet<ProductosListaPrecios> ProductosListaPrecios { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumento { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodegas>(entity =>
            {
                entity.ToTable("bodegas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasIndex(e => e.IdListaPrecios)
                    .HasName("Idlistaprecio_idx");

                entity.HasIndex(e => e.Identificacion)
                    .HasName("identificacion_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdListaPrecios)
                    .HasColumnName("idListaPrecios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasColumnName("identificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaNombre)
                    .HasColumnName("referenciaNombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdListaPreciosNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdListaPrecios)
                    .HasConstraintName("Idlistaprecio");
            });

            modelBuilder.Entity<ClientesListaPrecios>(entity =>
            {
                entity.ToTable("clientes_lista_precios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdListaPrecio)
                    .HasColumnName("idListaPrecio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.ToTable("empleados");

                entity.HasIndex(e => e.Documento)
                    .HasName("documento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eps)
                    .IsRequired()
                    .HasColumnName("eps")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.ToTable("estados");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListaPrecios>(entity =>
            {
                entity.ToTable("lista_precios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Motivos>(entity =>
            {
                entity.ToTable("motivos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoDetalleInventario>(entity =>
            {
                entity.ToTable("movimiento_detalle_inventario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEncabezado)
                    .HasColumnName("idEncabezado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoEncabezadoInventario>(entity =>
            {
                entity.ToTable("movimiento_encabezado_inventario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdBodegaDestino)
                    .HasColumnName("idBodegaDestino")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdBodegaOrigen)
                    .HasColumnName("idBodegaOrigen")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMotivo)
                    .HasColumnName("idMotivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoDocumento)
                    .HasColumnName("idTipoDocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("productos");

                entity.HasIndex(e => e.Codigo)
                    .HasName("codigo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Costo)
                    .HasColumnName("costo")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.FechaActualizacionCosto).HasColumnName("fechaActualizacionCosto");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Plu)
                    .HasColumnName("plu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductosBodegas>(entity =>
            {
                entity.ToTable("productos_bodegas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdBodega)
                    .HasColumnName("idBodega")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductosListaPrecios>(entity =>
            {
                entity.ToTable("productos_lista_precios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdListaPrecio)
                    .HasColumnName("idListaPrecio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.ToTable("proveedores");

                entity.HasIndex(e => e.Documento)
                    .HasName("documento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.ToTable("tipos_documento");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");

                entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transacciones>(entity =>
            {
                entity.HasKey(e => e.IdTransacciones);

                entity.ToTable("Transacciones");

                entity.Property(e => e.IdTransacciones)
                    .HasColumnName("idTransacciones")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.Estado).HasColumnType("int(11)");

                entity.Property(e => e.Intentos).HasColumnType("int(11)");

                entity.Property(e => e.Tipo).HasColumnType("int(11)");
            });
        }
    }
}
