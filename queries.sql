select * from Users

select * from Products

select * from SalePoints


USE [Products]
GO

USE [Products]
GO
select * from [ProductTypes]
INSERT INTO [dbo].[ProductTypes]
           ([Description])
     VALUES
           ('Testing')
GO

select * from Users

INSERT INTO [dbo].[Products]
           ([Description]
           ,[Price]
           ,[ProductTypeId]
           ,[UserId])
     VALUES
           ('asdas0'
           ,12
           ,1
           ,1)
GO

