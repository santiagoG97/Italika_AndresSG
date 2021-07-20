Create database Italika
use Italika
create schema Catalogo
create schema Inventario

/*-----------
CREACIÓN TABLAS
-------------*/
create table Catalogo.Tipo (
Id bigint not null IDENTITY(1,1),
Descripcion varchar (20),
Activo bit,
FechaRegistro Date,
primary key (Id)
)

create table Catalogo.Modelo (
Id bigint not null IDENTITY(1,1),
Descripcion varchar (20),
Fk_IdTipo bigint, 
Activo bit,
FechaRegistro Date,
FOREIGN KEY (Fk_IdTipo) REFERENCES  Catalogo.Tipo(Id),
primary key (Id)
)

create table Catalogo.Productos (
Id Bigint not null IDENTITY(1,1),
SKU varchar (30),
Fert varchar (30),
NumSerie varchar (20),
Fk_Modelo bigint not null,
Activo bit not null,
FechaRegistro date not null,
FOREIGN KEY (Fk_Modelo) REFERENCES Catalogo.Modelo(Id),
primary key (Id)
)
/*-----------
INSERCIÓN DATOS
-------------*/
select * from Catalogo.Tipo
insert into Catalogo.Tipo values ('Trabajo', 1, GETDATE())
insert into Catalogo.Tipo values ('Deportiva', 1, GETDATE())
insert into Catalogo.Tipo values ('Motoneta', 1, GETDATE())

select * from Catalogo.Modelo 
insert into Catalogo.Modelo values ('AT110',1,1,GETDATE())
insert into Catalogo.Modelo values ('AT110LT',1,1,GETDATE())
insert into Catalogo.Modelo values ('AT110RT',1,1,GETDATE())
insert into Catalogo.Modelo values ('RT200',2,1,GETDATE())
insert into Catalogo.Modelo values ('RT250',2,1,GETDATE())
insert into Catalogo.Modelo values ('D125',3,1,GETDATE())
insert into Catalogo.Modelo values ('D125LT',3,1,GETDATE())
insert into Catalogo.Modelo values ('D150',3,1,GETDATE())

select * from Catalogo.Productos
insert into Catalogo.Productos values ('DEPOR-RT200-001','Example-Fert-001','IT-0001',4,1,getdate())
insert into Catalogo.Productos values ('DEPOR-RT250-001','Example-Fert-002','IT-0002',5,1,getdate())
insert into Catalogo.Productos values ('TRABJ-AT110-001','Example-Fert-003','IT-0003',1,1,getdate())
insert into Catalogo.Productos values ('TRABJ-AT110LT-001','Example-Fert-004','IT-0004',2,1,getdate())
insert into Catalogo.Productos values ('MOTON-D125-001','Example-Fert-005','IT-0005',6,1,getdate())
insert into Catalogo.Productos values ('MOTON-D150-001','Example-Fert-006','IT-0006',8,1,getdate())

/*-----------
PROCEDIMIENTOS ALMACENADOS
-------------*/
Create PROCEDURE  [Catalogo].[spObtenerListaProductos]
As
BEGIN 
	select p.Id,SKU, Fert, NumSerie, t.Descripcion as Tipo, m.Descripcion as Modelo  from Catalogo.Productos p
	left join Catalogo.Modelo m on m.Id = p.Fk_Modelo
	left join Catalogo.Tipo t on t.Id = m.Fk_IdTipo 
	where p.Activo = 1
END
Create PROCEDURE  [Inventario].[spEliminarProducto]
@IdProducto int
As
BEGIN 
	update Catalogo.Productos set Activo=0 where Id = @IdProducto
END
alter PROCEDURE  [Catalogo].[spObtenerProductosById]
@IdProducto int 
As
BEGIN 
	select p.Id,SKU, Fert, NumSerie, p.Fk_Modelo, m.Fk_IdTipo  from Catalogo.Productos p
	left join Catalogo.Modelo m on m.Id = p.Fk_Modelo
	where p.Id=@IdProducto and p.Activo = 1
END
Create PROCEDURE  [Catalogo].[spObtenerListaTipoProducto]
As
BEGIN 
	select Id, Descripcion, Activo, FechaRegistro from Catalogo.Tipo 
	where Activo = 1
END
create PROCEDURE  [Catalogo].[spObtenerModeloProductoByIdTipo]
@IdTipoProducto int 
As
BEGIN 
	select Id, Descripcion, Fk_IdTipo, Activo, FechaRegistro from Catalogo.Modelo 
	where Activo=1 and Fk_IdTipo = @IdTipoProducto
END
create PROCEDURE  [Catalogo].[spActualizaProducto]
@Id bigint,
@SKU varchar (30),
@Fert varchar (30),
@NumSerie varchar (20),
@Fk_Modelo bigint
As
BEGIN 
	update Catalogo.Productos set SKU = @SKU, Fert = @Fert, NumSerie=@NumSerie, Fk_Modelo = @Fk_Modelo
	where Id = @Id
END










