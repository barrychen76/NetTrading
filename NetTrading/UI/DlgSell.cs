using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NetTrading.UI
{
    public partial class DlgSell : Form
    {
        public String StockName { get; set; }
        public String StockCode { get; set; } = String.Empty;
        public String ParentID { get; set; }
        public double SellPrice { get; set; }
        public int SellCount { get; set; }
        public DateTime DTSell { get; set; }
        public String Comment { get; set; }

        private int _maxCount;

        public DlgSell(String name, String code, int maxCount)
        {
            StockName = name;
            StockCode = code;
            _maxCount = maxCount;

            InitializeComponent();

            tbName.Text = name;
            tbCode.Text = code;
            dtSell.Value = DateTime.Now;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            SellPrice = double.Parse(tbPrice.Text);
            SellCount = int.Parse(tbCount.Text);
            DTSell = dtSell.Value;
            Comment = tbComment.Text;
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCount.Text))
            {
                tbAmount.Text = CalcAmount();
            }
        }

        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbPrice.Text))
            {
                tbAmount.Text = CalcAmount();
            }
        }

        private String CalcAmount()
        {
            float price = 0;
            int count = 0;

            if (float.TryParse(tbPrice.Text, out price) && int.TryParse(tbCount.Text, out count))
            {
                return (price * count).ToString("F2");
            }

            return String.Empty;
        }
    }
}
