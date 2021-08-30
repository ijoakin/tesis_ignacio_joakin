using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using Entities;
using IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WinForm.Helpers;

namespace process
{
    class Program
    {
        private static void TimerCallback(Object o)
        {
            processClass processClass = new processClass();
            processClass.SimulateSalesTask().Wait();
        }

        private static void TimerCallbackMonth(Object o)
        {
            processClass processClass = new processClass();
            processClass.SimulateNextMonth().Wait();
        }

        private static int showMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1) simular dos años de ventas para un producto y punto de venta.");
            Console.WriteLine("2) simular ventas para los sucesivos 7 días.");
            Console.WriteLine("3) simular predicciones, aplicar predicciones y ventas de los sucesivos 100 días.");
            Console.WriteLine("4) simular predicciones");
            Console.WriteLine("5) aplicar predicciones");
            Console.WriteLine("6) simular ventas para los sucesivos 7 días sync");

            Console.WriteLine("");
            Console.WriteLine("0) Salir.");
            Console.WriteLine("");
            Console.WriteLine("Seleccione una opción: ");
            var value = Console.ReadLine();

            return int.Parse(value);
        }
        static void RunPythonNotebook()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string pythonExecutable = configuration["pythonExecutable"];
            string pythonNotebook = configuration["pythonNotebook"];

            Console.WriteLine($"Executing Python notebook - predicciones 7 días - {DateTime.Now}");
            var pythonExecution = pythonExecutable;

            using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
            {
                pProcess.StartInfo.FileName = pythonExecution;
                pProcess.StartInfo.Arguments = pythonNotebook; //argument
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                pProcess.Start();
                string output = pProcess.StandardOutput.ReadToEnd(); //The output result
                pProcess.WaitForExit();
            }

        }
        static async void ApplyPrediction(ProductsDBContext productsDBContext)
        {
            var repositoryPrediction = new Repository<Prediction>(productsDBContext);
            var repositoryProducts = new Repository<Product>(productsDBContext);
            var repositorySalePoint = new Repository<SalePoint>(productsDBContext);
            var repositoryStock = new Repository<Stock>(productsDBContext);
            var repositoryCountry = new Repository<Country>(productsDBContext);

            PredictionsBL predictionsBL = new PredictionsBL(repositoryPrediction, repositoryProducts, repositorySalePoint, repositoryStock, repositoryCountry);
            Console.WriteLine($"Applying predictions 7 días - {DateTime.Now}");
            predictionsBL.ApplyAllPredictionsNoAsync();

        }
        static void SimulateLastDays(int salePointId, int productId, ProductsDBContext productsDBContext)
        {
            Console.WriteLine($"ventas de los sucesivos 7 días- {DateTime.Now}");
            var dBTools = new DBTools(productsDBContext);
            dBTools.SimulateProccessLastDays(salePointId, productId);
        }

        static void Main(string[] args)
        {
            var sel = showMenu();
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            //int timer = int.Parse(configuration["timer"]);
            //int month_timer = int.Parse(configuration["month_timer"]);
            string cnx = configuration["cnx"];

            int salePointId = int.Parse(configuration["salePointId"]);
            int productId = int.Parse(configuration["productId"]);

            

            List<Task> tasks = new List<Task>();
            
            DatabaseToolsHelper helper = new DatabaseToolsHelper();

            ProductsDBContext productsDBContext = new ProductsDBContext(cnx);
            while (sel != 0)
            {
                switch (sel)
                {
                    case 1:
                        Console.WriteLine($"Iniciando - Simulación de ventas 2 años - {DateTime.Now}");
                        Task t = helper.DBSimulateTwoYearsByProduct(salePointId, productId);
                        tasks.Add(t);

                        while (tasks.Any(t => !t.IsCompleted))
                        {
                            Thread.Sleep(1000);
                            Console.Write(".");
                        }
                        break;
                    
                    case 2:
                        Console.WriteLine($"Iniciando - Simulación de ventas y compra de predicciones - {DateTime.Now}");
                        Task t2 = helper.SimulateProccessLastDays(salePointId, productId);
                        
                        tasks.Add(t2);

                        while (tasks.Any(t => !t.IsCompleted))
                        {
                            Thread.Sleep(1000);
                            Console.Write(".");
                        }

                        break;
                    case 3:
                        for (int i = 1; i < 53; i++)
                        {
                            //generar predicciones
                            RunPythonNotebook();
                            //aplicar predicciones
                            ApplyPrediction(productsDBContext);
                            //vender para los sucesivos días
                            //SimulateLastDays(salePointId, productId, productsDBContext);

                            Console.WriteLine($"Iniciando - Simulación de ventas y compra de predicciones - {DateTime.Now}");
                            Task t3 = helper.SimulateProccessLastDays(salePointId, productId);

                            tasks.Add(t3);

                            while (tasks.Any(t => !t.IsCompleted))
                            {
                                Thread.Sleep(2000);
                                Console.Write(".");
                            }

                        }

                        break;
                    case 4:
                            //generar predicciones
                            RunPythonNotebook();
                        break;
                    case 5:
                        //aplicar predicciones
                        ApplyPrediction(productsDBContext);
                        break;
                    case 6:
                        //vender para los sucesivos días
                        SimulateLastDays(salePointId, productId, productsDBContext);
                        break;

                }
                sel = showMenu();
            }
        }
    }
}
