using NetTrading.Data;
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
    public partial class DlgBuy : Form
    {
        public String StockName = String.Empty;
        public String Code = String.Empty;
        public Double Price = 0;
        public int Count = 0;
        public Double Ammount = 0;
        public Double Target = 0;
        public DateTime DTBuy = DateTime.Now;
        public String Comment = String.Empty;

        public AccountType AccountType { get; set; }
        public String PolicyName { get; set; }

        public DlgBuy(String name = "", String code = "")
        {
            StockName = name;
            Code = code;

            InitializeComponent();

            cbAccount.Items.Add("我的");
            cbAccount.Items.Add("老婆");
            cbAccount.Items.Add("爸爸");
            cbAccount.Items.Add("妈妈");
            cbAccount.Items.Add("海妈");
            cbAccount.SelectedIndex = 0;

            cbPolicy.Items.Add("神奇公式");
            cbPolicy.Items.Add("铁牛策略");
            cbPolicy.Items.Add("大妈买菜策略");
            cbPolicy.Items.Add("买菜区间");
            cbPolicy.SelectedIndex = 0;

            cbTargetPercent.Items.Add("0.05");
            cbTargetPercent.Items.Add("0.1");
            cbTargetPercent.Items.Add("0.15");
            cbTargetPercent.Items.Add("0.2");
            cbTargetPercent.SelectedIndex = 0;

            dtBuy.Value = DateTime.Now;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            StockName = tbName.Text;
            Code = tbCode.Text;
            PolicyName = cbPolicy.Text;
            Price = Convert.ToDouble(tbPrice.Text);
            Count = Convert.ToInt32(tbCount.Text);
            DTBuy = dtBuy.Value;
            Ammount = Price * Count;
            Comment = tbComment.Text;

            switch (cbTargetPercent.SelectedIndex)
            {
                case 0:
                    Target = 0.05;
                    break;
                case 1:
                    Target = 0.1;
                    break;
                case 2:
                    Target = 0.15;
                    break;
                case 3:
                    Target = 0.2;
                    break;
            }

            switch (cbAccount.SelectedIndex)
            {
                case 0:
                    AccountType = AccountType.AT_Mine;
                    break;
                case 1:
                    AccountType = AccountType.AT_Wife;
                    break;
                case 2:
                    AccountType = AccountType.AT_Father;
                    break;
                case 3:
                    AccountType = AccountType.AT_Mother;
                    break;
                case 4:
                    AccountType = AccountType.AT_HaiMa;
                    break;
            }

            //DialogResult = DialogResult.OK;
            //Close();
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
