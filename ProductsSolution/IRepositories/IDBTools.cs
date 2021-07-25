using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepositories
{
    public interface IDBTools
    {
        void SimulateSales(int count, int month, int year);
        void DbInitialSalePointStockData();
        void SimulateFailSearches(int count, int month, int year);
        void SimulateProcess(string _date, int count);
        void SimulateProccessLastDays(int productId, int salePointId);
        void SimulateProccessByProduct(string _date, int productId, int salePointId);

        void SimulateCompraByProduct(int productId, int salePointId, int mes);

        void CreateInitialData(string webRoot);

        List<MLModel> GetMLModels();
        bool SimulateNextMonth();
    }
}
