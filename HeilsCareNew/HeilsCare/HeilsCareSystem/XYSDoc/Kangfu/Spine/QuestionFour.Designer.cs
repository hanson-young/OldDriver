using System.Drawing;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    partial class QuestionFour
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
            this.rdoQ3AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ3AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ2AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ2AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ1AnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoQ1AnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.lblQueation2 = new System.Windows.Forms.RichTextBox();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.lblTipTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlQ1Answer = new System.Windows.Forms.Panel();
            this.pnlQ3Answer = new System.Windows.Forms.Panel();
            this.pnlQ2Answer = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // rdoQ3AnswerNo
            // 
            this.rdoQ3AnswerNo.AutoSize = true;
            this.rdoQ3AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ3AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ3AnswerNo.Location = new System.Drawing.Point(232, 12);
            this.rdoQ3AnswerNo.Name = "rdoQ3AnswerNo";
            this.rdoQ3AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ3AnswerNo.TabIndex = 45;
            this.rdoQ3AnswerNo.TabStop = true;
            this.rdoQ3AnswerNo.Text = "B 否";
            this.rdoQ3AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ3AnswerYes
            // 
            this.rdoQ3AnswerYes.AutoSize = true;
            this.rdoQ3AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ3AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ3AnswerYes.Location = new System.Drawing.Point(55, 12);
            this.rdoQ3AnswerYes.Name = "rdoQ3AnswerYes";
            this.rdoQ3AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ3AnswerYes.TabIndex = 44;
            this.rdoQ3AnswerYes.TabStop = true;
            this.rdoQ3AnswerYes.Text = "A 是";
            this.rdoQ3AnswerYes.UseVisualStyleBackColor = true;
            // 
            // rdoQ2AnswerNo
            // 
            this.rdoQ2AnswerNo.AutoSize = true;
            this.rdoQ2AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ2AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ2AnswerNo.Location = new System.Drawing.Point(232, 12);
            this.rdoQ2AnswerNo.Name = "rdoQ2AnswerNo";
            this.rdoQ2AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ2AnswerNo.TabIndex = 43;
            this.rdoQ2AnswerNo.TabStop = true;
            this.rdoQ2AnswerNo.Text = "B 否";
            this.rdoQ2AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ2AnswerYes
            // 
            this.rdoQ2AnswerYes.AutoSize = true;
            this.rdoQ2AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ2AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ2AnswerYes.Location = new System.Drawing.Point(55, 12);
            this.rdoQ2AnswerYes.Name = "rdoQ2AnswerYes";
            this.rdoQ2AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ2AnswerYes.TabIndex = 42;
            this.rdoQ2AnswerYes.TabStop = true;
            this.rdoQ2AnswerYes.Text = "A 是";
            this.rdoQ2AnswerYes.UseVisualStyleBackColor = true;
            // 
            // rdoQ1AnswerNo
            // 
            this.rdoQ1AnswerNo.AutoSize = true;
            this.rdoQ1AnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ1AnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ1AnswerNo.Location = new System.Drawing.Point(232, 12);
            this.rdoQ1AnswerNo.Name = "rdoQ1AnswerNo";
            this.rdoQ1AnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoQ1AnswerNo.TabIndex = 41;
            this.rdoQ1AnswerNo.TabStop = true;
            this.rdoQ1AnswerNo.Text = "B 否";
            this.rdoQ1AnswerNo.UseVisualStyleBackColor = true;
            // 
            // rdoQ1AnswerYes
            // 
            this.rdoQ1AnswerYes.AutoSize = true;
            this.rdoQ1AnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoQ1AnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoQ1AnswerYes.Location = new System.Drawing.Point(55, 12);
            this.rdoQ1AnswerYes.Name = "rdoQ1AnswerYes";
            this.rdoQ1AnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoQ1AnswerYes.TabIndex = 40;
            this.rdoQ1AnswerYes.TabStop = true;
            this.rdoQ1AnswerYes.Text = "A 是";
            this.rdoQ1AnswerYes.UseVisualStyleBackColor = true;
            // 
            // lblQuestion3
            // 
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQuestion3.Location = new System.Drawing.Point(27, 487);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(416, 41);
            this.lblQuestion3.TabIndex = 39;
            this.lblQuestion3.Text = "10.是否棘突排列呈弯曲状？";
            // 
            // lblQueation2
            // 
            this.lblQueation2.AutoSize = true;
            this.lblQueation2.BackColor = System.Drawing.Color.White;
            this.lblQueation2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblQueation2.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQueation2.Location = new System.Drawing.Point(34, 317);
            this.lblQueation2.Multiline = false;
            this.lblQueation2.Name = "lblQueation2";
            this.lblQueation2.ReadOnly = true;
            this.lblQueation2.Size = new System.Drawing.Size(539, 43);
            this.lblQueation2.TabIndex = 38;
            this.lblQueation2.Text = "9.是否一侧胸廓和/或下背部不对称？";
            // 
            // lblQuestion1
            // 
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQuestion1.Location = new System.Drawing.Point(27, 147);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(397, 41);
            this.lblQuestion1.TabIndex = 37;
            this.lblQuestion1.Text = "8.胸段是否明显圆形隆起？";
            // 
            // lblTipTitle
            // 
            this.lblTipTitle.AutoSize = true;
            this.lblTipTitle.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblTipTitle.Location = new System.Drawing.Point(27, 46);
            this.lblTipTitle.Name = "lblTipTitle";
            this.lblTipTitle.Size = new System.Drawing.Size(148, 57);
            this.lblTipTitle.TabIndex = 36;
            this.lblTipTitle.Text = "胸&&背";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::XYS.Remp.Screening.Properties.Resources.u38;
            this.pictureBox2.Location = new System.Drawing.Point(557, 351);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(572, 224);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XYS.Remp.Screening.Properties.Resources.u37;
            this.pictureBox1.Location = new System.Drawing.Point(557, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(572, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pnlQ1Answer
            // 
            this.pnlQ1Answer.Controls.Add(this.rdoQ1AnswerNo);
            this.pnlQ1Answer.Controls.Add(this.rdoQ1AnswerYes);
            this.pnlQ1Answer.Location = new System.Drawing.Point(93, 191);
            this.pnlQ1Answer.Name = "pnlQ1Answer";
            this.pnlQ1Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ1Answer.TabIndex = 48;
            // 
            // pnlQ3Answer
            // 
            this.pnlQ3Answer.Controls.Add(this.rdoQ3AnswerNo);
            this.pnlQ3Answer.Controls.Add(this.rdoQ3AnswerYes);
            this.pnlQ3Answer.Location = new System.Drawing.Point(93, 531);
            this.pnlQ3Answer.Name = "pnlQ3Answer";
            this.pnlQ3Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ3Answer.TabIndex = 49;
            // 
            // pnlQ2Answer
            // 
            this.pnlQ2Answer.Controls.Add(this.rdoQ2AnswerNo);
            this.pnlQ2Answer.Controls.Add(this.rdoQ2AnswerYes);
            this.pnlQ2Answer.Location = new System.Drawing.Point(93, 361);
            this.pnlQ2Answer.Name = "pnlQ2Answer";
            this.pnlQ2Answer.Size = new System.Drawing.Size(400, 50);
            this.pnlQ2Answer.TabIndex = 49;
            // 
            // QuestionFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1280, 904);
            this.Name = "QuestionFour";
            this.Opacity = 1D;
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlQ1Answer.ResumeLayout(false);
            this.pnlQ1Answer.PerformLayout();
            this.pnlQ3Answer.ResumeLayout(false);
            this.pnlQ3Answer.PerformLayout();
            this.pnlQ2Answer.ResumeLayout(false);
            this.pnlQ2Answer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Public.CustomRadioButton rdoQ3AnswerNo;
        private Public.CustomRadioButton rdoQ3AnswerYes;
        private Public.CustomRadioButton rdoQ2AnswerNo;
        private Public.CustomRadioButton rdoQ2AnswerYes;
        private Public.CustomRadioButton rdoQ1AnswerNo;
        private Public.CustomRadioButton rdoQ1AnswerYes;
        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.RichTextBox lblQueation2;
        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.Label lblTipTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlQ3Answer;
        private System.Windows.Forms.Panel pnlQ2Answer;
        private System.Windows.Forms.Panel pnlQ1Answer;
    }
}
