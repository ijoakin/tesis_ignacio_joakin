using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAppUniversal
{
    public class HttpHelper
    {
        public string BaseURLPath { get; set; }

        public HttpHelper() { }

        public HttpHelper(string baseURLPath)
        {
            this.BaseURLPath = baseURLPath;
        }

        public async Task<List<T>> GetAll<T>(string URLPath)
        {
            HttpClient client = new HttpClient();
            List<T> returnList = new List<T>();
            HttpResponseMessage response = await client.GetAsync(this.BaseURLPath + URLPath);

            string res = "";
            if (response.IsSuccessStatusCode)
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                returnList = JsonConvert.DeserializeObject<List<T>>(result.Result);
                //returnList = await response.Content.ReadAsAsync<List<ProductDTO>>();
            }
            return returnList;
        }
        public async Task<bool> ExecuteURL(string URLPath)
        {
            HttpClient client = new HttpClient();
            //string URL = "https://localhost:44313/api/DBTools/CreateInitialData";
            HttpResponseMessage response = await client.GetAsync(this.BaseURLPath + URLPath);

            string res = "";
            if (response.IsSuccessStatusCode)
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result.Result);
                //returnList = await response.Content.ReadAsAsync<List<ProductDTO>>();
            }
            return false;
        }
    }
}
