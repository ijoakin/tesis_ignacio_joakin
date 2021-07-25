using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbInitializer
    {
        private ProductsDBContext context;

        public DbInitializer(ProductsDBContext _context)
        {
            context = _context;
        }

        public static void SimulateSales(ProductsDBContext dbContext)
        {
            var userId = 1;
        }
        public void DbInitialSalePointStockData()
        {
            for (int i = 0; i < 140; i++)
            {
                var salePoint = new SalePoint()
                {
                    Address = "Address " + i,
                    Description = "Sale Point" + i,
                    CountryId = i
                };
                this.context.SalePoints.Add(salePoint);
            }

            for (int p = 0; p < 2700; p++)
            {
                for (int sp = 0; sp < 140; sp++)
                {
                    var stock = new Stock()
                    {
                        Amount = new Random().Next(1, 10),
                        ProductId = p,
                        SalePointId = sp
                    };
                    this.context.Stocks.Add(stock);
                }
            }
        }

        public static void DbInitializerFirstUse(ProductsDBContext dbContext)
        {
            int cant = 1000;
            var price = new Random();

            for (int i = 0; i < cant; i++)
            {
                var user = new User()
                {
                    UserName = "user" + i,
                    Password = "password"
                };
                dbContext.Users.Add(user);
            }

            for (int i = 0; i < 100; i++)
            {
                dbContext.ProductTypes.Add(new ProductType()
                {
                    Description = "Product Type "+i
                });
            }

            dbContext.SaveChanges();

            for (int i = 0; i < cant; i++)
            {
                var product = new Product()
                {
                    Description = "Product " + i,
                    Price = (decimal)(price.Next(1,100)+ price.NextDouble()),
                    ProductTypeId = 1,
                    UserId = 1
                };
                dbContext.Products.Add(product);
            }

            for (int i = 0; i < 50; i++)
            {
                var salePoint = new SalePoint()
                {
                    Address = "Address " + i,
                    Description = "Sale Point" + i,
                    CountryId = new Random().Next(1, 100)
                };
                dbContext.SalePoints.Add(salePoint);
            }

            var points = new Random();
            for (int i = 0; i < cant; i++)
            {
                var sale = new Sale()
                {
                    SalePointId = points.Next(1,50),
                    ProductId = new Random().Next(1, cant),
                    Date = DateTime.Today,
                    Amount = new Random().Next(1,50),
                    UserId = 1
                };
                dbContext.Sales.Add(sale);
            }
            var productRandom = new Random();
            for (int i = 0; i < cant; i++)
            {

                var search = new Search()
                {
                    SalePointId = points.Next(1, 50),
                    searchtext = "Product",
                    ProductId = productRandom.Next(1, cant),
                    success = new Random().NextDouble() > 0.5,
                    UserId = new Random().Next(1, 50)
                };
                dbContext.Searches.Add(search);
            }

            dbContext.SaveChanges();
        }
    }
}
