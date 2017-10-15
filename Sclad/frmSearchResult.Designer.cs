namespace Sklad
{
    partial class FrmSearchResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchResult));
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.CodeDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DC_DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC_DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscontDB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PeriodDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBD = new System.Windows.Forms.GroupBox();
            this.gbPrices = new System.Windows.Forms.GroupBox();
            this.dgvPrice = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            this.gbBD.SuspendLayout();
            this.gbPrices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDB
            // 
            this.dgvDB.AllowUserToAddRows = false;
            this.dgvDB.AllowUserToDeleteRows = false;
            this.dgvDB.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeDB,
            this.NameDB,
            this.DC_DB,
            this.PC_DB,
            this.DiscontDB,
            this.PeriodDB});
            this.dgvDB.Location = new System.Drawing.Point(6, 19);
            this.dgvDB.MultiSelect = false;
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.ReadOnly = true;
            this.dgvDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDB.Size = new System.Drawing.Size(695, 146);
            this.dgvDB.TabIndex = 0;
            this.dgvDB.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // CodeDB
            // 
            this.CodeDB.DataPropertyName = "code";
            this.CodeDB.HeaderText = "Код";
            this.CodeDB.Name = "CodeDB";
            this.CodeDB.ReadOnly = true;
            this.CodeDB.Width = 62;
            // 
            // NameDB
            // 
            this.NameDB.DataPropertyName = "name";
            this.NameDB.HeaderText = "Наименование";
            this.NameDB.Name = "NameDB";
            this.NameDB.ReadOnly = true;
            this.NameDB.Width = 354;
            // 
            // DC_DB
            // 
            this.DC_DB.DataPropertyName = "priceDC";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.DC_DB.DefaultCellStyle = dataGridViewCellStyle1;
            this.DC_DB.HeaderText = "ДЦ";
            this.DC_DB.Name = "DC_DB";
            this.DC_DB.ReadOnly = true;
            this.DC_DB.Width = 55;
            // 
            // PC_DB
            // 
            this.PC_DB.DataPropertyName = "pricePC";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.PC_DB.DefaultCellStyle = dataGridViewCellStyle2;
            this.PC_DB.HeaderText = "ПЦ";
            this.PC_DB.Name = "PC_DB";
            this.PC_DB.ReadOnly = true;
            this.PC_DB.Width = 55;
            // 
            // DiscontDB
            // 
            this.DiscontDB.DataPropertyName = "discont";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.NullValue = false;
            this.DiscontDB.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiscontDB.HeaderText = "Скидка";
            this.DiscontDB.Name = "DiscontDB";
            this.DiscontDB.ReadOnly = true;
            this.DiscontDB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DiscontDB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DiscontDB.Width = 50;
            // 
            // PeriodDB
            // 
            this.PeriodDB.DataPropertyName = "period";
            this.PeriodDB.HeaderText = "Период";
            this.PeriodDB.Name = "PeriodDB";
            this.PeriodDB.ReadOnly = true;
            this.PeriodDB.Width = 59;
            // 
            // gbBD
            // 
            this.gbBD.Controls.Add(this.dgvDB);
            this.gbBD.Location = new System.Drawing.Point(12, 12);
            this.gbBD.Name = "gbBD";
            this.gbBD.Size = new System.Drawing.Size(707, 172);
            this.gbBD.TabIndex = 1;
            this.gbBD.TabStop = false;
            this.gbBD.Text = "Результаты поиска в локальной базе:";
            // 
            // gbPrices
            // 
            this.gbPrices.Controls.Add(this.dgvPrice);
            this.gbPrices.Location = new System.Drawing.Point(12, 190);
            this.gbPrices.Name = "gbPrices";
            this.gbPrices.Size = new System.Drawing.Size(707, 262);
            this.gbPrices.TabIndex = 1;
            this.gbPrices.TabStop = false;
            this.gbPrices.Text = "Результаты поиска в прайсах:";
            // 
            // dgvPrice
            // 
            this.dgvPrice.AllowUserToAddRows = false;
            this.dgvPrice.AllowUserToDeleteRows = false;
            this.dgvPrice.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Names,
            this.DC,
            this.PC,
            this.Discont,
            this.Period});
            this.dgvPrice.Location = new System.Drawing.Point(6, 19);
            this.dgvPrice.MultiSelect = false;
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            this.dgvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrice.Size = new System.Drawing.Size(695, 237);
            this.dgvPrice.TabIndex = 0;
            this.dgvPrice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Код";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 62;
            // 
            // Names
            // 
            this.Names.DataPropertyName = "Name";
            this.Names.HeaderText = "Наименование";
            this.Names.Name = "Names";
            this.Names.ReadOnly = true;
            this.Names.Width = 354;
            // 
            // DC
            // 
            this.DC.DataPropertyName = "DC";
            this.DC.HeaderText = "ДЦ";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Width = 55;
            // 
            // PC
            // 
            this.PC.DataPropertyName = "PC";
            this.PC.HeaderText = "ПЦ";
            this.PC.Name = "PC";
            this.PC.ReadOnly = true;
            this.PC.Width = 55;
            // 
            // Discont
            // 
            this.Discont.DataPropertyName = "Discont";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Discont.DefaultCellStyle = dataGridViewCellStyle4;
            this.Discont.HeaderText = "Скидка";
            this.Discont.Name = "Discont";
            this.Discont.ReadOnly = true;
            this.Discont.Width = 50;
            // 
            // Period
            // 
            this.Period.DataPropertyName = "Period";
            this.Period.HeaderText = "Период";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.Width = 59;
            // 
            // FrmSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 464);
            this.Controls.Add(this.gbPrices);
            this.Controls.Add(this.gbBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearchResult";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Результаты поиска";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            this.gbBD.ResumeLayout(false);
            this.gbPrices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.GroupBox gbBD;
        private System.Windows.Forms.GroupBox gbPrices;
        private System.Windows.Forms.DataGridView dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discont;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC_DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC_DB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DiscontDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeriodDB;
    }
}