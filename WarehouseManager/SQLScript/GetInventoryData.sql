
USE [Warehouse]
GO
CREATE  PROCEDURE GetInventoryData
AS
	SELECT
	ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as SerialNumber,
	Ob.DisplayName,
	SUM(Inp.Count) - SUM(Ou.Count) as Quantity
	FROM Object as Ob 
	inner join InputInfo as Inp
	ON Ob.Id = Inp.IdObject
	inner join OutputInfo AS Ou
	ON Ob.Id = Ou.IdObject
	GROUP BY Ob.DisplayName;
;