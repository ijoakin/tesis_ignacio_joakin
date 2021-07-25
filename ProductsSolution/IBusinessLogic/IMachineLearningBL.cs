using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IMachineLearningBL
    {
        Task<List<MLModelDTO>> GetMLModel();
    }
}
