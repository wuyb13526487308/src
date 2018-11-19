CREATE TABLE [Pro_Project]
(
	[Id] varchar(50) NOT NULL,
	[ProCode] varchar(50) NOT NULL,
	[ProName] varchar(200) NOT NULL,
	[CreateDate] datetime NOT NULL,
	[Creator] varchar(50),
	[ProAddress] varchar(200),
	[ProLeader] varchar(50),
	[Context] varchar(500),
	[Status] varchar(10) NOT NULL DEFAULT '0'
)
;
GO
ALTER TABLE [Pro_Project] 
 ADD CONSTRAINT [PK_Pro_Project]
	PRIMARY KEY CLUSTERED ([Id])
;
GO
ALTER TABLE [Pro_Project] 
 ADD CONSTRAINT [unique_code] UNIQUE NONCLUSTERED ([ProCode])
;