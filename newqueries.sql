select * from [dbo].[Sales]

SELECT [t].*
FROM (
    SELECT *
    FROM [Sales] AS [s]
    INNER JOIN [Products] AS [p] ON [s].[ProductId] = [p].[Id]
    INNER JOIN [SalePoints] AS [sp] ON [s].[SalePointId] = [sp].[Id]
) AS [t]
ORDER BY (SELECT 1)


exec sp_executesql N'SELECT [t].*
FROM (
    SELECT TOP(@__p_0) [s].[Id], [s].[Amount], [s].[Date], [p].[Description] AS [ProductDescription], [s].[ProductId], [s].[SalePointId], [sp].[Description] AS [SalePointDescription]
    FROM [Sales] AS [s]
    INNER JOIN [Products] AS [p] ON [s].[ProductId] = [p].[Id]
    INNER JOIN [SalePoints] AS [sp] ON [s].[SalePointId] = [sp].[Id]
) AS [t]
ORDER BY (SELECT 1)
OFFSET @__p_1 ROWS',N'@__p_0 int,@__p_1 int',@__p_0=10,@__p_1=0