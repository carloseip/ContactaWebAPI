
CREATE TABLE [utils].[Acceso]
( 
	[IdAcceso]           int  IDENTITY ( 1,1 )  NOT NULL ,
	[Correo]             varchar(50)  NULL ,
	[Contrasenia]        varchar(50)  NULL 
)
go

ALTER TABLE [utils].[Acceso]
	ADD PRIMARY KEY  CLUSTERED ([IdAcceso] ASC)
go

CREATE TABLE [appcontacta].[Categoria]
( 
	[IdCategoria]        int  IDENTITY ( 1,1 )  NOT NULL ,
	[Descripcion]        varchar(50)  NULL 
)
go

ALTER TABLE [appcontacta].[Categoria]
	ADD PRIMARY KEY  CLUSTERED ([IdCategoria] ASC)
go

CREATE TABLE [appcontacta].[CodigoPostal]
( 
	[IdCodigoPostal]     int  IDENTITY ( 1,1 )  NOT NULL ,
	[NumeroCodigo]       varchar(20)  NULL 
)
go

ALTER TABLE [appcontacta].[CodigoPostal]
	ADD PRIMARY KEY  CLUSTERED ([IdCodigoPostal] ASC)
go

CREATE TABLE [Contacto]
( 
	[IdTarjeta]          int  NOT NULL ,
	[IdUsuario]          int  NOT NULL ,
	[Estado]             char(18)  NULL ,
	[Evento]             char(18)  NULL 
)
go

ALTER TABLE [Contacto]
	ADD PRIMARY KEY  CLUSTERED ([IdTarjeta] ASC,[IdUsuario] ASC)
go

CREATE TABLE [appcontacta].[Empresa]
( 
	[IdEmpresa]          int  IDENTITY ( 1,1 )  NOT NULL ,
	[RazonSocial]        varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[RUC]                char(11) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Telefono]           char(9) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Logo]               varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[IdRubro]            int  NOT NULL ,
	[RepresentanteLegal] varchar(50)  NULL ,
	[Direccion]          varchar(50)  NULL ,
	[IdCodigoPostal]     int  NOT NULL 
)
go

ALTER TABLE [appcontacta].[Empresa]
	ADD PRIMARY KEY  CLUSTERED ([IdEmpresa] ASC)
go

CREATE TABLE [appcontacta].[Factura]
( 
	[IdFactura]          int  IDENTITY ( 1,1 )  NOT NULL ,
	[CodigoFactura]      varchar(50)  NULL ,
	[PrecioTotal]        float  NULL ,
	[IdEmpresa]          int  NOT NULL ,
	[Fecha]              datetime  NULL 
)
go

ALTER TABLE [appcontacta].[Factura]
	ADD PRIMARY KEY  CLUSTERED ([IdFactura] ASC)
go

CREATE TABLE [appcontacta].[Factura_Servicios]
( 
	[IdFactura]          int  NOT NULL ,
	[IdServicios]        int  NOT NULL ,
	[Cantidad]           float  NULL ,
	[FechaVencimiento]   datetime  NULL 
)
go

ALTER TABLE [appcontacta].[Factura_Servicios]
	ADD PRIMARY KEY  CLUSTERED ([IdFactura] ASC,[IdServicios] ASC)
go

CREATE TABLE [utils].[InfoLogin]
( 
	[IdInfoLogin]        int  NOT NULL ,
	[Correo]             varchar(50)  NULL ,
	[InicioSesion]       datetime  NULL ,
	[FinSesion]          datetime  NULL 
)
go

ALTER TABLE [utils].[InfoLogin]
	ADD PRIMARY KEY  CLUSTERED ([IdInfoLogin] ASC)
go

CREATE TABLE [appcontacta].[Pago]
( 
	[IdPago]             int  IDENTITY ( 1,1 )  NOT NULL ,
	[IdFactura]          int  NOT NULL ,
	[Descripcion]        varchar(50)  NULL ,
	[MesVencimiento]     char(2)  NULL ,
	[AñoVencimiento]     char(4)  NULL ,
	[CodigoSeguridad]    varchar(5)  NULL ,
	[NumeroTarjeta]      char(16)  NULL ,
	[IdTipoPago]         int  NOT NULL ,
	[Documento]          varchar(50)  NULL 
)
go

ALTER TABLE [appcontacta].[Pago]
	ADD PRIMARY KEY  CLUSTERED ([IdPago] ASC)
go

CREATE TABLE [appcontacta].[Rol]
( 
	[IdRol]              int  IDENTITY ( 1,1 )  NOT NULL ,
	[NombreRol]          varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL 
)
go

ALTER TABLE [appcontacta].[Rol]
	ADD PRIMARY KEY  CLUSTERED ([IdRol] ASC)
go

CREATE TABLE [appcontacta].[Rubro]
( 
	[IdRubro]            int  IDENTITY ( 1,1 )  NOT NULL ,
	[Descripcion]        varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL 
)
go

ALTER TABLE [appcontacta].[Rubro]
	ADD PRIMARY KEY  CLUSTERED ([IdRubro] ASC)
go

CREATE TABLE [appcontacta].[Servicios]
( 
	[IdServicios]        int  IDENTITY ( 1,1 )  NOT NULL ,
	[Descripcion]        varchar(50)  NULL ,
	[Precio]             float  NULL ,
	[Estado]             bit  NULL ,
	[IdCategoria]        int  NOT NULL 
)
go

ALTER TABLE [appcontacta].[Servicios]
	ADD PRIMARY KEY  CLUSTERED ([IdServicios] ASC)
