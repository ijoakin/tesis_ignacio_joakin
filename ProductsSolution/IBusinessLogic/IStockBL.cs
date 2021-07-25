using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IStockBL
    {
        Task<IList<StockDTO>> GetAllStock();
    }
}
