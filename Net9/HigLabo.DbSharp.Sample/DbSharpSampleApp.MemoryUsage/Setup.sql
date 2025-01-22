SELECT TOP 1000000
    Z.Id,
    CONVERT(nvarchar(36), NEWID()) AS Text1,
    CONVERT(nvarchar(36), NEWID()) AS Text2,
    CONVERT(nvarchar(36), NEWID()) AS Text3
	INTO OneMillionTable
 FROM
    (SELECT ROW_NUMBER() OVER (ORDER BY X.object_id) AS Id
    FROM sys.all_objects X
    CROSS JOIN sys.all_objects Y) Z

GO

CREATE PROCEDURE OneMillionTable_SelectAll
AS

SELECT * FROM OneMillionTable

GO

