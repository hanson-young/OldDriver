namespace XYS.Remp.Screening
{
    partial class QuitComfirmFrm
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
            this.btnContinue2 = new System.Windows.Forms.Button();
            this.btnQuit2 = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinue2
            // 
            this.btnContinue2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnContinue2.ForeColor = System.Drawing.Color.Green;
            this.btnContinue2.Location = new System.Drawing.Point(231, 254);
            this.btnContinue2.Name = "btnContinue2";
            this.btnContinue2.Size = new System.Drawing.Size(124, 45);
            this.btnContinue2.TabIndex = 4;
            this.btnContinue2.Text = "继续/再做一次";
            this.btnContinue2.UseVisualStyleBackColor = true;
            // 
            // btnQuit2
            // 
            this.btnQuit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnQuit2.Location = new System.Drawing.Point(596, 2);
            this.btnQuit2.Name = "btnQuit2";
            this.btnQuit2.Size = new System.Drawing.Size(43, 43);
            this.btnQuit2.TabIndex = 3;
            this.btnQuit2.Text = "X";
            this.btnQuit2.UseVisualStyleBackColor = true;
            this.btnQuit2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnContinue.ForeColor = System.Drawing.Color.Green;
            this.btnContinue.Location = new System.Drawing.Point(506, 254);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(124, 45);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "其他筛查";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnQuit.ForeColor = System.Drawing.Color.Blue;
            this.btnQuit.Location = new System.Drawing.Point(370, 254);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(124, 45);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "回到主界面";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lblTitle.Location = new System.Drawing.Point(12, 70);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(616, 135);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "接下来，要继续做其它筛查吗？";
            // 
            // QuitComfirmFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(640, 307);
            this.Controls.Add(this.btnContinue2);
            this.Controls.Add(this.btnQuit2);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblTitle);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "QuitComfirmFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuitComfirmFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.QuitComfirmFrm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuitComfirmFrm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnQuit2;
        private System.Windows.Forms.Button btnContinue2;
    }
}