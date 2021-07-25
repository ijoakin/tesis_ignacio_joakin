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
    public partial class MainWindows : Form
    {
        frmProducts productsForm = new frmProducts();
        frmlDatabaseTools databaseTools = new frmlDatabaseTools();
        frmSales salesFrm = new frmSales();
        frmSearches searchesFrm = new frmSearches();
        frmStock frmStock = new frmStock();
        frmMachineLearning frmMachineLearning = new frmMachineLearning();
        public MainWindows()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you really want to quit?","Products", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void setFormAttr(Form form)
        {
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productsForm.IsDisposed)
                productsForm = new frmProducts();

            setFormAttr(productsForm);
            productsForm.Show();
        }

        private void SalesMenu_Click(object sender, EventArgs e)
        {
            if (salesFrm.IsDisposed)
                salesFrm = new frmSales();
            setFormAttr(salesFrm);
            salesFrm.Show();
        }

        private void databaseToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (databaseTools.IsDisposed)
                databaseTools = new frmlDatabaseTools();
            databaseTools.MdiParent = this;
            databaseTools.Show();
        }

        private void MainWindows_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (searchesFrm.IsDisposed)
                searchesFrm = new frmSearches();
            setFormAttr(searchesFrm);
            searchesFrm.Show();
            
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmStock.IsDisposed)
                frmStock = new frmStock();
            setFormAttr(frmStock);
            frmStock.Show();
        }

        private void machineLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMachineLearning.IsDisposed)
                frmMachineLearning = new frmMachineLearning();
            setFormAttr(frmMachineLearning);
            frmMachineLearning.Show();
        }
    }
}
