using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Entities;
using IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockBL stockBL;

        public StockController(IStockBL _stockBL)
        {
            this.stockBL = _stockBL;
        }
        [HttpGet("GetStockDTOs")]
        public async Task<IList<StockDTO>> GetStockDTOs()
        {
            return await stockBL.GetAllStock();
        }
    }
}