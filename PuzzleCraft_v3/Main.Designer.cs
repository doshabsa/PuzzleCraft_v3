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
            this.btn_Cheat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cheat
            // 
            this.btn_Cheat.Location = new System.Drawing.Point(833, 28);
            this.btn_Cheat.Name = "btn_Cheat";
            this.btn_Cheat.Size = new System.Drawing.Size(75, 23);
            this.btn_Cheat.TabIndex = 0;
            this.btn_Cheat.Text = "button1";
            this.btn_Cheat.UseVisualStyleBackColor = true;
            this.btn_Cheat.Click += new System.EventHandler(this.btn_Cheat_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.btn_Cheat);
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

        private Button btn_Cheat;
    }
}