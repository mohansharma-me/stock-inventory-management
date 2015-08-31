namespace StockInventoryManagement.forms
{
    partial class frmStock
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
            this.olvColumnRef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnWoodType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lvStock
            // 
            this.lvStock.AllColumns.Add(this.olvColumnRef);
            this.lvStock.AllColumns.Add(this.olvColumnWoodType);
            this.lvStock.AllColumns.Add(this.olvColumn3);
            this.lvStock.AllowColumnReorder = true;
            this.lvStock.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
            this.lvStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvStock.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.lvStock.CellEditTabChangesRows = true;
            this.lvStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnRef,
            this.olvColumnWoodType,
            this.olvColumn3});
            this.lvStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStock.EmptyListMsg = "Stock Empty";
            this.lvStock.EmptyListMsgFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStock.FullRowSelect = true;
            this.lvStock.GridLines = true;
            this.lvStock.HeaderWordWrap = true;
            this.lvStock.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.lvStock.HighlightForegroundColor = System.Drawing.Color.White;
            this.lvStock.Location = new System.Drawing.Point(10, 10);
            this.lvStock.Name = "lvStock";
            this.lvStock.OverlayText.Text = "";
            this.lvStock.RenderNonEditableCheckboxesAsDisabled = true;
            this.lvStock.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lvStock.ShowCommandMenuOnRightClick = true;
            this.lvStock.ShowGroups = false;
            this.lvStock.ShowItemToolTips = true;
            this.lvStock.Size = new System.Drawing.Size(988, 708);
            this.lvStock.TabIndex = 4;
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
            // 
            // olvColumnRef
            // 
            this.olvColumnRef.AspectName = "itemCode";
            this.olvColumnRef.IsEditable = false;
            this.olvColumnRef.Text = "Reference";
            this.olvColumnRef.Width = 104;
            // 
            // olvColumnWoodType
            // 
            this.olvColumnWoodType.AspectName = "itemName";
            this.olvColumnWoodType.IsEditable = false;
            this.olvColumnWoodType.Text = "Item";
            this.olvColumnWoodType.Width = 184;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "qty";
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.Text = "Available";
            this.olvColumn3.Width = 142;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Controls.Add(this.lvStock);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStock";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public BrightIdeasSoftware.ObjectListView lvStock;
        private BrightIdeasSoftware.OLVColumn olvColumnRef;
        private BrightIdeasSoftware.OLVColumn olvColumnWoodType;
        private BrightIdeasSoftware.OLVColumn olvColumn3;

    }
}