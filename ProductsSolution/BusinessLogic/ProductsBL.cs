using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;

namespace BusinessLogic
{
    public class ProductsBL : IProductsBL
    {
        private readonly IRepository<Product> repositoryProduct;
        private readonly IRepository<ProductType> repositoryProductType;
        private readonly IRepository<Stock> repositoryStock;
        private readonly IRepository<Country> repositoryCountry;
        private readonly IRepository<SalePoint> repositorySalePoint;

        public ProductsBL(IRepository<Product> _repository, 
            IRepository<ProductType> _repositoryProductType,
            IRepository<Stock> _repositoryStock,
            IRepository<Country> _repositoryCountry,
            IRepository<SalePoint> _repositorySalePoint)
        {
            repositoryProduct = _repository;
            repositoryProductType = _repositoryProductType;
            repositoryStock = _repositoryStock;
            repositoryCountry = _repositoryCountry;
            repositorySalePoint = _repositorySalePoint;
        }

        public async Task<IList<ProductDTO>> GetAllProducts()
        {
            var returnList = new List<ProductDTO>();
            var productsAsync = await repositoryProduct.GetQueryAsync();
            var productTypesAsync = await repositoryProductType.GetQueryAsync();

            var productList = productsAsync
                .SelectMany(p => productTypesAsync, (p, t) => new {p, t})
                .Where(@t1 => @t1.p.ProductTypeId == @t1.t.Id)
                .OrderBy(@t1 => @t1.p.Id)
                .Select(@t1 => new
                {
                    @t1.p.Id,
                    @t1.p.ProductTypeId,
                    @t1.p.Description,
                    @t1.p.Price,
                    typeDescription = @t1.t.Description
                });

            foreach (var p in productList)
            {
                returnList.Add(new ProductDTO()
                {
                    description = p.Description,
                    id = p.Id,
                    price = Double.Parse(p.Price.ToString()),
                    productTypeId = p.ProductTypeId,
                    productTypeDescription = p.typeDescription
                });
            }

            return returnList;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int Id)
        {
            var query = await this.repositoryProduct.GetQueryAsync();
            
            return EntityToDTO(query.FirstOrDefault(x => x.Id == Id));
        }
        
        public bool DeleteProduct(int id)
        {
            return this.repositoryProduct.Delete(id);
        }

        private ProductDTO EntityToDTO(Product product)
        {
            if (product == null)
                return null;

            return new ProductDTO()
            {
                id =  product.Id,
                description = product.Description,
                price = Double.Parse(product.Price.ToString()),
                productTypeId = product.ProductTypeId,
            };
        }

        public IList<ProductTypeDTO> GetAllProductTypes()
        {
            var productList = repositoryProductType.GetAll();
            var returnList = new List<ProductTypeDTO>();

            foreach (var p in productList)
            {
                returnList.Add(new ProductTypeDTO()
                {
                    Description = p.Description,
                    Id = p.Id
                });
            }

            return returnList; 
        }

        public bool Save(ProductDTO productDTO)
        {
            try
            {
                var product = new Product()
                {
                    Id = productDTO.id,
                    Description = productDTO.description,
                    ProductTypeId = productDTO.productTypeId,
                    Price = decimal.Parse(productDTO.price.ToString()),
                    imageData = productDTO.imagen,
                    UserId = 1
                };

               return this.repositoryProduct.Save(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
