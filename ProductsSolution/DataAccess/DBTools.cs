using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DBTools : IDBTools
    {
        private ProductsDBContext context;

        public DBTools(ProductsDBContext _context)
        {
            context = _context;
        }
        public void SimulateFailSearches(int count, int month, int year)
        {
            var userId = 0;
            var cant = count;
            var salespoints = this.context.SalePoints.ToList();
            var stocks = this.context.Stocks.Where(x => x.Amount == 0).ToList();

            for (int i = 0; i < cant; i++)
            {
                Random r = new Random();
                IEnumerable<Stock> randomStocks = stocks.OrderBy(x => r.Next()).Take(1);

                var stock = randomStocks.FirstOrDefault();

                var search = new Search()
                {

                    ProductId = stock.ProductId,
                    SalePointId = stock.SalePointId,
                    UserId = 1,
                    success = false,
                    amount = r.Next(1, 100),
                    month = month,
                    year = year,
                    searchtext = "Busqueda fallida"
                };

                this.context.Searches.Add(search);
            }
            this.context.SaveChanges();
        }

        public List<MLModel> GetMLModels()
        {

            return this.context.MLModelView.ToList();

            /* var result = from sp in this.context.SalePoints
                         join c in this.context.Countries on sp.CountryId equals c.Id
                         join s in this.context.Stocks on sp.Id equals s.SalePointId
                         join p in this.context.Products on s.ProductId equals p.Id
                         select new MLModel()
                         {
                             country = c.description,
                             price = p.Price,
                             product = p.Description,
                             stockAmount = s.Amount
                         };

            return result.ToList();
            */
        }
        public bool SimulateNextMonth()
        {
            try
            {
                var currentBudget = this.context.Budget.LastOrDefault();
                var month = currentBudget.currentMonth;

                if (currentBudget.currentMonth == 12)
                {
                    currentBudget.currentMonth = 1;
                    currentBudget.currentYear = currentBudget.currentYear + 1;
                }
                else
                {
                    currentBudget.currentMonth = currentBudget.currentMonth + 1;
                }

                this.context.Update<Budget>(currentBudget);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SimulateProccessLastDays(int productId, int salePointId)
        {
            List<int> mesesConMásVentas = new List<int>() { 6, 7, 12 };

            var userId = 0;
            var salePoint = this.context.SalePoints.Where(x => x.Id == salePointId).FirstOrDefault();
            var product = this.context.Products.Where(x => x.Id == productId).FirstOrDefault();

            var lastDays = this.context.Searches.FromSql("select top 1 * from Searches order by [date] desc").FirstOrDefault();

            var lastDay = lastDays.Date;

            for (var i = 0; i < 7; i++)
            {
                lastDay = lastDay.AddDays(1);
                SimulateProccessByProductNoStock(lastDay.ToString("yyyy-MM-dd"), productId, salePointId);
            }
        }

        public void SimulateProccessByProductNoStock(string _date, int productId, int salePointId)
        {
            List<int> mesesConMásVentas = new List<int>() { 6, 7, 12 };

            var userId = 0;
            var salePoint = this.context.SalePoints.Where(x => x.Id == salePointId).FirstOrDefault();
            var product = this.context.Products.Where(x => x.Id == productId).FirstOrDefault();

            var currentBudget = this.context.Budget.LastOrDefault();
            var date = DateTime.Parse(_date);

            Random r = new Random();

            var country = context.Countries.Where(x => x.Id == salePoint.CountryId).FirstOrDefault();
            var category = context.Categories.Where(x => x.code == country.category).FirstOrDefault();

            // Verficar si van a comprar cosas más baratas o en un intervalo menor..
            IEnumerable<Stock> stocks = context.Stocks.Where(x => x.ProductId == product.Id && x.SalePointId == salePoint.Id);

            var stock = stocks.FirstOrDefault();

            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            var success = false;

            var amount = new Random().Next(1, 10);

            if (mesesConMásVentas.Contains(date.Month))
            {
                amount *= 10;
            }

            if ((stock is null) || (stock.Amount == 0))
            {
                //sale intention / stock 0
                success = false;
            }
            else
            {
                if (stock.Amount < amount) amount = stock.Amount;

                var sale = new Sale()
                {
                    ProductId = stock.ProductId,
                    SalePointId = stock.SalePointId,
                    Amount = amount,
                    UserId = 1,
                    month = month,
                    year = year,
                    Date = date,
                    day = day,
                    str_date = _date
                };
                success = true;
                this.context.Sales.Add(sale);
                stock.Amount -= amount;
                this.context.Stocks.Update(stock);
            }

            Search search = new Search()
            {
                ProductId = product.Id,
                SalePointId = salePoint.Id,
                UserId = 1,
                success = success,
                month = month,
                amount = amount,
                year = year,
                Date = date,
                day = day,
                str_date = _date,
                searchtext = success ? "success" : "fail"
            };
            this.context.Searches.Add(search);

            this.context.SaveChanges();

        }

        public void SimulateProccessByProduct(string _date, int productId, int salePointId)
        {
            List<int> mesesConMásVentas = new List<int>() { 6, 7, 12 };

            var userId = 0;
            var salePoint = this.context.SalePoints.Where(x => x.Id == salePointId).FirstOrDefault();
            var product = this.context.Products.Where(x => x.Id == productId).FirstOrDefault();

            var currentBudget = this.context.Budget.LastOrDefault();
            var date = DateTime.Parse(_date);

            Random r = new Random();

            var country = context.Countries.Where(x => x.Id == salePoint.CountryId).FirstOrDefault();
            var category = context.Categories.Where(x => x.code == country.category).FirstOrDefault();

            // Verficar si van a comprar cosas más baratas o en un intervalo menor..
            IEnumerable<Stock> stocks = context.Stocks.Where(x => x.ProductId == product.Id && x.SalePointId == salePoint.Id);

            var stock = stocks.FirstOrDefault();

            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            var success = false;

            var amount = new Random().Next(5, 10);

            if (mesesConMásVentas.Contains(date.Month))
            {
                amount *= 10;
            }

            if ((stock is null) || (stock.Amount == 0))
            {
                //sale intention / stock 0
                success = false;
            }
            else
            {
                if (stock.Amount < amount) amount = stock.Amount;

                var sale = new Sale()
                {
                    ProductId = stock.ProductId,
                    SalePointId = stock.SalePointId,
                    Amount = amount,
                    UserId = 1,
                    month = month,
                    year = year,
                    Date = date,
                    day = day,
                    str_date = _date
                };
                success = true;
                this.context.Sales.Add(sale);
                stock.Amount -= amount;
                this.context.Stocks.Update(stock);
            }

            Search search = new Search()
            {
                ProductId = product.Id,
                SalePointId = salePoint.Id,
                UserId = 1,
                success = success,
                month = month,
                amount = amount,
                year = year,
                Date = date,
                day = day,
                str_date = _date,
                searchtext = success ? "success" : "fail"
            };
            this.context.Searches.Add(search);



            this.context.SaveChanges();

        }

        public void SimulateProcess(string _date, int count)
        {
            var userId = 0;
            var cant = count;
            var salespoints = this.context.SalePoints.ToList();
            var currentBudget = this.context.Budget.LastOrDefault();
            var date = DateTime.Parse(_date);

            for (int i = 0; i < count; i++)
            {
                Random r = new Random();
                var ramdomSalePoint = salespoints.OrderBy(x => r.Next()).Take(1).FirstOrDefault();
                var country = context.Countries.Where(x => x.Id == ramdomSalePoint.CountryId).FirstOrDefault();
                var category = context.Categories.Where(x => x.code == country.category).FirstOrDefault();

                // Verficar si van a comprar cosas más baratas o en un intervalo menor..
                var products = this.context.Products.Where(p => p.Price <= category.maxprice);

                var ramdomProduct = products.OrderBy(x => r.Next()).Take(1).FirstOrDefault();

                IEnumerable<Stock> stocks = context.Stocks.Where(x => x.ProductId == ramdomProduct.Id && x.SalePointId == ramdomSalePoint.Id);

                var stock = stocks.FirstOrDefault();

                var day = new Random().Next(1, 27);
                var month = date.Month;
                var year = date.Year;

                var success = false;

                var amount = new Random().Next(1, 10);

                if ((stock is null) || (stock.Amount == 0))
                {
                    //sale intention / stock 0
                    success = false;
                }
                else
                {
                    if (stock.Amount < amount) amount = stock.Amount;

                    var sale = new Sale()
                    {
                        ProductId = stock.ProductId,
                        SalePointId = stock.SalePointId,
                        Amount = amount,
                        UserId = 1,
                        month = month,
                        year = year,
                        Date = date,
                        str_date = _date
                    };
                    success = true;
                    this.context.Sales.Add(sale);
                    stock.Amount -= amount;
                    this.context.Stocks.Update(stock);
                }

                Search search = new Search()
                {
                    ProductId = ramdomProduct.Id,
                    SalePointId = ramdomSalePoint.Id,
                    UserId = 1,
                    success = success,
                    month = month,
                    amount = amount,
                    year = year,
                    Date = date,
                    str_date = _date,
                    searchtext = success ? "success" : "fail"
                };
                this.context.Searches.Add(search);
            }
            this.context.SaveChanges();
        }

        public void SimulateSales(int count, int month, int year)
        {
            var userId = 0;
            var cant = count;
            var salespoints = this.context.SalePoints.ToList();
            var stocks = this.context.Stocks.Where(x => x.Amount > 0).ToList();

            for (int i = 0; i < cant; i++)
            {
                Random r = new Random();
                IEnumerable<Stock> randomStocks = stocks.OrderBy(x => r.Next()).Take(1);

                var stock = randomStocks.FirstOrDefault();
                var amount = new Random().Next(1, stock.Amount);

                var sale = new Sale()
                {
                    ProductId = stock.ProductId,
                    SalePointId = stock.SalePointId,
                    Amount = amount,
                    UserId = 1,
                    month = month,
                    year = year,
                    Date = DateTime.Now
                };

                this.context.Sales.Add(sale);
                stock.Amount -= amount;
                this.context.Stocks.Update(stock);
            }
            this.context.SaveChanges();
        }
        public void executeFileInserts(string file)
        {
            //var streamReader = File.OpenText(file);

            string[] lines = System.IO.File.ReadAllLines(file);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line)) this.context.Database.ExecuteSqlCommand(line);
            }
        }
        public void executeProductTypesInserts(string webRoot)
        {
            executeFileInserts(string.Format("{0}ProductTypes.sql", webRoot));
        }
        public void SimulateCompraByProduct(int productId, int salePointId, int mes)
        {
            List<int> mesesConMásVentas = new List<int>() { 6, 7, 12 };
            var stock = this.context.Stocks.Where(x => x.ProductId == productId && x.SalePointId == salePointId).FirstOrDefault();

            if(stock != null)
            {
                if (stock.Amount == 0)
                {
                    var valor = new Random().Next(1, 70);

                    if (mesesConMásVentas.Contains(mes)) valor *= 10;

                    stock.Amount = valor;
                    this.context.Update(stock);
                    this.context.SaveChanges();
                }
            }
        }
        public void AddDistanceData(int countryOrigenId, int countryDestinationId, int Kms)
        {
            var salepointOrigen = this.context.SalePoints.Where(x => x.CountryId == countryOrigenId).FirstOrDefault();
            var salepointDestino = this.context.SalePoints.Where(x => x.CountryId == countryDestinationId).FirstOrDefault();

            Distance distance = new Distance()
            {
                DistanceKm = Kms,
                SalePoint_origenId = salepointOrigen.Id,
                SalePoint_destinoId = salepointDestino.Id
            };
            this.context.Distances.Add(distance);
            this.context.SaveChanges();
        }

        public void DbInitialSalePointStockData()
        {
            try
            {
                for (int i = 1; i <= 140; i++)
                {
                    var salePoint = new SalePoint()
                    {
                        Address = "Address " + i,
                        Description = "Sale Point" + i,
                        CountryId = i
                    };
                    this.context.SalePoints.Add(salePoint);
                }
                this.context.SaveChanges();

                var salespoints = this.context.SalePoints.ToList();
               
                //Ramdom product distribution 
                for (int p = 1; p <= 100; p++)
                {
                    foreach(SalePoint sp in this.context.SalePoints)
                    {
                        var salepointId = sp.Id;
                        var stock = new Stock()
                        {
                            Amount = new Random().Next(0, 100),
                            ProductId = p,
                            SalePointId = salepointId
                        };
                        this.context.Stocks.Add(stock);
                    }
                }
                this.context.SaveChanges();

                this.AddDistanceData(6, 25, 2220);
                this.AddDistanceData(6, 39, 1407);
                this.AddDistanceData(6, 22, 2611);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CreateInitialData(string webRoot)
        {
            try
            {
                string[] strSqls = { "deleteall", "Budget", "categories", "countries", "users", "ProductTypes", "Products", "MLModel" };

                foreach (var s in strSqls)
                {
                    executeFileInserts(string.Format("{0}{1}.sql", webRoot, s));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
