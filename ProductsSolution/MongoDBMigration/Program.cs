using DTO;
using MongoDBAccess;
using MongoDBMigration.Helpers;
using System;
using System.Collections.Generic;

namespace MongoDBMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            var ph = new productHelper();

            var task = ph.getAllProducts().GetAwaiter();

            var service = new MongoDBService();

            foreach (var dto in task.GetResult())
            {
                service.CreateProduct(dto);
            }
        }
    }
}
