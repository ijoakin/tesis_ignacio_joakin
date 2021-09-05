using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineLearningController : ControllerBase
    {

        [HttpGet("GetMLModel")]
        public async Task<MLModelDTO> GetMLModel()
        {
            return await doSomethingAsync();
        }
        [HttpGet("doSomethingAsync")]
        public async Task<MLModelDTO> doSomethingAsync()
        {
            return await Task.Run(() =>
            {
                return new MLModelDTO()
                {
                    amount = 100,
                    month = 1,
                    year = 2020,
                    product = 1,
                    salepoint = 1,
                    success = 0                    
                };
            });
        }
    }
}