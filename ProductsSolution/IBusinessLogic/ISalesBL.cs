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

        Task<IList<SalePointDTO>> GetSalesPoints();

        PageServerSideDTO<SaleDTO> GetAllSalesPaginate(int page);
    }
}
