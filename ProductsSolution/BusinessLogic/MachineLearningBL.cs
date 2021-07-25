using DTO;
using IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MachineLearningBL : IMachineLearningBL
    {
        public Task<List<MLModelDTO>> GetMLModel()
        {
            return Task.Run(() => new List<MLModelDTO>());
        }
    }
}
