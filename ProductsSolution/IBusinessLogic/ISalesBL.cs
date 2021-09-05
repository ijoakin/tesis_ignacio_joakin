using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace IBusinessLogic
{
    public interface ISalesBL
    {
        IList<SaleDTO> GetAllSales();
        bool Save(SaleDTO saleDto);
        bool Delete(int id);
        SaleDTO GetById(int id);
        Task<bool> SaveAsync(SaleDTO saleDto);
        Task<IList<SalePointDTO>> GetSalesPoints();
        Task<SalePointDTO> GetSalePointById(int id);
        
        bool DeleteSalePoint(int id);

        PageServerSideDTO<SaleDTO> GetAllSalesPaginate(int page);
        bool saveSalePoint(SalePointDTO salePointDTO);
    }
}
