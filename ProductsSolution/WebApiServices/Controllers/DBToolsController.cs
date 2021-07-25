using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBToolsController : ControllerBase
    {
        IDBToolsBL _iDBTools;
        private IHostingEnvironment _env;
        public DBToolsController(IDBToolsBL iDBTools, IHostingEnvironment env)
        {
            _iDBTools = iDBTools;
            _env = env;
        }

        [HttpGet("SimulateNextMonth")]
        public bool SimulateNextMonth()
        {
            try
            {
                this._iDBTools.SimulateNextMonth();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("SimulateSales")]
        public bool SimulateSales(int count, int month, int year)
        {
            try
            {
                this._iDBTools.SimulateSales(count, month, year);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetMLModel")]
        public List<MLModelDTO> GetMLModel()
        {
            return this._iDBTools.GetMLModelDTO();
        }

        [HttpGet("DbInitialSalePointStockData")]
        public bool DbInitialSalePointStockData()
        {
            try
            {
                this._iDBTools.DbInitialSalePointStockData();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        



        [HttpGet("SimulateFailSearches")]
        public bool SimulateFailSearches(int count, int month, int year)
        {
            try
            {
                this._iDBTools.SimulateFailSearches(count, month, year);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("CreateInitialData")]
        public bool CreateInitialData()
        {
            try
            {
                var webRoot = string.Format("{0}\\Controllers\\SQL\\", _env.ContentRootPath);
                this._iDBTools.CreateInitialData(webRoot);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpGet("SimulateExecuteProccess")]
        public bool SimulateExecuteProccess(string date, int count)
        {
            try
            {
                this._iDBTools.SimulateExecuteProccess(date, count);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        [HttpGet("GetDataToGraph")]
        public async Task<IList<GraphDTO>> getDataToGraph()
        {
            return await this._iDBTools.getDataToGraph();
        }

        [HttpGet("SimulateProccessLastDays")]
        public bool SimulateProccessLastDays(int productId, int salePointId)
        {
            try
            {
                this._iDBTools.SimulateProccessLastDays(productId, salePointId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
            

        [HttpGet("SimulateExecuteProccessByProductYears")]
        public bool SimulateExecuteProccessByProductYears(int productId, int salePointId)
        {
            try
            {
                int[] years = { 2017, 2018 };

                foreach (var year in years)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        int days = DateTime.DaysInMonth(year, month);
                        for (int day = 1; day <= days; day++)
                        {
                            var date = new DateTime(year, month, day);

                            Console.WriteLine("Initial - Simulation Process - ");

                            this._iDBTools.SimulateProccessByProduct(date.ToString(), productId, salePointId);

                            if (day % 7 == 0)
                            {
                                this._iDBTools.SimulateCompraByProduct(productId, salePointId, month);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //TODO: Implement log4net
                return false;
            }
        }

        [HttpGet("SimulateExecuteProccessByProduct")]
        public bool SimulateExecuteProccessByProduct(string date, int productId, int salePointId)
        {
            try
            {
                this._iDBTools.SimulateProccessByProduct(date, productId, salePointId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}