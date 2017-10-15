//#define DEVELOP
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    partial class FrmMain : Form
    {
        string currentCode;
        FrmAdd frmAdd;
        FrmSearchResult searchResult;

        public FrmMain()
        {
            InitializeComponent();
            Settings.StartUpSettings();
            DataBase.ConfigConnectionString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DataBase.CheckConnection())
            {
                if (!DataBase.CheckExistDB())
                {
                    DataBase.CreateDB();
                    DataBase.CreateAllTabels();
                    DataBase.FillTestData();
                }

                // ! используются только во время разработки
#if DEVELOP
                CatalogPeriod.FillDBCatalog();
                Catalog.FillDBCatalog();
#endif

                CatalogType.MakeList();
                Category.MakeList();
                CatalogPeriod.MakeList();
                Catalog.MakeList();
            }
            else
            {
                MessageBox.Show("Невозможно установить соединение с базой данных" + Environment.NewLine +
                                "Проверьте строку подключения (connectionString) к вашему MS SQL Server" + Environment.NewLine +
                                "в файле \""+ System.Reflection.Assembly.GetExecutingAssembly().Location + ".config\"", "Ошибка соединения");
                Environment.Exit(2);
            }


            // заполняем грид при загрузке всеми продуктами
            dgvMain.DataSource = SkladBase.SearchProdByCode(tbCode.Text);

            dgvMain.SelectionChanged += new System.EventHandler(dgvMain_SelectionChanged);

            // если грид заполнен, получаем код первого продукта и заполняем грид Details
            if (dgvMain.CurrentRow != null)
            {
                currentCode = dgvMain.CurrentRow.Cells["Code"].Value.ToString();
                dgvDetails.DataSource = SkladBase.FilldgvDetails(currentCode);
            }

            tbCode.Select();

        }

        // обновляем грид после ввода каждого символа
        private void tbCode_TextChanged(object sender, EventArgs e)
        {
            int input;
            if ((tbCode.Text.Length >= 4 && int.TryParse(tbCode.Text, out input) && input >= 1000) | tbNames.Text.Length > 0) btnSearch.Enabled = true;//btnSearch.Visible != true && 
            else btnSearch.Enabled = false;

            DataTable res = SkladBase.SearchProdByCode(tbCode.Text);
            dgvMain.DataSource = res; //заполняем грид

            if (res.Rows.Count == 0) // если после поиска введенного кода выборка пуста, очищаем грид Details
            {
                DataTable dt = dgvDetails.DataSource as DataTable;
                if (dt != null) dt.Clear();
            }
        }

        private void tbNames_TextChanged(object sender, EventArgs e)
        {
            if (tbNames.Text.Length > 0 || tbCode.Text.Length >= 4) btnSearch.Enabled = true;
            else btnSearch.Enabled = false;

            DataTable res = SkladBase.SearchProdByName(tbNames.Text);
            dgvMain.DataSource = res; //заполняем грид

            if (res.Rows.Count == 0) // если после поиска введенного кода выборка пуста, очищаем грид Details
            {
                DataTable dt = dgvDetails.DataSource as DataTable;
                if (dt != null) dt.Clear();
            }
        }

        // отрабатывает изменения выделения в основном гриде (мышью или клавишами)
        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null)
                currentCode = dgvMain.CurrentRow.Cells["Code"].Value.ToString();

            dgvDetails.DataSource = SkladBase.FilldgvDetails(currentCode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd = new FrmAdd(tbCode.Text, tbNames.Text);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                dgvMain.DataSource = SkladBase.SearchProdByCode("");
            }
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            FrmAbout aboutBox = new FrmAbout();
            aboutBox.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                TopMost = true;
                tsmAlwaysOnTop.Checked = true;
                picboxOnTopOFF.Visible = false;
                picboxOnTopON.Visible = true;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (TopMost == true)
            {
                TopMost = false;
                tsmAlwaysOnTop.Checked = false;
                picboxOnTopON.Visible = false;
                picboxOnTopOFF.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbCode.Text.Length < 4 & btnSearch.Visible)
                searchResult = new FrmSearchResult(tbNames.Text, SearchBy.Name);
            else
                searchResult = new FrmSearchResult(tbCode.Text, SearchBy.Code);

            if (searchResult.ShowDialog() == DialogResult.Yes)
            {
                frmAdd = new FrmAdd(searchResult.SelectedCode, searchResult.SelectedName, searchResult.SelectedPriceDC, searchResult.SelectedPricePC, searchResult.SelectedDiscont, searchResult.SelectedPeriodText, searchResult.selectedPeriod, searchResult.selectedYear);
                frmAdd.ShowDialog();
            }
            dgvMain.DataSource = SkladBase.SearchProdByName("");
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        // обрабатываем нажатие на +/- в грид Detail
        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // если грид Detail пуст, не обрабатывать нажатие на кнопку +/-, т.к. генерируется исключение
            if (((sender as DataGridView).DataSource as DataTable) == null || ((sender as DataGridView).DataSource as DataTable).Rows.Count == 0)
                return;

            if (e.RowIndex == -1) return;

            int quant = (int)dgvDetails.Rows[e.RowIndex].Cells["Quant"].Value; //текущ. знач. Quantity
            int code = (int)dgvDetails.Rows[e.RowIndex].Cells["CodeDetails"].Value; //текущ. зна. code
            decimal pc = (decimal)dgvDetails.Rows[e.RowIndex].Cells["PC"].Value;
            decimal dc = (decimal)dgvDetails.Rows[e.RowIndex].Cells["DC"].Value;
            bool discont = (bool)dgvDetails.Rows[e.RowIndex].Cells["Disc"].Value;


            switch (e.ColumnIndex)
            {
                case 0:  // если нажали на кнопку "-1"
                    if (quant > 1)
                    {
                        SkladBase.UpDownQtyPrice(code, quant, dc, pc, discont, UpDownOperation.Down); // вызываем метод уменьшения кол-ва продукта в DB

                        // Обновляем кол-во в ячейках обоих гридов
                        dgvMain.SelectedRows[0].Cells["Quantity"].Value = (int)dgvMain.SelectedRows[0].Cells["Quantity"].Value - 1;// = Total quant - 1;
                        dgvDetails.Rows[e.RowIndex].Cells["Quant"].Value = (int)dgvDetails.Rows[e.RowIndex].Cells["Quant"].Value - 1;// = Total quant - 1;
                    }
                    break;

                case 1:  // если нажали на кнопку "+1"
                    SkladBase.UpDownQtyPrice(code, quant, dc, pc, discont, UpDownOperation.Up); // вызываем метод уменьшения кол-ва продукта в DB

                    dgvMain.SelectedRows[0].Cells["Quantity"].Value = (int)dgvMain.SelectedRows[0].Cells["Quantity"].Value + 1;// = Total quant + 1;
                    dgvDetails.Rows[e.RowIndex].Cells["Quant"].Value = (int)dgvDetails.Rows[e.RowIndex].Cells["Quant"].Value + 1;// = Total quant + 1;
                    break;

                case 2: // если нажали "Х" во грид Detail
                    DeleteProdFromPrice(code, quant, dc, pc, discont, e.RowIndex);
                    break;
            }
        }

        private void DeleteProdFromPrice(int code, int quant, decimal dc, decimal pc, bool discont, int rowIndex)
        {
            SkladBase.DeleteProdFromPrice(code, quant, dc, pc, discont);

            dgvDetails.Rows.RemoveAt(rowIndex); //удаляем строку из грид Detail

            // Корректируем кол-во в основном гриде
            if (dgvDetails.Rows.Count > 0)
            {
                dgvMain.SelectedRows[0].Cells["Quantity"].Value = (int)dgvMain.SelectedRows[0].Cells["Quantity"].Value - quant;
            }
            else
            {
                SkladBase.DeleteProdFromProductTable(code); // удаляем продукт из табл Product

                dgvMain.Rows.Remove(dgvMain.CurrentRow);

                if (dgvMain.RowCount > 0)
                    dgvMain.CurrentRow.Selected = true;
            }
        }

        // Обрабатываем нажатие кнопки 'X' в гриде
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            SkladBase.DeleteProdFromPrice(Int32.Parse(currentCode));
            SkladBase.DeleteProdFromProductTable(Int32.Parse(currentCode));

            dgvMain.Rows.Remove(dgvMain.CurrentRow);
            if (dgvMain.RowCount > 0)
                dgvMain.CurrentRow.Selected = true;
        }


        private void tsmOptions_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();

            if (frmSettings.ShowDialog() == DialogResult.OK)
            {
                Settings.FolderPrices = frmSettings.tbFolderPrices.Text;
                Settings.Discount = int.Parse(frmSettings.tbDiscont.Text);
                Settings.DisplayCatalogPeriodsWithZero = frmSettings.chbAddZero.Checked;

                //TODO: Реализоавть
                Settings.SaveSettings();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                TopMost = true;
                picboxOnTopOFF.Visible = false;
                picboxOnTopON.Visible = true;
            }
            else
            {
                TopMost = false;
                picboxOnTopOFF.Visible = true;
                picboxOnTopON.Visible = false;
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmExport_Click(object sender, EventArgs e)
        {
            savefdExport.Filter = "Excel (*.xlsx)|*.xlsx";
            savefdExport.DefaultExt = "xlsx";
            savefdExport.FileName = "SkladOriflame_BackUp_" + DateTime.Now.Date.ToString("yyyy_MM_dd") + ".xlsx";
            //savefdExport.InitialDirectory = Environment.CurrentDirectory;
            if (savefdExport.ShowDialog() == DialogResult.OK && savefdExport.FileName.Length > 0)
            {
                ImportExport.Export(savefdExport.FileName);
            }
        }

        private void tsmImport_Click(object sender, EventArgs e)
        {
            openfdImport.Filter = "Excel (*.xlsx)|*.xlsx";
            openfdImport.DefaultExt = "xlsx";
            if (openfdImport.ShowDialog() == DialogResult.OK && File.Exists(openfdImport.FileName))
            {
                ImportExport.Import(openfdImport.FileName);

                CatalogType.MakeList();
                Category.MakeList();
                CatalogPeriod.MakeList();
                Catalog.MakeList();
                dgvMain.DataSource = SkladBase.SearchProdByCode(tbCode.Text);


            }

        }

        private void tsmMenuStatistic_Click(object sender, EventArgs e)
        {
            FrmStatistic frmStaristic = new FrmStatistic();
            frmStaristic.ShowDialog();
        }
    }
}

