using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IPredictionsBL
    {
        Task<IList<PredictionDTO>> GetAllPredictions();
        Task<IList<PredictionDTO>> GetPredictionsByProductId(int productId, int countryId);

        Task<bool> applyByProductIdCountryId(int productid, int countryorigenid, int countryDestinoid, int amount);

        PredictionDTO GetPredictionById(int Id);
        
        bool Save(PredictionDTO prediction);
        
        bool DeletePrediction(int id);
        Task<bool> ApplyAllPredictions();
    }
}
