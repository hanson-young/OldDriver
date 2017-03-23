namespace XYS.Remp.Screening
{
    partial class XYSMainfrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblTotalMsg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPageMsg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.callHisDataManagePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdOther = new System.Windows.Forms.RadioButton();
            this.rdKangfu = new System.Windows.Forms.RadioButton();
            this.rdAD = new System.Windows.Forms.RadioButton();
            this.rdNaocz = new System.Windows.Forms.RadioButton();
            this.rdZaoai = new System.Windows.Forms.RadioButton();
            this.rbVisitor = new System.Windows.Forms.RadioButton();
            this.rbOperator = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchActiv = new System.Windows.Forms.Button();
            this.BtnGetHouse = new System.Windows.Forms.Button();
            this.lvCottage = new System.Windows.Forms.ListView();
            this.cottageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ADate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.txtCottageName = new XYS.Remp.Screening.Public.CustomWaterTextBox();
            this.txtActivName = new XYS.Remp.Screening.Public.CustomWaterTextBox();
            this.txtDrAccount = new XYS.Remp.Screening.Public.CustomWaterTextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.ForeColor = System.Drawing.Color.Black;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1264, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.btnTest);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 789);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 85);
            this.panel2.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnTest.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Location = new System.Drawing.Point(656, 17);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(139, 55);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "退出系统";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(449, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 55);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.ForeColor = System.Drawing.Color.Black;
            this.splitter2.Location = new System.Drawing.Point(0, 786);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1264, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 783);
            this.panel3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.txtCottageName);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.txtActivName);
            this.groupBox1.Controls.Add(this.txtDrAccount);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Controls.Add(this.btnSkip);
            this.groupBox1.Controls.Add(this.txtSkip);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Controls.Add(this.lblTotalMsg);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblPageMsg);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.callHisDataManagePanel);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rbVisitor);
            this.groupBox1.Controls.Add(this.rbOperator);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearchActiv);
            this.groupBox1.Controls.Add(this.BtnGetHouse);
            this.groupBox1.Controls.Add(this.lvCottage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1264, 783);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(43, 592);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1175, 1);
            this.panel5.TabIndex = 42;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(43, 223);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1175, 1);
            this.panel4.TabIndex = 41;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel9.ForeColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(43, 55);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1175, 1);
            this.panel9.TabIndex = 40;
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkip.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnSkip.ForeColor = System.Drawing.Color.Black;
            this.btnSkip.Location = new System.Drawing.Point(1132, 497);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(86, 33);
            this.btnSkip.TabIndex = 39;
            this.btnSkip.Text = "跳转";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txtSkip
            // 
            this.txtSkip.BackColor = System.Drawing.Color.White;
            this.txtSkip.ForeColor = System.Drawing.Color.Black;
            this.txtSkip.Location = new System.Drawing.Point(1055, 498);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(63, 31);
            this.txtSkip.TabIndex = 38;
            this.txtSkip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkip_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(999, 503);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "转到";
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.ForeColor = System.Drawing.Color.Black;
            this.btnLast.Location = new System.Drawing.Point(907, 497);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(86, 33);
            this.btnLast.TabIndex = 36;
            this.btnLast.Text = "末页";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(804, 497);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 33);
            this.btnNext.TabIndex = 35;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(701, 497);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 33);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "上一页";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnFirst.ForeColor = System.Drawing.Color.Black;
            this.btnFirst.Location = new System.Drawing.Point(599, 497);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(86, 33);
            this.btnFirst.TabIndex = 33;
            this.btnFirst.Text = "首页";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblTotalMsg
            // 
            this.lblTotalMsg.AutoSize = true;
            this.lblTotalMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTotalMsg.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMsg.Location = new System.Drawing.Point(295, 503);
            this.lblTotalMsg.Name = "lblTotalMsg";
            this.lblTotalMsg.Size = new System.Drawing.Size(0, 21);
            this.lblTotalMsg.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(222, 503);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 31;
            this.label8.Text = "总计：";
            // 
            // lblPageMsg
            // 
            this.lblPageMsg.AutoSize = true;
            this.lblPageMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblPageMsg.ForeColor = System.Drawing.Color.Black;
            this.lblPageMsg.Location = new System.Drawing.Point(127, 503);
            this.lblPageMsg.Name = "lblPageMsg";
            this.lblPageMsg.Size = new System.Drawing.Size(0, 21);
            this.lblPageMsg.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(54, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 29;
            this.label6.Text = "页次：";
            // 
            // callHisDataManagePanel
            // 
            this.callHisDataManagePanel.BackColor = System.Drawing.Color.Transparent;
            this.callHisDataManagePanel.ForeColor = System.Drawing.Color.Black;
            this.callHisDataManagePanel.Location = new System.Drawing.Point(1103, 62);
            this.callHisDataManagePanel.Name = "callHisDataManagePanel";
            this.callHisDataManagePanel.Size = new System.Drawing.Size(149, 134);
            this.callHisDataManagePanel.TabIndex = 28;
            this.callHisDataManagePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.callHisDataManagePanel_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.rdOther);
            this.panel1.Controls.Add(this.rdKangfu);
            this.panel1.Controls.Add(this.rdAD);
            this.panel1.Controls.Add(this.rdNaocz);
            this.panel1.Controls.Add(this.rdZaoai);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(43, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 86);
            this.panel1.TabIndex = 27;
            // 
            // rdOther
            // 
            this.rdOther.AutoSize = true;
            this.rdOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdOther.Font = new System.Drawing.Font("宋体", 14.75F);
            this.rdOther.ForeColor = System.Drawing.Color.Black;
            this.rdOther.Location = new System.Drawing.Point(536, 5);
            this.rdOther.Name = "rdOther";
            this.rdOther.Size = new System.Drawing.Size(67, 24);
            this.rdOther.TabIndex = 8;
            this.rdOther.Text = "其他";
            this.rdOther.UseVisualStyleBackColor = false;
            // 
            // rdKangfu
            // 
            this.rdKangfu.AutoSize = true;
            this.rdKangfu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdKangfu.Font = new System.Drawing.Font("宋体", 14.75F);
            this.rdKangfu.ForeColor = System.Drawing.Color.Black;
            this.rdKangfu.Location = new System.Drawing.Point(296, 5);
            this.rdKangfu.Name = "rdKangfu";
            this.rdKangfu.Size = new System.Drawing.Size(147, 24);
            this.rdKangfu.TabIndex = 7;
            this.rdKangfu.Text = "康复医院筛查";
            this.rdKangfu.UseVisualStyleBackColor = false;
            // 
            // rdAD
            // 
            this.rdAD.AutoSize = true;
            this.rdAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdAD.Checked = true;
            this.rdAD.Font = new System.Drawing.Font("宋体", 14.75F);
            this.rdAD.ForeColor = System.Drawing.Color.Black;
            this.rdAD.Location = new System.Drawing.Point(5, 5);
            this.rdAD.Name = "rdAD";
            this.rdAD.Size = new System.Drawing.Size(217, 24);
            this.rdAD.TabIndex = 4;
            this.rdAD.TabStop = true;
            this.rdAD.Text = "301医院老年认知筛查";
            this.rdAD.UseVisualStyleBackColor = false;
            // 
            // rdNaocz
            // 
            this.rdNaocz.AutoSize = true;
            this.rdNaocz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdNaocz.Font = new System.Drawing.Font("宋体", 14.75F);
            this.rdNaocz.ForeColor = System.Drawing.Color.Black;
            this.rdNaocz.Location = new System.Drawing.Point(690, 5);
            this.rdNaocz.Name = "rdNaocz";
            this.rdNaocz.Size = new System.Drawing.Size(227, 24);
            this.rdNaocz.TabIndex = 5;
            this.rdNaocz.Text = "深圳市二院脑卒中筛查";
            this.rdNaocz.UseVisualStyleBackColor = false;
            // 
            // rdZaoai
            // 
            this.rdZaoai.AutoSize = true;
            this.rdZaoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdZaoai.Font = new System.Drawing.Font("宋体", 14.75F);
            this.rdZaoai.ForeColor = System.Drawing.Color.Black;
            this.rdZaoai.Location = new System.Drawing.Point(5, 44);
            this.rdZaoai.Name = "rdZaoai";
            this.rdZaoai.Size = new System.Drawing.Size(247, 24);
            this.rdZaoai.TabIndex = 6;
            this.rdZaoai.Text = "深圳市人民医院早癌筛查";
            this.rdZaoai.UseVisualStyleBackColor = false;
            // 
            // rbVisitor
            // 
            this.rbVisitor.AutoSize = true;
            this.rbVisitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbVisitor.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbVisitor.ForeColor = System.Drawing.Color.Black;
            this.rbVisitor.Location = new System.Drawing.Point(254, 185);
            this.rbVisitor.Name = "rbVisitor";
            this.rbVisitor.Size = new System.Drawing.Size(111, 24);
            this.rbVisitor.TabIndex = 25;
            this.rbVisitor.TabStop = true;
            this.rbVisitor.Text = "访客模式";
            this.rbVisitor.UseVisualStyleBackColor = false;
            this.rbVisitor.CheckedChanged += new System.EventHandler(this.rbVisitor_CheckedChanged);
            // 
            // rbOperator
            // 
            this.rbOperator.AutoSize = true;
            this.rbOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbOperator.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbOperator.ForeColor = System.Drawing.Color.Black;
            this.rbOperator.Location = new System.Drawing.Point(43, 185);
            this.rbOperator.Name = "rbOperator";
            this.rbOperator.Size = new System.Drawing.Size(153, 24);
            this.rbOperator.TabIndex = 24;
            this.rbOperator.TabStop = true;
            this.rbOperator.Text = "操作人员登录";
            this.rbOperator.UseVisualStyleBackColor = false;
            this.rbOperator.CheckedChanged += new System.EventHandler(this.rbOperator_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "请选择筛查分类：";
            // 
            // btnSearchActiv
            // 
            this.btnSearchActiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearchActiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchActiv.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnSearchActiv.ForeColor = System.Drawing.Color.Black;
            this.btnSearchActiv.Location = new System.Drawing.Point(1032, 237);
            this.btnSearchActiv.Name = "btnSearchActiv";
            this.btnSearchActiv.Size = new System.Drawing.Size(110, 45);
            this.btnSearchActiv.TabIndex = 19;
            this.btnSearchActiv.Text = "查 询";
            this.btnSearchActiv.UseVisualStyleBackColor = false;
            this.btnSearchActiv.Click += new System.EventHandler(this.btnSearchActiv_Click);
            // 
            // BtnGetHouse
            // 
            this.BtnGetHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BtnGetHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGetHouse.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.BtnGetHouse.ForeColor = System.Drawing.Color.Black;
            this.BtnGetHouse.Location = new System.Drawing.Point(685, 610);
            this.BtnGetHouse.Name = "BtnGetHouse";
            this.BtnGetHouse.Size = new System.Drawing.Size(110, 45);
            this.BtnGetHouse.TabIndex = 2;
            this.BtnGetHouse.Text = "查 询";
            this.BtnGetHouse.UseVisualStyleBackColor = false;
            this.BtnGetHouse.Click += new System.EventHandler(this.BtnGetHouse_Click);
            // 
            // lvCottage
            // 
            this.lvCottage.BackColor = System.Drawing.Color.White;
            this.lvCottage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cottageName});
            this.lvCottage.ForeColor = System.Drawing.Color.Black;
            this.lvCottage.FullRowSelect = true;
            this.lvCottage.Location = new System.Drawing.Point(43, 669);
            this.lvCottage.Name = "lvCottage";
            this.lvCottage.Size = new System.Drawing.Size(1175, 179);
            this.lvCottage.TabIndex = 13;
            this.lvCottage.UseCompatibleStateImageBehavior = false;
            this.lvCottage.View = System.Windows.Forms.View.Details;
            this.lvCottage.SelectedIndexChanged += new System.EventHandler(this.lvCottage_SelectedIndexChanged);
            // 
            // cottageName
            // 
            this.cottageName.Text = "小屋名称";
            this.cottageName.Width = 1175;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "活动所属小屋：";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.OrgName,
            this.ADate,
            this.EndDate,
            this.Adress});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(43, 293);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1175, 192);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "标题";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Title.Width = 350;
            // 
            // OrgName
            // 
            this.OrgName.Text = "举办单位";
            this.OrgName.Width = 350;
            // 
            // ADate
            // 
            this.ADate.Text = "开始时间";
            this.ADate.Width = 235;
            // 
            // EndDate
            // 
            this.EndDate.Text = "结束时间";
            this.EndDate.Width = 235;
            // 
            // Adress
            // 
            this.Adress.Text = "活动地址";
            this.Adress.Width = 500;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(116)))), ((int)(((byte)(71))))));
            // 
            // txtCottageName
            // 
            this.txtCottageName.BackColor = System.Drawing.Color.White;
            this.txtCottageName.ForeColor = System.Drawing.Color.Black;
            this.txtCottageName.Location = new System.Drawing.Point(43, 618);
            this.txtCottageName.Name = "txtCottageName";
            this.txtCottageName.Size = new System.Drawing.Size(603, 31);
            this.txtCottageName.TabIndex = 43;
            this.txtCottageName.WaterText = "";
            // 
            // txtActivName
            // 
            this.txtActivName.BackColor = System.Drawing.Color.White;
            this.txtActivName.ForeColor = System.Drawing.Color.Black;
            this.txtActivName.Location = new System.Drawing.Point(363, 245);
            this.txtActivName.Name = "txtActivName";
            this.txtActivName.Size = new System.Drawing.Size(632, 31);
            this.txtActivName.TabIndex = 42;
            this.txtActivName.WaterText = "";
            this.txtActivName.Click += new System.EventHandler(this.txtActivName_Click);
            this.txtActivName.Leave += new System.EventHandler(this.txtActivName_Leave);
            // 
            // txtDrAccount
            // 
            this.txtDrAccount.BackColor = System.Drawing.Color.White;
            this.txtDrAccount.ForeColor = System.Drawing.Color.Black;
            this.txtDrAccount.Location = new System.Drawing.Point(43, 245);
            this.txtDrAccount.Name = "txtDrAccount";
            this.txtDrAccount.Size = new System.Drawing.Size(294, 31);
            this.txtDrAccount.TabIndex = 41;
            this.txtDrAccount.WaterText = "";
            this.txtDrAccount.Click += new System.EventHandler(this.txtDrAccount_Click);
            this.txtDrAccount.Leave += new System.EventHandler(this.txtDrAccount_Leave);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1264, 874);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimizeBox = false;
            this.Name = "Mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新元素疾病筛查系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainfrm_FormClosing);
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdKangfu;
        private System.Windows.Forms.RadioButton rdZaoai;
        private System.Windows.Forms.RadioButton rdNaocz;
        private System.Windows.Forms.RadioButton rdAD;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView lvCottage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.Button BtnGetHouse;
        private System.Windows.Forms.ColumnHeader cottageName;
        private System.Windows.Forms.Button btnSearchActiv;
        private System.Windows.Forms.ColumnHeader OrgName;
        private System.Windows.Forms.ColumnHeader ADate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbOperator;
        private System.Windows.Forms.RadioButton rbVisitor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel callHisDataManagePanel;
        private System.Windows.Forms.RadioButton rdOther;
        private System.Windows.Forms.ColumnHeader EndDate;
        private System.Windows.Forms.ColumnHeader Adress;
        private System.Windows.Forms.Label lblPageMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalMsg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TextBox txtSkip;
        private System.Windows.Forms.Panel panel9;
        private Public.CustomWaterTextBox txtDrAccount;
        private Public.CustomWaterTextBox txtActivName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Public.CustomWaterTextBox txtCottageName;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}

