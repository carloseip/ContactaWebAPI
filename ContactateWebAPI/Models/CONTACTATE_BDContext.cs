using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactateWebAPI.Models
{
    public partial class CONTACTATE_BDContext : DbContext
    {
        public CONTACTATE_BDContext()
        {
        }

        public CONTACTATE_BDContext(DbContextOptions<CONTACTATE_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceso> Acceso { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CodigoPostal> CodigoPostal { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<FacturaServicios> FacturaServicios { get; set; }
        public virtual DbSet<InfoLogin> InfoLogin { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rubro> Rubro { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<TarjetaPresentacion> TarjetaPresentacion { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuariosHash> UsuariosHash { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=connection.cbl8pa1rhfhk.sa-east-1.rds.amazonaws.com; Initial Catalog=CONTACTATE_BD; User ID=carlitos; Password=987654321carlos");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.HasKey(e => e.IdAcceso)
                    .HasName("XPKAcceso");

                entity.ToTable("Acceso", "utils");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("XPKCategoria");

                entity.ToTable("Categoria", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CodigoPostal>(entity =>
            {
                entity.HasKey(e => e.IdCodigoPostal)
                    .HasName("XPKCodigoPostal");

                entity.ToTable("CodigoPostal", "appcontacta");

                entity.Property(e => e.NumeroCodigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("XPKEmpresa");

                entity.ToTable("Empresa", "appcontacta");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentanteLegal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .HasColumnName("RUC")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCodigoPostalNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdCodigoPostal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_9");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_6");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("XPKFactura");

                entity.ToTable("Factura", "appcontacta");

                entity.Property(e => e.CodigoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_10");
            });

            modelBuilder.Entity<FacturaServicios>(entity =>
            {
                entity.HasKey(e => new { e.IdFactura, e.IdServicios })
                    .HasName("XPKFactura_Servicios");

                entity.ToTable("Factura_Servicios", "appcontacta");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_12");

                entity.HasOne(d => d.IdServiciosNavigation)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => d.IdServicios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_13");
            });

            modelBuilder.Entity<InfoLogin>(entity =>
            {
                entity.HasKey(e => e.IdInfoLogin)
                    .HasName("XPKInfoLogin");

                entity.ToTable("InfoLogin", "utils");

                entity.Property(e => e.IdInfoLogin).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinSesion).HasColumnType("datetime");

                entity.Property(e => e.InicioSesion).HasColumnType("datetime");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("XPKPago");

                entity.ToTable("Pago", "appcontacta");

                entity.Property(e => e.AñoVencimiento)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSeguridad)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MesVencimiento)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_15");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_16");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("XPKRol");

                entity.ToTable("Rol", "appcontacta");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.HasKey(e => e.IdRubro)
                    .HasName("XPKRubro");

                entity.ToTable("Rubro", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.HasKey(e => e.IdServicios)
                    .HasName("XPKServicios");

                entity.ToTable("Servicios", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_14");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo)
                    .HasName("XPKSexo");

                entity.ToTable("Sexo", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TarjetaPresentacion>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("XPKTarjetaPresentacion");

                entity.ToTable("TarjetaPresentacion", "appcontacta");

                entity.Property(e => e.Correo)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Ocupación)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TarjetaPresentacion)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("R_5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TarjetaPresentacion)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_2");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago)
                    .HasName("XPKTipoPago");

                entity.ToTable("TipoPago", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("XPKUsuario");

                entity.ToTable("Usuario", "appcontacta");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCodigoPostalNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdCodigoPostal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_8");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_1");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_05");
            });

            modelBuilder.Entity<UsuariosHash>(entity =>
            {
                entity.HasKey(e => e.IdUsuariosHash)
                    .HasName("XPKUsuariosHash");

                entity.ToTable("UsuariosHash", "utils");

                entity.Property(e => e.Aleatorio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
