using CosmosDBMigration.Helpers;
using Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBMigration
{
    public class CosmosDBHelper
    {
        private readonly string EndPointUri = ConfigurationManager.AppSettings["EndPointUri"];
        private readonly string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];

        private string databaseId = "productsDb4";
        private string containerId = "products";

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            CosmosClient cosmosClient = new CosmosClient(EndPointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "Products DB migration" });
            Database cosmosDatabase = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Container container = await cosmosDatabase.CreateContainerIfNotExistsAsync(containerId, "/Description", 400);

            Container productContainer = cosmosClient.GetContainer(databaseId, containerId);

            productContainer.GetItemLinqQueryable<ProductDTO>();

            //productHelper productHelper = new productHelper();
            //var products = await productHelper.getAllProducts();

            //QueryDefinition queryDefinition = new QueryDefinition("select * from Products");
            /*using (FeedIterator<ProductDTO> feedIterator = container.GetItemQueryIterator<ProductDTO>(
                queryDefinition,
                null,
                new QueryRequestOptions() { PartitionKey = new PartitionKey("/Description") }))
            {*/
            var feedIterator = productContainer.GetItemLinqQueryable<ProductDTO>().ToFeedIterator();

            while (feedIterator.HasMoreResults)
            {
                foreach (var item in await feedIterator.ReadNextAsync())
                {
                    {
                        Console.WriteLine(item.Description);
                    }
                }
            }

            return new List<ProductDTO>();

        }

        public async Task StartMigration()
        {
            CosmosClient cosmosClient = new CosmosClient(EndPointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "Products DB migration" });
            Database cosmosDatabase = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Container container = await cosmosDatabase.CreateContainerIfNotExistsAsync(containerId, "/Description", 400);

            productHelper productHelper = new productHelper();
            var products = await productHelper.getAllProducts();

            foreach(ProductDTO dto in products)
            {
                try
                {
                    //dto.id = new Guid().ToString();
                    ItemResponse<ProductDTO> itemResponse = await container.ReadItemAsync<ProductDTO>(dto.Description, new PartitionKey(dto.Description));
                    Console.WriteLine("Item in database with id: {0} already exists\n", itemResponse.Resource.id);
                }
                catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    ItemResponse<ProductDTO> itemResponse = await container.CreateItemAsync<ProductDTO>(dto, new PartitionKey(dto.Description));
                    Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", itemResponse.Resource.Description, itemResponse.RequestCharge);
                }
            }
        }

        public void CreateDataBaseIfExists()
        {

        }
    }
}
