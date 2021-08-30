using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface ICountryBL
    {
        Task<IList<CountryDTO>> GetAllCountryDTOs();
        Task<IList<DistanceDto>> GetDistanceDtosAsync();
        Task<IList<DistanceDto>> GetDistanceByProductBySalePointDtosAsync(int product, int countryId);
        Task<IList<CategoryDto>> GetAllCategories();


    }
}
