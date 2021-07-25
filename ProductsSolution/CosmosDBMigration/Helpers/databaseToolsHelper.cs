using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBMigration.Helpers
{
    public class DatabaseToolsHelper
    {
        const string baseUrl = "https://localhost:44313/api/";

        public async Task<bool> CreateInitialData()
        {
            int count = 0;
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;
            bool returnValue = await httpHelper.ExecuteURL("DBTools/createinitialdata");

            return returnValue;
        }

        public async Task<bool> DbInitialSalePointStockData()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            bool returnValue = await httpHelper.ExecuteURL("DBTools/DbInitialSalePointStockData");
            
            return returnValue;
        }
        public async Task<bool> SimulateFailSearches(int count)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            //SimulateSales
            //GetMLModel
            //DbInitialSalePointStockData
            //SimulateFailSearches

            bool returnValue = await httpHelper.ExecuteURL("DBTools/SimulateFailSearches/?count=" + count );

            return returnValue;
        }
        public async Task<bool> SimulateSales(int count)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            //SimulateSales
            //GetMLModel
            //DbInitialSalePointStockData
            //SimulateFailSearches

            bool returnValue = await httpHelper.ExecuteURL("DBTools/SimulateSales/?count=" + count);

            return returnValue;
        }

        public async Task<bool> SimulateNextMonth()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            bool returnValue = await httpHelper.ExecuteURL("DBTools/SimulateNextMonth/");

            return returnValue;
        }

        public async Task<bool> DbInitialSimulateProcess()
        {
            int count = 100;
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            bool returnValue = await httpHelper.ExecuteURL("DBTools/SimulateExecuteProccess/?count=" + count);

            return returnValue;
        }
    }
}
