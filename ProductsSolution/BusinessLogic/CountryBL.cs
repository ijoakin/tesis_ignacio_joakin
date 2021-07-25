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

        public CountryBL(IRepository<Country> _repositoryCountry, 
            IRepository<Distance> _repositoryDistance, 
            IRepository<SalePoint> _repositorySalePoint,
            IRepository<Product> _repositoryProduct,
            IRepository<Stock> _repositoryStock)
        {
            this.repositoryCountry = _repositoryCountry ?? throw new ArgumentNullException(nameof(_repositoryCountry));
            this.repositoryDistance = _repositoryDistance ?? throw new ArgumentNullException(nameof(_repositoryDistance));
            this.repositorySalePoint = _repositorySalePoint ?? throw new ArgumentNullException(nameof(_repositorySalePoint));
            this.repositoryProduct = _repositoryProduct ?? throw new ArgumentException(nameof(_repositoryProduct));
            this.repositoryStock = _repositoryStock ?? throw new ArgumentException(nameof(_repositoryStock));
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
                                countryDestino = cd.description
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
            return returnList.OrderBy(x=>x.DistanceKm).ToList();
        }
        public async Task<IList<DistanceDto>> GetDistanceByProductBySalePointDtosAsync(int productId, int salePoint)
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
                                ProductDescription = p.Description,
                                Productid = st.ProductId,
                                Amount = st.Amount
                            };

            if (productId != null)
            {
                distances = distances.Where(x => x.Productid == productId);
            }

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
            return returnList;
        }
    }
}

