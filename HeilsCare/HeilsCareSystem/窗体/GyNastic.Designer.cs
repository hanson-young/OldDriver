namespace HeilsCareSystem
{
    partial class GyNastic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GyNastic));
            this.mainExit = new System.Windows.Forms.Button();
            this.Video = new System.Windows.Forms.Button();
            this.Game = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainExit
            // 
            this.mainExit.BackColor = System.Drawing.Color.White;
            this.mainExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainExit.BackgroundImage")));
            this.mainExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainExit.FlatAppearance.BorderSize = 0;
            this.mainExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainExit.Location = new System.Drawing.Point(987, 4);
            this.mainExit.Name = "mainExit";
            this.mainExit.Size = new System.Drawing.Size(95, 86);
            this.mainExit.TabIndex = 6;
            this.mainExit.TabStop = false;
            this.mainExit.UseVisualStyleBackColor = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.Paint += new System.Windows.Forms.PaintEventHandler(this.mainExit_Paint);
            // 
            // Video
            // 
            this.Video.BackColor = System.Drawing.Color.Transparent;
            this.Video.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Video.BackgroundImage")));
            this.Video.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Video.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Video.FlatAppearance.BorderSize = 0;
            this.Video.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Video.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Video.Location = new System.Drawing.Point(159, 319);
            this.Video.Name = "Video";
            this.Video.Size = new System.Drawing.Size(342, 344);
            this.Video.TabIndex = 7;
            this.Video.TabStop = false;
            this.Video.UseVisualStyleBackColor = false;
            this.Video.Visible = false;
            this.Video.Click += new System.EventHandler(this.Video_Click);
            this.Video.Paint += new System.Windows.Forms.PaintEventHandler(this.Video_Paint);
            // 
            // Game
            // 
            this.Game.BackColor = System.Drawing.Color.Transparent;
            this.Game.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Game.BackgroundImage")));
            this.Game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Game.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Game.FlatAppearance.BorderSize = 0;
            this.Game.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Game.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Game.Location = new System.Drawing.Point(579, 317);
            this.Game.Name = "Game";
            this.Game.Size = new System.Drawing.Size(342, 344);
            this.Game.TabIndex = 7;
            this.Game.TabStop = false;
            this.Game.UseVisualStyleBackColor = false;
            this.Game.Visible = false;
            this.Game.Click += new System.EventHandler(this.Game_Click);
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(308, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 149);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label3.Location = new System.Drawing.Point(458, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 52);
            this.label3.TabIndex = 9;
            this.label3.Text = "您的私人健康助理";
            // 
            // GyNastic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 816);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Game);
            this.Controls.Add(this.Video);
            this.Controls.Add(this.mainExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GyNastic";
            this.Text = "GyNastic";
            this.Load += new System.EventHandler(this.GyNastic_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GyNastic_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mainExit;
        private System.Windows.Forms.Button Video;
        private System.Windows.Forms.Button Game;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}