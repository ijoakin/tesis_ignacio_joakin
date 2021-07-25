using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IPredictionsBL
    {
        Task<IList<PredictionDTO>> GetAllPredictions();
             
        PredictionDTO GetPredictionById(int Id);
        
        bool Save(PredictionDTO prediction);
        
        bool DeletePrediction(int id);
        Task<bool> ApplyAllPredictions();
    }
}
