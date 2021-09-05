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
    public class StockController : ControllerBase
    {
        private IStockBL stockBL;
        private ICountryBL countryBL;
        private readonly ISalesBL _salesBl;
        public StockController(IStockBL _stockBL, ICountryBL _countryBL, ISalesBL salesBl)
        {
            this.stockBL = _stockBL ?? throw new ArgumentNullException(nameof(_stockBL));
            this.countryBL = _countryBL ?? throw new ArgumentNullException(nameof(_countryBL));
            _salesBl = salesBl ?? throw new ArgumentNullException(nameof(salesBl));

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
            var stocks = await stockBL.GetAllStock();

            var salepoints = await _salesBl.GetSalesPoints();

            var salePoint = salepoints.Where(x => x.countryId == countryid).FirstOrDefault();

            var stockDto = stocks.Where(x => x.ProductId == productId && x.SalePointId == salePoint.id).FirstOrDefault();

            if (stockDto != null)
                return Ok(stockDto);

            return NotFound();
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(StockDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<StockDTO>> GetById(int id)
        {
            var stocks = await stockBL.GetAllStock();

            var stockDto = stocks.Where(x => x.Id == id).FirstOrDefault();

            if (stockDto != null)
                return Ok(stockDto);

            return NotFound();
        }

        [HttpPost("SaveStock")]
        public bool SaveStock(StockDTO stockDTO)
        {
            return this.stockBL.Save(stockDTO);
        }

        [HttpDelete("deleteStock")]
        public bool deleteStock(int id)
        {
            return this.stockBL.Delete(id);
        }
    }
}