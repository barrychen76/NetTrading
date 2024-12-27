namespace NetTrading.UI
{
    partial class DlgSell
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
            tbName = new TextBox();
            label1 = new Label();
            tbCode = new TextBox();
            label5 = new Label();
            tbPrice = new TextBox();
            label2 = new Label();
            tbCount = new TextBox();
            label3 = new Label();
            tbAmount = new TextBox();
            label4 = new Label();
            btnSell = new Button();
            tbComment = new TextBox();
            label9 = new Label();
            dtSell = new DateTimePicker();
            label6 = new Label();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(137, 31);
            tbName.Margin = new Padding(2, 3, 2, 3);
            tbName.Name = "tbName";
            tbName.ReadOnly = true;
            tbName.Size = new Size(142, 23);
            tbName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 2;
            label1.Text = "股票名：";
            // 
            // tbCode
            // 
            tbCode.Location = new Point(137, 76);
            tbCode.Margin = new Padding(2, 3, 2, 3);
            tbCode.Name = "tbCode";
            tbCode.ReadOnly = true;
            tbCode.Size = new Size(142, 23);
            tbCode.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 78);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 10;
            label5.Text = "股票代码：";
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(137, 150);
            tbPrice.Margin = new Padding(2, 3, 2, 3);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(142, 23);
            tbPrice.TabIndex = 1;
            tbPrice.TextChanged += tbPrice_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 153);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 12;
            label2.Text = "卖出价格：";
            // 
            // tbCount
            // 
            tbCount.Location = new Point(137, 192);
            tbCount.Margin = new Padding(2, 3, 2, 3);
            tbCount.Name = "tbCount";
            tbCount.Size = new Size(142, 23);
            tbCount.TabIndex = 2;
            tbCount.TextChanged += tbCount_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 195);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 14;
            label3.Text = "卖出数量：";
            // 
            // tbAmount
            // 
            tbAmount.Location = new Point(137, 234);
            tbAmount.Margin = new Padding(2, 3, 2, 3);
            tbAmount.Name = "tbAmount";
            tbAmount.ReadOnly = true;
            tbAmount.Size = new Size(142, 23);
            tbAmount.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 237);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 16;
            label4.Text = "金额：";
            // 
            // btnSell
            // 
            btnSell.DialogResult = DialogResult.OK;
            btnSell.Location = new Point(205, 422);
            btnSell.Margin = new Padding(2, 3, 2, 3);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(73, 25);
            btnSell.TabIndex = 4;
            btnSell.Text = "卖出";
            btnSell.UseVisualStyleBackColor = true;
            btnSell.Click += btnSell_Click;
            // 
            // tbComment
            // 
            tbComment.Location = new Point(32, 291);
            tbComment.Margin = new Padding(2, 3, 2, 3);
            tbComment.Multiline = true;
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(247, 114);
            tbComment.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 271);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(68, 17);
            label9.TabIndex = 19;
            label9.Text = "详细描述：";
            // 
            // dtSell
            // 
            dtSell.Location = new Point(137, 113);
            dtSell.Name = "dtSell";
            dtSell.Size = new Size(142, 23);
            dtSell.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 118);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 21;
            label6.Text = "卖出时间：";
            // 
            // DlgSell
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 438);
            Controls.Add(label6);
            Controls.Add(dtSell);
            Controls.Add(btnSell);
            Controls.Add(tbComment);
            Controls.Add(label9);
            Controls.Add(tbAmount);
            Controls.Add(label4);
            Controls.Add(tbCount);
            Controls.Add(label3);
            Controls.Add(tbPrice);
            Controls.Add(label2);
            Controls.Add(tbCode);
            Controls.Add(label5);
            Controls.Add(tbName);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "DlgSell";
            Text = "DlgSell";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private Label label1;
        private TextBox tbCode;
        private Label label5;
        private TextBox tbPrice;
        private Label label2;
        private TextBox tbCount;
        private Label label3;
        private TextBox tbAmount;
        private Label label4;
        private Button btnSell;
        private TextBox tbComment;
        private Label label9;
        private DateTimePicker dtSell;
        private Label label6;
    }
}