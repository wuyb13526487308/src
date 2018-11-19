CREATE TABLE [Pro_UseMateriel]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[ProName] varchar(50),
	[MatNo] varchar(50) NOT NULL,
	[MatName] varchar(50),
	[GuiGe] varchar(50),
	[UnitNo] varchar(50),
	[Quantity] numeric(10,2),
	[UseDate] datetime,
	[RegDate] datetime,
	[Creator] varchar(50)
)
;
GO
ALTER TABLE [Pro_UseMateriel] 
 ADD CONSTRAINT [PK_Pro_UseMateriel]
	PRIMARY KEY CLUSTERED ([Id])
;