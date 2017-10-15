using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    public partial class FrmAdd : Form
    {
        FrmSearchResult searchResult;
        FrmAddPeriod frmAddPeriod;

        public FrmAdd()
        {
            InitializeComponent();

            cbTypeCatalog.DataSource = CatalogType.catalogType;

            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            cbCategory.DataSource = Category.category;

            cbCatalog.DisplayMember = "CatalogPeriodText";
            cbCatalog.ValueMember = "PeriodId";
            cbCatalog.DataSource = CatalogPeriod.catalogPeriod;

        }

        public FrmAdd(string code, string name) : this()
        {
            tbCode.Text = code;
            tbNames.Text = name;
        }

        public FrmAdd(string code, string name, string priceDC, string pricePC, bool discont, string periodText, int period, int year) : this()
        {
            tbCode.Text = code;
            tbNames.Text = name;
            tbPriceDC.Text = priceDC;
            tbPricePC.Text = pricePC;
            cbDiscont.Checked = discont;

            // Устанавливаем в ComboBox с периодами каталога выбранное значение. Если такового нет в БД - добавляем
            if (CatalogPeriod.SearchSuchCatalog(periodText))
                cbCatalog.Text = periodText;
            else
            {
                // добавляем каталожный период в БД (без проверки на его существование)
                SkladBase.AddCatalogPeriod(period, year);

                cbCatalog.DataSource = CatalogPeriod.catalogPeriod;
                cbCatalog.Text = periodText;
            }
        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {
            int input;
            if ((tbCode.Text.Length >= 4 && int.TryParse(tbCode.Text, out input) && input >= 1000) | tbNames.Text.Length > 0) btnSearch.Enabled = true;//btnSearch.Visible != true && 
            else btnSearch.Enabled = false;//btnSearch.Visible == true && 
        }

        private void tbNames_TextChanged(object sender, EventArgs e)
        {
            if (tbNames.Text.Length > 0 || tbCode.Text.Length >= 4) btnSearch.Enabled = true;
            else btnSearch.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbCode.Text.Length < 4 & btnSearch.Visible)
                searchResult = new FrmSearchResult(tbNames.Text, SearchBy.Name);
            else
                searchResult = new FrmSearchResult(tbCode.Text, SearchBy.Code);

            if (searchResult.ShowDialog() == DialogResult.Yes)
            {
                tbCode.Text = searchResult.SelectedCode;
                tbNames.Text = searchResult.SelectedName;
                tbPriceDC.Text = searchResult.SelectedPriceDC;
                tbPricePC.Text = searchResult.SelectedPricePC;
                cbDiscont.Checked = searchResult.SelectedDiscont;

                // Устанавливаем в ComboBox с периодами каталога выбранное значение. Если такового нет в БД - добавляем
                if (CatalogPeriod.SearchSuchCatalog(searchResult.SelectedPeriodText))
                    cbCatalog.Text = searchResult.SelectedPeriodText;
                else
                {
                    // добавляем каталожный период в БД (без проверки на его существование)
                    SkladBase.AddCatalogPeriod(searchResult.selectedPeriod, searchResult.selectedYear);

                    cbCatalog.DataSource = CatalogPeriod.catalogPeriod;
                    cbCatalog.Text = searchResult.SelectedPeriodText;
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInputData()) // Проверяем введенные данные в форме
            {
                // Проверяем есть ли такой период и тип в БД.Если есть, получаем id(табл Catalog), если нет - создаём и получаем id
                int catalogId = SkladBase.AddCatalog((int)cbCatalog.SelectedValue, cbTypeCatalog.SelectedIndex + 1);

                // Проверяем есть ли такой продукт в БД. Если есть, получаем id (табл Product), если нет - создаём и получаем id
                SkladBase.AddProduct(tbCode.Text, tbNames.Text, (int)cbCategory.SelectedValue);

                // проверяем наличие такого продукта в БД.
                int quantityInBD;
                int idProductInPrice = SkladBase.CheckExistProductFull(out quantityInBD, tbCode.Text, Convert.ToDecimal(tbPricePC.Text), Convert.ToDecimal(tbPriceDC.Text), catalogId, cbDiscont.Checked);
                if (0 == idProductInPrice) // если нет, то добавляем
                    SkladBase.AddProductToPrice(tbCode.Text, Convert.ToDecimal(tbPricePC.Text), Convert.ToDecimal(tbPriceDC.Text), catalogId, (int)numQuantity.Value, cbDiscont.Checked, tbDescription.Text);
                else // если есть, добавляем количество
                    SkladBase.UpdateProductQuantInPrice(idProductInPrice, quantityInBD + (int)numQuantity.Value);
                
                this.DialogResult = DialogResult.OK;
            }

            ///проверяем все поля на валидность
            ///проверяем на существование каталога (период+тип) табл Catalog
            ///если есть, берем id
            ///если нет - создаём, берём id созданного
            ///обновляем коллекцию catalog
            ///проверяем на существование такого продукта в табл Product, берем его id
            ///если нет - то создаём, берем id
            ///
            ///создаём продукт в прайсе
            ///устанавливаем dialogresult = OK;
            /// 
            /// в frmMain
            ///обновляем колекцию и датагриды
            ///
            ///

        }

        private void btAddCategory_Click(object sender, EventArgs e)
        {
            foreach (CategoryOne item in Category.category)
            {
                if (item.Name.ToLower().Trim() == (cbCategory.Text.ToLower().Trim()))
                {
                    MessageBox.Show($"Категория \"{cbCategory.Text}\" уже существует." + Environment.NewLine + Environment.NewLine +
                                "Введите новую категорию.", "Ошибка");
                    return;
                }
            }

            if (string.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Введите новую категорию.", "Ошибка");
                return;
            }

            if (cbCategory.Text.Length > 25)
            {
                MessageBox.Show("До 25 символов", "Ошибка");
                return;
            }

            SkladBase.AddCategory(cbCategory.Text.Trim());
            MessageBox.Show($"Категория \"{cbCategory.Text.Trim()}\" добавлена", "Добавлено");

            string categoryAdded = cbCategory.Text.Trim();
            Category.MakeList();
            cbCategory.DataSource = Category.category;
            cbCategory.Text = categoryAdded;

        }

        private void btnAddCatalog_Click(object sender, EventArgs e)
        {
            frmAddPeriod = new FrmAddPeriod();
            DialogResult dRes = frmAddPeriod.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                // добавляем каталожный период в БД (без проверки на его существование)
                SkladBase.AddCatalogPeriod(frmAddPeriod.Period, frmAddPeriod.Year);

                cbCatalog.DataSource = CatalogPeriod.catalogPeriod;
                cbCatalog.Text = frmAddPeriod.InputedPeriodText;
            }
        }



        private void tbPricePC_Leave(object sender, EventArgs e)
        {
            tbPricePC.Text = tbPricePC.Text.Replace('.', ',');
            if (tbPricePC.Text.Length != 0 & tbPriceDC.Text.Length == 0)
            {
                double pc;
                if (double.TryParse(tbPricePC.Text, out pc))
                {
                    tbPriceDC.Text = (pc * (1 - (Settings.Discount / 100d))).ToString();
                }
            }
        }

        private void tbPriceDC_Leave(object sender, EventArgs e)
        {
            tbPriceDC.Text = tbPriceDC.Text.Replace('.', ',');
            if (tbPriceDC.Text.Length != 0 && tbPricePC.Text.Length == 0)
            {
                double dc;
                if (double.TryParse(tbPriceDC.Text, out dc))
                {
                    tbPricePC.Text = (dc * (100d / (100d - Settings.Discount))).ToString();
                }
            }
        }

        bool CheckInputData()
        {
            // проверяем поле Код
            if (tbCode.Text.Length < 4 || tbCode.Text.Length > 6)
            {
                this.lbCode.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            int n;
            if (!int.TryParse(tbCode.Text, out n) & n >= 1000)
            {
                this.lbCode.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Проверяем поле Название
            if (tbNames.Text.Length == 0 || tbNames.Text.Length > 80)
            {
                this.lbNames.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Проверяем, внесен ли хоть один период
            if (CatalogPeriod.catalogPeriod.Count == 0)
            {
                this.lbCatalog.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Проверяем выбрана ли категория товара
            if (cbCategory.SelectedValue == null)
            {
                this.lbCategory.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Проверяем ПЦ и ДЦ
            double price;
            if (!double.TryParse(tbPricePC.Text, out price))
            {
                this.lbPricePC.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!double.TryParse(tbPriceDC.Text, out price))
            {
                this.lbPriceDC.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Проверяем поле Описание
            if (tbDescription.Text.Length > 190)
            {
                this.lbDescription.ForeColor = System.Drawing.Color.Magenta;
                return false;
            }

            // Всё ОК
            return true;
        }

        private void tbCode_Enter(object sender, EventArgs e)
        {
            this.lbCode.ForeColor = SystemColors.ControlText;
        }

        private void tbNames_Enter(object sender, EventArgs e)
        {
            this.lbNames.ForeColor = SystemColors.ControlText;
        }

        private void cbCategory_Enter(object sender, EventArgs e)
        {
            this.lbCategory.ForeColor = SystemColors.ControlText;
        }

        private void tbPricePC_Enter(object sender, EventArgs e)
        {
            this.lbPricePC.ForeColor = SystemColors.ControlText;
        }

        private void tbPriceDC_Enter(object sender, EventArgs e)
        {
            this.lbPriceDC.ForeColor = SystemColors.ControlText;
        }

        private void cbCatalog_Enter(object sender, EventArgs e)
        {
            this.lbCatalog.ForeColor = SystemColors.ControlText;
        }

        private void tbDescription_Enter(object sender, EventArgs e)
        {
            this.lbDescription.ForeColor = SystemColors.ControlText;

        }

        private void tbDescription_KeyUp(object sender, KeyEventArgs e)
        {
            ShowDescriptionCount();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            ShowDescriptionCount();
        }

        void ShowDescriptionCount() // отображаем счетчик символов в поле Описание
        {
            if (tbDescription.Text.Length < 190)
                this.lbDescriptionCount.ForeColor = SystemColors.ControlText;
            if (tbDescription.Text.Length >= 190 & tbDescription.Text.Length < 200)
                this.lbDescriptionCount.ForeColor = System.Drawing.Color.Magenta;
            if (tbDescription.Text.Length >= 200)
                this.lbDescriptionCount.ForeColor = System.Drawing.Color.Red;

            lbDescriptionCount.Text = $"[{tbDescription.Text.Length}/200]";
        }

    }
}
