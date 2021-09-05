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
    public class StockController : ControllerBase
    {
        private IStockBL stockBL;
        private ICountryBL countryBL;
        private readonly ISalesBL _salesBl;
        public StockController(IStockBL _stockBL, ICountryBL _countryBL, ISalesBL salesBl)
        {
            this.stockBL = _stockBL;
            this.countryBL = _countryBL ?? throw new ArgumentNullException(nameof(_countryBL));
            _salesBl = salesBl;

        }
        [HttpGet("GetStockDTOs")]
        public async Task<IList<StockDTO>> GetStockDTOs()
        {
            return await stockBL.GetAllStock();
        }

        [HttpGet("GetStockBySalePointProduct")]
        [ProducesResponseType(typeof(StockDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<StockDTO>> GetStockBySalePointProduct(int productId, int countryid) {
            if (countryid == 0) return NotFound();

            var stocks = await stockBL.GetAllStock();

            var salepoints = await _salesBl.GetSalesPoints();

            var salePoint = salepoints.Where(x => x.countryId == countryid).FirstOrDefault();

            var stockDto = stocks.Where(x => x.ProductId == productId && x.SalePointId == salePoint.id).FirstOrDefault();

            if (stockDto != null)
                return Ok(stockDto);

            return NotFound();
        }
    }
}