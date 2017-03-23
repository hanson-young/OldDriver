namespace XYS.Remp.Screening.Other.THAH
{
    partial class ThahResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThahResult));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label9 = new System.Windows.Forms.Label();
            this.lblVisitor = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.ptop = new System.Windows.Forms.Panel();
            this.lblDangerReasonTitle = new System.Windows.Forms.Label();
            this.lblAppraiseTitle = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblDangerReason = new System.Windows.Forms.Label();
            this.lblAppraise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.ptop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 852);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1280, 60);
            this.label9.TabIndex = 84;
            this.label9.Text = "深圳市新元素医疗技术开发有限公司版权所有";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVisitor
            // 
            this.lblVisitor.AutoSize = true;
            this.lblVisitor.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVisitor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblVisitor.Location = new System.Drawing.Point(289, 177);
            this.lblVisitor.Name = "lblVisitor";
            this.lblVisitor.Size = new System.Drawing.Size(117, 28);
            this.lblVisitor.TabIndex = 88;
            this.lblVisitor.Text = "游客编号：";
            this.lblVisitor.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // timerPrint
            // 
            this.timerPrint.Interval = 1000;
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XYS.Remp.Screening.Properties.Resources.result;
            this.pictureBox1.Location = new System.Drawing.Point(28, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 336);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(705, 794);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(162, 52);
            this.btnPrint.TabIndex = 82;
            this.btnPrint.Text = "打印结果";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(125, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1030, 147);
            this.label8.TabIndex = 2;
            this.label8.Text = "青少年二高筛查";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::XYS.Remp.Screening.Properties.Resources.titleBackground;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1280, 147);
            this.panel6.TabIndex = 17;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnExit);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1155, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(125, 147);
            this.panel10.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::XYS.Remp.Screening.Properties.Resources.btnExit;
            this.btnExit.Location = new System.Drawing.Point(35, 47);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 64);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(125, 147);
            this.panel11.TabIndex = 0;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("宋体", 24F);
            this.btnPrintPreview.Location = new System.Drawing.Point(423, 794);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(162, 52);
            this.btnPrintPreview.TabIndex = 86;
            this.btnPrintPreview.Text = "打印预览";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResultTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblResultTitle.Location = new System.Drawing.Point(289, 231);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(117, 28);
            this.lblResultTitle.TabIndex = 89;
            this.lblResultTitle.Text = "筛查结果：";
            // 
            // ptop
            // 
            this.ptop.BackgroundImage = global::XYS.Remp.Screening.Properties.Resources.titleBackground;
            this.ptop.Controls.Add(this.panel6);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(1280, 147);
            this.ptop.TabIndex = 83;
            // 
            // lblDangerReasonTitle
            // 
            this.lblDangerReasonTitle.AutoSize = true;
            this.lblDangerReasonTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDangerReasonTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDangerReasonTitle.Location = new System.Drawing.Point(289, 368);
            this.lblDangerReasonTitle.Name = "lblDangerReasonTitle";
            this.lblDangerReasonTitle.Size = new System.Drawing.Size(117, 28);
            this.lblDangerReasonTitle.TabIndex = 90;
            this.lblDangerReasonTitle.Text = "高危因素：";
            // 
            // lblAppraiseTitle
            // 
            this.lblAppraiseTitle.AutoSize = true;
            this.lblAppraiseTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppraiseTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAppraiseTitle.Location = new System.Drawing.Point(289, 517);
            this.lblAppraiseTitle.Name = "lblAppraiseTitle";
            this.lblAppraiseTitle.Size = new System.Drawing.Size(243, 28);
            this.lblAppraiseTitle.TabIndex = 91;
            this.lblAppraiseTitle.Text = "综合评估（治疗建议）：";
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.Black;
            this.lblResult.Location = new System.Drawing.Point(289, 259);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(866, 109);
            this.lblResult.TabIndex = 92;
            // 
            // lblDangerReason
            // 
            this.lblDangerReason.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lblDangerReason.ForeColor = System.Drawing.Color.Black;
            this.lblDangerReason.Location = new System.Drawing.Point(289, 396);
            this.lblDangerReason.Name = "lblDangerReason";
            this.lblDangerReason.Size = new System.Drawing.Size(866, 109);
            this.lblDangerReason.TabIndex = 93;
            // 
            // lblAppraise
            // 
            this.lblAppraise.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lblAppraise.ForeColor = System.Drawing.Color.Black;
            this.lblAppraise.Location = new System.Drawing.Point(289, 554);
            this.lblAppraise.Name = "lblAppraise";
            this.lblAppraise.Size = new System.Drawing.Size(866, 186);
            this.lblAppraise.TabIndex = 94;
            // 
            // ThahResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 912);
            this.Controls.Add(this.lblAppraise);
            this.Controls.Add(this.lblDangerReason);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblAppraiseTitle);
            this.Controls.Add(this.lblDangerReasonTitle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblVisitor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.lblResultTitle);
            this.Controls.Add(this.ptop);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ThahResult";
            this.Text = "ThahResult";
            this.Load += new System.EventHandler(this.ThahResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ptop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblVisitor;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Timer timerPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.Label lblDangerReasonTitle;
        private System.Windows.Forms.Label lblAppraiseTitle;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblDangerReason;
        private System.Windows.Forms.Label lblAppraise;

    }
}