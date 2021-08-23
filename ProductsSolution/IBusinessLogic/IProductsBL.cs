using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace IBusinessLogic
{
    public interface IProductsBL
    {
        Task<IList<ProductDTO>> GetAllProducts();

        IList<ProductTypeDTO> GetAllProductTypes();

        Task<ProductDTO> GetProductByIdAsync(int Id);
        bool Save(ProductDTO product);
        bool DeleteProduct(int id);
    }
}
