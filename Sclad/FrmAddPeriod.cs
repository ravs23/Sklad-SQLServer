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
    public partial class FrmAddPeriod : Form
    {
        public int Period { get; private set; }
        public int Year { get; private set; }
        public string InputedPeriodText
        {
            get
            {
                return SkladBase.ConvertPeriodToText(Period, Year);
            }
        }

        public FrmAddPeriod()
        {
            InitializeComponent();
        }

        private void FrmAddPeriod_Load(object sender, EventArgs e)
        {
            nudYear.Value = DateTime.Now.Year;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbmPeriod.Text) || tbmPeriod.Text == " " || tbmPeriod.Text == "  ")
            {
                lblErrorPeriodExist.Visible = false;
                lblError.Visible = true;
                return;
            }

            Period = Int32.Parse(tbmPeriod.Text);
            Year = (int)nudYear.Value;

            if (CatalogPeriod.SearchSuchCatalog(InputedPeriodText))
            {
                lblErrorPeriodExist.Text = string.Format($"Период \"{InputedPeriodText}\" существует !");
                lblError.Visible = false;
                lblErrorPeriodExist.Visible = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        //private bool SearchSuchCatalog(string periodTEXT)
        //{
        //    foreach (CatalogPeriodOne item in CatalogPeriod.catalogPeriod)
        //    {
        //        if (item.CatalogPeriodText == periodTEXT)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
