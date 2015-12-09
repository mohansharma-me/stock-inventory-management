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
    public partial class frmStockReport : Form
    {
        private long itemId = 0;

        public frmStockReport(long itemId, string itemName)
        {
            InitializeComponent();
            this.itemId = itemId;
            this.Text = "Stock Report : " + itemName;
        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            loadItemDetails();
        }

        private void loadItemDetails()
        {
            try
            {
                List<classes.Item> items = Job.Database.getItem_TransactionDetails(itemId);
                lvStock.SetObjects(items);

                lvStock.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvStock.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "Unable to generate stock detail report, please try again." + Environment.NewLine + "Error message: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lvStock.SelectedIndex>-1 && lvStock.SelectedObject!=null)
            {
                Job.showInvoiceDialog(this, (lvStock.SelectedObject as classes.Item).id);
            }
        }
    }
}
