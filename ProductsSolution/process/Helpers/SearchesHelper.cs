using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Helpers
{
    public class SearchDTO
    {
        public int id { get; set; }
        public string searchtext { get; set; }
        public bool success { get; set; }
        public int ProductId { get; set; }
        public int userid { get; set; }
        public string productDescription { get; set; }
        public string SalePointDescription { get; set; }
    }
    public class SearchesHelper
    {
        public async Task<List<SearchDTO>> getAllSearches()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.BaseURLPath = "https://localhost:44313/api/";

            List<SearchDTO> returnList = await httpHelper.GetAll<SearchDTO>("searches/getAllSearches");

            return returnList;
        }
    }
}
