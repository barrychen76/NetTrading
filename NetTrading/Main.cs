using NetTrading.Data;
using NetTrading.UI;
using Python.Runtime;
using PyWrapper;
using System.Windows.Forms;

namespace NetTrading
{
    public partial class Main : Form
    {
        MainModel Model { get; set; } = new MainModel();
        BindingSource tradingsBindingSource = null;
        BindingSource subtradingsBindingSource = null;

        public Main()
        {
            InitializeComponent();

            //Model.Buy("格力电器", "000651", 30.3, 1000, AccountType.AT_Mine, "铁牛策略", "abc");
            //Model.SaveTradings();

            Model.Init();

            tradingsBindingSource = new BindingSource();
            tradingsBindingSource.DataSource = Model.Tradings;

            //subtradingsBindingSource = new BindingSource();
            dgvTradings.DataSource = tradingsBindingSource;

            Model.SetMessageHandler(ShowMessage);
            Model.SetPriceReceivedHandler(PriceReceivedHandler);
            Model.StartBkMonitor();

            dgvTradings.CellValueChanged += DgvTradings_CellValueChanged;
        }

        private void DgvTradings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dg = sender as DataGridView;

                DataGridViewRow row = dg.Rows[e.RowIndex];

                String columnName = dg.Columns[e.ColumnIndex].Name;

                var dataObject = row.DataBoundItem as Trading;

                if (dataObject != null)
                {
                    object objValue = row.Cells[e.ColumnIndex].Value;


                }
            }
            //dgvTradings.
            //e.RowIndex
            //throw new NotImplementedException();
        }


        private void tbBuy_Click(object sender, EventArgs e)
        {
            if (dgvTradings.SelectedRows.Count < 0)
                return;

            bool selected_one = dgvTradings.SelectedRows.Count == 1;

            if (dgvTradings.SelectedRows.Count > 0)
            {
                if (!selected_one)
                {
                    MessageBox.Show("添加记录时，只能选中一条父订单。");
                    return;
                }
            }

            Trading trading = new Trading();
            if (selected_one)
            {
                var vv = dgvTradings.SelectedRows[0].Cells;
                String name = vv["Name"].Value.ToString();
                trading = Model.Tradings.Find(x => x.Name == name);

                //trading = dgvTradings.SelectedRows[0].Tag as Trading;
            }

            DlgBuy dlg = new DlgBuy();
            //dlg.Trading = trading;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Model.Buy(dlg.StockName, dlg.Code, dlg.Price, dlg.Count, dlg.AccountType, dlg.PolicyName, dlg.DTBuy, dlg.Comment);

                tradingsBindingSource.ResetBindings(false);
                subtradingsBindingSource.ResetBindings(false);
                if (selected_one)
                {
                    //BindingSource bindingSource = new BindingSource();
                    //bindingSource.DataSource = trading.SubTradings;

                    //dgvSubTradings.DataSource = bindingSource;
                }
                else
                {
                    //BindingSource bindingSource = new BindingSource();
                    //bindingSource.DataSource = Model.Tradings;

                    //dgvTradings.DataSource = bindingSource;
                }

            }
        }

        private void tbSell_Click(object sender, EventArgs e)
        {
            if (dgvSubTradings.SelectedRows.Count != 1)
                return;


            var vv = dgvTradings.SelectedRows[0].Cells;
            String name = vv["Name"].Value.ToString();
            Trading trading = Model.Tradings.Find(x => x.Name == name);

            vv = dgvSubTradings.SelectedRows[0].Cells;
            int id = int.Parse(vv["Id"].Value.ToString());

            SubTrading subTrading = trading.SubTradings.Find(x => x.Id == id);

            DlgSell dlg = new DlgSell(trading.Name, trading.Code, subTrading.BuyCount);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                double price = dlg.SellPrice;
                int count = dlg.SellCount;
                String comment = dlg.Comment;

                Model.Sell(trading.Name, subTrading.Id, price, count, comment);

                tradingsBindingSource.ResetBindings(false);
                subtradingsBindingSource.ResetBindings(false);
            }
        }

        private void dgvTradings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTradings.SelectedRows.Count != 1)
                return;

            var vv = dgvTradings.SelectedRows[0].Cells;
            String name = vv["Name"].Value.ToString();
            //String name = dgvTradings.SelectedRows[0].Cells["Name"].Value.ToString();

            Trading selectedTrading = Model.Tradings.Find(x => x.Name == name);

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = selectedTrading.SubTradings;

            if (subtradingsBindingSource == null)
            {
                subtradingsBindingSource = new BindingSource();
                subtradingsBindingSource.DataSource = selectedTrading.SubTradings;

                dgvSubTradings.DataSource = subtradingsBindingSource;
            }
            else
            {
                subtradingsBindingSource.DataSource = selectedTrading.SubTradings;
                dgvSubTradings.DataSource = subtradingsBindingSource;
                //subtradingsBindingSource?.ResetBindings(false);
            }
        }

        private void dgvSubTradings_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void ShowMessage(String message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<String>(ShowMessage), message);
            }
            else
            {
                try
                {
                    String msg = String.Format("{0} -- {1}", DateTime.Now.ToString("F"), message);

                    tbMessages.Text += "\r\n" + msg;
                    tslMessage.Text = msg;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                }
            }
        }

        public void PriceReceivedHandler(List<RT_Code_Price> lsPrices)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<RT_Code_Price>>(PriceReceivedHandler), lsPrices);
            }
            else
            {
                try
                {
                    foreach (RT_Code_Price item in lsPrices)
                    {
                        String code = item.Code.Substring(0, 6);
                        double price = item.Price;

                        Trading? trading = Model.Tradings.Find(x => x.Code == code);

                        if (trading != null)
                        {
                            trading.CurrentPrice = price;
                            //trading.priceReceived(item);
                        }
                    }

                    tradingsBindingSource.ResetBindings(false);
                    subtradingsBindingSource.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Model.Exit();
        }
    }
}