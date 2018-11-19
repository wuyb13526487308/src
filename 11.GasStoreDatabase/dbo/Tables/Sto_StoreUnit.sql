CREATE TABLE [Sto_StoreUnit]
(
	[Id] varchar(50) NOT NULL,
	[StoreId] varchar(50),
	[UnitNo] varchar(50),
	[UnitName] varchar(50),
	[UnitClass] varchar(50),
	[UsedState] bit DEFAULT 1,
	[CreateTime] datetime,
	[Context] varchar(100)
)
;
GO
ALTER TABLE [Sto_StoreUnit] 
 ADD CONSTRAINT [PK_Sto_StoreUnit]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_StoreUnit] 
 ADD CONSTRAINT [unique_UnitNo] UNIQUE NONCLUSTERED ([UnitNo])
;