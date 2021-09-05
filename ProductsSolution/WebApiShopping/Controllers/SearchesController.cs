using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApiShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        public ISearchesBL searchesBL;
        private IStockBL stockBL;
        private ICountryBL countryBL;
        private readonly ISalesBL _salesBl;
        public SearchesController(ISearchesBL _searchesBL, IStockBL _stockBL, ICountryBL _countryBL, ISalesBL salesBl)
        {
            this.searchesBL = _searchesBL ?? throw new ArgumentNullException(nameof(_searchesBL)); ;
            this.stockBL = _stockBL ?? throw new ArgumentNullException(nameof(_stockBL)); ;
            this.countryBL = _countryBL ?? throw new ArgumentNullException(nameof(_countryBL));
            this._salesBl = salesBl ?? throw new ArgumentNullException(nameof(salesBl)); ;
        }

        [HttpGet("GetAllSearches")]
        public async Task<ActionResult<IList<SearchDTO>>> GetAllSearches()
        {
            var listSearchDTO = await this.searchesBL.GetAllSearches();

            return Ok(listSearchDTO);
        }

        [HttpPost("SaveIntencionCompra")]
        public async Task<bool> SaveIntencionCompra(SearchDTO searchDTO)
        {
            searchDTO.year = DateTime.Today.Year;
            searchDTO.month = DateTime.Today.Month;
            var listSearchDTO = this.searchesBL.SaveSearch(searchDTO);

            if (searchDTO.success)
            {
                var stocks = await stockBL.GetAllStock();
                var salepoints = await _salesBl.GetSalesPoints();
                var stockDto = stocks.Where(x => x.ProductId == searchDTO.ProductId && x.SalePointId == searchDTO.salepointid).FirstOrDefault();

                if (stockDto != null)
                {
                    stockDto.Amount -= 1;
                    listSearchDTO = stockBL.Save(stockDto);
                }

                var saleDto = new SaleDTO()
                {
                    month = searchDTO.month,
                    Amount = searchDTO.amount,
                    Date = DateTime.Now,
                    ProductId = searchDTO.ProductId,
                    SalePointId = searchDTO.salepointid,
                    year = searchDTO.year
                };

                this._salesBl.Save(saleDto);
            }

            return listSearchDTO;
        }
    }
}