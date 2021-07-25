using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBMigration.Helpers
{
   
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
