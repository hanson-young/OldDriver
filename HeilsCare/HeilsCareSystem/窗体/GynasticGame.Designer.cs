namespace HeilsCareSystem
{
    partial class GynasticGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GynasticGame));
            this.mainExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainExit
            // 
            this.mainExit.BackColor = System.Drawing.Color.White;
            this.mainExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainExit.BackgroundImage")));
            this.mainExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainExit.FlatAppearance.BorderSize = 0;
            this.mainExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainExit.Location = new System.Drawing.Point(989, 2);
            this.mainExit.Name = "mainExit";
            this.mainExit.Size = new System.Drawing.Size(95, 86);
            this.mainExit.TabIndex = 4;
            this.mainExit.TabStop = false;
            this.mainExit.UseVisualStyleBackColor = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.Paint += new System.Windows.Forms.PaintEventHandler(this.mainExit_Paint);
            // 
            // GynasticGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1088, 816);
            this.Controls.Add(this.mainExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GynasticGame";
            this.Text = "GynasticGame";
            this.Load += new System.EventHandler(this.GynasticGame_Load);
            this.Resize += new System.EventHandler(this.GynasticGame_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainExit;
    }
}