
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinForm.Helpers
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string ProductDescription { get; set; }
        public string SalePointDescription { get; set; }
        public int ProductId { get; set; }
        public int SalePointId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class SalesHelper
    {
        public async Task<List<SaleDTO>> getAllSales()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

            List<SaleDTO> returnList = await httpHelper.GetAll<SaleDTO>("sales/GetSales");

            return returnList;
        }

    }
}
