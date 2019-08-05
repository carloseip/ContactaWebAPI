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
        public virtual DbSet<Contacto> Contacto { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.HasKey(e => e.IdAcceso)
                    .HasName("PK__Acceso__99B2858FC1FD4691");

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
                    .HasName("PK__Categori__A3C02A10FEF5DB38");

                entity.ToTable("Categoria", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CodigoPostal>(entity =>
            {
                entity.HasKey(e => e.IdCodigoPostal)
                    .HasName("PK__CodigoPo__4D148960C55C73EC");

                entity.ToTable("CodigoPostal", "appcontacta");

                entity.Property(e => e.NumeroCodigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => new { e.IdTarjeta, e.IdUsuario })
                    .HasName("PK__Contacto__0F4267ECD8816441");

                entity.ToTable("Contacto", "appcontacta");

                entity.Property(e => e.Evento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.IdTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__IdTarj__5535A963");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__IdUsua__5629CD9C");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033E90B1D1B7");

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
                    .HasConstraintName("FK__Empresa__IdCodig__5812160E");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empresa__IdRubro__571DF1D5");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__50E7BAF16065AE0C");

                entity.ToTable("Factura", "appcontacta");

                entity.Property(e => e.CodigoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__IdEmpre__59063A47");
            });

            modelBuilder.Entity<FacturaServicios>(entity =>
            {
                entity.HasKey(e => new { e.IdFactura, e.IdServicios })
                    .HasName("PK__Factura___D0F68DD89CA95C48");

                entity.ToTable("Factura_Servicios", "appcontacta");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_S__IdFac__59FA5E80");

                entity.HasOne(d => d.IdServiciosNavigation)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => d.IdServicios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_S__IdSer__5AEE82B9");
            });

            modelBuilder.Entity<InfoLogin>(entity =>
            {
                entity.HasKey(e => e.IdInfoLogin)
                    .HasName("PK__InfoLogi__EF9D8082767683E6");

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
                    .HasName("PK__Pago__FC851A3A4EA2FA6A");

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
                    .HasConstraintName("FK__Pago__IdFactura__5BE2A6F2");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__IdTipoPago__5CD6CB2B");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CBF14EB73");

                entity.ToTable("Rol", "appcontacta");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.HasKey(e => e.IdRubro)
                    .HasName("PK__Rubro__5355E1C1F72E5246");

                entity.ToTable("Rubro", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.HasKey(e => e.IdServicios)
                    .HasName("PK__Servicio__01137299D5C928A3");

                entity.ToTable("Servicios", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Servicios__IdCat__5DCAEF64");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo)
                    .HasName("PK__Sexo__A7739FA2AC449B3C");

                entity.ToTable("Sexo", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TarjetaPresentacion>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("PK__TarjetaP__6AF43C15378FD6DE");

                entity.ToTable("TarjetaPresentacion", "appcontacta");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TarjetaPresentacion)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__TarjetaPr__IdEmp__5FB337D6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TarjetaPresentacion)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TarjetaPr__IdUsu__5EBF139D");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago)
                    .HasName("PK__TipoPago__EB0AA9E704E15B09");

                entity.ToTable("TipoPago", "appcontacta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF970CD64A5B");

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
                    .HasConstraintName("FK__Usuario__IdCodig__628FA481");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdRol__60A75C0F");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdSexo__619B8048");
            });

            modelBuilder.Entity<UsuariosHash>(entity =>
            {
                entity.HasKey(e => e.IdUsuariosHash)
                    .HasName("PK__Usuarios__ADAB6092322EE704");

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
