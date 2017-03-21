namespace XYS.Remp.Screening.HistoryData
{
    partial class HistoryDataManager
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
            this.btnJizhu = new System.Windows.Forms.Button();
            this.btnZuhuai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJizhu
            // 
            this.btnJizhu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJizhu.Location = new System.Drawing.Point(32, 123);
            this.btnJizhu.Name = "btnJizhu";
            this.btnJizhu.Size = new System.Drawing.Size(118, 39);
            this.btnJizhu.TabIndex = 0;
            this.btnJizhu.Text = "脊柱问卷打分";
            this.btnJizhu.UseVisualStyleBackColor = true;
            this.btnJizhu.Click += new System.EventHandler(this.btnJizhu_Click);
            // 
            // btnZuhuai
            // 
            this.btnZuhuai.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZuhuai.Location = new System.Drawing.Point(202, 123);
            this.btnZuhuai.Name = "btnZuhuai";
            this.btnZuhuai.Size = new System.Drawing.Size(118, 39);
            this.btnZuhuai.TabIndex = 1;
            this.btnZuhuai.Text = "足踝问卷打分";
            this.btnZuhuai.UseVisualStyleBackColor = true;
            this.btnZuhuai.Click += new System.EventHandler(this.btnZuhuai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(92, 47);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(228, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(344, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "备注：以上两个按钮仅用于问卷表中QuestionnaireType=1的数据，且点击一次后请耐心等待直到提示更新成功";
            // 
            // HistoryDataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 398);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZuhuai);
            this.Controls.Add(this.btnJizhu);
            this.Name = "HistoryDataManager";
            this.Text = "历史数据处理";
            this.Load += new System.EventHandler(this.HistoryDataManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJizhu;
        private System.Windows.Forms.Button btnZuhuai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}