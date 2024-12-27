namespace NetTrading
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            tbBuy = new ToolStripLabel();
            tbSell = new ToolStripLabel();
            scMain = new SplitContainer();
            scLeft = new SplitContainer();
            groupBox1 = new GroupBox();
            dgvTradings = new DataGridView();
            groupBox2 = new GroupBox();
            dgvSubTradings = new DataGridView();
            scRight = new SplitContainer();
            groupBox3 = new GroupBox();
            tbMessages = new TextBox();
            statusStrip1 = new StatusStrip();
            tslMessage = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scLeft).BeginInit();
            scLeft.Panel1.SuspendLayout();
            scLeft.Panel2.SuspendLayout();
            scLeft.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTradings).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubTradings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scRight).BeginInit();
            scRight.Panel2.SuspendLayout();
            scRight.SuspendLayout();
            groupBox3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tbBuy, tbSell });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(940, 37);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tbBuy
            // 
            tbBuy.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            tbBuy.Margin = new Padding(5);
            tbBuy.Name = "tbBuy";
            tbBuy.Size = new Size(52, 27);
            tbBuy.Text = "买入";
            tbBuy.Click += tbBuy_Click;
            // 
            // tbSell
            // 
            tbSell.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            tbSell.Margin = new Padding(5);
            tbSell.Name = "tbSell";
            tbSell.Size = new Size(52, 27);
            tbSell.Text = "卖出";
            tbSell.Click += tbSell_Click;
            // 
            // scMain
            // 
            scMain.BorderStyle = BorderStyle.Fixed3D;
            scMain.Dock = DockStyle.Fill;
            scMain.Location = new Point(0, 37);
            scMain.Margin = new Padding(2, 3, 2, 3);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(scLeft);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(scRight);
            scMain.Size = new Size(940, 529);
            scMain.SplitterDistance = 343;
            scMain.SplitterWidth = 8;
            scMain.TabIndex = 1;
            // 
            // scLeft
            // 
            scLeft.BorderStyle = BorderStyle.Fixed3D;
            scLeft.Dock = DockStyle.Fill;
            scLeft.Location = new Point(0, 0);
            scLeft.Margin = new Padding(2, 3, 2, 3);
            scLeft.Name = "scLeft";
            scLeft.Orientation = Orientation.Horizontal;
            // 
            // scLeft.Panel1
            // 
            scLeft.Panel1.Controls.Add(groupBox1);
            // 
            // scLeft.Panel2
            // 
            scLeft.Panel2.Controls.Add(groupBox2);
            scLeft.Size = new Size(343, 529);
            scLeft.SplitterDistance = 219;
            scLeft.SplitterWidth = 8;
            scLeft.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvTradings);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(339, 215);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "交易订单：";
            // 
            // dgvTradings
            // 
            dgvTradings.AllowUserToAddRows = false;
            dgvTradings.AllowUserToDeleteRows = false;
            dgvTradings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTradings.Dock = DockStyle.Fill;
            dgvTradings.Location = new Point(2, 19);
            dgvTradings.Margin = new Padding(2, 3, 2, 3);
            dgvTradings.MultiSelect = false;
            dgvTradings.Name = "dgvTradings";
            dgvTradings.ReadOnly = true;
            dgvTradings.RowHeadersWidth = 51;
            dgvTradings.RowTemplate.Height = 29;
            dgvTradings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTradings.Size = new Size(335, 193);
            dgvTradings.TabIndex = 0;
            dgvTradings.SelectionChanged += dgvTradings_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvSubTradings);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(339, 298);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "子订单：";
            // 
            // dgvSubTradings
            // 
            dgvSubTradings.AllowUserToAddRows = false;
            dgvSubTradings.AllowUserToDeleteRows = false;
            dgvSubTradings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubTradings.Dock = DockStyle.Fill;
            dgvSubTradings.Location = new Point(2, 19);
            dgvSubTradings.Margin = new Padding(2, 3, 2, 3);
            dgvSubTradings.MultiSelect = false;
            dgvSubTradings.Name = "dgvSubTradings";
            dgvSubTradings.ReadOnly = true;
            dgvSubTradings.RowHeadersWidth = 51;
            dgvSubTradings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubTradings.Size = new Size(335, 276);
            dgvSubTradings.TabIndex = 1;
            // 
            // scRight
            // 
            scRight.BorderStyle = BorderStyle.Fixed3D;
            scRight.Dock = DockStyle.Fill;
            scRight.Location = new Point(0, 0);
            scRight.Margin = new Padding(2, 3, 2, 3);
            scRight.Name = "scRight";
            scRight.Orientation = Orientation.Horizontal;
            // 
            // scRight.Panel2
            // 
            scRight.Panel2.Controls.Add(groupBox3);
            scRight.Size = new Size(589, 529);
            scRight.SplitterDistance = 219;
            scRight.SplitterWidth = 8;
            scRight.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(statusStrip1);
            groupBox3.Controls.Add(tbMessages);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Margin = new Padding(2, 3, 2, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2, 3, 2, 3);
            groupBox3.Size = new Size(585, 298);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "消息：";
            // 
            // tbMessages
            // 
            tbMessages.Dock = DockStyle.Fill;
            tbMessages.Location = new Point(2, 19);
            tbMessages.Margin = new Padding(2, 3, 2, 3);
            tbMessages.Multiline = true;
            tbMessages.Name = "tbMessages";
            tbMessages.Size = new Size(581, 276);
            tbMessages.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslMessage });
            statusStrip1.Location = new Point(2, 269);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(581, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslMessage
            // 
            tslMessage.Name = "tslMessage";
            tslMessage.Size = new Size(171, 21);
            tslMessage.Text = "toolStripStatusLabel1";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 566);
            Controls.Add(scMain);
            Controls.Add(toolStrip1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Main";
            Text = "交易记录";
            FormClosing += Main_FormClosing;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            scLeft.Panel1.ResumeLayout(false);
            scLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scLeft).EndInit();
            scLeft.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTradings).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubTradings).EndInit();
            scRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scRight).EndInit();
            scRight.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel tbBuy;
        private ToolStripLabel tbSell;
        private SplitContainer scMain;
        private SplitContainer scLeft;
        private SplitContainer scRight;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView dgvTradings;
        private DataGridView dgvSubTradings;
        private TextBox tbMessages;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslMessage;
    }
}