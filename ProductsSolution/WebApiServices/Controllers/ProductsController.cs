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
using WebApiServices.Helpers;

namespace WebApiServices.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductsBL productsBL;
        private ICachingMemoryHelper memoryCache;

        public ProductsController(IProductsBL _productsBL, ICachingMemoryHelper _memoryCache)
        {
            productsBL = _productsBL;
            this.memoryCache = _memoryCache;
        }

        [HttpPost("UploadFile")]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> UploadFile(IFormFile file, string id)
        {
            try
            {
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);

                ProductDTO productDTO = new ProductDTO();
                productDTO.id = 0;
                productDTO.description = "testing";
                productDTO.price = 12;
                productDTO.productTypeId = 1;
                productDTO.userid = 1;
                productDTO.imagen = memoryStream.ToArray();

                productsBL.Save(productDTO);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(List<ProductDTO>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IList<ProductDTO>>> GetProducts()
        {
            try
            {
                var returnObject = await productsBL.GetAllProducts();

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
        [ProducesResponseType(typeof(ProductDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
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
                return (List<ProductTypeDTO>) memoryCache.GetValue( "ProductTypes");
            }

            //adding list to the cache
            var list = productsBL.GetAllProductTypes().ToList();
            memoryCache.Add("ProductTypes", list, DateTimeOffset.MaxValue);
            return list;
        }

        [HttpPost]
        public bool InsertProduct(ProductDTO product)
        {
            return productsBL.Save(product);
        }

        [HttpPost("UpdateProduct")]
        public bool UpdateProduct(ProductDTO product)
        {
            return productsBL.Save(product);
        }

        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(int id)
        {
            return this.productsBL.DeleteProduct(id);
        }
    }
}
