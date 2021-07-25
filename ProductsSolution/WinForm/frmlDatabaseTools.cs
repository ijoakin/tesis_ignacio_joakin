using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Helpers;

namespace WinForm
{
    public partial class frmlDatabaseTools : Form
    {
        bool start = false;
        int count = 0;
        public frmlDatabaseTools()
        {
            InitializeComponent();
        }

        private void logText(string message)
        {
            this.lstCommands.Items.Add(message);
        }
        private void enabledDisable(bool value)
        {
            button1.Enabled = value;
            button2.Enabled = value;
            button3.Enabled = value;
            button4.Enabled = value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            logText("Initial - Simulate Sales");
            start = true;
            timer1.Enabled = true;
            enabledDisable(false);
            int count = int.Parse(this.txtSaleCount.Text);
            Task task = SimulateSalesTask(count);
        }

        internal async Task SimulateSalesTask(int count)
        {
            DatabaseToolsHelper helper = new DatabaseToolsHelper();
            var value = await helper.SimulateSales(count);
            start = false;
            timer1.Enabled = false;
            enabledDisable(true);
            logText("Finish - Simulate Sales - " + value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start)
            {
                string value = (string) this.lstCommands.Items[this.lstCommands.Items.Count - 1];
                this.lstCommands.Items[this.lstCommands.Items.Count - 1] = value + ".";
                count++;
                if (count == 300)
                {
                    count = 0;
                    this.lstCommands.Items.Add("Processing.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logText("Initial - Simulate Fail Searches");
            start = true;
            timer1.Enabled = true;
            enabledDisable(false);
            int count = int.Parse(this.txtCountSearches.Text);
            Task task = SimulateSearchesTask(count);
        }

        internal async Task SimulateSearchesTask(int count)
        {
            DatabaseToolsHelper helper = new DatabaseToolsHelper();
            var value = await helper.SimulateFailSearches(count);
            start = false;
            timer1.Enabled = false;
            enabledDisable(true);
            logText("Finish - Simulate Fail Searches - " + value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logText("Initial - Simulate initial stock");
            start = true;
            timer1.Enabled = true;
            enabledDisable(false);
            int count = int.Parse(this.txtCountSearches.Text);
            Task task = DbInitialSalePointStockData();
        }

        internal async Task DbInitialSalePointStockData()
        {
            DatabaseToolsHelper helper = new DatabaseToolsHelper();
            var value = await helper.DbInitialSalePointStockData();
            start = false;
            timer1.Enabled = false;
            enabledDisable(true);
            logText("Finish - Simulate initial stock - " + value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logText("Initial - Creating initial data");
            start = true;
            timer1.Enabled = true;
            enabledDisable(false);
            int count = int.Parse(this.txtCountSearches.Text);
            Task task = CreateInitialData();
        }
        internal async Task CreateInitialData()
        {
            DatabaseToolsHelper helper = new DatabaseToolsHelper();
            var value = await helper.CreateInitialData();
            start = false;
            timer1.Enabled = false;
            enabledDisable(true);
            logText("Finish - Simulate initial data - " + value);
        }

        private void frmlDatabaseTools_Load(object sender, EventArgs e)
        {

        }
    }
}
