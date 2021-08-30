using System;
using System.Collections.Generic;
using System.Linq;
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
        private ISalesBL salesBL;

        public CountryController(ICountryBL _countryBL, ISalesBL _salesBL)
        {
            this.countryBL = _countryBL ?? throw new ArgumentNullException(nameof(_countryBL));
            this.salesBL = _salesBL ?? throw new ArgumentNullException(nameof(_salesBL));
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

        [HttpGet("getAllDistancesByIdProductIdCountry")]
        [ProducesResponseType(typeof(DistanceDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IList<DistanceDto>>> getAllDistancesByIdProductIdCountry(int productId, int countryId)
        {
            var salePoints = await this.salesBL.GetSalesPoints();
            var salePoint = salePoints.Where(x => x.countryId == countryId).FirstOrDefault();

            var distances = await this.countryBL.GetDistanceByProductBySalePointDtosAsync(productId, countryId);

            if (distances == null) return NotFound();

            return Ok(distances);
        }

        [HttpGet("GetAllCAtegories")]
        [ProducesResponseType(typeof(CategoryDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<CategoryDto>>> GetAllCategories()
        {
            var categories = await this.countryBL.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("getDistances")]
        [ProducesResponseType(typeof(DistanceDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<DistanceDto>>> getDistances()
        {
            var distances = await this.countryBL.GetDistanceDtosAsync();

            if (distances == null) return NotFound();

            return Ok(distances);
        }
    }
}
