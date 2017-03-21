namespace XYS.Remp.Screening
{
    partial class LoginFormNew
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFormNew));
            this.timerLogin = new System.Windows.Forms.Timer(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPatientLogin = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurMobile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvLoginAccount = new System.Windows.Forms.ListView();
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLogin
            // 
            this.timerLogin.Enabled = true;
            this.timerLogin.Interval = 1000;
            this.timerLogin.Tick += new System.EventHandler(this.timerLogin_Tick);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(26, 44);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 64);
            this.btnBack.TabIndex = 13;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblCurMobile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnGuest);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMobile);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 758);
            this.panel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(135, 541);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 20;
            this.label6.Text = "操作提示：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPatientLogin);
            this.panel3.Controls.Add(this.btnReg);
            this.panel3.Location = new System.Drawing.Point(946, 235);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 282);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnPatientLogin
            // 
            this.btnPatientLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientLogin.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPatientLogin.Location = new System.Drawing.Point(51, 33);
            this.btnPatientLogin.Name = "btnPatientLogin";
            this.btnPatientLogin.Size = new System.Drawing.Size(80, 80);
            this.btnPatientLogin.TabIndex = 7;
            this.btnPatientLogin.Text = "会员登录";
            this.btnPatientLogin.UseVisualStyleBackColor = true;
            this.btnPatientLogin.Click += new System.EventHandler(this.btnPatientLogin_Click);
            // 
            // btnReg
            // 
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReg.Location = new System.Drawing.Point(51, 168);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(80, 80);
            this.btnReg.TabIndex = 6;
            this.btnReg.Text = "新人注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(140, 585);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(988, 1);
            this.panel4.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(659, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "）";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(231, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 26);
            this.label9.TabIndex = 17;
            this.label9.Text = "已注册会员可以刷身份证快速登录";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 13.25F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(444, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "固话例：0755-82445959";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(135, 599);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(613, 99);
            this.label7.TabIndex = 15;
            this.label7.Text = "1、输入手机号-->查询会员-->选择账户-->会员登录\r\n                     |\r\n                     |-->新人" +
    "注册\r\n\r\n2、游客登录（不保存筛查结果）";
            // 
            // lblCurMobile
            // 
            this.lblCurMobile.AutoSize = true;
            this.lblCurMobile.Font = new System.Drawing.Font("微软雅黑", 13.25F);
            this.lblCurMobile.ForeColor = System.Drawing.Color.Red;
            this.lblCurMobile.Location = new System.Drawing.Point(135, 199);
            this.lblCurMobile.Name = "lblCurMobile";
            this.lblCurMobile.Size = new System.Drawing.Size(0, 24);
            this.lblCurMobile.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13.25F);
            this.label2.Location = new System.Drawing.Point(262, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "关联的账户";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvLoginAccount);
            this.panel2.Location = new System.Drawing.Point(139, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(807, 282);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lvLoginAccount
            // 
            this.lvLoginAccount.BackColor = System.Drawing.Color.White;
            this.lvLoginAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLoginAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PName,
            this.PAccount});
            this.lvLoginAccount.Font = new System.Drawing.Font("宋体", 18F);
            this.lvLoginAccount.FullRowSelect = true;
            this.lvLoginAccount.Location = new System.Drawing.Point(1, 1);
            this.lvLoginAccount.Name = "lvLoginAccount";
            this.lvLoginAccount.Size = new System.Drawing.Size(805, 280);
            this.lvLoginAccount.TabIndex = 0;
            this.lvLoginAccount.UseCompatibleStateImageBehavior = false;
            this.lvLoginAccount.View = System.Windows.Forms.View.Details;
            this.lvLoginAccount.SelectedIndexChanged += new System.EventHandler(this.lvLoginAccount_SelectedIndexChanged);
            // 
            // PName
            // 
            this.PName.Text = "会员姓名";
            this.PName.Width = 300;
            // 
            // PAccount
            // 
            this.PAccount.Text = "账号";
            this.PAccount.Width = 505;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(135, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "温馨提示：";
            // 
            // btnGuest
            // 
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuest.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnGuest.Location = new System.Drawing.Point(789, 139);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(110, 45);
            this.btnGuest.TabIndex = 8;
            this.btnGuest.Text = "访客登录";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Visible = false;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 698);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1280, 60);
            this.label3.TabIndex = 7;
            this.label3.Text = "深圳市新元素医疗技术开发有限公司版权所有";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(136, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入完整手机、固话、小灵通号码（";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMobile.Location = new System.Drawing.Point(139, 148);
            this.txtMobile.MaxLength = 25;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(481, 29);
            this.txtMobile.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnLogin.Location = new System.Drawing.Point(647, 139);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 45);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "查询";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.picTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(0, 0);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(1280, 154);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitle.TabIndex = 7;
            this.picTitle.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(545, 282);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 5;
            // 
            // LoginFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 912);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblInfo);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LoginFormNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Timer timerLogin;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvLoginAccount;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.ColumnHeader PAccount;
        private System.Windows.Forms.Label lblCurMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPatientLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
    }
}