using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionsController : ControllerBase
    {

        readonly private IPredictionsBL predictionsBL;
        public PredictionsController(IPredictionsBL _predictionsBL)
        {
            this.predictionsBL = _predictionsBL;
        }

        [HttpGet("getAllPredictions")]
        public async Task<IList<PredictionDTO>> getAllPredictions()
        {
            return await this.predictionsBL.GetAllPredictions();
        }
        [HttpGet("applyAllPredictions")]
        public async Task<bool> applyAllPredictions()
        {
            return await this.predictionsBL.ApplyAllPredictions();
        }

    }
}
