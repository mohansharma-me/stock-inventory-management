namespace StockInventoryManagement.forms
{
    partial class frmItems
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
            this.lvItems = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnNewItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.AllColumns.Add(this.olvColumn1);
            this.lvItems.AllColumns.Add(this.olvColumn2);
            this.lvItems.AllColumns.Add(this.olvColumn3);
            this.lvItems.AllowColumnReorder = true;
            this.lvItems.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvItems.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.lvItems.CellEditTabChangesRows = true;
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.lvItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvItems.EmptyListMsg = "Stock Empty";
            this.lvItems.EmptyListMsgFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.HeaderWordWrap = true;
            this.lvItems.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.lvItems.HighlightForegroundColor = System.Drawing.Color.White;
            this.lvItems.Location = new System.Drawing.Point(10, 10);
            this.lvItems.Name = "lvItems";
            this.lvItems.OverlayText.Text = "";
            this.lvItems.RenderNonEditableCheckboxesAsDisabled = true;
            this.lvItems.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lvItems.ShowCommandMenuOnRightClick = true;
            this.lvItems.ShowGroups = false;
            this.lvItems.ShowItemToolTips = true;
            this.lvItems.Size = new System.Drawing.Size(520, 390);
            this.lvItems.TabIndex = 5;
            this.lvItems.TintSortColumn = true;
            this.lvItems.UnfocusedHighlightBackgroundColor = System.Drawing.Color.SteelBlue;
            this.lvItems.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.UseCustomSelectionColors = true;
            this.lvItems.UseExplorerTheme = true;
            this.lvItems.UseFilterIndicator = true;
            this.lvItems.UseFiltering = true;
            this.lvItems.UseHotItem = true;
            this.lvItems.UseHyperlinks = true;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "itemCode";
            this.olvColumn1.Text = "Ref";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "itemName";
            this.olvColumn2.Text = "Name";
            this.olvColumn2.Width = 314;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "itemPPU";
            this.olvColumn3.Text = "Rate";
            this.olvColumn3.Width = 141;
            // 
            // btnNewItem
            // 
            this.btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewItem.Location = new System.Drawing.Point(10, 410);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(75, 33);
            this.btnNewItem.TabIndex = 6;
            this.btnNewItem.Text = "&New Item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteItem.Location = new System.Drawing.Point(90, 410);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(130, 33);
            this.btnDeleteItem.TabIndex = 6;
            this.btnDeleteItem.Text = "&Delete Item(s)";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(440, 410);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(540, 457);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnNewItem);
            this.Controls.Add(this.lvItems);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items";
            this.Load += new System.EventHandler(this.frmItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public BrightIdeasSoftware.ObjectListView lvItems;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnRefresh;

    }
}