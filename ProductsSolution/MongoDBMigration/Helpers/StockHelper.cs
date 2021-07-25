using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBMigration.Helpers
{
    public class StockDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int SalePointId { get; set; }
        public string SalePointDescription { get; set; }
        public int Amount { get; set; }

    }
    public class StockHelper
    {
        public async Task<List<StockDTO>> getAllStock()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

            List<StockDTO> returnList = await httpHelper.GetAll<StockDTO>("Stock/GetStockDTOs");

            return returnList;
        }
    }
}
