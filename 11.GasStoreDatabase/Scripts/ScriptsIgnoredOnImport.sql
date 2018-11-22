
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_Template]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_Template]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_TemplateItem]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_TemplateItem]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_BigClass]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_BigClass]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Material]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Material]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_MaterialUnit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_MaterialUnit]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Storage]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Storage]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StoreUnit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StoreUnit]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Supplier]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Supplier]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Unit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Unit]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_MaterialRequisition]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_MaterialRequisition]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_MaterialRequisitionItem]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_MaterialRequisitionItem]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_Project]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_Project]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_ProjectMateriel]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_ProjectMateriel]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_UseMateriel]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_UseMateriel]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Pro_GetMaterial]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Pro_GetMaterial]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Stock]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Stock]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockIn]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockIn]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockInItem]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockInItem]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockOut]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockOut]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockOutItem]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockOutItem]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockSettlement]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockSettlement]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_StockSettlementItem]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_StockSettlementItem]
;
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sto_Material]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sto_Material]
;
GO
