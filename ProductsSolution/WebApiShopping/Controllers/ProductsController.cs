using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiShopping.Helpers;

namespace WebApiShopping.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBL productsBL;
        private ICachingMemoryHelper memoryCache;

        public ProductsController(IProductsBL _productsBL, ICachingMemoryHelper _memoryCache)
        {
            productsBL = _productsBL ?? throw new ArgumentNullException(nameof(_productsBL));
            this.memoryCache = _memoryCache ?? throw new ArgumentNullException(nameof(_memoryCache));
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(List<ProductDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IList<ProductDTO>>> GetProducts()
        {
            try
            {
                var returnObject = await productsBL.GetAllProducts();

                returnObject = returnObject.OrderBy(x => x.description).ToList();
                return Ok(returnObject);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetProductsSecure")]
        [Authorize]
        public async Task<IList<ProductDTO>> GetProductsSecure()
        {
            return await productsBL.GetAllProducts();
        }

        [HttpGet("getProductById")]
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var productDto = await productsBL.GetProductByIdAsync(id);

            if (productDto == null) return NotFound();

            return Ok(productDto);
        }

        [HttpGet("getProductTypes")]
        public List<ProductTypeDTO> GetAllProductTypes()
        {
            if (memoryCache.GetValue("ProductTypes") != null)
            {
                return (List<ProductTypeDTO>)memoryCache.GetValue("ProductTypes");
            }

            //adding list to the cache
            var list = productsBL.GetAllProductTypes().ToList();
            memoryCache.Add("ProductTypes", list, DateTimeOffset.MaxValue);
            return list;
        }
    }
}
