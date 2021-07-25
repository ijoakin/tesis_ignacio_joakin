using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Immutable;

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
            this.repositoryStock = _repositoryStock;
            this.productRepository = _productRepository;
            this.salePointRepository = _salePointRepository;
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
    }
}
