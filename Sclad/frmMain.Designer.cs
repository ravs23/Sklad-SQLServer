namespace Sklad
{
    public partial class FrmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNames = new System.Windows.Forms.TextBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCode = new System.Windows.Forms.MaskedTextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.picboxOnTopOFF = new System.Windows.Forms.PictureBox();
            this.picboxOnTopON = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savefdExport = new System.Windows.Forms.SaveFileDialog();
            this.openfdImport = new System.Windows.Forms.OpenFileDialog();
            this.CodeDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Plus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOnTopOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOnTopON)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(426, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 47);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Names,
            this.Quantity,
            this.Column1});
            this.dgvMain.Location = new System.Drawing.Point(12, 101);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(737, 164);
            this.dgvMain.TabIndex = 8;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "code";
            this.Code.Frozen = true;
            this.Code.HeaderText = "Код товара";
            this.Code.MaxInputLength = 6;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 87;
            // 
            // Names
            // 
            this.Names.DataPropertyName = "name";
            this.Names.Frozen = true;
            this.Names.HeaderText = "Наименование";
            this.Names.Name = "Names";
            this.Names.ReadOnly = true;
            this.Names.Width = 460;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "total";
            this.Quantity.Frozen = true;
            this.Quantity.HeaderText = "Количество";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 90;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Text = "X";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Поиск по коду:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поиск по названию:";
            // 
            // tbNames
            // 
            this.tbNames.Location = new System.Drawing.Point(132, 66);
            this.tbNames.Name = "tbNames";
            this.tbNames.Size = new System.Drawing.Size(140, 20);
            this.tbNames.TabIndex = 5;
            this.tbNames.TextChanged += new System.EventHandler(this.tbNames_TextChanged);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Location = new System.Drawing.Point(706, 40);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(28, 13);
            this.lblAbout.TabIndex = 4;
            this.lblAbout.Text = "v1.0";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(289, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 47);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // tbCode
            // 
            this.tbCode.HidePromptOnLeave = true;
            this.tbCode.Location = new System.Drawing.Point(120, 14);
            this.tbCode.Mask = "000000";
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(140, 20);
            this.tbCode.TabIndex = 0;
            this.tbCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalc.BackgroundImage")));
            this.btnCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalc.Location = new System.Drawing.Point(598, 43);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(41, 39);
            this.btnCalc.TabIndex = 1;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeDetails,
            this.DC,
            this.PC,
            this.Quant,
            this.CatN,
            this.CatY,
            this.Disc,
            this.Descrip,
            this.TypeCat,
            this.Minus,
            this.Plus,
            this.Delete});
            this.dgvDetails.Location = new System.Drawing.Point(12, 285);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.Size = new System.Drawing.Size(737, 150);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // picboxOnTopOFF
            // 
            this.picboxOnTopOFF.Image = ((System.Drawing.Image)(resources.GetObject("picboxOnTopOFF.Image")));
            this.picboxOnTopOFF.Location = new System.Drawing.Point(710, 63);
            this.picboxOnTopOFF.Name = "picboxOnTopOFF";
            this.picboxOnTopOFF.Size = new System.Drawing.Size(16, 16);
            this.picboxOnTopOFF.TabIndex = 2;
            this.picboxOnTopOFF.TabStop = false;
            this.picboxOnTopOFF.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picboxOnTopON
            // 
            this.picboxOnTopON.Image = ((System.Drawing.Image)(resources.GetObject("picboxOnTopON.Image")));
            this.picboxOnTopON.InitialImage = ((System.Drawing.Image)(resources.GetObject("picboxOnTopON.InitialImage")));
            this.picboxOnTopON.Location = new System.Drawing.Point(710, 63);
            this.picboxOnTopON.Name = "picboxOnTopON";
            this.picboxOnTopON.Size = new System.Drawing.Size(16, 16);
            this.picboxOnTopON.TabIndex = 11;
            this.picboxOnTopON.TabStop = false;
            this.picboxOnTopON.Visible = false;
            this.picboxOnTopON.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuFile,
            this.tsmMenuStatistic,
            this.tsmMenuOptions,
            this.tsmMenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMenuFile
            // 
            this.tsmMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImport,
            this.tsmExport,
            this.toolStripSeparator1,
            this.tsmExit});
            this.tsmMenuFile.Name = "tsmMenuFile";
            this.tsmMenuFile.Size = new System.Drawing.Size(48, 20);
            this.tsmMenuFile.Text = "Файл";
            // 
            // tsmImport
            // 
            this.tsmImport.Name = "tsmImport";
            this.tsmImport.Size = new System.Drawing.Size(128, 22);
            this.tsmImport.Text = "Импорт...";
            this.tsmImport.Click += new System.EventHandler(this.tsmImport_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(128, 22);
            this.tsmExport.Text = "Экспорт...";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(128, 22);
            this.tsmExit.Text = "Выход";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmMenuStatistic
            // 
            this.tsmMenuStatistic.Name = "tsmMenuStatistic";
            this.tsmMenuStatistic.Size = new System.Drawing.Size(80, 20);
            this.tsmMenuStatistic.Text = "Статистика";
            this.tsmMenuStatistic.Click += new System.EventHandler(this.tsmMenuStatistic_Click);
            // 
            // tsmMenuOptions
            // 
            this.tsmMenuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAlwaysOnTop,
            this.tsmOptions});
            this.tsmMenuOptions.Name = "tsmMenuOptions";
            this.tsmMenuOptions.Size = new System.Drawing.Size(79, 20);
            this.tsmMenuOptions.Text = "Настройки";
            // 
            // tsmAlwaysOnTop
            // 
            this.tsmAlwaysOnTop.CheckOnClick = true;
            this.tsmAlwaysOnTop.Name = "tsmAlwaysOnTop";
            this.tsmAlwaysOnTop.Size = new System.Drawing.Size(147, 22);
            this.tsmAlwaysOnTop.Text = "Закрепить";
            this.tsmAlwaysOnTop.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // tsmOptions
            // 
            this.tsmOptions.Name = "tsmOptions";
            this.tsmOptions.Size = new System.Drawing.Size(147, 22);
            this.tsmOptions.Text = "Параметры...";
            this.tsmOptions.Click += new System.EventHandler(this.tsmOptions_Click);
            // 
            // tsmMenuHelp
            // 
            this.tsmMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.tsmMenuHelp.Name = "tsmMenuHelp";
            this.tsmMenuHelp.Size = new System.Drawing.Size(24, 20);
            this.tsmMenuHelp.Text = "?";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // savefdExport
            // 
            this.savefdExport.Title = "Экспорт базы данных";
            // 
            // CodeDetails
            // 
            this.CodeDetails.DataPropertyName = "code";
            this.CodeDetails.HeaderText = "Код";
            this.CodeDetails.Name = "CodeDetails";
            this.CodeDetails.ReadOnly = true;
            this.CodeDetails.Width = 50;
            // 
            // DC
            // 
            this.DC.DataPropertyName = "priceDC";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.DC.DefaultCellStyle = dataGridViewCellStyle1;
            this.DC.HeaderText = "ДЦ";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Width = 50;
            // 
            // PC
            // 
            this.PC.DataPropertyName = "pricePC";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.PC.DefaultCellStyle = dataGridViewCellStyle2;
            this.PC.HeaderText = "ПЦ";
            this.PC.Name = "PC";
            this.PC.ReadOnly = true;
            this.PC.Width = 50;
            // 
            // Quant
            // 
            this.Quant.DataPropertyName = "quantity";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.Quant.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quant.HeaderText = "Кол";
            this.Quant.Name = "Quant";
            this.Quant.ReadOnly = true;
            this.Quant.Width = 30;
            // 
            // CatN
            // 
            this.CatN.DataPropertyName = "number";
            this.CatN.HeaderText = "№Кат";
            this.CatN.Name = "CatN";
            this.CatN.ReadOnly = true;
            this.CatN.Width = 40;
            // 
            // CatY
            // 
            this.CatY.DataPropertyName = "year";
            this.CatY.HeaderText = "Год";
            this.CatY.Name = "CatY";
            this.CatY.ReadOnly = true;
            this.CatY.Width = 40;
            // 
            // Disc
            // 
            this.Disc.DataPropertyName = "discont";
            this.Disc.HeaderText = "Диск";
            this.Disc.Name = "Disc";
            this.Disc.ReadOnly = true;
            this.Disc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Disc.Width = 50;
            // 
            // Descrip
            // 
            this.Descrip.DataPropertyName = "description";
            this.Descrip.HeaderText = "Описание";
            this.Descrip.Name = "Descrip";
            this.Descrip.ReadOnly = true;
            this.Descrip.Width = 148;
            // 
            // TypeCat
            // 
            this.TypeCat.DataPropertyName = "type";
            this.TypeCat.HeaderText = "Каталог";
            this.TypeCat.Name = "TypeCat";
            this.TypeCat.ReadOnly = true;
            this.TypeCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TypeCat.Width = 99;
            // 
            // Minus
            // 
            this.Minus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Minus.HeaderText = "";
            this.Minus.Name = "Minus";
            this.Minus.ReadOnly = true;
            this.Minus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Minus.Text = "-1";
            this.Minus.UseColumnTextForButtonValue = true;
            this.Minus.Width = 40;
            // 
            // Plus
            // 
            this.Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Plus.HeaderText = "";
            this.Plus.Name = "Plus";
            this.Plus.ReadOnly = true;
            this.Plus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Plus.Text = "+1";
            this.Plus.UseColumnTextForButtonValue = true;
            this.Plus.Width = 40;
            // 
            // Delete
            // 
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Text = "X";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 40;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.picboxOnTopOFF);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.tbNames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picboxOnTopON);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOnTopOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOnTopON)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNames;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picboxOnTopOFF;
        private System.Windows.Forms.PictureBox picboxOnTopON;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.MaskedTextBox tbCode;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuFile;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmAlwaysOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmImport;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuStatistic;
        private System.Windows.Forms.SaveFileDialog savefdExport;
        private System.Windows.Forms.OpenFileDialog openfdImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatY;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Disc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCat;
        private System.Windows.Forms.DataGridViewButtonColumn Minus;
        private System.Windows.Forms.DataGridViewButtonColumn Plus;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

