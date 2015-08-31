namespace StockInventoryManagement.forms
{
    partial class frmClient
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearClient = new System.Windows.Forms.Button();
            this.btnSaveClient = new System.Windows.Forms.Button();
            this.txtRefCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLandline = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvClients = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvClientTransactions = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvClients)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvClientTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearClient);
            this.tabPage1.Controls.Add(this.btnSaveClient);
            this.tabPage1.Controls.Add(this.txtRefCode);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtSurname);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTelephone);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLandline);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Client";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClearClient
            // 
            this.btnClearClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearClient.Location = new System.Drawing.Point(600, 252);
            this.btnClearClient.Name = "btnClearClient";
            this.btnClearClient.Size = new System.Drawing.Size(84, 36);
            this.btnClearClient.TabIndex = 8;
            this.btnClearClient.Text = "&CLEAR";
            this.btnClearClient.UseVisualStyleBackColor = true;
            this.btnClearClient.Click += new System.EventHandler(this.btnClearClient_Click);
            // 
            // btnSaveClient
            // 
            this.btnSaveClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClient.Location = new System.Drawing.Point(504, 252);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(84, 36);
            this.btnSaveClient.TabIndex = 7;
            this.btnSaveClient.Text = "&SAVE";
            this.btnSaveClient.UseVisualStyleBackColor = true;
            this.btnSaveClient.Click += new System.EventHandler(this.btnSaveClient_Click);
            // 
            // txtRefCode
            // 
            this.txtRefCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefCode.Location = new System.Drawing.Point(492, 204);
            this.txtRefCode.Name = "txtRefCode";
            this.txtRefCode.Size = new System.Drawing.Size(192, 29);
            this.txtRefCode.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ref code :";
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurname.Location = new System.Drawing.Point(432, 24);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(252, 29);
            this.txtSurname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Surname :";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(108, 84);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(576, 29);
            this.txtAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address :";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(492, 144);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(192, 29);
            this.txtTelephone.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Telephone :";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(156, 204);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(228, 29);
            this.txtEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email address :";
            // 
            // txtLandline
            // 
            this.txtLandline.Location = new System.Drawing.Point(144, 144);
            this.txtLandline.Name = "txtLandline";
            this.txtLandline.Size = new System.Drawing.Size(228, 29);
            this.txtLandline.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Landline No :";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(96, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 29);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvClients);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Client Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvClients
            // 
            this.lvClients.AllColumns.Add(this.olvColumn1);
            this.lvClients.AllColumns.Add(this.olvColumn2);
            this.lvClients.AllColumns.Add(this.olvColumn3);
            this.lvClients.AllColumns.Add(this.olvColumn4);
            this.lvClients.AllColumns.Add(this.olvColumn5);
            this.lvClients.AllColumns.Add(this.olvColumn6);
            this.lvClients.AllColumns.Add(this.olvColumn7);
            this.lvClients.AllowColumnReorder = true;
            this.lvClients.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
            this.lvClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvClients.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only;
            this.lvClients.CellEditTabChangesRows = true;
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn7});
            this.lvClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClients.EmptyListMsg = "Empty list";
            this.lvClients.EmptyListMsgFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClients.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClients.FullRowSelect = true;
            this.lvClients.GridLines = true;
            this.lvClients.HeaderWordWrap = true;
            this.lvClients.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.lvClients.HighlightForegroundColor = System.Drawing.Color.White;
            this.lvClients.Location = new System.Drawing.Point(3, 3);
            this.lvClients.Name = "lvClients";
            this.lvClients.OverlayText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClients.OverlayText.Text = "Press F2 to edit client and Double click to see all transactions.";
            this.lvClients.OverlayText.TextColor = System.Drawing.Color.Black;
            this.lvClients.RenderNonEditableCheckboxesAsDisabled = true;
            this.lvClients.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lvClients.ShowCommandMenuOnRightClick = true;
            this.lvClients.ShowGroups = false;
            this.lvClients.ShowItemToolTips = true;
            this.lvClients.Size = new System.Drawing.Size(701, 460);
            this.lvClients.TabIndex = 9;
            this.lvClients.TintSortColumn = true;
            this.lvClients.UnfocusedHighlightBackgroundColor = System.Drawing.Color.SteelBlue;
            this.lvClients.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.UseCustomSelectionColors = true;
            this.lvClients.UseExplorerTheme = true;
            this.lvClients.UseFilterIndicator = true;
            this.lvClients.UseFiltering = true;
            this.lvClients.UseHotItem = true;
            this.lvClients.UseHyperlinks = true;
            this.lvClients.View = System.Windows.Forms.View.Details;
            this.lvClients.SelectedIndexChanged += new System.EventHandler(this.lvClients_SelectedIndexChanged);
            this.lvClients.DoubleClick += new System.EventHandler(this.lvClients_DoubleClick);
            this.lvClients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvClients_KeyDown);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "name";
            this.olvColumn1.Text = "Client name";
            this.olvColumn1.Width = 106;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "surname";
            this.olvColumn2.Text = "Surname";
            this.olvColumn2.Width = 95;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "address";
            this.olvColumn3.Text = "Address";
            this.olvColumn3.Width = 91;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "landline";
            this.olvColumn4.Text = "Landline";
            this.olvColumn4.Width = 122;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "telephone";
            this.olvColumn5.Text = "Telephone";
            this.olvColumn5.Width = 90;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "email";
            this.olvColumn6.Text = "Email";
            this.olvColumn6.Width = 97;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "refcode";
            this.olvColumn7.Text = "Ref Code";
            this.olvColumn7.Width = 94;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvClientTransactions);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(707, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Client Transactions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvClientTransactions
            // 
            this.lvClientTransactions.AllColumns.Add(this.olvColumn8);
            this.lvClientTransactions.AllColumns.Add(this.olvColumn9);
            this.lvClientTransactions.AllColumns.Add(this.olvColumn10);
            this.lvClientTransactions.AllColumns.Add(this.olvColumn11);
            this.lvClientTransactions.AllColumns.Add(this.olvColumn12);
            this.lvClientTransactions.AllowColumnReorder = true;
            this.lvClientTransactions.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
            this.lvClientTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvClientTransactions.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only;
            this.lvClientTransactions.CellEditTabChangesRows = true;
            this.lvClientTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn11,
            this.olvColumn12});
            this.lvClientTransactions.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvClientTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClientTransactions.EmptyListMsg = "Empty list";
            this.lvClientTransactions.EmptyListMsgFont = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClientTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClientTransactions.FullRowSelect = true;
            this.lvClientTransactions.GridLines = true;
            this.lvClientTransactions.HeaderWordWrap = true;
            this.lvClientTransactions.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.lvClientTransactions.HighlightForegroundColor = System.Drawing.Color.White;
            this.lvClientTransactions.Location = new System.Drawing.Point(3, 3);
            this.lvClientTransactions.Name = "lvClientTransactions";
            this.lvClientTransactions.OverlayText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClientTransactions.OverlayText.Text = "Double click to \'Print Invoice\'";
            this.lvClientTransactions.OverlayText.TextColor = System.Drawing.Color.Black;
            this.lvClientTransactions.RenderNonEditableCheckboxesAsDisabled = true;
            this.lvClientTransactions.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.lvClientTransactions.ShowCommandMenuOnRightClick = true;
            this.lvClientTransactions.ShowGroups = false;
            this.lvClientTransactions.ShowItemToolTips = true;
            this.lvClientTransactions.Size = new System.Drawing.Size(701, 460);
            this.lvClientTransactions.TabIndex = 10;
            this.lvClientTransactions.TintSortColumn = true;
            this.lvClientTransactions.UnfocusedHighlightBackgroundColor = System.Drawing.Color.SteelBlue;
            this.lvClientTransactions.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.lvClientTransactions.UseCompatibleStateImageBehavior = false;
            this.lvClientTransactions.UseCustomSelectionColors = true;
            this.lvClientTransactions.UseExplorerTheme = true;
            this.lvClientTransactions.UseFilterIndicator = true;
            this.lvClientTransactions.UseFiltering = true;
            this.lvClientTransactions.UseHotItem = true;
            this.lvClientTransactions.UseHyperlinks = true;
            this.lvClientTransactions.View = System.Windows.Forms.View.Details;
            this.lvClientTransactions.DoubleClick += new System.EventHandler(this.lvClientTransactions_DoubleClick);
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "id";
            this.olvColumn8.Text = "Invoice";
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "timestamp";
            this.olvColumn9.Text = "Time";
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "type";
            this.olvColumn10.Text = "Purchase/Sell";
            // 
            // olvColumn11
            // 
            this.olvColumn11.AspectName = "items.Count";
            this.olvColumn11.Text = "Items Count";
            // 
            // olvColumn12
            // 
            this.olvColumn12.AspectName = "total_price";
            this.olvColumn12.Text = "Invoice Amount";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(735, 520);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClient";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvClients)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvClientTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLandline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRefCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearClient;
        private System.Windows.Forms.Button btnSaveClient;
        public BrightIdeasSoftware.ObjectListView lvClients;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private System.Windows.Forms.TabPage tabPage3;
        public BrightIdeasSoftware.ObjectListView lvClientTransactions;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvColumn11;
        private BrightIdeasSoftware.OLVColumn olvColumn12;
    }
}