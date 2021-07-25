using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using Entities;
using IBusinessLogic;
using IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace DIManagement
{
    public static class DataAccessDIResolution
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ProductsDBContext>(_ => new ProductsDBContext(connectionString));
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<ProductType>, Repository<ProductType>>();
            services.AddTransient<IRepository<Sale>, Repository<Sale>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Stock>, Repository<Stock>>();
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<SalePoint>, Repository<SalePoint>>();
            services.AddTransient<IRepository<Search>, Repository<Search>>();
            services.AddTransient<IRepository<Stock>, Repository<Stock>>();
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<Prediction>, Repository<Prediction>>();
            services.AddTransient<IRepository<Distance>, Repository<Distance>>();

            services.AddTransient<IDBTools, DataAccess.DBTools>();
        }
    }
}
