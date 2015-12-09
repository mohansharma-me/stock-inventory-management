namespace StockInventoryManagement.forms
{
    partial class frmStockReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvStock = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lvStock
            // 
            this.lvStock.AllColumns.Add(this.olvColumn5);
            this.lvStock.AllColumns.Add(this.olvColumn2);
            this.lvStock.AllColumns.Add(this.olvColumn3);
            this.lvStock.AllColumns.Add(this.olvColumn4);
            this.lvStock.AllowColumnReorder = true;
            this.lvStock.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
            this.lvStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvStock.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.lvStock.CellEditTabChangesRows = true;
            this.lvStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn5,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.lvStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStock.EmptyListMsg = "Stock Empty";
            this.lvStock.EmptyListMsgFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvStock.FullRowSelect = true;
            this.lvStock.GridLines = true;
            this.lvStock.HeaderWordWrap = true;
            this.lvStock.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.lvStock.HighlightForegroundColor = System.Drawing.Color.White;
            this.lvStock.Location = new System.Drawing.Point(0, 0);
            this.lvStock.Margin = new System.Windows.Forms.Padding(4);
            this.lvStock.Name = "lvStock";
            this.lvStock.OverlayText.Text = "";
            this.lvStock.RenderNonEditableCheckboxesAsDisabled = true;
            this.lvStock.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lvStock.ShowCommandMenuOnRightClick = true;
            this.lvStock.ShowGroups = false;
            this.lvStock.ShowItemToolTips = true;
            this.lvStock.Size = new System.Drawing.Size(582, 453);
            this.lvStock.TabIndex = 5;
            this.lvStock.TintSortColumn = true;
            this.lvStock.UnfocusedHighlightBackgroundColor = System.Drawing.Color.SteelBlue;
            this.lvStock.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.lvStock.UseCompatibleStateImageBehavior = false;
            this.lvStock.UseCustomSelectionColors = true;
            this.lvStock.UseExplorerTheme = true;
            this.lvStock.UseFilterIndicator = true;
            this.lvStock.UseFiltering = true;
            this.lvStock.UseHotItem = true;
            this.lvStock.UseHyperlinks = true;
            this.lvStock.View = System.Windows.Forms.View.Details;
            this.lvStock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStock_MouseDoubleClick);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "itemName";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "Client";
            this.olvColumn2.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "qty";
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.Text = "Qty";
            this.olvColumn3.Width = 130;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "itemPPU";
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.Text = "Rate";
            this.olvColumn4.Width = 128;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "extraData";
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.Text = "Date Time";
            this.olvColumn5.Width = 128;
            // 
            // frmStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.lvStock);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "frmStockReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.frmStockReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public BrightIdeasSoftware.ObjectListView lvStock;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
    }
}