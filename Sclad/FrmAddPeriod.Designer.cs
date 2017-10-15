namespace Sklad
{
    partial class FrmAddPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPeriod));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.tbmPeriod = new System.Windows.Forms.MaskedTextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblErrorPeriodExist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(52, 65);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(142, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(142, 24);
            this.nudYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(50, 20);
            this.nudYear.TabIndex = 2;
            this.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // tbmPeriod
            // 
            this.tbmPeriod.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.tbmPeriod.Location = new System.Drawing.Point(77, 23);
            this.tbmPeriod.Mask = "00";
            this.tbmPeriod.Name = "tbmPeriod";
            this.tbmPeriod.PromptChar = ' ';
            this.tbmPeriod.Size = new System.Drawing.Size(50, 20);
            this.tbmPeriod.TabIndex = 1;
            this.tbmPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.SystemColors.Control;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(84, 47);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(104, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Не указан период !";
            this.lblError.Visible = false;
            // 
            // lblErrorPeriodExist
            // 
            this.lblErrorPeriodExist.AutoSize = true;
            this.lblErrorPeriodExist.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrorPeriodExist.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPeriodExist.Location = new System.Drawing.Point(52, 47);
            this.lblErrorPeriodExist.Name = "lblErrorPeriodExist";
            this.lblErrorPeriodExist.Size = new System.Drawing.Size(164, 13);
            this.lblErrorPeriodExist.TabIndex = 5;
            this.lblErrorPeriodExist.Text = "Период \"0 / 0000\"существует !";
            this.lblErrorPeriodExist.Visible = false;
            // 
            // FrmAddPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 114);
            this.Controls.Add(this.lblErrorPeriodExist);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tbmPeriod);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddPeriod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление каталожного периода";
            this.Load += new System.EventHandler(this.FrmAddPeriod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.MaskedTextBox tbmPeriod;
        private System.Windows.Forms.Label lblErrorPeriodExist;
    }
}