using AutoMapper;
using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CountryBL : ICountryBL
    {

        private readonly IRepository<Country> repositoryCountry;
        private readonly IRepository<Distance> repositoryDistance;
        private readonly IRepository<SalePoint> repositorySalePoint;
        private readonly IRepository<Product> repositoryProduct;
        private readonly IRepository<Stock> repositoryStock;
        private readonly IRepository<Category> repositoryCategory;

        public CountryBL(IRepository<Country> _repositoryCountry, 
            IRepository<Distance> _repositoryDistance, 
            IRepository<SalePoint> _repositorySalePoint,
            IRepository<Product> _repositoryProduct,
            IRepository<Stock> _repositoryStock,
            IRepository<Category> _repositoryCategory)
        {
            this.repositoryCountry = _repositoryCountry ?? throw new ArgumentNullException(nameof(_repositoryCountry));
            this.repositoryDistance = _repositoryDistance ?? throw new ArgumentNullException(nameof(_repositoryDistance));
            this.repositorySalePoint = _repositorySalePoint ?? throw new ArgumentNullException(nameof(_repositorySalePoint));
            this.repositoryProduct = _repositoryProduct ?? throw new ArgumentNullException(nameof(_repositoryProduct));
            this.repositoryStock = _repositoryStock ?? throw new ArgumentNullException(nameof(_repositoryStock));
            this.repositoryCategory = _repositoryCategory ?? throw new ArgumentNullException(nameof(_repositoryCategory));
        }

        public async Task<IList<CountryDTO>> GetAllCountryDTOs()
        {
            var list = await this.repositoryCountry.GetAllAsync();
            var returnList = new List<CountryDTO>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Country, CountryDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var country in list)
            {
                var countryDto = iMapper.Map<Country, CountryDTO>(country);
                returnList.Add(countryDto);
            }
            return returnList;
        }

        public async Task<IList<DistanceDto>> GetDistanceDtosAsync()
        {
            var list = await this.repositoryDistance.GetAllAsync();
            var SalePoints = await this.repositorySalePoint.GetAllAsync();

            var returnList = new List<DistanceDto>();

            var distances = from d in this.repositoryDistance.GetQuery()
                            join so in this.repositorySalePoint.GetQuery() on d.SalePoint_origenId equals so.Id
                            join sd in this.repositorySalePoint.GetQuery() on d.SalePoint_destinoId equals sd.Id
                            join co in this.repositoryCountry.GetQuery() on so.CountryId equals co.Id
                            join cd in this.repositoryCountry.GetQuery() on sd.CountryId equals cd.Id
                            select new
                            {
                                d.Id,
                                d.SalePoint_destinoId,
                                d.SalePoint_origenId,
                                d.DistanceKm,
                                salePointOrigen = so.Description,
                                salePointDestino = sd.Description,
                                countryOrigen = co.description,
                                countryDestino = cd.description,
                              
                            };


            foreach (var distance in distances)
            {
                var distanceDto = new DistanceDto()
                {
                    DistanceKm = distance.DistanceKm,
                    Id = distance.Id,
                    SalePoint_destinoId = distance.SalePoint_destinoId,
                    salePointDestino = distance.salePointDestino,
                    SalePoint_origenId = distance.SalePoint_origenId,
                    salePointOrigen = distance.salePointOrigen,
                    countryDestino = distance.countryDestino,
                    countryOrigen = distance.countryOrigen
                };

                returnList.Add(distanceDto);
            }
            return returnList.OrderBy(x => x.DistanceKm).ToList();
        }

        public async Task<IList<DistanceDto>> GetDistanceDtosAsync(int productId)
        {
            var list = await this.repositoryDistance.GetAllAsync();
            var SalePoints = await this.repositorySalePoint.GetAllAsync();

            var returnList = new List<DistanceDto>();

            var distances = from d in this.repositoryDistance.GetQuery()
                            join so in this.repositorySalePoint.GetQuery() on d.SalePoint_origenId equals so.Id
                            join sd in this.repositorySalePoint.GetQuery() on d.SalePoint_destinoId equals sd.Id
                            join co in this.repositoryCountry.GetQuery() on so.CountryId equals co.Id
                            join cd in this.repositoryCountry.GetQuery() on sd.CountryId equals cd.Id
                            join st in this.repositoryStock.GetQuery() on so.Id equals st.SalePointId
                            join p in this.repositoryProduct.GetQuery() on st.ProductId equals p.Id
                            where p.Id == productId
                            select new
                            {
                                d.Id,
                                d.SalePoint_destinoId,
                                d.SalePoint_origenId,
                                d.DistanceKm,
                                salePointOrigen = so.Description,
                                salePointDestino = sd.Description,
                                countryOrigen = co.description,
                                countryDestino = cd.description,
                                amount = st.Amount,
                                productid = p.Id,
                                product = p.Description
                            };


            foreach (var distance in distances)
            {
                var distanceDto = new DistanceDto()
                {
                    DistanceKm = distance.DistanceKm,
                    Id = distance.Id,
                    SalePoint_destinoId = distance.SalePoint_destinoId,
                    salePointDestino = distance.salePointDestino,
                    SalePoint_origenId = distance.SalePoint_origenId,
                    salePointOrigen = distance.salePointOrigen,
                    countryDestino = distance.countryDestino,
                    countryOrigen = distance.countryOrigen,
                    Amount = distance.amount,
                    ProductDescription = distance.product,
                    Productid = distance.productid
                };

                returnList.Add(distanceDto);
            }
            return returnList.OrderBy(x=>x.DistanceKm).ToList();
        }
        public async Task<IList<DistanceDto>> GetDistanceByProductBySalePointDtosAsync(int productId, int countryId)
        {
            var list = await this.repositoryDistance.GetAllAsync();
            var SalePoints = await this.repositorySalePoint.GetAllAsync();
            

            var returnList = new List<DistanceDto>();

            var distances = from d in this.repositoryDistance.GetQuery()
                            join so in this.repositorySalePoint.GetQuery() on d.SalePoint_origenId equals so.Id
                            join sd in this.repositorySalePoint.GetQuery() on d.SalePoint_destinoId equals sd.Id
                            join co in this.repositoryCountry.GetQuery() on so.CountryId equals co.Id
                            join cd in this.repositoryCountry.GetQuery() on sd.CountryId equals cd.Id
                            join st in this.repositoryStock.GetQuery() on sd.Id equals st.SalePointId
                            join p in this.repositoryProduct.GetQuery() on st.ProductId equals p.Id
                            where (p.Id == productId && co.Id == countryId)
                            select new
                            {
                                d.Id,
                                d.SalePoint_destinoId,
                                d.SalePoint_origenId,
                                d.DistanceKm,
                                salePointOrigen = so.Description,
                                salePointDestino = sd.Description,
                                countryOrigenid = co.Id,
                                countryOrigen = co.description,
                                countryDestinoid = cd.Id,
                                countryDestino = cd.description,
                                ProductDescription = p.Description,
                                Productid = st.ProductId,
                                Amount = st.Amount
                            };

            //distances.Where(p => p.Productid.Equals(productId) && p.countryOrigenid.Equals(countryId));

            //if (productId != null)
            //{
            //    distances = distances.Where(x => x.Productid == productId);
            //}

            foreach (var distance in distances)
            {
                var distanceDto = new DistanceDto()
                {
                    DistanceKm = distance.DistanceKm,
                    Id = distance.Id,
                    SalePoint_destinoId = distance.SalePoint_destinoId,
                    salePointDestino = distance.salePointDestino,
                    SalePoint_origenId = distance.SalePoint_origenId,
                    salePointOrigen = distance.salePointOrigen,
                    countryDestino = distance.countryDestino,
                    countryOrigen = distance.countryOrigen,
                    Productid = distance.Productid,
                    ProductDescription = distance.ProductDescription,
                    Amount = distance.Amount
                };

                returnList.Add(distanceDto);
            }
            return returnList;
        }
        public async Task<IList<CategoryDto>> GetAllCategories()
        {
            var list = await this.repositoryCategory.GetAllAsync();
            var returnList = new List<CategoryDto>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDto>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var category in list)
            {
                var categoryDto = iMapper.Map<Category, CategoryDto>(category);
                returnList.Add(categoryDto);
            }
            return returnList;
        }
    }
}

