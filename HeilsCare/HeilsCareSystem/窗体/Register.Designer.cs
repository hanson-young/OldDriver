namespace HeilsCareSystem
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.Male = new System.Windows.Forms.Button();
            this.feMale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mainExit = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.DirectLogin = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.secondPassword = new XYS.Remp.Screening.Public.CustomTextBox();
            this.firstPassword = new XYS.Remp.Screening.Public.CustomTextBox();
            this.phoneNum = new XYS.Remp.Screening.Public.CustomTextBox();
            this.txtQ2 = new XYS.Remp.Screening.Public.CustomTextBox();
            this.SuspendLayout();
            // 
            // Male
            // 
            this.Male.BackColor = System.Drawing.Color.White;
            this.Male.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Male.BackgroundImage")));
            this.Male.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Male.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Male.FlatAppearance.BorderSize = 0;
            this.Male.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Male.Location = new System.Drawing.Point(452, 178);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(81, 81);
            this.Male.TabIndex = 0;
            this.Male.TabStop = false;
            this.Male.UseVisualStyleBackColor = false;
            this.Male.Click += new System.EventHandler(this.Male_Click);
            this.Male.Paint += new System.Windows.Forms.PaintEventHandler(this.Male_Paint);
            // 
            // feMale
            // 
            this.feMale.BackColor = System.Drawing.Color.White;
            this.feMale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("feMale.BackgroundImage")));
            this.feMale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.feMale.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.feMale.FlatAppearance.BorderSize = 0;
            this.feMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feMale.Location = new System.Drawing.Point(567, 169);
            this.feMale.Name = "feMale";
            this.feMale.Size = new System.Drawing.Size(62, 99);
            this.feMale.TabIndex = 0;
            this.feMale.TabStop = false;
            this.feMale.UseVisualStyleBackColor = false;
            this.feMale.Paint += new System.Windows.Forms.PaintEventHandler(this.feMale_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label1.Location = new System.Drawing.Point(475, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "您的性别？";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label2.Location = new System.Drawing.Point(350, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "您的年龄？";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label5.Location = new System.Drawing.Point(349, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 35);
            this.label5.TabIndex = 5;
            this.label5.Text = "请输入您的手机号作为账号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label6.Location = new System.Drawing.Point(349, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "请设置您的账号密码:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label7.Location = new System.Drawing.Point(349, 555);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 35);
            this.label7.TabIndex = 5;
            this.label7.Text = "请再次输入您的密码:";
            // 
            // mainExit
            // 
            this.mainExit.BackColor = System.Drawing.Color.White;
            this.mainExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainExit.BackgroundImage")));
            this.mainExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainExit.FlatAppearance.BorderSize = 0;
            this.mainExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainExit.Location = new System.Drawing.Point(981, 12);
            this.mainExit.Name = "mainExit";
            this.mainExit.Size = new System.Drawing.Size(95, 86);
            this.mainExit.TabIndex = 13;
            this.mainExit.TabStop = false;
            this.mainExit.UseVisualStyleBackColor = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.Paint += new System.Windows.Forms.PaintEventHandler(this.mainExit_Paint);
            // 
            // btnRegister
            // 
            this.btnRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.BackgroundImage")));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.Location = new System.Drawing.Point(461, 662);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(165, 50);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.TabStop = false;
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRegister_Paint);
            this.btnRegister.MouseEnter += new System.EventHandler(this.btnRegister_MouseEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            // 
            // DirectLogin
            // 
            this.DirectLogin.BackColor = System.Drawing.Color.White;
            this.DirectLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DirectLogin.BackgroundImage")));
            this.DirectLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DirectLogin.CausesValidation = false;
            this.DirectLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DirectLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DirectLogin.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DirectLogin.ForeColor = System.Drawing.Color.White;
            this.DirectLogin.Location = new System.Drawing.Point(858, 60);
            this.DirectLogin.Name = "DirectLogin";
            this.DirectLogin.Size = new System.Drawing.Size(117, 50);
            this.DirectLogin.TabIndex = 16;
            this.DirectLogin.TabStop = false;
            this.DirectLogin.UseVisualStyleBackColor = false;
            this.DirectLogin.Click += new System.EventHandler(this.DirectLogin_Click);
            this.DirectLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Back.CausesValidation = false;
            this.Back.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Back.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Back.Location = new System.Drawing.Point(95, 57);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(124, 53);
            this.Back.TabIndex = 17;
            this.Back.TabStop = false;
            this.Back.Text = "< 返回";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            this.Back.Paint += new System.Windows.Forms.PaintEventHandler(this.Back_Paint);
            // 
            // secondPassword
            // 
            this.secondPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondPassword.Font = new System.Drawing.Font("宋体", 26.25F);
            this.secondPassword.Location = new System.Drawing.Point(349, 601);
            this.secondPassword.Name = "secondPassword";
            this.secondPassword.PasswordChar = '*';
            this.secondPassword.Size = new System.Drawing.Size(400, 40);
            this.secondPassword.TabIndex = 12;
            this.secondPassword.TabStop = false;
            this.secondPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.secondPassword.Click += new System.EventHandler(this.secondPassword_Click);
            this.secondPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.secondPassword_KeyUp);
            this.secondPassword.Leave += new System.EventHandler(this.secondPassword_Leave);
            // 
            // firstPassword
            // 
            this.firstPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstPassword.Font = new System.Drawing.Font("宋体", 26.25F);
            this.firstPassword.Location = new System.Drawing.Point(349, 512);
            this.firstPassword.Name = "firstPassword";
            this.firstPassword.PasswordChar = '*';
            this.firstPassword.Size = new System.Drawing.Size(400, 40);
            this.firstPassword.TabIndex = 12;
            this.firstPassword.TabStop = false;
            this.firstPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstPassword.Click += new System.EventHandler(this.firstPassword_Click);
            this.firstPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.firstPassword_KeyUp);
            this.firstPassword.Leave += new System.EventHandler(this.firstPassword_Leave);
            // 
            // phoneNum
            // 
            this.phoneNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneNum.Font = new System.Drawing.Font("宋体", 26.25F);
            this.phoneNum.Location = new System.Drawing.Point(349, 429);
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.Size = new System.Drawing.Size(400, 40);
            this.phoneNum.TabIndex = 12;
            this.phoneNum.TabStop = false;
            this.phoneNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.phoneNum.Click += new System.EventHandler(this.phoneNum_Click);
            this.phoneNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.phoneNum_KeyUp);
            this.phoneNum.Leave += new System.EventHandler(this.phoneNum_Leave);
            // 
            // txtQ2
            // 
            this.txtQ2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQ2.Font = new System.Drawing.Font("宋体", 26.25F);
            this.txtQ2.Location = new System.Drawing.Point(349, 340);
            this.txtQ2.Name = "txtQ2";
            this.txtQ2.Size = new System.Drawing.Size(400, 40);
            this.txtQ2.TabIndex = 12;
            this.txtQ2.TabStop = false;
            this.txtQ2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQ2.Click += new System.EventHandler(this.txtQ2_Click);
            this.txtQ2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQ2_KeyUp);
            this.txtQ2.Leave += new System.EventHandler(this.txtQ2_Leave);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 816);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.DirectLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.mainExit);
            this.Controls.Add(this.secondPassword);
            this.Controls.Add(this.firstPassword);
            this.Controls.Add(this.phoneNum);
            this.Controls.Add(this.txtQ2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.feMale);
            this.Controls.Add(this.Male);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Male;
        private System.Windows.Forms.Button feMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private XYS.Remp.Screening.Public.CustomTextBox txtQ2;
        private System.Windows.Forms.Label label5;
        private XYS.Remp.Screening.Public.CustomTextBox phoneNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private XYS.Remp.Screening.Public.CustomTextBox firstPassword;
        private XYS.Remp.Screening.Public.CustomTextBox secondPassword;
        private System.Windows.Forms.Button mainExit;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button DirectLogin;
        private System.Windows.Forms.Button Back;
    }
}