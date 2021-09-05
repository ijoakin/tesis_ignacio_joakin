using AutoMapper;
using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SearchesBL : ISearchesBL
    {
        IRepository<Search> repositorySearches;
        IRepository<Product> repositoryProduct;
        IRepository<SalePoint> repositorySalePoint; 
        public SearchesBL(IRepository<Search> _repositorySearches, IRepository<Product> _repositoryProduct, IRepository<SalePoint> _repositorySalePoint)
        {
            this.repositorySearches = _repositorySearches;
            this.repositoryProduct = _repositoryProduct;
            this.repositorySalePoint = _repositorySalePoint;
        }

        public bool SaveSearch(SearchDTO searchDTO) {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SearchDTO, Search>();
            });
            IMapper iMapper = config.CreateMapper();

            var search = iMapper.Map<SearchDTO, Search>(searchDTO);

            search.year = DateTime.Today.Year;
            search.month = DateTime.Today.Month;
            search.Date = DateTime.Today;
            search.UserId = 1;
            return this.repositorySearches.Save(search);
        }

        public async Task<IList<SearchDTO>> GetAllSearches()
        {
            var returnList = new List<SearchDTO>();

            var searchesAsync = await repositorySearches.GetAllAsync();
            var productsAsync = await repositoryProduct.GetQueryAsync();
            var salepointAsync = await repositorySalePoint.GetAllAsync();

            IEnumerable<SearchDTO> searches = from s in searchesAsync
                           join p in productsAsync on s.ProductId equals p.Id
                           join sp in salepointAsync on s.SalePointId equals sp.Id
                           orderby s.Id
                           select new SearchDTO
                           {
                               id = s.Id,
                               productDescription = p.Description,
                               ProductId = p.Id,
                               SalePointDescription = sp.Description,
                               searchtext = s.searchtext,
                               success = s.success,
                               amount = s.amount,
                               userid = s.UserId,
                               month = s.month,
                               year = s.year
                           };

            return searches.ToList();
        }
    }
}
