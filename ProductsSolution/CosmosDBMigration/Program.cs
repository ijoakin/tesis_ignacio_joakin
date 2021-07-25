using System;
using System.Threading.Tasks;

namespace CosmosDBMigration
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            CosmosDBHelper helper = new CosmosDBHelper();
            //await helper.StartMigration();
            var list = await helper.GetAllProducts();

            list.ForEach(x => Console.WriteLine(x.Description));
        }
    }
}
