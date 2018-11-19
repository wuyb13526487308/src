CREATE TABLE [Sto_Unit]
(
	[Id] varchar(50) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Context] varchar(50)
)
;
GO
ALTER TABLE [Sto_Unit] 
 ADD CONSTRAINT [PK_Sto_Unit]
	PRIMARY KEY CLUSTERED ([Id])
;