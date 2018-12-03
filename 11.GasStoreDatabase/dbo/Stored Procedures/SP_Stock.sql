
CREATE PROCEDURE SP_Stock
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
declare @Stock TABLE (
	[Id] [varchar](50),
	[StoreId] [varchar](50) NULL,
	[StoreUnitId] [varchar](50) NULL,
	[MatNo] [varchar](50) NOT NULL,
	[MatName] [varchar](50) NULL,
	[GuiGe] [varchar](50) NULL,
	[UnitNo] [varchar](50) NULL,
	[Quantity] [numeric](10, 2) NULL,
	[Price] [numeric](10, 2) NULL,
	[UpToTime] [datetime] NULL,
	[BigClass] [varchar](50))

	insert into @stock
	select *  from Sto_Stock

	insert into @Stock([StoreId],
						[StoreUnitId],
						[MatNo] ,
						[MatName] ,
						[GuiGe] ,
						[UnitNo],
						[Quantity] ,
						[Price],
						[BigClass])

	SELECT   Sto_StockIn.StoreId, '' AS Expr1, Sto_StockInItem.MatNo, Sto_StockInItem.MatName, Sto_StockInItem.GuiGe, 
					Sto_StockInItem.UnitNo, Sto_StockInItem.Quantity, Sto_StockInItem.Price,Sto_Stock.BigClass
	FROM      Sto_StockIn INNER JOIN
                Sto_StockInItem ON Sto_StockIn.InNo = Sto_StockInItem.InNo INNER JOIN
                Sto_Stock ON Sto_StockInItem.MatNo = Sto_Stock.MatNo AND Sto_StockIn.StoreId = Sto_Stock.StoreId AND 
                Sto_StockIn.InDate >= Sto_Stock.UpToTime

	insert into @Stock([StoreId],
						[StoreUnitId],
						[MatNo] ,
						[MatName] ,
						[GuiGe] ,
						[UnitNo],
						[Quantity] ,
						[Price],
						[BigClass])

	SELECT   Sto_StockOut.StoreId, '' AS Expr1, Sto_StockOutItem.MatNo, Sto_StockOutItem.MatName, Sto_StockOutItem.GuiGe, 
					Sto_StockOutItem.UnitNo, Sto_StockOutItem.Quantity * -1, isnull(Sto_StockOutItem.Price,0),Sto_Stock.BigClass
	FROM      Sto_StockOut INNER JOIN
                Sto_StockOutItem ON Sto_StockOut.OutNo = Sto_StockOutItem.OutNo INNER JOIN
                Sto_Stock ON Sto_StockOutItem.MatNo = Sto_Stock.MatNo AND Sto_StockOut.StoreId = Sto_Stock.StoreId AND 
                Sto_StockOut.OutDate >= Sto_Stock.UpToTime

	select StoreId,StoreUnitId,MatNo,MatName,GuiGe,UnitNo,Sum(Quantity) as Quantity,avg(Price) as Price,BigClass from @Stock group by  StoreId,StoreUnitId,MatNo,MatName,GuiGe,UnitNo,BigClass

END