using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace BusinessLogic
{
    public class StockBL: IStockBL
    {
        private IRepository<Stock> repositoryStock;
        private IRepository<Product> productRepository;
        private IRepository<SalePoint> salePointRepository;

        public StockBL(IRepository<Stock> _repositoryStock, 
            IRepository<Product> _productRepository,
            IRepository<SalePoint> _salePointRepository)
        {
            this.repositoryStock = _repositoryStock ?? throw new ArgumentNullException(nameof(_repositoryStock));
            this.productRepository = _productRepository ?? throw new ArgumentNullException(nameof(_productRepository));
            this.salePointRepository = _salePointRepository ?? throw new ArgumentNullException(nameof(_salePointRepository));
        }

        public bool Delete(int Id)
        {
            return this.repositoryStock.Delete(Id);
        }

        public async Task<IList<StockDTO>> GetAllStock()
        {
            var returnvalue = new List<StockDTO>();

            //var list = await repositoryStock.GetAllAsync();

            var query = from s in repositoryStock.GetQuery()
                         join p in productRepository.GetQuery() on s.ProductId equals p.Id
                         join sp in salePointRepository.GetQuery() on s.SalePointId equals sp.Id
                         select new StockDTO
                         {
                             Id = s.Id,
                             Amount = s.Amount,                             
                             ProductId = s.ProductId,
                             ProductDescription = p.Description,
                             SalePointDescription = sp.Description,
                             SalePointId = s.SalePointId
                         };
            return query.ToList();
        }
        public bool Save(StockDTO stockDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StockDTO, Stock>();
            });
            IMapper iMapper = config.CreateMapper();

            var stock = iMapper.Map<StockDTO, Stock>(stockDTO);

            return this.repositoryStock.Save(stock);
        }
    }
}
