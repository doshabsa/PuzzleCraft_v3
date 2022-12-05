namespace PuzzleCraft_v3
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBackpack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackpack
            // 
            this.btnBackpack.BackColor = System.Drawing.Color.OldLace;
            this.btnBackpack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackpack.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBackpack.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnBackpack.Location = new System.Drawing.Point(12, 12);
            this.btnBackpack.Name = "btnBackpack";
            this.btnBackpack.Size = new System.Drawing.Size(109, 33);
            this.btnBackpack.TabIndex = 0;
            this.btnBackpack.Text = "Open Pack";
            this.btnBackpack.UseVisualStyleBackColor = false;
            this.btnBackpack.Visible = false;
            this.btnBackpack.Click += new System.EventHandler(this.btnBackpack_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.btnBackpack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "225_PuzzleCraft_v3";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnBackpack;
    }
}