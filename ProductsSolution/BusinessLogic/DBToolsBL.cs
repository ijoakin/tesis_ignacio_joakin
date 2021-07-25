using AutoMapper;
using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<MLModel, MLModelDTO>();
        }
    }

    public class DBToolsBL : IDBToolsBL
    {
        IRepository<Search> repositorySearch;

        IDBTools _dBTools;
        public DBToolsBL(IDBTools dBTools, IRepository<Search> _repositorySearch)
        {
            this._dBTools = dBTools;
            repositorySearch = _repositorySearch;
        }

        public List<MLModelDTO> GetMLModelDTO()
        {
            var result = new List<MLModelDTO>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            Mapper mapper = new Mapper(mappingConfig);
            var entities = this._dBTools.GetMLModels();

            foreach (var entity in entities)
            {
                result.Add(mapper.Map<MLModel, MLModelDTO>(entity));
            }

            return result;
        }

        public async Task<List<GraphDTO>> getDataToGraph()
        {
            try
            {
                var listsearchs = await repositorySearch.GetAllAsync();

                var result = from s in listsearchs
                             group s by new { s.year, s.month, s.success } into g
                             orderby g.Key.year, g.Key.month
                             select new GraphDTO()
                             {
                                 year = g.Key.year,
                                 month = g.Key.month,
                                 success = g.Key.success,
                                 amount = g.Sum(x => x.amount)
                             };


                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getMLValues()
        {

        }

        public void SimulateSales(int count, int month, int year)
        {
            try
            {
                this._dBTools.SimulateSales(count, month, year);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        public void DbInitialSalePointStockData()
        {
            try
            {
                this._dBTools.DbInitialSalePointStockData();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public void SimulateCompraByProduct(int productId, int salePointId, int mes)
        {
            try
            {
                this._dBTools.SimulateCompraByProduct(productId, salePointId, mes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void SimulateFailSearches(int count, int month, int year)
        {
            try
            {
                this._dBTools.SimulateFailSearches(count, month, year);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void SimulateProccessLastDays(int productId, int salePointId)
        {
            try
            {
                this._dBTools.SimulateProccessLastDays(productId, salePointId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SimulateProccessByProduct(string _date, int productId, int salePointId)
        {
            try
            {
                this._dBTools.SimulateProccessByProduct(_date, productId, salePointId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SimulateExecuteProccess(string date, int count)
        {
            try
            {
                this._dBTools.SimulateProcess(date, count);
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
                this._dBTools.CreateInitialData(webRoot);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SimulateNextMonth()
        {
            try
            {
                this._dBTools.SimulateNextMonth();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
