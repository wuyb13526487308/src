CREATE TABLE [Sto_BigClass]
(
	[Id] varchar(50) NOT NULL,
	[BigClassCode] varchar(50) NOT NULL,
	[BigClassName] varchar(50) NOT NULL,
	[LastTime] datetime,
	[Context] varchar(50)
)
;
GO
ALTER TABLE [Sto_BigClass] 
 ADD CONSTRAINT [PK_Sto_BigClass]
	PRIMARY KEY CLUSTERED ([Id])
;