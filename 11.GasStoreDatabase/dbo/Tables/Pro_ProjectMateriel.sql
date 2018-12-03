CREATE TABLE [Pro_ProjectMateriel]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[ProName] varchar(200),
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[PlanQuantity] numeric(10,2),
	[Context] varchar(500)
)
;
GO
ALTER TABLE [Pro_ProjectMateriel] 
 ADD CONSTRAINT [PK_Pro_ProjectMateriel]
	PRIMARY KEY CLUSTERED ([Id])
;