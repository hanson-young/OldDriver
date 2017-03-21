namespace HeilsCareSystem
{
    partial class GymnasticForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GymnasticForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.axUnityWebPlayerMain = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
            this.pnlPaddingLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenKinect = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayerGym = new AxWMPLib.AxWindowsMediaPlayer();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBefore = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblQuestionnaireTitle = new System.Windows.Forms.Label();
            this.pnlExit = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayerMain)).BeginInit();
            this.pnlPaddingLeft.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerGym)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlExit.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.axUnityWebPlayerMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(479, 159);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(801, 623);
            this.pnlContent.TabIndex = 19;
            // 
            // axUnityWebPlayerMain
            // 
            this.axUnityWebPlayerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axUnityWebPlayerMain.Enabled = true;
            this.axUnityWebPlayerMain.Location = new System.Drawing.Point(0, 0);
            this.axUnityWebPlayerMain.Name = "axUnityWebPlayerMain";
            this.axUnityWebPlayerMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnityWebPlayerMain.OcxState")));
            this.axUnityWebPlayerMain.Size = new System.Drawing.Size(801, 623);
            this.axUnityWebPlayerMain.TabIndex = 0;
            // 
            // pnlPaddingLeft
            // 
            this.pnlPaddingLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaddingLeft.Controls.Add(this.tableLayoutPanel1);
            this.pnlPaddingLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPaddingLeft.Location = new System.Drawing.Point(0, 159);
            this.pnlPaddingLeft.Name = "pnlPaddingLeft";
            this.pnlPaddingLeft.Size = new System.Drawing.Size(479, 623);
            this.pnlPaddingLeft.TabIndex = 21;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenKinect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picUser, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayerGym, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 623);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOpenKinect
            // 
            this.btnOpenKinect.Location = new System.Drawing.Point(3, 283);
            this.btnOpenKinect.Name = "btnOpenKinect";
            this.btnOpenKinect.Size = new System.Drawing.Size(77, 37);
            this.btnOpenKinect.TabIndex = 0;
            this.btnOpenKinect.Text = "打开Kinect";
            this.btnOpenKinect.UseVisualStyleBackColor = true;
            this.btnOpenKinect.Click += new System.EventHandler(this.btnOpenKinect_Click);
            // 
            // picUser
            // 
            this.picUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUser.Location = new System.Drawing.Point(3, 345);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(473, 275);
            this.picUser.TabIndex = 2;
            this.picUser.TabStop = false;
            // 
            // axWindowsMediaPlayerGym
            // 
            this.axWindowsMediaPlayerGym.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayerGym.Enabled = true;
            this.axWindowsMediaPlayerGym.Location = new System.Drawing.Point(3, 3);
            this.axWindowsMediaPlayerGym.Name = "axWindowsMediaPlayerGym";
            this.axWindowsMediaPlayerGym.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerGym.OcxState")));
            this.axWindowsMediaPlayerGym.Size = new System.Drawing.Size(473, 274);
            this.axWindowsMediaPlayerGym.TabIndex = 3;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnNext);
            this.pnlAction.Controls.Add(this.btnBefore);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 782);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(1280, 66);
            this.pnlAction.TabIndex = 17;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(1114, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(166, 66);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBefore
            // 
            this.btnBefore.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBefore.FlatAppearance.BorderSize = 0;
            this.btnBefore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBefore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBefore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBefore.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBefore.Image = ((System.Drawing.Image)(resources.GetObject("btnBefore.Image")));
            this.btnBefore.Location = new System.Drawing.Point(0, 0);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(166, 66);
            this.btnBefore.TabIndex = 7;
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.lblQuestionnaireTitle);
            this.pnlTop.Controls.Add(this.pnlExit);
            this.pnlTop.Controls.Add(this.pnlBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1280, 159);
            this.pnlTop.TabIndex = 16;
            // 
            // lblQuestionnaireTitle
            // 
            this.lblQuestionnaireTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionnaireTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuestionnaireTitle.ForeColor = System.Drawing.Color.White;
            this.lblQuestionnaireTitle.Location = new System.Drawing.Point(125, 0);
            this.lblQuestionnaireTitle.Name = "lblQuestionnaireTitle";
            this.lblQuestionnaireTitle.Size = new System.Drawing.Size(1030, 159);
            this.lblQuestionnaireTitle.TabIndex = 2;
            this.lblQuestionnaireTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExit
            // 
            this.pnlExit.Controls.Add(this.btnExit);
            this.pnlExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlExit.Location = new System.Drawing.Point(1155, 0);
            this.pnlExit.Name = "pnlExit";
            this.pnlExit.Size = new System.Drawing.Size(125, 159);
            this.pnlExit.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(35, 47);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 64);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.btnBack);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(125, 159);
            this.pnlBack.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(28, 47);
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(66, 66);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseCompatibleTextRendering = true;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 848);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1280, 64);
            this.pnlFooter.TabIndex = 20;
            // 
            // lblFooter
            // 
            this.lblFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFooter.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(0, 4);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(1280, 60);
            this.lblFooter.TabIndex = 8;
            this.lblFooter.Text = "深圳市新元素医疗技术开发有限公司版权所有";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GymnasticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 912);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlPaddingLeft);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlFooter);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "GymnasticForm";
            this.Text = "QuestionOne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GymnasticForm_FormClosing);
            this.Load += new System.EventHandler(this.FormLoadEven);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayerMain)).EndInit();
            this.pnlPaddingLeft.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerGym)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlExit.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel pnlExit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        protected System.Windows.Forms.Button btnNext;
        protected System.Windows.Forms.Button btnBefore;
        protected System.Windows.Forms.Button btnBack;
        protected System.Windows.Forms.Panel pnlAction;
        protected System.Windows.Forms.Label lblQuestionnaireTitle;
        protected System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlPaddingLeft;
        private AxUnityWebPlayerAXLib.AxUnityWebPlayer axUnityWebPlayerMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOpenKinect;
        private System.Windows.Forms.PictureBox picUser;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerGym;
    }
}