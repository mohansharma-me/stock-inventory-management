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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            loadClients();
        }

        void loadClients()
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    #region Thread

                    List<classes.Client> clients = Job.Database.getAllClients();

                    Invoke(new Action(() =>
                    {
                        lvClients.SetObjects(clients);

                        olvColumn1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        olvColumn7.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }));

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to refresh client log, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Enabled = false;
        }

        private void btnClearClient_Click(object sender, EventArgs e)
        {
            txtName.Text = txtSurname.Text = txtAddress.Text = txtLandline.Text = txtTelephone.Text = txtEmail.Text = txtRefCode.Text = "";
            txtName.Focus();
            loadClients();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            String clientName = txtName.Text.Trim();

            if (clientName.Length == 0)
            {
                MessageBox.Show(this, "Please enter valid client name, try again.", "Client name not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtName.Focus();
                return;
            }

            String surname = txtSurname.Text.Trim();
            String address = txtAddress.Text.Trim();
            String landline = txtLandline.Text.Trim();
            String telephone = txtTelephone.Text.Trim();
            String email = txtEmail.Text.Trim();
            String refcode = txtRefCode.Text.Trim();

            new System.Threading.Thread(() =>
            {

                try
                {
                    #region Thread

                    if (Job.Database.addClient(clientName, surname, address, landline, telephone, email, refcode))
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Client details successfully saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnClearClient_Click(btnClearClient, new EventArgs());
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Client not added, please try again.", "Not added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to add new client to record, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Enabled = false;

        }

        private void lvClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvClients.SelectedObjects.Count > 0 && e.KeyCode == Keys.Delete)
            {

                if (MessageBox.Show(this, "Are you sure to delete all selected clients ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                System.Collections.IEnumerable list = lvClients.SelectedObjects;

                new System.Threading.Thread(() =>
                {

                    try
                    {
                        #region Thread

                        foreach (classes.Client client in list)
                        {
                            client.delete();
                        }

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Sorry, unable to delete client records, please try agian." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    finally
                    {
                        Invoke(new Action(() =>
                        {
                            Enabled = true;
                            loadClients();
                        }));
                    }

                }).Start();

                Enabled = false;

            }
        }
    }
}
