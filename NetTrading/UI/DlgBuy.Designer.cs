namespace NetTrading.UI
{
    partial class DlgBuy
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
            label1 = new Label();
            tbName = new TextBox();
            tbPrice = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbCode = new TextBox();
            label5 = new Label();
            tbCount = new TextBox();
            label6 = new Label();
            tbAmount = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbComment = new TextBox();
            btnBuy = new Button();
            cbAccount = new ComboBox();
            cbPolicy = new ComboBox();
            cbTargetPercent = new ComboBox();
            dtBuy = new DateTimePicker();
            label10 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 38);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "股票名：";
            // 
            // tbName
            // 
            tbName.Location = new Point(138, 36);
            tbName.Margin = new Padding(2, 3, 2, 3);
            tbName.Name = "tbName";
            tbName.Size = new Size(142, 23);
            tbName.TabIndex = 1;
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(138, 231);
            tbPrice.Margin = new Padding(2, 3, 2, 3);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(142, 23);
            tbPrice.TabIndex = 5;
            tbPrice.TextChanged += tbPrice_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 233);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 2;
            label2.Text = "买入价格：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 162);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 4;
            label3.Text = "买入策略：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 122);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 6;
            label4.Text = "买入账户：";
            // 
            // tbCode
            // 
            tbCode.Location = new Point(138, 77);
            tbCode.Margin = new Padding(2, 3, 2, 3);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(142, 23);
            tbCode.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 80);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 8;
            label5.Text = "股票代码：";
            // 
            // tbCount
            // 
            tbCount.Location = new Point(138, 273);
            tbCount.Margin = new Padding(2, 3, 2, 3);
            tbCount.Name = "tbCount";
            tbCount.Size = new Size(142, 23);
            tbCount.TabIndex = 6;
            tbCount.TextChanged += tbCount_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 276);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 10;
            label6.Text = "买入数量：";
            // 
            // tbAmount
            // 
            tbAmount.Location = new Point(138, 311);
            tbAmount.Margin = new Padding(2, 3, 2, 3);
            tbAmount.Name = "tbAmount";
            tbAmount.Size = new Size(142, 23);
            tbAmount.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 314);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(44, 17);
            label7.TabIndex = 12;
            label7.Text = "金额：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 352);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(104, 17);
            label8.TabIndex = 14;
            label8.Text = "第一目标百分比：";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 395);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(68, 17);
            label9.TabIndex = 16;
            label9.Text = "详细描述：";
            // 
            // tbComment
            // 
            tbComment.Location = new Point(33, 414);
            tbComment.Margin = new Padding(2, 3, 2, 3);
            tbComment.Multiline = true;
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(247, 114);
            tbComment.TabIndex = 9;
            // 
            // btnBuy
            // 
            btnBuy.DialogResult = DialogResult.OK;
            btnBuy.Location = new Point(206, 546);
            btnBuy.Margin = new Padding(2, 3, 2, 3);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(73, 25);
            btnBuy.TabIndex = 10;
            btnBuy.Text = "买入";
            btnBuy.UseVisualStyleBackColor = true;
            btnBuy.Click += btnBuy_Click;
            // 
            // cbAccount
            // 
            cbAccount.FormattingEnabled = true;
            cbAccount.Location = new Point(138, 119);
            cbAccount.Margin = new Padding(2, 3, 2, 3);
            cbAccount.Name = "cbAccount";
            cbAccount.Size = new Size(142, 25);
            cbAccount.TabIndex = 3;
            // 
            // cbPolicy
            // 
            cbPolicy.Enabled = false;
            cbPolicy.FormattingEnabled = true;
            cbPolicy.Location = new Point(138, 159);
            cbPolicy.Margin = new Padding(2, 3, 2, 3);
            cbPolicy.Name = "cbPolicy";
            cbPolicy.Size = new Size(142, 25);
            cbPolicy.TabIndex = 4;
            // 
            // cbTargetPercent
            // 
            cbTargetPercent.Enabled = false;
            cbTargetPercent.FormattingEnabled = true;
            cbTargetPercent.Location = new Point(138, 350);
            cbTargetPercent.Margin = new Padding(2, 3, 2, 3);
            cbTargetPercent.Name = "cbTargetPercent";
            cbTargetPercent.Size = new Size(142, 25);
            cbTargetPercent.TabIndex = 8;
            // 
            // dtBuy
            // 
            dtBuy.Location = new Point(138, 197);
            dtBuy.Name = "dtBuy";
            dtBuy.Size = new Size(141, 23);
            dtBuy.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(33, 203);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(68, 17);
            label10.TabIndex = 18;
            label10.Text = "买入日期：";
            // 
            // DlgBuy
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 583);
            Controls.Add(label10);
            Controls.Add(dtBuy);
            Controls.Add(cbTargetPercent);
            Controls.Add(cbPolicy);
            Controls.Add(cbAccount);
            Controls.Add(btnBuy);
            Controls.Add(tbComment);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tbAmount);
            Controls.Add(label7);
            Controls.Add(tbCount);
            Controls.Add(label6);
            Controls.Add(tbCode);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbPrice);
            Controls.Add(label2);
            Controls.Add(tbName);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "DlgBuy";
            Text = "买入";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private TextBox tbPrice;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbCode;
        private Label label5;
        private TextBox tbCount;
        private Label label6;
        private TextBox tbAmount;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbComment;
        private Button btnBuy;
        private ComboBox cbAccount;
        private ComboBox cbPolicy;
        private ComboBox cbTargetPercent;
        private DateTimePicker dtBuy;
        private Label label10;
    }
}