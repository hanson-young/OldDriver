namespace XYS.Remp.Screening.Kangfu.Spine
{
    partial class QuestionOne
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rdoAnswerYes = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.rdoAnswerNo = new XYS.Remp.Screening.Public.CustomRadioButton();
            this.lblTipTitle = new System.Windows.Forms.Label();
            this.lblTipDesc = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            // 
            // btnBefore
            // 
            this.btnBefore.FlatAppearance.BorderSize = 0;
            this.btnBefore.Visible = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblTipDesc);
            this.pnlContent.Controls.Add(this.lblTipTitle);
            this.pnlContent.Controls.Add(this.rdoAnswerNo);
            this.pnlContent.Controls.Add(this.rdoAnswerYes);
            this.pnlContent.Controls.Add(this.lblQuestion);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblQuestion.Location = new System.Drawing.Point(41, 306);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(470, 41);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "1. 是否有脊柱侧凸的家族病史？";
            // 
            // rdoAnswerYes
            // 
            this.rdoAnswerYes.AutoSize = true;
            this.rdoAnswerYes.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoAnswerYes.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoAnswerYes.Location = new System.Drawing.Point(126, 371);
            this.rdoAnswerYes.Name = "rdoAnswerYes";
            this.rdoAnswerYes.Size = new System.Drawing.Size(83, 36);
            this.rdoAnswerYes.TabIndex = 9;
            this.rdoAnswerYes.TabStop = true;
            this.rdoAnswerYes.Text = "A 是";
            this.rdoAnswerYes.UseVisualStyleBackColor = true;
            // 
            // rdoAnswerNo
            // 
            this.rdoAnswerNo.AutoSize = true;
            this.rdoAnswerNo.CheckColor = System.Drawing.SystemColors.ControlText;
            this.rdoAnswerNo.Font = new System.Drawing.Font("微软雅黑", 18.75F);
            this.rdoAnswerNo.Location = new System.Drawing.Point(303, 371);
            this.rdoAnswerNo.Name = "rdoAnswerNo";
            this.rdoAnswerNo.Size = new System.Drawing.Size(81, 36);
            this.rdoAnswerNo.TabIndex = 10;
            this.rdoAnswerNo.TabStop = true;
            this.rdoAnswerNo.Text = "B 否";
            this.rdoAnswerNo.UseVisualStyleBackColor = true;
            // 
            // lblTipTitle
            // 
            this.lblTipTitle.AutoSize = true;
            this.lblTipTitle.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.lblTipTitle.Location = new System.Drawing.Point(39, 53);
            this.lblTipTitle.Name = "lblTipTitle";
            this.lblTipTitle.Size = new System.Drawing.Size(562, 41);
            this.lblTipTitle.TabIndex = 11;
            this.lblTipTitle.Text = "脊柱侧凸筛查时，我们应该准备什么？";
            // 
            // lblTipDesc
            // 
            this.lblTipDesc.AutoSize = true;
            this.lblTipDesc.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipDesc.Location = new System.Drawing.Point(41, 139);
            this.lblTipDesc.Name = "lblTipDesc";
            this.lblTipDesc.Size = new System.Drawing.Size(888, 56);
            this.lblTipDesc.TabIndex = 12;
            this.lblTipDesc.Text = "      男孩应该赤膊、将裤子退到双侧髋骨以下或穿短内裤，女孩检查时应穿可轻易退去的衣物，\r\n鼓励穿运动型文胸或仅有上半身的泳衣。";
            // 
            // QuestionOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1280, 904);
            this.Name = "QuestionOne";
            this.Opacity = 1D;
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private Public.CustomRadioButton rdoAnswerYes;
        private Public.CustomRadioButton rdoAnswerNo;
        private System.Windows.Forms.Label lblTipDesc;
        private System.Windows.Forms.Label lblTipTitle;
    }
}
