namespace Sklad
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.lblDiscont = new System.Windows.Forms.Label();
            this.tbDiscont = new System.Windows.Forms.TextBox();
            this.chbAddZero = new System.Windows.Forms.CheckBox();
            this.tbFolderPrices = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog_Prices = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolders = new System.Windows.Forms.Button();
            this.lblAddZero = new System.Windows.Forms.Label();
            this.lblProcent = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancelSettings = new System.Windows.Forms.Button();
            this.lblFormat = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiscont
            // 
            this.lblDiscont.AutoSize = true;
            this.lblDiscont.Location = new System.Drawing.Point(14, 34);
            this.lblDiscont.Name = "lblDiscont";
            this.lblDiscont.Size = new System.Drawing.Size(88, 13);
            this.lblDiscont.TabIndex = 0;
            this.lblDiscont.Text = "Размер скидки:";
            // 
            // tbDiscont
            // 
            this.tbDiscont.Location = new System.Drawing.Point(119, 31);
            this.tbDiscont.MaxLength = 2;
            this.tbDiscont.Name = "tbDiscont";
            this.tbDiscont.Size = new System.Drawing.Size(29, 20);
            this.tbDiscont.TabIndex = 1;
            // 
            // chbAddZero
            // 
            this.chbAddZero.AutoSize = true;
            this.chbAddZero.Location = new System.Drawing.Point(17, 28);
            this.chbAddZero.Name = "chbAddZero";
            this.chbAddZero.Size = new System.Drawing.Size(15, 14);
            this.chbAddZero.TabIndex = 2;
            this.chbAddZero.UseVisualStyleBackColor = true;
            // 
            // tbFolderPrices
            // 
            this.tbFolderPrices.Location = new System.Drawing.Point(9, 19);
            this.tbFolderPrices.Name = "tbFolderPrices";
            this.tbFolderPrices.Size = new System.Drawing.Size(374, 20);
            this.tbFolderPrices.TabIndex = 3;
            this.tbFolderPrices.Leave += new System.EventHandler(this.tbFolderPrices_Leave);
            // 
            // btnFolders
            // 
            this.btnFolders.Location = new System.Drawing.Point(9, 45);
            this.btnFolders.Name = "btnFolders";
            this.btnFolders.Size = new System.Drawing.Size(75, 23);
            this.btnFolders.TabIndex = 4;
            this.btnFolders.Text = "Обзор...";
            this.btnFolders.UseVisualStyleBackColor = true;
            this.btnFolders.Click += new System.EventHandler(this.btnFolders_Click);
            // 
            // lblAddZero
            // 
            this.lblAddZero.AutoSize = true;
            this.lblAddZero.Location = new System.Drawing.Point(14, 28);
            this.lblAddZero.Name = "lblAddZero";
            this.lblAddZero.Size = new System.Drawing.Size(166, 52);
            this.lblAddZero.TabIndex = 5;
            this.lblAddZero.Text = "           Добавлять \"0\"\r\n\r\nОтметьте, чтобы период\r\nкаталога  имел вид 01, 02, 03" +
    "...";
            // 
            // lblProcent
            // 
            this.lblProcent.AutoSize = true;
            this.lblProcent.Location = new System.Drawing.Point(147, 34);
            this.lblProcent.Name = "lblProcent";
            this.lblProcent.Size = new System.Drawing.Size(15, 13);
            this.lblProcent.TabIndex = 0;
            this.lblProcent.Text = "%";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(229, 217);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "Сохранить";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancelSettings
            // 
            this.btnCancelSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSettings.Location = new System.Drawing.Point(319, 217);
            this.btnCancelSettings.Name = "btnCancelSettings";
            this.btnCancelSettings.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSettings.TabIndex = 6;
            this.btnCancelSettings.Text = "Отмена";
            this.btnCancelSettings.UseVisualStyleBackColor = true;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(130, 43);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(253, 26);
            this.lblFormat.TabIndex = 8;
            this.lblFormat.Text = "Поддерживаются прайс-листы в формате XLSX.\r\nВерсия Microsoft Excel 2007 и выше.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Оптимизировать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFormat);
            this.groupBox1.Controls.Add(this.tbFolderPrices);
            this.groupBox1.Controls.Add(this.btnFolders);
            this.groupBox1.Location = new System.Drawing.Point(220, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Каталог с прайсами";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDiscont);
            this.groupBox2.Controls.Add(this.lblDiscont);
            this.groupBox2.Controls.Add(this.lblProcent);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 79);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbAddZero);
            this.groupBox3.Controls.Add(this.lblAddZero);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 105);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(220, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 105);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Оптимизация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Оптимизация позволяет удалить из базы данных неиспользуемые\r\nэлементы, такие как:" +
    " каталожные периоды, категории продуктов,\r\nтипы катологов.\r\n";
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.btnSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelSettings;
            this.ClientSize = new System.Drawing.Size(621, 254);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelSettings);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDiscont;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Prices;
        private System.Windows.Forms.Button btnFolders;
        private System.Windows.Forms.Label lblAddZero;
        private System.Windows.Forms.Label lblProcent;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancelSettings;
        public System.Windows.Forms.TextBox tbDiscont;
        public System.Windows.Forms.CheckBox chbAddZero;
        public System.Windows.Forms.TextBox tbFolderPrices;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
    }
}