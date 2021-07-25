using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface ISearchesBL
    {
        Task<IList<SearchDTO>> GetAllSearches();
    }
}
