using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IDBToolsBL
    {
        void SimulateSales(int count, int month, int year);
        void DbInitialSalePointStockData();
        void SimulateFailSearches(int count, int month, int year);
        void CreateInitialData(string webRoot);
        void SimulateProccessLastDays(int productId, int salePointId);
        void SimulateProccessByProduct(string _date, int productId, int salePointId);

        void SimulateCompraByProduct(int productId, int salePointId, int mes);

        List<MLModelDTO> GetMLModelDTO();

        void SimulateExecuteProccess(string date, int count);

        bool SimulateNextMonth();

        Task<List<GraphDTO>> getDataToGraph();
        
        
    }
}
