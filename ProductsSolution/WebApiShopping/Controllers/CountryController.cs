using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShopping.Controllers
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
    }
}
