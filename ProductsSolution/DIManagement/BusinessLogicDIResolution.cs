using BusinessLogic;
using IBusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace DIManagement
{
    public static class BusinessLogicDIResolution
    {
        public static void AddBusinessLogicDependencies(IServiceCollection services)
        {
            services.AddTransient<IProductsBL, ProductsBL>();
            services.AddTransient<ISalesBL, SalesBL>();
            services.AddTransient<ISecurityBL, SecurityBL>();
            services.AddTransient<IDBToolsBL, DBToolsBL>();
            services.AddTransient<ISearchesBL, SearchesBL>();
            services.AddTransient<IStockBL, StockBL>();
            services.AddTransient<ICountryBL, CountryBL>();
            services.AddTransient<IPredictionsBL, PredictionsBL>();
        }
    }
}
