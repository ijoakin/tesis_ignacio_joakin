using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Helpers;


namespace WinForm
{
    public partial class frmSearches : Form
    {
        public frmSearches()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = this.refreshSearches();
            List<SearchDTO> blankSearches = new List<SearchDTO>();
        }
        internal async Task refreshSearches()
        {
            var searchesHelper = new SearchesHelper();
            var searchesList = await searchesHelper.getAllSearches();
            this.searchesdataGridView.DataSource = searchesList;
            this.searchesdataGridView.Refresh();
        }
    }
}
