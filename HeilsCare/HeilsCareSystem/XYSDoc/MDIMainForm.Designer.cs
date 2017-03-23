namespace XYS.Remp.Screening
{
    partial class MDIMainForm
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
            this.SuspendLayout();
            // 
            // MDIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1022, 616);
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MDIMainForm";
            this.Opacity = 1D;
            this.ShowIcon = false;
            this.Text = "新元素疾病筛查系统";
            this.Load += new System.EventHandler(this.MDIMainForm_Load);
            this.DoubleClick += new System.EventHandler(this.MDIMainForm_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}