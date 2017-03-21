namespace HeilsCareSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.mainExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ForgetPassword = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.PasswordText = new XYS.Remp.Screening.Public.CustomTextBox();
            this.txtQ2 = new XYS.Remp.Screening.Public.CustomTextBox();
            this.SuspendLayout();
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
            this.mainExit.TabIndex = 4;
            this.mainExit.TabStop = false;
            this.mainExit.UseVisualStyleBackColor = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.Paint += new System.Windows.Forms.PaintEventHandler(this.mainExit_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label2.Location = new System.Drawing.Point(401, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 35);
            this.label2.TabIndex = 14;
            this.label2.Text = "请输入您的账号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label1.Location = new System.Drawing.Point(399, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "请输入您的密码:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.CausesValidation = false;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(486, 521);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(124, 53);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.TabStop = false;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLogin_Paint);
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
            this.Back.Location = new System.Drawing.Point(101, 74);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(124, 53);
            this.Back.TabIndex = 16;
            this.Back.TabStop = false;
            this.Back.Text = "< 返回";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            this.Back.Paint += new System.Windows.Forms.PaintEventHandler(this.Back_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(599, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "(手机号):";
            // 
            // ForgetPassword
            // 
            this.ForgetPassword.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ForgetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ForgetPassword.CausesValidation = false;
            this.ForgetPassword.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ForgetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForgetPassword.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForgetPassword.ForeColor = System.Drawing.Color.White;
            this.ForgetPassword.Location = new System.Drawing.Point(611, 362);
            this.ForgetPassword.Name = "ForgetPassword";
            this.ForgetPassword.Size = new System.Drawing.Size(124, 53);
            this.ForgetPassword.TabIndex = 15;
            this.ForgetPassword.TabStop = false;
            this.ForgetPassword.Text = "忘记密码?";
            this.ForgetPassword.UseVisualStyleBackColor = false;
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Register.CausesValidation = false;
            this.Register.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Register.ForeColor = System.Drawing.Color.White;
            this.Register.Location = new System.Drawing.Point(840, 67);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(124, 53);
            this.Register.TabIndex = 15;
            this.Register.TabStop = false;
            this.Register.Text = "注 册";
            this.Register.UseVisualStyleBackColor = false;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            this.Register.Paint += new System.Windows.Forms.PaintEventHandler(this.Register_Paint);
            // 
            // PasswordText
            // 
            this.PasswordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordText.Font = new System.Drawing.Font("宋体", 26.25F);
            this.PasswordText.Location = new System.Drawing.Point(354, 427);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.PasswordChar = '*';
            this.PasswordText.Size = new System.Drawing.Size(400, 40);
            this.PasswordText.TabIndex = 13;
            this.PasswordText.TabStop = false;
            this.PasswordText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordText.Click += new System.EventHandler(this.PasswordText_Click);
            this.PasswordText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswordText_KeyUp);
            this.PasswordText.Leave += new System.EventHandler(this.PasswordText_Leave);
            // 
            // txtQ2
            // 
            this.txtQ2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQ2.Font = new System.Drawing.Font("宋体", 26.25F);
            this.txtQ2.Location = new System.Drawing.Point(354, 303);
            this.txtQ2.Name = "txtQ2";
            this.txtQ2.Size = new System.Drawing.Size(400, 40);
            this.txtQ2.TabIndex = 13;
            this.txtQ2.TabStop = false;
            this.txtQ2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQ2.Click += new System.EventHandler(this.txtQ2_Click);
            this.txtQ2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQ2_KeyUp);
            this.txtQ2.Leave += new System.EventHandler(this.txtQ2_Leave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 816);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.ForgetPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.txtQ2);
            this.Controls.Add(this.mainExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mainExit;
        private XYS.Remp.Screening.Public.CustomTextBox txtQ2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private XYS.Remp.Screening.Public.CustomTextBox PasswordText;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ForgetPassword;
        private System.Windows.Forms.Button Register;
    }
}