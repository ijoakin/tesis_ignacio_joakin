using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = RefreshProducts();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            /*this.dataGridView1.DataSource = productDTOs;
            this.dataGridView1.Refresh();
            */
        }

        internal async Task RefreshProducts()
        {
            productHelper helper = new productHelper();
            var list = await helper.getAllProducts();

            this.dataGridView1.DataSource = list;
            this.dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productHelper helper = new productHelper();
            var list = helper.getAllProducts().GetAwaiter();

            foreach(ProductDTO product in list.GetResult())
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var gm = GCMonitor.getInstance();

            gm.StartGCMonitoring();
        }
    }
}
