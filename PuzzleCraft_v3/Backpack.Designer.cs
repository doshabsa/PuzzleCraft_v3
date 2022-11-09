namespace PuzzleCraft_v3
{
    partial class Backpack
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBag = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlBag
            // 
            this.pnlBag.BackColor = System.Drawing.Color.OldLace;
            this.pnlBag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBag.Location = new System.Drawing.Point(0, 0);
            this.pnlBag.Name = "pnlBag";
            this.pnlBag.Size = new System.Drawing.Size(382, 210);
            this.pnlBag.TabIndex = 0;
            // 
            // Backpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBag);
            this.Name = "Backpack";
            this.Size = new System.Drawing.Size(382, 210);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlBag;
    }
}
