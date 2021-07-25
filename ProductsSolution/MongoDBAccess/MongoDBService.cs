using System;
using System.Collections.Generic;
using DTO;
using Entities;
using MongoDB.Driver;

namespace MongoDBAccess
{
    public class MongoDBService
    {
        private readonly IMongoCollection<ProductDTO> _products;

        public MongoDBService()
        {
            var CollectionName = "Products";
            var ConnectionString = "mongodb://localhost:27017";
            var DatabaseName = "Test";

            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);

            _products = database.GetCollection<ProductDTO>(CollectionName);

        }
        public void connect()
        {

        }
        public List<ProductDTO> GetProducts() =>
            _products.Find(book => true).ToList();

        public ProductDTO GetProduct(int id) =>
            _products.Find<ProductDTO>(product => product.id == id).FirstOrDefault();

        public ProductDTO CreateProduct(ProductDTO product)
        {
            _products.InsertOne(product);
            return product;
        }
    }
}
