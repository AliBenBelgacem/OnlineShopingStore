
CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL, 
    [Description] NCHAR(500) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [Category] NCHAR(50) NOT NULL
)
