using System;
using System.Threading.Tasks;
using WinForm.Helpers;

namespace process
{
    public class processClass
    {
        public void ExecuteProcess(DateTime date)
        {
            Task task = SimulateSalesTask();
        }

        public async Task SimulateNextMonth()
        {
            Console.WriteLine("Initial - Change month - ");
            DatabaseToolsHelper helper = new DatabaseToolsHelper();
            var value = await helper.SimulateNextMonth();
            Console.WriteLine("Finish - " + value);
        }

        public async Task SimulateSalesTask()
        {
            //Console.WriteLine("Initial - Simulation Process - ");
            //DatabaseToolsHelper helper = new DatabaseToolsHelper();
            //var value = await helper.DbInitialSimulateProcess();
            //Console.WriteLine("Finish - " + value);
        }
    }
}
