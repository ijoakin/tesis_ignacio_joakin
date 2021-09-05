using DTO;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        public ISearchesBL searchesBL;
        public SearchesController(ISearchesBL _searchesBL)
        {
            this.searchesBL = _searchesBL ?? throw new ArgumentNullException(nameof(_searchesBL));
        }

        [HttpGet("GetAllSearches")]
        public async Task<IList<SearchDTO>> GetAllSearches()
        {
            var listSearchDTO = await this.searchesBL.GetAllSearches();

            return listSearchDTO;
        }
    }
}