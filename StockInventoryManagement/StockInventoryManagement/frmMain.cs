using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace StockInventoryManagement
{
    public partial class frmMain : Form
    {

        #region All Forms

        forms.frmStock saleForm = new forms.frmStock();
        forms.frmTransaction tranForm = new forms.frmTransaction();
        forms.frmClient clientForm = new forms.frmClient();
        forms.frmItems itemForm = new forms.frmItems();

        #endregion

        #region Main Form Methods

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            initScreen();
            Job.Database.openDatabaseConnection();
        }

        private void initScreen()
        {
            saleForm.TopLevel = false;
            saleForm.Dock = DockStyle.Fill;

            tranForm.TopLevel = false;
            tranForm.Dock = DockStyle.Fill;

            clientForm.TopLevel = false;
            clientForm.Dock = DockStyle.Fill;

            itemForm.TopLevel = false;
            itemForm.Dock = DockStyle.Fill;

            Job.initActionListView(lvActions);
        }

        private void lvActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvActions.SelectedObjects.Count == 1)
            {
                performAction((classes.ActionItem)lvActions.SelectedObject);
            }
        }
    
        private void performAction(classes.ActionItem actionItem)
        {
            Form form = null;
            switch (actionItem.action)
            {
                case classes.ActionItem.Action.STOCK:
                    form = saleForm;
                    break;

                case classes.ActionItem.Action.TRANSACTIONS:
                    form = tranForm;
                    break;

                case classes.ActionItem.Action.CLIENTS:
                    form = clientForm;
                    break;

                case classes.ActionItem.Action.ITEMS:
                    form = itemForm;
                    break;
            }

            if (form == null) return;

            panContent.Controls.Clear();
            panContent.Controls.Add(form);
            form.Show();
            form.WindowState = FormWindowState.Normal;
            form.WindowState = FormWindowState.Maximized;

            switch (actionItem.action)
            {
                case classes.ActionItem.Action.STOCK:
                    saleForm.refreshReport();
                    break;

                case classes.ActionItem.Action.TRANSACTIONS:
                    tranForm.init();
                    break;

                case classes.ActionItem.Action.CLIENTS:
                    
                    break;

                case classes.ActionItem.Action.ITEMS:
                    itemForm.initMethod();
                    break;
            }

        }

        private void panContent_SizeChanged(object sender, EventArgs e)
        {
            if (saleForm.Visible)
            {
                saleForm.WindowState = FormWindowState.Normal;
                saleForm.WindowState = FormWindowState.Maximized;
            }

            if (tranForm.Visible)
            {
                tranForm.WindowState = FormWindowState.Normal;
                tranForm.WindowState = FormWindowState.Maximized;
            }

            if (clientForm.Visible)
            {
                clientForm.WindowState = FormWindowState.Normal;
                clientForm.WindowState = FormWindowState.Maximized;
            }

            if (itemForm.Visible)
            {
                itemForm.WindowState = FormWindowState.Normal;
                itemForm.WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

    }
}
