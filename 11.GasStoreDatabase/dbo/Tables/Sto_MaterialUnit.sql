CREATE TABLE [Sto_MaterialUnit]
(
	[Id] varchar(50) NOT NULL,
	[UnitNum] varchar(50),
	[Name] varchar(50)
)
;
GO
ALTER TABLE [Sto_MaterialUnit] 
 ADD CONSTRAINT [PK_Sto_MaterialUnit]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Sto_MaterialUnit] 
 ADD CONSTRAINT [unique_UnitNum] UNIQUE NONCLUSTERED ([UnitNum])
;