namespace HeilsCareSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSet = new System.Windows.Forms.Button();
            this.btnOutSideMode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsideMode = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.mainExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSet.FlatAppearance.BorderSize = 3;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Location = new System.Drawing.Point(840, 67);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(117, 50);
            this.btnSet.TabIndex = 0;
            this.btnSet.TabStop = false;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            this.btnSet.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSet_Paint);
            // 
            // btnOutSideMode
            // 
            this.btnOutSideMode.BackColor = System.Drawing.Color.Transparent;
            this.btnOutSideMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOutSideMode.BackgroundImage")));
            this.btnOutSideMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOutSideMode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOutSideMode.FlatAppearance.BorderSize = 0;
            this.btnOutSideMode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOutSideMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOutSideMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutSideMode.Location = new System.Drawing.Point(107, 279);
            this.btnOutSideMode.Name = "btnOutSideMode";
            this.btnOutSideMode.Size = new System.Drawing.Size(388, 388);
            this.btnOutSideMode.TabIndex = 2;
            this.btnOutSideMode.TabStop = false;
            this.btnOutSideMode.UseVisualStyleBackColor = false;
            this.btnOutSideMode.Click += new System.EventHandler(this.btnOutSideMode_Click);
            this.btnOutSideMode.Paint += new System.Windows.Forms.PaintEventHandler(this.btnOutSideMode_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(118, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "请选择您本次使用的场景模式:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(267, 706);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 57);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(235, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "户外广场";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(696, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "健康小屋";
            // 
            // btnInsideMode
            // 
            this.btnInsideMode.BackColor = System.Drawing.Color.Transparent;
            this.btnInsideMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInsideMode.BackgroundImage")));
            this.btnInsideMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInsideMode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsideMode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInsideMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInsideMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsideMode.Location = new System.Drawing.Point(567, 277);
            this.btnInsideMode.Name = "btnInsideMode";
            this.btnInsideMode.Size = new System.Drawing.Size(390, 390);
            this.btnInsideMode.TabIndex = 2;
            this.btnInsideMode.TabStop = false;
            this.btnInsideMode.UseVisualStyleBackColor = false;
            this.btnInsideMode.Click += new System.EventHandler(this.btnInsideMode_Click);
            this.btnInsideMode.Paint += new System.Windows.Forms.PaintEventHandler(this.btnInsideMode_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(742, 710);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 53);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // mainExit
            // 
            this.mainExit.BackColor = System.Drawing.Color.White;
            this.mainExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainExit.BackgroundImage")));
            this.mainExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainExit.FlatAppearance.BorderSize = 0;
            this.mainExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainExit.Location = new System.Drawing.Point(986, 8);
            this.mainExit.Name = "mainExit";
            this.mainExit.Size = new System.Drawing.Size(95, 86);
            this.mainExit.TabIndex = 5;
            this.mainExit.TabStop = false;
            this.mainExit.UseVisualStyleBackColor = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.Paint += new System.Windows.Forms.PaintEventHandler(this.mainExit_Paint_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 816);
            this.Controls.Add(this.mainExit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsideMode);
            this.Controls.Add(this.btnOutSideMode);
            this.Controls.Add(this.btnSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnOutSideMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsideMode;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button mainExit;
    }
}

