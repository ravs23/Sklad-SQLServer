using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    public partial class FrmSearchResult : Form
    {
        public string SelectedCode { get; set; }
        public string SelectedName { get; set; }
        public string SelectedPriceDC { get; set; }
        public string SelectedPricePC { get; set; }
        public bool SelectedDiscont { get; set; }
        public int selectedPeriod;
        public int selectedYear;
        public string SelectedPeriodText
        {
            get
            {
                return SkladBase.ConvertPeriodToText(selectedPeriod, selectedYear);
              
            }
}

public FrmSearchResult()
        {
            InitializeComponent();
        }

        public FrmSearchResult(string fieldSearch, SearchBy searchBy) : this()
        {
            dgvDB.DataSource = SkladBase.SearchForAdd(fieldSearch, searchBy);
            dgvPrice.DataSource = ExcelSearch.Search(fieldSearch, searchBy);

            this.Text += string.Format($"  ({fieldSearch})");

            gbBD.Text += "  (" + (dgvDB.DataSource as DataTable).Rows.Count.ToString() + ")";
            gbPrices.Text += "  (" + (dgvPrice.DataSource as DataTable).Rows.Count.ToString() + ")";
        }

        private void SetPeriod(string period, out int periodSelected, out int yearSelected)
        {
            if (period.Length == 9)
            {
                string _period = period.Substring(7, 2);
                string _year = period.Substring(0, 4);

                if (!int.TryParse(_period, out periodSelected))
                    periodSelected = 0;
                if (!int.TryParse(_year, out yearSelected))
                    yearSelected = 0;
            }
            else
            {
                periodSelected = 0;
                yearSelected = 0;
            }
        }

        // Определяем есть ли пометка "скидка" у товара.
        private bool GetDiscont(DataGridView dgv)
        {
            if (dgv.CurrentRow.Cells[4].ValueType == typeof(bool))
                return Convert.ToBoolean(dgv.CurrentRow.Cells[4].Value);
            else
            {
                string cel_val = dgv.CurrentRow.Cells[4].Value.ToString().ToLower();
                if (cel_val.Contains("с") || cel_val.Contains("з"))
                    return true;
                else return false;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1) return; //если нажали на заголовок
            DataGridView dgv = sender as DataGridView;

            SelectedCode = dgv.CurrentRow.Cells[0].Value.ToString();
            SelectedName = dgv.CurrentRow.Cells[1].Value.ToString();
            SelectedPriceDC = Convert.ToDouble(dgv.CurrentRow.Cells[2].Value).ToString();
            SelectedPricePC = Convert.ToDouble(dgv.CurrentRow.Cells[3].Value).ToString();
            SelectedDiscont = GetDiscont(dgv);
            //SelectedPeriodText = dgv.CurrentRow.Cells[5].Value.ToString();
            SetPeriod(dgv.CurrentRow.Cells[5].Value.ToString(), out selectedPeriod, out selectedYear);

            this.DialogResult = DialogResult.Yes;
        }
    }
}
