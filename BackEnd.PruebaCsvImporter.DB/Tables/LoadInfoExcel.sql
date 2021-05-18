CREATE TABLE [dbo].[LoadInfoExcel]
(
	[id] int primary key identity(1,1) not null,
	[PointOfSale] varchar(max) not null,
	[Product] varchar(max) not null,
	[Date] datetime not null,
	[Stock] int not null
)
