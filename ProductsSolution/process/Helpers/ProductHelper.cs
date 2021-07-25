using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinForm
{
    public class ProductDTO 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
    }
    public class productHelper
    {
        public async Task<List<ProductDTO>> getAllProducts()
        {
            HttpHelper helper = new HttpHelper();
            helper.BaseURLPath = "https://localhost:44313/api/";

            List<ProductDTO> returnList = await helper.GetAll<ProductDTO>("products/getProducts");
           
            return returnList;
        }
    }
}
