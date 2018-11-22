CREATE TABLE [Sto_Stock]
(
	[Id] varchar(50) NOT NULL,
	[StoreId] varchar(50),
	[StoreUnitId] varchar(50),
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Quantity] numeric(10,2),
	[Price] varchar(50),
	[UpToTime] datetime
)
;
GO
ALTER TABLE [Sto_Stock] 
 ADD CONSTRAINT [PK_Sto_Stock]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_Stock] 
 ADD CONSTRAINT [Unique_stock] UNIQUE NONCLUSTERED ([StoreId],[MatNo])
;