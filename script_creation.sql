create database products2
go
use products2
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] identity(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	primary key(Id)
)
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] identity(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[ProductTypeId] [int] NOT NULL REFERENCES [ProductTypes](Id),
	primary key(Id)
) ON [PRIMARY]
GO

create table SalePoints (
	[Id] [int] identity(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	primary key(Id)
)
GO
create table Sales (
	[Id] [int] identity(1,1) NOT NULL,
	[ProductId] int references products (Id),
	SalePointId int references SalePoints (Id), 
	[Count] int,
	[Date] date,
	primary key(Id)
)
GO
insert into [ProductTypes] VALUES
('ProductType1'),
('ProductType2'),
('ProductType3'),
('ProductType4')
GO

INSERT INTO [dbo].[Products] VALUES
('Product 1', 12.2, 1), 
('Product 3', 12.2, 2), 
('Product 4', 12.2, 3), 
('Product 5', 12.2, 2),
('Product 6', 12.2, 4) 
GO
INSERT INTO SalePoints VALUES
('SalePoint 1', 'Address 1'),
('SalePoint 2', 'Address 2'),
('SalePoint 3', 'Address 3'),
('SalePoint 4', 'Address 4')
GO

INSERT INTO Sales VALUES
(1, 1, 10, GETDATE()),
(2, 1, 40, GETDATE()),
(3, 2, 20, GETDATE()),
(4, 1, 50, GETDATE()),
(2, 3, 60, GETDATE()),
(1, 4, 70, GETDATE()),
(3, 1, 80, GETDATE()),
(1, 4, 130, GETDATE())

GO

