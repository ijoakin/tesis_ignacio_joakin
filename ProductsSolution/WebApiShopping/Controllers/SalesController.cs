using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesBL _salesBl;

        public SalesController(ISalesBL salesBl)
        {
            _salesBl = salesBl;
        }

        [HttpGet("GetSales")]
        [Produces("application/json")]
        public IList<SaleDTO> GetSales()
        {
            return _salesBl.GetAllSales();
        }

        [HttpPost("SaveSale")]
        [Produces("application/json")]
        public bool SaveSale(SaleDTO saleDto)
        {
            return _salesBl.Save(saleDto);
        }
        [HttpDelete("DeleteSale")]
        public bool DeleteSale(int id)
        {
            return _salesBl.Delete(id);
        }

        [HttpGet("GetSaleById")]
        [Produces("application/json")]
        public SaleDTO GetSaleById(int id)
        {
            return this._salesBl.GetById(id);
        }

        [HttpGet("GetSalesPoints")]
        public async Task<IList<SalePointDTO>> GetSalesPoints()
        {
            return await this._salesBl.GetSalesPoints();
        }

        [HttpGet("GetAllSalesPaginate")]
        public PageServerSideDTO<SaleDTO> GetAllSalesPaginate(int page)
        {
            return this._salesBl.GetAllSalesPaginate(page);
        }
        [HttpPatch("PatchSales")]
        public IList<SaleDTO> PatchAllSales()
        {
            //Update part of the existing data
            return this._salesBl.GetAllSales();
        }
    }
}