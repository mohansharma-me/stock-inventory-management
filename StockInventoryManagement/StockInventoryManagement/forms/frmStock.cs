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
    }
}
