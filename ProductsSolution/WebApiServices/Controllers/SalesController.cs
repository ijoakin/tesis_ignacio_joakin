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
    public class SalesController : ControllerBase
    {
        private readonly ISalesBL _salesBl;

        public SalesController(ISalesBL salesBl)
        {
            _salesBl = salesBl;
        }

        [HttpGet("GetSales")]
        [ProducesResponseType(typeof(List<SaleDTO>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public ActionResult<IList<SaleDTO>> GetSales()
        {

            return Ok(_salesBl.GetAllSales());
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
        [ProducesResponseType(typeof(IList<SalePointDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IList<SalePointDTO>>> GetSalesPoints()
        {
            return Ok(await this._salesBl.GetSalesPoints());
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(SalePointDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<SalePointDTO>> GetById(string id)
        {
            return Ok(await this._salesBl.GetSalePointById(int.Parse(id)));
        }

        [HttpGet("GetAllSalesPaginate")]
        [ProducesResponseType(typeof(PageServerSideDTO<SaleDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public PageServerSideDTO<SaleDTO> GetAllSalesPaginate(int page)
        {
            return this._salesBl.GetAllSalesPaginate(page);
        }

        [HttpDelete("deleteSalePoint")]
        public bool deleteSalePoint(int id)
        {
            return this._salesBl.DeleteSalePoint(id);
        }

        [HttpPost("SaveSalePoint")]
        public bool SaveSalePoint(SalePointDTO salePointDTO)
        {
            return this._salesBl.saveSalePoint(salePointDTO);
        }

        [HttpPatch("PatchSales")]
        public IList<SaleDTO> PatchAllSales()
        {
            //Update part of the existing data
            return this._salesBl.GetAllSales();
        }
    }
}