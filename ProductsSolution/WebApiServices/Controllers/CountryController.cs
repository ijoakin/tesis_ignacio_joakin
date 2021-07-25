using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
       private ICountryBL countryBL;

       public CountryController(ICountryBL _countryBL)
        {
            this.countryBL = _countryBL;
        }

        [HttpGet("GetAllCountries")]
        [ProducesResponseType(typeof(IList<CountryDTO>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<CountryDTO>>> GetAllCountries()
        {
            var countryList = await this.countryBL.GetAllCountryDTOs();
            if (countryList == null) return NotFound();

            return Ok(countryList);
        }

        [HttpGet("GetDistances")]
        [ProducesResponseType(typeof(DistanceDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IList<DistanceDto>>> getDistances()
        {
            var distances = await this.countryBL.GetDistanceDtosAsync();

            if (distances == null) return NotFound();

            return Ok(distances);
        }
    }
}
