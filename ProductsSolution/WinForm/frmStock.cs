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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void GetStockBtn_Click(object sender, EventArgs e)
        {
            Task task = this.refreshSearches();
            List<StockDTO> blankSearches = new List<StockDTO>();
        }
        internal async Task refreshSearches()
        {
            var stockHelper = new StockHelper();
            var stockList = await stockHelper.getAllStock();
            this.dataGridViewStock.DataSource = stockList;
            this.dataGridViewStock.Refresh();
        }
    }
}
