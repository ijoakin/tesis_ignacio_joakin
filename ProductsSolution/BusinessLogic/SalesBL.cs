using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using IRepositories;
using DTO;
using IBusinessLogic;

namespace BusinessLogic
{
    public class SalesBL: ISalesBL
    {
        private IRepository<Sale> saleRepository;
        private IRepository<Product> productRepository;
        private IRepository<ProductType> ProductTypeRepository;
        private IRepository<SalePoint> salePointRepository;
        private IRepository<Country> countryRepository;

        public SalesBL(IRepository<Sale> saleRepository, 
                                IRepository<Product> productRepository,
                                IRepository<ProductType> ProductTypeRepository,
                                IRepository<SalePoint> salePointTypeRepository,
                                IRepository<Country> _countryRepository)
        {
            this.saleRepository = saleRepository;
            this.productRepository = productRepository;
            this.ProductTypeRepository = ProductTypeRepository;
            this.salePointRepository = salePointTypeRepository;
            this.countryRepository = _countryRepository;
        }

        public PageServerSideDTO<SaleDTO> GetAllSalesPaginate(int page)
        {
            var r = new PageServerSideDTO<SaleDTO>();

            var salesDtoList = new List<SaleDTO>();

            var query = (from s in saleRepository.GetQuery()
                join p in productRepository.GetQuery() on s.ProductId equals p.Id
                join sp in salePointRepository.GetQuery() on s.SalePointId equals sp.Id
                select new
                {
                    Id = s.Id,
                    Amount = s.Amount,
                    Date = s.Date,
                    ProductDescription = p.Description,
                    ProductId = s.ProductId,
                    SalePointId = s.SalePointId,
                    SalePointDescription = sp.Description,
                    month = s.month,
                    year = s.year
                }).Skip(10 * (page - 1)).Take(10);
          
            foreach (var sale in query.ToList())
            {
                var saleDto = new SaleDTO()
                {
                    Id = sale.Id,
                    Amount = sale.Amount,
                    Date = sale.Date,
                    ProductDescription = sale.ProductDescription,
                    ProductId = sale.ProductId,
                    SalePointId = sale.SalePointId,
                    SalePointDescription = sale.SalePointDescription,
                    month = sale.month,
                    year = sale.year
                };
                salesDtoList.Add(saleDto);
            }

            r.Data = salesDtoList;
            r.Count = saleRepository.GetAll().Count;
            //Thread.Sleep(1000);
            return r;
        }

        public IList<SaleDTO> GetAllSales()
        {
           var salesDtoList = new List<SaleDTO>();

            var query = from s in saleRepository.GetQuery() 
                join p in productRepository.GetQuery() on s.ProductId equals p.Id
                join sp in salePointRepository.GetQuery() on s.SalePointId equals  sp.Id
                select new {
                    Id = s.Id,
                    Amount = s.Amount,
                    Date = s.Date,
                    ProductDescription = p.Description,
                    ProductId = s.ProductId,
                    SalePointId = s.SalePointId,
                    SalePointDescription = sp.Description,
                    month = s.month,
                    year = s.year
                };


            foreach (var sale in query.ToList())
           {
               var saleDto = new SaleDTO()
               {
                   Id = sale.Id,
                   Amount = sale.Amount,
                   Date = sale.Date,
                   ProductDescription = sale.ProductDescription,
                   ProductId = sale.ProductId,
                   SalePointId = sale.SalePointId,
                   SalePointDescription = sale.SalePointDescription,
                   month = sale.month,
                   year = sale.year
               };
               salesDtoList.Add(saleDto);
           }

           return salesDtoList;
        }

        public async Task<bool> SaveAsync(SaleDTO saleDto)
        {
            var sale = new Sale();

            if (saleDto.Id != 0) sale = this.saleRepository.GetById(saleDto.Id);

            sale.Id = saleDto.Id;
            sale.Amount = saleDto.Amount;
            sale.Date = saleDto.Date;
            sale.ProductId = saleDto.ProductId;
            sale.SalePointId = saleDto.SalePointId;

            return this.saleRepository.Save(sale);
        }

        public bool Save(SaleDTO saleDto)
        {
            var sale = new Sale();

            if (saleDto.Id != 0) sale = this.saleRepository.GetById(saleDto.Id);

            sale.Id = saleDto.Id;
            sale.Amount = saleDto.Amount;
            sale.Date = saleDto.Date;
            sale.ProductId = saleDto.ProductId;
            sale.SalePointId = saleDto.SalePointId;

            return this.saleRepository.Save(sale);
        }

        public bool Delete(int id)
        {
            return this.saleRepository.Delete(id);
        }

        public SaleDTO GetById(int id)
        {
            var salesDtoList = new List<SaleDTO>();

            var query = from s in saleRepository.GetQuery()
                join p in productRepository.GetQuery() on s.ProductId equals p.Id
                join sp in salePointRepository.GetQuery() on s.SalePointId equals sp.Id
                        where (s.Id == id)
                select new
                {
                    Id = s.Id,
                    Amount = s.Amount,
                    Date = s.Date,
                    ProductDescription = p.Description,
                    ProductId = s.ProductId,
                    SalePointId = s.SalePointId,
                    SalePointDescription = sp.Description
                };


            var sale = query.FirstOrDefault();
            return new SaleDTO()
                {
                    Id = sale.Id,
                    Amount = sale.Amount,
                    Date = sale.Date,
                    ProductDescription = sale.ProductDescription,
                    ProductId = sale.ProductId,
                    SalePointId = sale.SalePointId,
                    SalePointDescription = sale.SalePointDescription
                };
        }
        public async Task<IList<SalePointDTO>> GetSalesPoints()
        {
            var list = await Task.Run(() => salePointRepository.GetAll());

            var listreturn = new List<SalePointDTO>();

            var query = from sp in salePointRepository.GetQuery()
                        join c in this.countryRepository.GetQuery() on sp.CountryId equals c.Id
                        select new SalePointDTO()
                        {
                            id = sp.Id,
                            Description = sp.Description,
                            Address = sp.Address,
                            country = c.description,
                            countryId = c.Id,
                            countryCategory = c.category
                        };

            //Parallel way!!!
            /*
            Parallel.ForEach(list, (salePoint) =>
            {
                listreturn.Add(new SalePointDTO()
                {
                    id = salePoint.Id,
                    Description = salePoint.Description,
                    Address = salePoint.Address
                });
            });
            */
            return query.ToList();
        }

        public SaleDTO EntityToDto(Sale entity)
        {
            var saleDto = new SaleDTO()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Date = entity.Date,
                ProductId = entity.ProductId,
                SalePointId = entity.SalePointId
            };
            return saleDto;
        }
    }
}
