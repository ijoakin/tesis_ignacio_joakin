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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = this.refreshSales();
            List<SaleDTO> blankSales = new List<SaleDTO>();
            this.salesDataGridView.DataSource = blankSales;
            this.salesDataGridView.Refresh();
        }

        internal async Task refreshSales()
        {
            var salesHelper = new SalesHelper();
            var saleslist = await salesHelper.getAllSales();

            this.salesDataGridView.DataSource = saleslist;
            this.salesDataGridView.Refresh();
        }
    }
}
