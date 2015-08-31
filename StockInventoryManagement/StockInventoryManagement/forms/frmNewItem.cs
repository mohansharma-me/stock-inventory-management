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
    public partial class frmNewItem : Form
    {
        public frmNewItem()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string code = textBox2.Text.Trim();
            string ppt_string = textBox3.Text.Trim();
            double ppt = 0;

            if (name.Length == 0)
            {
                MessageBox.Show(this, "Please enter valid item name.", "Item name", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
                return;
            }

            double.TryParse(ppt_string, out ppt);

            new System.Threading.Thread(() => {
                try
                {
                    #region MyRegion
                    if (Job.Database.addItem(name, code, ppt))
                    {
                        Invoke(new Action(() =>
                        {
                            textBox1.Text = textBox2.Text = textBox3.Text = "";
                            textBox1.Focus();
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() => {
                            MessageBox.Show(this, "Error occured unable to add new item please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Focus();
                        }));
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => { MessageBox.Show(this, "Error occured while adding new item, please try again." + Environment.NewLine + "Error message :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
                }
                finally
                {
                    Invoke(new Action(() => { Enabled = true; }));
                }
            }).Start();
        }
    }
}
