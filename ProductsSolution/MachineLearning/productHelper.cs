using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MachineLearning.Helpers;

namespace MachineLearning
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
        public async Task<List<MLModelDTO>> getMLModel()
        {
            HttpHelper helper = new HttpHelper();
            helper.BaseURLPath = "https://localhost:44313/api/";

            List<MLModelDTO> returnList = await helper.GetAll<MLModelDTO>("DBTools/getMLModel");

            return returnList;
        }
    }
}
