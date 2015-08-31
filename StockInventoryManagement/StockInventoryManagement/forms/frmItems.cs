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
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }
        
        public void initMethod()
        {
            Enabled = false;
            new System.Threading.Thread(() => {
                try
                {
                    #region MyRegion
                    List<classes.Item> items = Job.Database.getAllItems();
                    Invoke(new Action(() => {
                        lvItems.SetObjects(items);
                    }));
                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => {
                        MessageBox.Show(this, "Error occured while initializing items page, please try again." + Environment.NewLine + "Error message :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally {
                    Invoke(new Action(() => {
                        Enabled = true;
                    }));
                }
            }).Start();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {

        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            new forms.frmNewItem().ShowDialog(this);
            initMethod();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one item to perform delete operation.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, "Are you sure to delete all selected item(s) ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Collections.IList list = lvItems.SelectedObjects;
                Enabled = false;
                new System.Threading.Thread(()=>{
                    try
                    {
                        #region MyRegion
                        foreach (classes.Item item in list)
                        {
                            item.delete();
                        }
                        Invoke(new Action(() => { MessageBox.Show(this, "Delete operation successfully performed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information); initMethod(); }));
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() => { MessageBox.Show(this, "Error occured while delete operation, please try again." + Environment.NewLine + "Error message :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
                    }
                    finally
                    {
                        Invoke(new Action(() => { Enabled = true; }));
                    }
                }).Start();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) 
        {
            initMethod();
        }
    }
}
