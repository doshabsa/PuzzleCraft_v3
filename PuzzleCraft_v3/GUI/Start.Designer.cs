namespace PuzzleCraft_v3
{
    partial class Start
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
            this.btnRandom = new System.Windows.Forms.Button();
            this.lblPTselect = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tplTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tplTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRandom
            // 
            this.tplTable.SetColumnSpan(this.btnRandom, 3);
            this.btnRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRandom.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRandom.Location = new System.Drawing.Point(4, 638);
            this.btnRandom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(542, 48);
            this.btnRandom.TabIndex = 14;
            this.btnRandom.Text = "Randomize Options";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // lblPTselect
            // 
            this.lblPTselect.AutoSize = true;
            this.tplTable.SetColumnSpan(this.lblPTselect, 3);
            this.lblPTselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTselect.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPTselect.Location = new System.Drawing.Point(4, 0);
            this.lblPTselect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPTselect.Name = "lblPTselect";
            this.lblPTselect.Size = new System.Drawing.Size(542, 38);
            this.lblPTselect.TabIndex = 13;
            this.lblPTselect.Text = "Please select your character:";
            this.lblPTselect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.tplTable.SetColumnSpan(this.btnStart, 3);
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(4, 696);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(542, 49);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtName
            // 
            this.tplTable.SetColumnSpan(this.txtName, 3);
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(4, 43);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Enter your name here!";
            this.txtName.Size = new System.Drawing.Size(542, 45);
            this.txtName.TabIndex = 21;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tplTable
            // 
            this.tplTable.ColumnCount = 3;
            this.tplTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tplTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tplTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tplTable.Controls.Add(this.lblPTselect, 0, 0);
            this.tplTable.Controls.Add(this.btnStart, 0, 6);
            this.tplTable.Controls.Add(this.txtName, 0, 1);
            this.tplTable.Controls.Add(this.btnRandom, 0, 5);
            this.tplTable.Controls.Add(this.panel1, 0, 2);
            this.tplTable.Controls.Add(this.panel2, 1, 2);
            this.tplTable.Controls.Add(this.panel3, 2, 2);
            this.tplTable.Controls.Add(this.panel4, 0, 3);
            this.tplTable.Controls.Add(this.panel5, 1, 3);
            this.tplTable.Controls.Add(this.panel6, 2, 3);
            this.tplTable.Controls.Add(this.panel7, 0, 4);
            this.tplTable.Controls.Add(this.panel8, 1, 4);
            this.tplTable.Controls.Add(this.panel9, 2, 4);
            this.tplTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplTable.Location = new System.Drawing.Point(0, 0);
            this.tplTable.Name = "tplTable";
            this.tplTable.RowCount = 7;
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplTable.Size = new System.Drawing.Size(550, 750);
            this.tplTable.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 174);
            this.panel1.TabIndex = 22;
            this.panel1.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(186, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 174);
            this.panel2.TabIndex = 23;
            this.panel2.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(369, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 174);
            this.panel3.TabIndex = 24;
            this.panel3.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel4
            // 
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 276);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 174);
            this.panel4.TabIndex = 25;
            this.panel4.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel5
            // 
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(186, 276);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(177, 174);
            this.panel5.TabIndex = 26;
            this.panel5.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel6
            // 
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(369, 276);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(178, 174);
            this.panel6.TabIndex = 27;
            this.panel6.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel7
            // 
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 456);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(177, 174);
            this.panel7.TabIndex = 28;
            this.panel7.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel8
            // 
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(186, 456);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(177, 174);
            this.panel8.TabIndex = 29;
            this.panel8.Click += new System.EventHandler(this.Panel_Select);
            // 
            // panel9
            // 
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(369, 456);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(178, 174);
            this.panel9.TabIndex = 30;
            this.panel9.Click += new System.EventHandler(this.Panel_Select);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tplTable);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Start";
            this.Size = new System.Drawing.Size(550, 750);
            this.tplTable.ResumeLayout(false);
            this.tplTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRandom;
        private Label lblPTselect;
        private Button btnStart;
        private TextBox txtName;
        private TableLayoutPanel tplTable;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
    }
}
