using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
    
namespace StockInventoryManagement.forms
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            refreshReport();
        }

        public void refreshReport()
        {
            new System.Threading.Thread(() =>
            {

                try
                {
                    while (!Enabled) { System.Threading.Thread.Sleep(1000); }
                    Invoke(new Action(() =>
                    {
                        Enabled = false;
                        lvStock.ClearObjects();
                    }));

                    List<classes.Item> items = Job.Database.getStockReport();

                    Invoke(new Action(() =>
                    {
                        lvStock.SetObjects(items);
                    }));

                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to refresh stock report, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        Enabled = true;
                    }));
                }

            }).Start();
        }

        private void lvStock_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            
        }

        private void lvStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvStock.SelectedIndex > -1 && lvStock.SelectedObject != null)
            {
                try
                {
                    new frmStockReport((lvStock.SelectedObject as classes.Item).id, (lvStock.SelectedObject as classes.Item).itemName).ShowDialog(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "System error : " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
