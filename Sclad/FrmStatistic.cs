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
    public partial class FrmStatistic : Form
    {
        List<string> catalogTypeStatistic;
        List<CategoryOne> categoryStatistic;
        string[] ResultTotal;
        string[] ResultSelect;
        Label[] lblTotal;
        Label[] lblSelect;

        public FrmStatistic()
        {
            InitializeComponent();
            lblTotal = new Label[] { lbl1_1, lbl1_2, lbl1_3, lbl1_4, lbl1_5, lbl1_6, lbl1_7 };
            lblSelect = new Label[] { lbl2_1, lbl2_2, lbl2_3, lbl2_4, lbl2_5, lbl2_6, lbl2_7 };
        }

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            for(int i=0; i < lblTotal.Length; i++)
            {
                lblTotal[i].Text = string.Empty;
                lblSelect[i].Text = string.Empty;
            }

            catalogTypeStatistic = new List<string>(CatalogType.catalogType);
            catalogTypeStatistic.Insert(0, "");
            cbTypeCatalog.DataSource = catalogTypeStatistic;

            categoryStatistic = new List<CategoryOne>(Category.category);
            CategoryOne empty = new CategoryOne() { Id = 0, Name = "" };
            categoryStatistic.Insert(0, empty);

            cbCategory.DataSource = categoryStatistic;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";

            ResultTotal = Statistic.GetStatistic();
            for (int i = 0; i < lblTotal.Length; i++)
                lblTotal[i].Text = ResultTotal[i];
        }

        private void comboboxes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTypeCatalog.SelectedIndex < 0)
                cbTypeCatalog.SelectedIndex = 0;
            if (cbCategory.SelectedValue == null)
                cbCategory.SelectedValue = 0;

            ResultSelect = Statistic.GetStatistic(cbTypeCatalog.SelectedIndex, (int)cbCategory.SelectedValue,this);

            for(int i=0; i < ResultSelect.Length; i++)
            {
                lblSelect[i].Text = ResultSelect[i];
            }
        }
    }
}
