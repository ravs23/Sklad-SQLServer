using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Sklad
{
    public partial class FrmSettings : Form
    {
        string defaultFolderPrices = @"Prices\";
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            tbDiscont.Text = Settings.Discount.ToString();
            chbAddZero.Checked = Settings.DisplayCatalogPeriodsWithZero;
            tbFolderPrices.Text = Settings.FolderPrices;

            folderBrowserDialog_Prices.Description = "Выберите папку с прайс-листами:";

        }

        private void btnFolders_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_Prices.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog_Prices.SelectedPath.ToLower() != Environment.CurrentDirectory.ToLower())
                {
                    folderBrowserDialog_Prices.SelectedPath = folderBrowserDialog_Prices.SelectedPath.TrimEnd('\\');

                    if (folderBrowserDialog_Prices.SelectedPath.ToLower().Contains(Environment.CurrentDirectory.ToLower()))
                    {
                        MessageBox.Show("Test");
                        string folder = folderBrowserDialog_Prices.SelectedPath.ToLower().Replace(Environment.CurrentDirectory.ToLower(), "");
                        folder = folder.TrimStart('\\') + "\\";
                        tbFolderPrices.Text = folder.Substring(0, 1).ToUpper() + folder.Substring(1, folder.Length - 1);
                    }
                    else
                        tbFolderPrices.Text = folderBrowserDialog_Prices.SelectedPath + @"\";
                }
                else
                    tbFolderPrices.Text = defaultFolderPrices;
            }

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            //TODO: Сделать проверку ввоа полей!!!
            this.DialogResult = DialogResult.OK;
        }

        private void tbFolderPrices_Leave(object sender, EventArgs e)
        {
            if (tbFolderPrices.Text == "\\" || tbFolderPrices.Text.Trim() == string.Empty)
                tbFolderPrices.Text = defaultFolderPrices;
            tbFolderPrices.Text=tbFolderPrices.Text.TrimEnd('\\');
            tbFolderPrices.Text += "\\";
        }
    }
}
