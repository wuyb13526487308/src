CREATE TABLE [Sto_StockOut]
(
	[Id] varchar(50) NOT NULL,
	[OutNo] varchar(50) NOT NULL,
	[OutDate] datetime NOT NULL,
	[OutOperID] varchar(50) NOT NULL,
	[Context] varchar(50),
	[State] smallint NOT NULL DEFAULT 0,
	[Auditor] varchar(50),
	[AuditDate] datetime,
	[OutType] smallint,
	[ApplyNo] varchar(50),
	[StoreId] varchar(50) NOT NULL
)
;
GO
ALTER TABLE [Sto_StockOut] 
 ADD CONSTRAINT [PK_Sto_StockOut]
	PRIMARY KEY CLUSTERED ([Id])
;