CREATE TABLE [Sto_Supplier]
(
	[Id] varchar(50) NOT NULL,
	[SupNumber] varchar(50),
	[SupName] varchar(50),
	[SupType] int,
	[Phone] varchar(50),
	[Fax] varchar(50),
	[Mail] varchar(100),
	[Address] varchar(50),
	[PostCode] varchar(50),
	[ContactName] varchar(50),
	[Context] varchar(100),
	[CreateTime] datetime,
	[Creater] varchar(50)
)
;
GO
ALTER TABLE [Sto_Supplier] 
 ADD CONSTRAINT [PK_Sto_Supplier]
	PRIMARY KEY CLUSTERED ([Id])
;