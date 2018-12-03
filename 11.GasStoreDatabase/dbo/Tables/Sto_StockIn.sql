CREATE TABLE [Sto_StockIn]
(
	[Id] varchar(50) NOT NULL,
	[InNo] varchar(50) NOT NULL,
	[InDate] datetime NOT NULL,
	[InOperID] varchar(50) NOT NULL,
	[Context] varchar(200),
	[State] smallint,
	[Auditor] varchar(50),
	[AuditDate] datetime,
	[StoreId] varchar(50) NOT NULL,
	[StoreUnitId] varchar(50)
)
;
GO
ALTER TABLE [Sto_StockIn] 
 ADD CONSTRAINT [PK_Sto_StockIn]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_StockIn] 
 ADD CONSTRAINT [unique_inNo] UNIQUE NONCLUSTERED ([InNo])
;