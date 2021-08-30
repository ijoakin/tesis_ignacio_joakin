using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            this.predictionsBL = _predictionsBL ?? throw new ArgumentNullException(nameof(_predictionsBL));
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

        [HttpGet("getAllPredictionsByProductIdCountryId")]
        [ProducesResponseType(typeof(PredictionDTO), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<PredictionDTO>> getAllPredictionsByProductIdCountryId(int productId, int countryId)
        {
            var total = 0;
            var predictions = await this.predictionsBL.GetPredictionsByProductId(productId, countryId);

            if (predictions.Count > 0)
            {
                foreach (var pre in predictions)
                {

                    total += pre.amount;
                }

                var prediction = predictions.FirstOrDefault();
                prediction.amount = total;

                if (prediction != null)
                    return Ok(prediction);
            }
            
            return NotFound();
        }

        [HttpGet("applyByProductIdCountryId")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> applyByProductIdCountryId( int productid, int countryorigenid, int countryDestinoid, int amount)
        {

            var applyPrediction = await this.predictionsBL.applyByProductIdCountryId(productid, countryorigenid, countryDestinoid, amount);

            /*var prediction = predictions.FirstOrDefault();

            if (prediction != null)
                return Ok(prediction);
            return NotFound();*/
            return applyPrediction;
        }

    }
}
