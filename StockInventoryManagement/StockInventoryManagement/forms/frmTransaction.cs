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
    public partial class frmTransaction : Form
    {
        #region Form Method
        public frmTransaction()
        {
            InitializeComponent();

            olvColumnTotalPrice.AspectGetter = (r) =>
            {
                if (r == null) return null;
                classes.Item item = ((classes.Item)r);
                return item.itemPPU * item.qty;
            };

            olvColumnTotalSalePrice.AspectGetter = (r) =>
            {
                if (r == null) return null;
                classes.Item item = (classes.Item)r;
                return ((item.qty * item.itemPPU) - item.discount);
            };

        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            txtQty.Maximum = txtQty1.Maximum = Decimal.MaxValue;
            txtPPU.Maximum = txtPPU1.Maximum = Decimal.MaxValue;
            txtDiscount.Maximum = Decimal.MaxValue;

            dpInvoiceDate.Value = DateTime.Today;
            //init();
        }

        public void init()
        {
            loadItems();
            loadClients();
        }

        public void loadItems()
        {
            try
            {
                new System.Threading.Thread(() =>
                {

                    #region Thread
                    try
                    {
                        while (!Enabled) { System.Threading.Thread.Sleep(1000); }

                        Invoke(new Action(() =>
                        {
                            Enabled = false;
                        }));

                        Invoke(new Action(() =>
                        {
                            cmbItemCode.Items.Clear();
                            cmbItemCode1.Items.Clear();
                        }));

                        List<classes.Item> items = Job.Database.getAllItems();

                        AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                        foreach (classes.Item item in items)
                        {
                            auto.Add(item.itemName);
                            if (item.itemCode != null && item.itemCode.Trim().Length > 0)
                            {
                                auto.Add(item.itemCode);
                            }
                            Invoke(new Action(() =>
                            {
                                cmbItemCode.Items.Add(item);
                                cmbItemCode1.Items.Add(item);
                            }));
                        }
                        Invoke(new Action(() =>
                        {
                            cmbItemCode.AutoCompleteCustomSource = cmbItemCode1.AutoCompleteCustomSource = auto;
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Please try again, unable to load stock items into auto-complete." + Environment.NewLine + "Error message : " + ex.Message, "Auto-complete Error #1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    finally
                    {
                        Invoke(new Action(() =>
                        {
                            Enabled = true;
                        }));
                    }
                    #endregion
                }).Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Sorry, unable to load items into auto-complete list, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Auto-complete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadClients()
        {
            new System.Threading.Thread(() =>
            {

                try
                {
                    #region Thread

                    while (!Enabled) { System.Threading.Thread.Sleep(1000); }

                    Invoke(new Action(() =>
                    {
                        Enabled = false;
                    }));

                    List<classes.Client> clients = Job.Database.getAllClients();

                    Invoke(new Action(() =>
                    {
                        cmbClientRef.Items.Clear();
                        cmbClientRefPurchase.Items.Clear();
                        cmbClientRef.Items.AddRange(clients.ToArray());
                        cmbClientRefPurchase.Items.AddRange(clients.ToArray());
                    }));

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to load clients into reference list, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        #region Purchase

        private void btnAddPurchaseItem_Click(object sender, EventArgs e)
        {
            String itemCode = cmbItemCode1.Text.Trim();
            double qty = double.Parse(txtQty1.Value.ToString());
            double ppu = double.Parse(txtPPU1.Value.ToString());

            if (itemCode.Length == 0)
            {
                MessageBox.Show(this, "Please enter valid item/item code.", "No item", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            classes.Item item = new classes.Item();
            item.itemCode = item.itemName = itemCode;
            item.qty = qty;
            item.itemPPU = ppu;

            lvItemsPurchase.AddObject(item);
            cmbItemCode1.Focus();
        }

        private void btnAddToStock_Click(object sender, EventArgs e)
        {

            DateTime selectedDate = dpInvoiceDate_Purchase.Value;
            /*if(cmbClientRefPurchase.SelectedIndex==-1)
            {
                MessageBox.Show(this, "Please select client from list shown near to 'Add to Stock' button.", "Client not selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbClientRefPurchase.Focus();
                return;
            }*/

            // iterate each added item
            // find existing if not add that new item
            // prepare transaction item list
            // add new transaction with items
            long clientId = 0;
            if(cmbClientRefPurchase.SelectedIndex>-1)
            {
                clientId = (cmbClientRefPurchase.SelectedItem as classes.Client).id;
            }
            else
            {
                try
                {
                    string clientName = cmbClientRefPurchase.Text;
                    if(clientName.Trim().Length==0)
                    {
                        MessageBox.Show(this, "Please enter valid client name."+Environment.NewLine+"Unable to add client entry, please try again.", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbClientRefPurchase.Focus();
                        return;
                    }
                    else
                    {
                        if(!Job.Database.addClient(clientName, "", "", "", "", "", ""))
                        {
                            MessageBox.Show(this, "Client name not added successfully into database." + Environment.NewLine + "Unable to add client entry, please try again.", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbClientRefPurchase.Focus();
                            return;
                        }
                        clientId = Job.Database.last_inserted_rowid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Unable to add client entry, please try again." + Environment.NewLine + "Error Message: " + ex, "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClientRefPurchase.Focus();
                    return;
                }
            }
            System.Collections.IEnumerable items = lvItemsPurchase.Objects;
            
            new System.Threading.Thread(() =>
            {

                try
                {
                    #region Thread

                    if (items != null)
                    {
                        List<classes.TransactionItem> tItems = new List<classes.TransactionItem>();
                        double totalAmount = 0;
                        #region Prepare TransactionData List
                        foreach (classes.Item item in items)
                        {
                            int counter = 0;
                        searchItem: classes.Item oldItem = Job.Database.findItem(item.itemCode, item.itemName);
                            if (oldItem == null)
                            {
                                try
                                {
                                    Job.Database.addItem(item.itemName, "", item.itemPPU);
                                }
                                catch (Exception) { }
                                counter++;
                                if (counter < 4)
                                    goto searchItem;
                            }

                            if (oldItem != null)
                            {
                                classes.TransactionItem tItem = new classes.TransactionItem();
                                tItem.discount = 0;
                                tItem.item = oldItem.itemName;
                                tItem.itemCode = oldItem.itemCode;
                                tItem.itemId = oldItem.id;
                                tItem.ppu = item.itemPPU;
                                tItem.qty = item.qty;
                                totalAmount += (item.qty * item.itemPPU);
                                tItems.Add(tItem);
                            }
                        }
                        #endregion

                        #region Submit new Transaction

                        bool added = Job.Database.addTransaction(totalAmount,0, selectedDate, classes.Transaction.TransactionType.PURCHASE, "", null, tItems, clientId);
                        if (added)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show(this, "Your purchase transaction successfully submited.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnClearPurchaseForm_Click(btnClearPurchaseForm, new EventArgs());
                                lvItemsPurchase.ClearObjects();
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show(this, "Sorry, your new transaction isn't added into database, please try again.", "Problem while adding transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }

                        #endregion
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to add new purchase transaction, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        Enabled = true;
                        loadItems();
                    }));
                }

            }).Start();

            Enabled = false;

        }

        private void lvItemsPurchase_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            countTotalOfPurchaseItems();
        }

        void countTotalOfPurchaseItems()
        {
            if (lvItemsPurchase.Objects == null)
            {
                lblTotalPurchasedItems.Text = "Items: Rs. 0/-";
                return;
            }
            double totalPrice = 0;
            foreach (classes.Item item in lvItemsPurchase.Objects)
            {
                totalPrice += (item.qty * item.itemPPU);
            }
            lblTotalPurchasedItems.Text = "Items: Rs. " + totalPrice + "/-";
        }

        private void lvItemsPurchase_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void lvItemsPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvItemsPurchase.SelectedObjects.Count > 0 && e.KeyCode == Keys.Delete)
                lvItemsPurchase.RemoveObjects(lvItemsPurchase.SelectedObjects);
        }

        private void btnClearPurchaseForm_Click(object sender, EventArgs e)
        {
            cmbItemCode1.SelectedIndex = -1;
            cmbItemCode1.Text = "";
            txtQty1.Value = 0;
            txtPPU1.Value = 0;
            loadItems();
            cmbItemCode1.Focus();
        }

        private void lvItemsPurchase_CellOver(object sender, BrightIdeasSoftware.CellOverEventArgs e)
        {
            countTotalOfPurchaseItems();
        }

        #endregion

        #region Sale

        private void btnAddSaleItem_Click(object sender, EventArgs e)
        {
            if (cmbItemCode.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select item from list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String itemCode = cmbItemCode.Text.Trim();
            double qty = double.Parse(txtQty.Value.ToString());
            double ppu = double.Parse(txtPPU.Value.ToString());
            double dicount = 0;// double.Parse(txtDiscount.Value.ToString());

            if (itemCode.Length == 0)
            {
                MessageBox.Show(this, "Please enter valid item/item code.", "No item", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            classes.Item item = new classes.Item();
            item.itemCode = item.itemName = itemCode;
            item.qty = qty;
            item.itemPPU = ppu;
            item.discount = dicount;

            classes.Item _item = cmbItemCode.SelectedItem as classes.Item;
            Enabled = false;

            new System.Threading.Thread(() =>
            {
                try
                {
                    #region MyRegion
                    double avail = Job.Database.getAvailableItem(_item.id);
                    Invoke(new Action(() =>
                    {
                        if (lvItemsSale.Items.Count > 0)
                        {
                            foreach (classes.Item i_item in lvItemsSale.Objects)
                            {
                                avail -= i_item.qty;
                            }
                        }
                    }));

                    if (avail < qty)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Sorry you can sale this much quantity as its not available. You need to purchase first.", "Stock not available", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            lvItemsSale.AddObject(item);
                            cmbItemCode.Focus();
                        }));
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, error occured please try again." + Environment.NewLine + "Error message :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lvItemsSale_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            countTotalOfSaleItems();
        }

        void countTotalOfSaleItems()
        {
            if (lvItemsSale.Objects == null)
            {
                lblTotalSalePrice.Text = "Item purchased : Rs. 0/-";
                return;
            }

            double totalAmount = 0;
            foreach (classes.Item item in lvItemsSale.Objects)
            {
                totalAmount += ((item.qty * item.itemPPU) - item.discount);
            }
            lblTotalSalePrice.Text = "Item purchased : Rs. " + totalAmount + "/-";
        }

        private void lvItemsSale_CellOver(object sender, BrightIdeasSoftware.CellOverEventArgs e)
        {
            countTotalOfSaleItems();
        }
        private void lvItemsSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvItemsSale.SelectedObjects.Count > 0 && e.KeyCode == Keys.Delete)
            {
                lvItemsSale.RemoveObjects(lvItemsSale.SelectedObjects);
            }
        }

        private void btnClearSaleForm_Click(object sender, EventArgs e)
        {
            cmbItemCode.Text = "";
            cmbItemCode.SelectedIndex = -1;
            txtQty.Value = 0;
            txtPPU.Value = 0;
            txtDiscount.Value = 0;
            cmbItemCode.Focus();
        }
        #endregion

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dpInvoiceDate.Value;
            /*if (cmbClientRef.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select client from list shown near 'Print Invoice' button.", "Client not selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbClientRef.Focus();
                return;
            }*/

            double discount = 0;
            if(!double.TryParse(txtDiscount.Value.ToString(), out discount))
            {
                MessageBox.Show(this, "Please enter valid Discount value.", "Discount Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDiscount.Focus();
                return;
            }
            

            System.Collections.IEnumerable items = lvItemsSale.Objects;

            String deliveryAddress = txtDeliveryAddress.Text.Trim();
            DateTime? deliveryDate = null;
            if (deliveryAddress.Length > 0)
                deliveryDate = dtDelivery.Value;

            long client = 0;// ((classes.Client)cmbClientRef.SelectedItem).id;

            if (cmbClientRef.SelectedIndex > -1)
            {
                client = (cmbClientRef.SelectedItem as classes.Client).id;
            }
            else
            {
                try
                {
                    string clientName = cmbClientRef.Text;
                    if (clientName.Trim().Length == 0)
                    {
                        MessageBox.Show(this, "Please enter valid client name." + Environment.NewLine + "Unable to add client entry, please try again.", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbClientRef.Focus();
                        return;
                    }
                    else
                    {
                        if (!Job.Database.addClient(clientName, "", "", "", "", "", ""))
                        {
                            MessageBox.Show(this, "Client name not added successfully into database." + Environment.NewLine + "Unable to add client entry, please try again.", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbClientRef.Focus();
                            return;
                        }
                        client = Job.Database.last_inserted_rowid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Unable to add client entry, please try again." + Environment.NewLine + "Error Message: " + ex, "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClientRef.Focus();
                    return;
                }
            }

            new System.Threading.Thread(() =>
            {

                try
                {
                    #region Thread

                    if (items != null)
                    {
                        List<classes.TransactionItem> tItems = new List<classes.TransactionItem>();
                        double totalAmount = 0;
                        #region Prepare TransactionData List
                        foreach (classes.Item item in items)
                        {
                            int counter = 0;
                        searchItem: classes.Item oldItem = Job.Database.findItem(item.itemCode, item.itemName);
                            if (oldItem == null)
                            {
                                try
                                {
                                    Job.Database.addItem(item.itemName, "", item.itemPPU);
                                }
                                catch (Exception) { }
                                counter++;
                                if (counter < 4)
                                    goto searchItem;
                            }

                            if (oldItem != null)
                            {
                                classes.TransactionItem tItem = new classes.TransactionItem();
                                tItem.discount = 0;
                                tItem.item = oldItem.itemName;
                                tItem.itemCode = oldItem.itemCode;
                                tItem.itemId = oldItem.id;
                                tItem.ppu = item.itemPPU;
                                tItem.qty = item.qty;
                                tItem.discount = item.discount;
                                totalAmount += ((item.qty * item.itemPPU) - item.discount);
                                tItems.Add(tItem);
                            }
                        }
                        #endregion

                        #region Submit new Transaction

                        bool added = Job.Database.addTransaction(totalAmount - discount, discount, selectedDate, classes.Transaction.TransactionType.SALE, deliveryAddress, deliveryDate, tItems, client);
                        if (added)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show(this, "Your sale transaction successfully submited.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnClearSaleForm_Click(btnClearSaleForm, new EventArgs());
                                lvItemsSale.ClearObjects();

                                if (MessageBox.Show(this, "Do you want to print invoice now ?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Job.showInvoiceDialog(this, Job.Database.LastTransactionID);
                                }

                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show(this, "Sorry, your new transaction isn't added into database, please try again.", "Problem while adding transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }

                        #endregion
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry, unable to add new sale transaction, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        Enabled = true;
                        loadItems();
                    }));
                }

            }).Start();

            Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            olvColumnDate.AspectToStringConverter = (r) =>
            {
                if (r is DateTime?)
                {
                    DateTime? dt = ((DateTime?)r).Value;
                    if(dt.HasValue)
                    {
                        return dt.Value.ToShortDateString() + " " + dt.Value.ToShortTimeString();
                    }
                    return "";
                }
                return "";
            };

            DateTime fromDate = dtFrom.Value;
            DateTime toDate = dtTo.Value;
            new System.Threading.Thread(() =>
            {
                try
                {
                    #region Thread
                    double totalSales = 0, totalPurchases = 0;
                    string mostItem = "n/a", leastItem = "n/a";
                    List<classes.TransactionReport> report = Job.Database.getTransactionReport(ref mostItem, ref leastItem, ref totalSales, ref totalPurchases, fromDate, toDate);

                    Invoke(new Action(() =>
                    {
                        lblTotalIncome.Text = (totalSales - totalPurchases).ToString("0.00");
                        lblTotalExpenses.Text = totalPurchases.ToString("0.00");
                        lblMostItemSold.Text = mostItem;
                        lblLeastItemSold.Text = leastItem;
                        lvReport.SetObjects(report);
                        lblTotalStatus.Text = "Total Sale: " + totalSales.ToString("0.00") + "/- and Total Purchase:" + totalPurchases.ToString("0.00");
                    }));

                    #endregion
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Sorry unable to search amongs database, please try again." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void chkPurchases_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPurchases.Checked)
            {
                if (olvColumnPurchases.Tag != null)
                {
                    olvColumnPurchases.Width = (int)olvColumnPurchases.Tag;
                }
                else
                {
                    olvColumnPurchases.Width = 100;
                }
            }
            else
            {
                olvColumnPurchases.Tag = olvColumnPurchases.Width;
                olvColumnPurchases.Width = 0;
            }
        }

        private void chkSales_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSales.Checked)
            {
                if (olvColumnSales.Tag != null)
                {
                    olvColumnSales.Width = (int)olvColumnSales.Tag;
                }
                else
                {
                    olvColumnSales.Width = 100;
                }
            }
            else
            {
                olvColumnSales.Tag = olvColumnSales.Width;
                olvColumnSales.Width = 0;
            }
        }

        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemCode.SelectedIndex > -1)
            {
                txtPPU.Value = (Decimal)((classes.Item)cmbItemCode.SelectedItem).itemPPU;
            }
        }

        private void cmbItemCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemCode1.SelectedIndex > -1)
            {
                txtPPU1.Value = (Decimal)((classes.Item)cmbItemCode1.SelectedItem).itemPPU;
            }
        }

        private void lvReport_DoubleClick(object sender, EventArgs e)
        {
            if (lvReport.SelectedObjects.Count == 1 && lvReport.SelectedObjects[0] is classes.TransactionReport)
            {
                classes.TransactionReport report = lvReport.SelectedObjects[0] as classes.TransactionReport;
                Job.showInvoiceDialog(this, report.tranId);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