go

CREATE TABLE [appcontacta].[Sexo]
( 
	[IdSexo]             int  IDENTITY ( 1,1 )  NOT NULL ,
	[Descripcion]        varchar(50)  NULL 
)
go

ALTER TABLE [appcontacta].[Sexo]
	ADD PRIMARY KEY  CLUSTERED ([IdSexo] ASC)
go

CREATE TABLE [appcontacta].[TarjetaPresentacion]
( 
	[IdTarjeta]          int  IDENTITY ( 1,1 )  NOT NULL ,
	[Ocupación]          varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Empresa]            varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Especialidad]       varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Imagen]             varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[IdUsuario]          int  NOT NULL ,
	[IdEmpresa]          int  NULL ,
	[Telefono]           char(18)  NULL ,
	[Correo]             char(18)  NULL 
)
go

ALTER TABLE [appcontacta].[TarjetaPresentacion]
	ADD PRIMARY KEY  CLUSTERED ([IdTarjeta] ASC)
go

CREATE TABLE [appcontacta].[TipoPago]
( 
	[IdTipoPago]         int  IDENTITY ( 1,1 )  NOT NULL ,
	[Descripcion]        varchar(50)  NULL 
)
go

ALTER TABLE [appcontacta].[TipoPago]
	ADD PRIMARY KEY  CLUSTERED ([IdTipoPago] ASC)
go

CREATE TABLE [appcontacta].[Usuario]
( 
	[IdUsuario]          int  IDENTITY ( 1,1 )  NOT NULL ,
	[Nombres]            varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[ApellidoPaterno]    varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[ApellidoMaterno]    varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Correo]             varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Telefono]           char(9) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Direccion]          varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL ,
	[Estado]             bit  NULL ,
	[FechaNacimiento]    datetime  NULL ,
	[IdRol]              int  NOT NULL ,
	[IdSexo]             int  NOT NULL ,
	[IdCodigoPostal]     int  NOT NULL 
)
go

ALTER TABLE [appcontacta].[Usuario]
	ADD PRIMARY KEY  CLUSTERED ([IdUsuario] ASC)
go

CREATE TABLE [utils].[UsuariosHash]
( 
	[IdUsuariosHash]     int  IDENTITY ( 1,1 )  NOT NULL ,
	[Correo]             varchar(50)  NULL ,
	[Aleatorio]          varchar(50)  NULL 
)
go

ALTER TABLE [utils].[UsuariosHash]
	ADD PRIMARY KEY  CLUSTERED ([IdUsuariosHash] ASC)
go


ALTER TABLE [Contacto]
	ADD  FOREIGN KEY ([IdTarjeta]) REFERENCES [appcontacta].[TarjetaPresentacion]([IdTarjeta])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [Contacto]
	ADD  FOREIGN KEY ([IdUsuario]) REFERENCES [appcontacta].[Usuario]([IdUsuario])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[Empresa] WITH CHECK 
	ADD  FOREIGN KEY ([IdRubro]) REFERENCES [appcontacta].[Rubro]([IdRubro])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[Empresa]
	  WITH CHECK CHECK CONSTRAINT [R_6]
go

ALTER TABLE [appcontacta].[Empresa]
	ADD  FOREIGN KEY ([IdCodigoPostal]) REFERENCES [appcontacta].[CodigoPostal]([IdCodigoPostal])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[Factura]
	ADD  FOREIGN KEY ([IdEmpresa]) REFERENCES [appcontacta].[Empresa]([IdEmpresa])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[Factura_Servicios]
	ADD  FOREIGN KEY ([IdFactura]) REFERENCES [appcontacta].[Factura]([IdFactura])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[Factura_Servicios]
	ADD  FOREIGN KEY ([IdServicios]) REFERENCES [appcontacta].[Servicios]([IdServicios])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[Pago]
	ADD  FOREIGN KEY ([IdFactura]) REFERENCES [appcontacta].[Factura]([IdFactura])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[Pago]
	ADD  FOREIGN KEY ([IdTipoPago]) REFERENCES [appcontacta].[TipoPago]([IdTipoPago])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[Servicios]
	ADD  FOREIGN KEY ([IdCategoria]) REFERENCES [appcontacta].[Categoria]([IdCategoria])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [appcontacta].[TarjetaPresentacion] WITH CHECK 
	ADD  FOREIGN KEY ([IdUsuario]) REFERENCES [appcontacta].[Usuario]([IdUsuario])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[TarjetaPresentacion]
	  WITH CHECK CHECK CONSTRAINT [R_2]
go

ALTER TABLE [appcontacta].[TarjetaPresentacion] WITH CHECK 
	ADD  FOREIGN KEY ([IdEmpresa]) REFERENCES [appcontacta].[Empresa]([IdEmpresa])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[TarjetaPresentacion]
	  WITH CHECK CHECK CONSTRAINT [R_5]
go


ALTER TABLE [appcontacta].[Usuario] WITH CHECK 
	ADD  FOREIGN KEY ([IdRol]) REFERENCES [appcontacta].[Rol]([IdRol])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[Usuario]
	  WITH CHECK CHECK CONSTRAINT [R_1]
go

ALTER TABLE [appcontacta].[Usuario]
	ADD  FOREIGN KEY ([IdSexo]) REFERENCES [appcontacta].[Sexo]([IdSexo])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [appcontacta].[Usuario]
	ADD  FOREIGN KEY ([IdCodigoPostal]) REFERENCES [appcontacta].[CodigoPostal]([IdCodigoPostal])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go
