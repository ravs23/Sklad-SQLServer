namespace Sklad
{
    partial class FrmAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdd));
            this.lbCode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbNames = new System.Windows.Forms.Label();
            this.lbCuantity = new System.Windows.Forms.Label();
            this.lbPricePC = new System.Windows.Forms.Label();
            this.lbPriceDC = new System.Windows.Forms.Label();
            this.lbCatalog = new System.Windows.Forms.Label();
            this.tbNames = new System.Windows.Forms.TextBox();
            this.tbPricePC = new System.Windows.Forms.TextBox();
            this.tbPriceDC = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbCatalog = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDiscont = new System.Windows.Forms.CheckBox();
            this.lbDescriptionCount = new System.Windows.Forms.Label();
            this.btAddCategory = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.btnAddCatalog = new System.Windows.Forms.Button();
            this.lbTypeCatalog = new System.Windows.Forms.Label();
            this.cbTypeCatalog = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Location = new System.Drawing.Point(32, 34);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(67, 13);
            this.lbCode.TabIndex = 11;
            this.lbCode.Text = "Код товара:";
            this.toolTip1.SetToolTip(this.lbCode, "Код от 4 до 6 цифр");
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(132, 31);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 20);
            this.tbCode.TabIndex = 0;
            this.tbCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            this.tbCode.Enter += new System.EventHandler(this.tbCode_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowDrop = true;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(529, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 46);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbNames
            // 
            this.lbNames.AutoSize = true;
            this.lbNames.Location = new System.Drawing.Point(32, 60);
            this.lbNames.Name = "lbNames";
            this.lbNames.Size = new System.Drawing.Size(86, 13);
            this.lbNames.TabIndex = 3;
            this.lbNames.Text = "Наименование:";
            this.toolTip1.SetToolTip(this.lbNames, "От 1 до 80 символов");
            // 
            // lbCuantity
            // 
            this.lbCuantity.AutoSize = true;
            this.lbCuantity.Location = new System.Drawing.Point(32, 87);
            this.lbCuantity.Name = "lbCuantity";
            this.lbCuantity.Size = new System.Drawing.Size(69, 13);
            this.lbCuantity.TabIndex = 4;
            this.lbCuantity.Text = "Количество:";
            // 
            // lbPricePC
            // 
            this.lbPricePC.AutoSize = true;
            this.lbPricePC.Location = new System.Drawing.Point(357, 79);
            this.lbPricePC.Name = "lbPricePC";
            this.lbPricePC.Size = new System.Drawing.Size(26, 13);
            this.lbPricePC.TabIndex = 5;
            this.lbPricePC.Text = "ПЦ:";
            // 
            // lbPriceDC
            // 
            this.lbPriceDC.AutoSize = true;
            this.lbPriceDC.Location = new System.Drawing.Point(370, 113);
            this.lbPriceDC.Name = "lbPriceDC";
            this.lbPriceDC.Size = new System.Drawing.Size(27, 13);
            this.lbPriceDC.TabIndex = 6;
            this.lbPriceDC.Text = "ДЦ:";
            // 
            // lbCatalog
            // 
            this.lbCatalog.AutoSize = true;
            this.lbCatalog.Location = new System.Drawing.Point(19, 131);
            this.lbCatalog.Name = "lbCatalog";
            this.lbCatalog.Size = new System.Drawing.Size(51, 13);
            this.lbCatalog.TabIndex = 7;
            this.lbCatalog.Text = "Каталог:";
            // 
            // tbNames
            // 
            this.tbNames.Location = new System.Drawing.Point(132, 57);
            this.tbNames.Name = "tbNames";
            this.tbNames.Size = new System.Drawing.Size(381, 20);
            this.tbNames.TabIndex = 1;
            this.tbNames.TextChanged += new System.EventHandler(this.tbNames_TextChanged);
            this.tbNames.Enter += new System.EventHandler(this.tbNames_Enter);
            // 
            // tbPricePC
            // 
            this.tbPricePC.Location = new System.Drawing.Point(413, 84);
            this.tbPricePC.Name = "tbPricePC";
            this.tbPricePC.Size = new System.Drawing.Size(100, 20);
            this.tbPricePC.TabIndex = 4;
            this.tbPricePC.Enter += new System.EventHandler(this.tbPricePC_Enter);
            this.tbPricePC.Leave += new System.EventHandler(this.tbPricePC_Leave);
            // 
            // tbPriceDC
            // 
            this.tbPriceDC.Location = new System.Drawing.Point(413, 110);
            this.tbPriceDC.Name = "tbPriceDC";
            this.tbPriceDC.Size = new System.Drawing.Size(100, 20);
            this.tbPriceDC.TabIndex = 5;
            this.tbPriceDC.Enter += new System.EventHandler(this.tbPriceDC_Enter);
            this.tbPriceDC.Leave += new System.EventHandler(this.tbPriceDC_Leave);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(132, 83);
            this.numQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbCatalog
            // 
            this.cbCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCatalog.FormattingEnabled = true;
            this.cbCatalog.Location = new System.Drawing.Point(119, 129);
            this.cbCatalog.Name = "cbCatalog";
            this.cbCatalog.Size = new System.Drawing.Size(100, 21);
            this.cbCatalog.TabIndex = 3;
            this.cbCatalog.Enter += new System.EventHandler(this.cbCatalog_Enter);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(235, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(181, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDiscont);
            this.groupBox1.Controls.Add(this.lbDescriptionCount);
            this.groupBox1.Controls.Add(this.btAddCategory);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.lbCategory);
            this.groupBox1.Controls.Add(this.btnAddCatalog);
            this.groupBox1.Controls.Add(this.lbTypeCatalog);
            this.groupBox1.Controls.Add(this.cbCatalog);
            this.groupBox1.Controls.Add(this.lbPricePC);
            this.groupBox1.Controls.Add(this.cbTypeCatalog);
            this.groupBox1.Controls.Add(this.lbCatalog);
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Controls.Add(this.lbDescription);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 244);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cbDiscont
            // 
            this.cbDiscont.AutoSize = true;
            this.cbDiscont.Checked = true;
            this.cbDiscont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDiscont.Location = new System.Drawing.Point(444, 25);
            this.cbDiscont.Name = "cbDiscont";
            this.cbDiscont.Size = new System.Drawing.Size(63, 17);
            this.cbDiscont.TabIndex = 14;
            this.cbDiscont.Text = "Скидка";
            this.toolTip1.SetToolTip(this.cbDiscont, "Продукт куплен со скидкой в каталоге");
            this.cbDiscont.UseVisualStyleBackColor = true;
            // 
            // lbDescriptionCount
            // 
            this.lbDescriptionCount.AutoSize = true;
            this.lbDescriptionCount.Location = new System.Drawing.Point(506, 186);
            this.lbDescriptionCount.Name = "lbDescriptionCount";
            this.lbDescriptionCount.Size = new System.Drawing.Size(42, 13);
            this.lbDescriptionCount.TabIndex = 12;
            this.lbDescriptionCount.Text = "[0/200]";
            // 
            // btAddCategory
            // 
            this.btAddCategory.Location = new System.Drawing.Point(309, 154);
            this.btAddCategory.Name = "btAddCategory";
            this.btAddCategory.Size = new System.Drawing.Size(24, 23);
            this.btAddCategory.TabIndex = 11;
            this.btAddCategory.Text = "+";
            this.toolTip1.SetToolTip(this.btAddCategory, "Добавить новую категорию");
            this.btAddCategory.UseVisualStyleBackColor = true;
            this.btAddCategory.Click += new System.EventHandler(this.btAddCategory_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(119, 156);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(184, 21);
            this.cbCategory.TabIndex = 10;
            this.cbCategory.Enter += new System.EventHandler(this.cbCategory_Enter);
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(19, 159);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(63, 13);
            this.lbCategory.TabIndex = 9;
            this.lbCategory.Text = "Категория:";
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.Location = new System.Drawing.Point(225, 127);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(108, 23);
            this.btnAddCatalog.TabIndex = 8;
            this.btnAddCatalog.Text = "Добавить каталог";
            this.btnAddCatalog.UseVisualStyleBackColor = true;
            this.btnAddCatalog.Click += new System.EventHandler(this.btnAddCatalog_Click);
            // 
            // lbTypeCatalog
            // 
            this.lbTypeCatalog.AutoSize = true;
            this.lbTypeCatalog.Location = new System.Drawing.Point(19, 105);
            this.lbTypeCatalog.Name = "lbTypeCatalog";
            this.lbTypeCatalog.Size = new System.Drawing.Size(78, 13);
            this.lbTypeCatalog.TabIndex = 7;
            this.lbTypeCatalog.Text = "Тип каталога:";
            // 
            // cbTypeCatalog
            // 
            this.cbTypeCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCatalog.FormattingEnabled = true;
            this.cbTypeCatalog.Location = new System.Drawing.Point(119, 102);
            this.cbTypeCatalog.Name = "cbTypeCatalog";
            this.cbTypeCatalog.Size = new System.Drawing.Size(100, 21);
            this.cbTypeCatalog.TabIndex = 3;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(119, 183);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(381, 46);
            this.tbDescription.TabIndex = 10;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            this.tbDescription.Enter += new System.EventHandler(this.tbDescription_Enter);
            this.tbDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDescription_KeyUp);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(19, 186);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "Описание:";
            this.toolTip1.SetToolTip(this.lbDescription, "До 200 символов");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(554, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 318);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.tbPriceDC);
            this.Controls.Add(this.tbPricePC);
            this.Controls.Add(this.tbNames);
            this.Controls.Add(this.lbPriceDC);
            this.Controls.Add(this.lbCuantity);
            this.Controls.Add(this.lbNames);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.lbCode);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление продукта";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbNames;
        private System.Windows.Forms.Label lbCuantity;
        private System.Windows.Forms.Label lbPricePC;
        private System.Windows.Forms.Label lbPriceDC;
        private System.Windows.Forms.Label lbCatalog;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbNames;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cbCatalog;
        private System.Windows.Forms.TextBox tbPricePC;
        private System.Windows.Forms.TextBox tbPriceDC;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTypeCatalog;
        private System.Windows.Forms.ComboBox cbTypeCatalog;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnAddCatalog;
        private System.Windows.Forms.Button btAddCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbDescriptionCount;
        private System.Windows.Forms.CheckBox cbDiscont;
        private System.Windows.Forms.Button btnCancel;
    }
}