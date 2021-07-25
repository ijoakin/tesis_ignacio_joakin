using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Helpers
{
    public class DatabaseToolsHelper
    {
        public async Task<bool> CreateInitialData()
        {
            int count = 0;
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";
            bool returnValue = await httpHelper.ExecuteURL("DBTools/createinitialdata");

            return returnValue;
        }

        public async Task<bool> DbInitialSalePointStockData()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

            bool returnValue = await httpHelper.ExecuteURL("DBTools/DbInitialSalePointStockData");
            
            return returnValue;
        }
        public async Task<bool> SimulateFailSearches(int count)
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

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
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

            //SimulateSales
            //GetMLModel
            //DbInitialSalePointStockData
            //SimulateFailSearches

            bool returnValue = await httpHelper.ExecuteURL("DBTools/SimulateSales/?count=" + count);

            return returnValue;
        }
    }
}
