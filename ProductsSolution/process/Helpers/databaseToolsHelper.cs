using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Helpers
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

        public async Task<bool> DbInitialSimulateProcess(int count, string date)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;
            var salePointId = 92;
            var productId = 14;

            bool returnValue = await httpHelper.ExecuteURL($"DBTools/SimulateExecuteProccessByProduct/?count={count}&date={date}&productId={productId}&salePointId={salePointId}");

            return returnValue;
        }

        public async Task<bool> DBSimulateTwoYearsByProduct(int salePointId, int productId)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;
            
            bool returnValue = await httpHelper.ExecuteURL($"DBTools/SimulateExecuteProccessByProductYears/?productId={productId}&salePointId={salePointId}");

            return returnValue;
        }
        public async Task<bool> SimulateProccessLastDays(int salePointId, int productId)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            bool returnValue = await httpHelper.ExecuteURL($"DBTools/SimulateProccessLastDays/?productId={productId}&salePointId={salePointId}");

            return returnValue;
        }

        public async Task<bool> ApplyPredictions()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;

            bool returnValue = await httpHelper.ExecuteURL($"Predictions/applyAllPredictions/");

            return returnValue;
        }

        /*public async Task<bool> DbInitialSimulateProcess(int count, string date, string productId, string salePointId)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = baseUrl;


            bool returnValue = await httpHelper.ExecuteURL($"DBTools/SimulateExecuteProccess/?count={count}&date={date}");

            return returnValue;
        }        */
    }
}
