using System.Drawing;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    partial class QuestionTwo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTipTitle = new System.Windows.Forms.Label();
            this.lblQuestion1 = new System.Windows.Forms.RichTextBox();
            this.lblQueation2 = new System.Windows.Forms.Label();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.rdoQ1AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ1AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ2AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ2AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ3AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ3AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlQ1Answer = new System.Windows.Forms.Panel();
            this.pnlQ3Answer = new System.Windows.Forms.Panel();
            this.pnlQ2Answer = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlQ1Answer.SuspendLayout();
            this.pnlQ3Answer.SuspendLayout();
            this.pnlQ2Answer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            // 
            // btnBefore
            // 
            this.btnBefore.FlatAppearance.BorderSize = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlQ3Answer);
            this.pnlContent.Controls.Add(this.pnlQ2Answer);
            this.pnlContent.Controls.Add(this.pnlQ1Answer);
            this.pnlContent.Controls.Add(this.pictureBox2);
            this.pnlContent.Controls.Add(this.pictureBox1);
            this.pnlContent.Controls.Add(this.lblQuestion3);
            this.pnlContent.Controls.Add(this.lblQueation2);
            this.pnlContent.Controls.Add(this.lblQuestion1);
            this.pnlContent.Controls.Add(this.lblTipTitle);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            // 
            // lblTipTitle
            // 
            this.lblTipTitle.AutoSize = true;
            this.lblTipTitle.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblTipTitle.Location = new System.Drawing.Point(12, 32);
            this.lblTipTitle.Name = "lblTipTitle";
            this.lblTipTitle.Size = new System.Drawing.Size(148, 57);
            this.lblTipTitle.TabIndex = 12;
            this.lblTipTitle.Text = "头&&颈";
            // 
            // lblQuestion1
            // 
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.BackColor = System.Drawing.Color.White;
            this.lblQuestion1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblQuestion1.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQuestion1.Location = new System.Drawing.Point(19, 136);
            this.lblQuestion1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblQuestion1.Multiline = false;
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.ReadOnly = true;
            this.lblQuestion1.Size = new System.Drawing.Size(461, 43);
            this.lblQuestion1.TabIndex = 13;
            this.lblQuestion1.Text = "2.头部是否不在臀部正中线上？";
            // 
            // lblQueation2
            // 
            this.lblQueation2.AutoSize = true;
            this.lblQueation2.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQueation2.Location = new System.Drawing.Point(12, 308);
            this.lblQueation2.Name = "lblQueation2";
            this.lblQueation2.Size = new System.Drawing.Size(333, 41);
            this.lblQueation2.TabIndex = 14;
            this.lblQueation2.Text = "3.头及下颌是否前伸？\r\n";
            // 
            // lblQuestion3
            // 
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQuestion3.Location = new System.Drawing.Point(12, 478);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(269, 41);
            this.lblQuestion3.TabIndex = 15;
            this.lblQuestion3.Text = "4.颈部是否前倾？";
            // 
            // rdoQ1AnswerNo
            // 
            this.rdoQ1AnswerNo.AutoSize = true;
            this.rdoQ1AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ1AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ1AnswerNo.Location = new System.Drawing.Point(237, 12);
            this.rdoQ1AnswerNo.Name = "rdoQ1AnswerNo";
            this.rdoQ1AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ1AnswerNo.TabIndex = 17;
            this.rdoQ1AnswerNo.TabStop = true;
            this.rdoQ1AnswerNo.Text = "B 否";
            this.rdoQ1AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ1AnswerYes
            // 
            this.rdoQ1AnswerYes.AutoSize = true;
            this.rdoQ1AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ1AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ1AnswerYes.Location = new System.Drawing.Point(60, 12);
            this.rdoQ1AnswerYes.Name = "rdoQ1AnswerYes";
            this.rdoQ1AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ1AnswerYes.TabIndex = 16;
            this.rdoQ1AnswerYes.TabStop = true;
            this.rdoQ1AnswerYes.Text = "A 是";
            this.rdoQ1AnswerYes.UseVisualStyleBackColor = true;
            // 
            // rdoQ2AnswerNo
            // 
            this.rdoQ2AnswerNo.AutoSize = true;
            this.rdoQ2AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ2AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ2AnswerNo.Location = new System.Drawing.Point(237, 12);
            this.rdoQ2AnswerNo.Name = "rdoQ2AnswerNo";
            this.rdoQ2AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ2AnswerNo.TabIndex = 19;
            this.rdoQ2AnswerNo.TabStop = true;
            this.rdoQ2AnswerNo.Text = "B 否";
            this.rdoQ2AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ2AnswerYes
            // 
            this.rdoQ2AnswerYes.AutoSize = true;
            this.rdoQ2AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ2AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ2AnswerYes.Location = new System.Drawing.Point(60, 12);
            this.rdoQ2AnswerYes.Name = "rdoQ2AnswerYes";
            this.rdoQ2AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ2AnswerYes.TabIndex = 18;
            this.rdoQ2AnswerYes.TabStop = true;
            this.rdoQ2AnswerYes.Text = "A 是";
            this.rdoQ2AnswerYes.UseVisualStyleBackColor = true;
            // 
            // rdoQ3AnswerNo
            // 
            this.rdoQ3AnswerNo.AutoSize = true;
            this.rdoQ3AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ3AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ3AnswerNo.Location = new System.Drawing.Point(237, 12);
            this.rdoQ3AnswerNo.Name = "rdoQ3AnswerNo";
            this.rdoQ3AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ3AnswerNo.TabIndex = 21;
            this.rdoQ3AnswerNo.TabStop = true;
            this.rdoQ3AnswerNo.Text = "B 否";
            this.rdoQ3AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ3AnswerYes
            // 
            this.rdoQ3AnswerYes.AutoSize = true;
            this.rdoQ3AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ3AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ3AnswerYes.Location = new System.Drawing.Point(60, 12);
            this.rdoQ3AnswerYes.Name = "rdoQ3AnswerYes";
            this.rdoQ3AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ3AnswerYes.TabIndex = 20;
            this.rdoQ3AnswerYes.TabStop = true;
            this.rdoQ3AnswerYes.Text = "A 是";
            this.rdoQ3AnswerYes.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XYS.Remp.Screening.Properties.Resources.u37;
            this.pictureBox1.Location = new System.Drawing.Point(533, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(572, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::XYS.Remp.Screening.Properties.Resources.u36;
            this.pictureBox2.Location = new System.Drawing.Point(533, 339);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(572, 224);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pnlQ1Answer
            // 
            this.pnlQ1Answer.Controls.Add(this.rdoQ1AnswerYes);
            this.pnlQ1Answer.Controls.Add(this.rdoQ1AnswerNo);
            this.pnlQ1Answer.Location = new System.Drawing.Point(73, 182);
            this.pnlQ1Answer.Name = "pnlQ1Answer";
            this.pnlQ1Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ1Answer.TabIndex = 26;
            // 
            // pnlQ3Answer
            // 
            this.pnlQ3Answer.Controls.Add(this.rdoQ3AnswerNo);
            this.pnlQ3Answer.Controls.Add(this.rdoQ3AnswerYes);
            this.pnlQ3Answer.Location = new System.Drawing.Point(73, 522);
            this.pnlQ3Answer.Name = "pnlQ3Answer";
            this.pnlQ3Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ3Answer.TabIndex = 27;
            // 
            // pnlQ2Answer
            // 
            this.pnlQ2Answer.Controls.Add(this.rdoQ2AnswerNo);
            this.pnlQ2Answer.Controls.Add(this.rdoQ2AnswerYes);
            this.pnlQ2Answer.Location = new System.Drawing.Point(73, 352);
            this.pnlQ2Answer.Name = "pnlQ2Answer";
            this.pnlQ2Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ2Answer.TabIndex = 27;
            // 
            // QuestionTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1280, 904);
            this.Name = "QuestionTwo";
            this.Opacity = 1D;
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlQ1Answer.ResumeLayout(false);
            this.pnlQ1Answer.PerformLayout();
            this.pnlQ3Answer.ResumeLayout(false);
            this.pnlQ3Answer.PerformLayout();
            this.pnlQ2Answer.ResumeLayout(false);
            this.pnlQ2Answer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTipTitle;
        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.Label lblQueation2;
        private System.Windows.Forms.RichTextBox lblQuestion1;
        private Public.CustomRadioButton rdoQ3AnswerNo;
        private Public.CustomRadioButton rdoQ3AnswerYes;
        private Public.CustomRadioButton rdoQ2AnswerNo;
        private Public.CustomRadioButton rdoQ2AnswerYes;
        private Public.CustomRadioButton rdoQ1AnswerNo;
        private Public.CustomRadioButton rdoQ1AnswerYes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlQ1Answer;
        private System.Windows.Forms.Panel pnlQ3Answer;
        private System.Windows.Forms.Panel pnlQ2Answer;
    }
}
