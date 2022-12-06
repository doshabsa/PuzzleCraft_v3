namespace PuzzleCraft_v3.GUI
{
    partial class QuestLog
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
            this.tlpTable = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblReward = new System.Windows.Forms.Label();
            this.picReward = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClosePack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pic0 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblDayCycle = new System.Windows.Forms.Label();
            this.tlpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpTable
            // 
            this.tlpTable.ColumnCount = 2;
            this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.91391F));
            this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.08609F));
            this.tlpTable.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTable.Controls.Add(this.rtbDescription, 1, 0);
            this.tlpTable.Controls.Add(this.lblReward, 0, 2);
            this.tlpTable.Controls.Add(this.picReward, 1, 2);
            this.tlpTable.Controls.Add(this.btnClose, 1, 0);
            this.tlpTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTable.Location = new System.Drawing.Point(0, 0);
            this.tlpTable.Name = "tlpTable";
            this.tlpTable.RowCount = 3;
            this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.984556F));
            this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.01544F));
            this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTable.Size = new System.Drawing.Size(300, 600);
            this.tlpTable.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.OldLace;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlpTable.SetColumnSpan(this.rtbDescription, 2);
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Enabled = false;
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.rtbDescription.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.rtbDescription.Location = new System.Drawing.Point(3, 34);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(294, 481);
            this.rtbDescription.TabIndex = 2;
            this.rtbDescription.Text = "";
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReward.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReward.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblReward.Location = new System.Drawing.Point(3, 518);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(182, 82);
            this.lblReward.TabIndex = 1;
            this.lblReward.Text = "Reward:";
            this.lblReward.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picReward
            // 
            this.picReward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picReward.Location = new System.Drawing.Point(191, 521);
            this.picReward.Name = "picReward";
            this.picReward.Size = new System.Drawing.Size(106, 76);
            this.picReward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReward.TabIndex = 3;
            this.picReward.TabStop = false;
            this.picReward.Click += new System.EventHandler(this.picReward_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.OldLace;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnClose.Location = new System.Drawing.Point(191, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnPack_Click);
            // 
            // btnClosePack
            // 
            this.btnClosePack.BackColor = System.Drawing.Color.OldLace;
            this.tableLayoutPanel1.SetColumnSpan(this.btnClosePack, 2);
            this.btnClosePack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosePack.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClosePack.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnClosePack.Location = new System.Drawing.Point(9, 6);
            this.btnClosePack.Name = "btnClosePack";
            this.btnClosePack.Size = new System.Drawing.Size(109, 25);
            this.btnClosePack.TabIndex = 0;
            this.btnClosePack.Text = "Close";
            this.btnClosePack.UseVisualStyleBackColor = false;
            this.btnClosePack.Click += new System.EventHandler(this.BtnPack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(375, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Gold: $0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl2, 2);
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl2.Location = new System.Drawing.Point(375, 127);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(116, 18);
            this.lbl2.TabIndex = 9;
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl4, 2);
            this.lbl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl4.Location = new System.Drawing.Point(192, 251);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(116, 18);
            this.lbl4.TabIndex = 11;
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl3, 2);
            this.lbl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl3.Location = new System.Drawing.Point(9, 251);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(116, 18);
            this.lbl3.TabIndex = 10;
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic4
            // 
            this.pic4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic4, 2);
            this.pic4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic4.Location = new System.Drawing.Point(192, 161);
            this.pic4.Name = "pic4";
            this.tableLayoutPanel1.SetRowSpan(this.pic4, 3);
            this.pic4.Size = new System.Drawing.Size(116, 87);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 5;
            this.pic4.TabStop = false;
            // 
            // pic3
            // 
            this.pic3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic3, 2);
            this.pic3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic3.Location = new System.Drawing.Point(9, 161);
            this.pic3.Name = "pic3";
            this.tableLayoutPanel1.SetRowSpan(this.pic3, 3);
            this.pic3.Size = new System.Drawing.Size(116, 87);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 4;
            this.pic3.TabStop = false;
            // 
            // lbl0
            // 
            this.lbl0.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl0, 2);
            this.lbl0.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl0.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl0.Location = new System.Drawing.Point(9, 127);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(116, 18);
            this.lbl0.TabIndex = 7;
            this.lbl0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl5, 2);
            this.lbl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl5.Location = new System.Drawing.Point(375, 251);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(116, 18);
            this.lbl5.TabIndex = 12;
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.351351F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.351351F));
            this.tableLayoutPanel1.Controls.Add(this.btnClosePack, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pic0, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pic1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.pic2, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.pic3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.pic4, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.pic5, 7, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbl0, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl1, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl2, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl3, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbl4, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbl5, 7, 9);
            this.tableLayoutPanel1.Controls.Add(this.label1, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDayCycle, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.097695F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.86718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.097695F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 288);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pic0
            // 
            this.pic0.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic0, 2);
            this.pic0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic0.Location = new System.Drawing.Point(9, 37);
            this.pic0.Name = "pic0";
            this.tableLayoutPanel1.SetRowSpan(this.pic0, 3);
            this.pic0.Size = new System.Drawing.Size(116, 87);
            this.pic0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic0.TabIndex = 1;
            this.pic0.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic1, 2);
            this.pic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic1.Location = new System.Drawing.Point(192, 37);
            this.pic1.Name = "pic1";
            this.tableLayoutPanel1.SetRowSpan(this.pic1, 3);
            this.pic1.Size = new System.Drawing.Size(116, 87);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 2;
            this.pic1.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic2, 2);
            this.pic2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic2.Location = new System.Drawing.Point(375, 37);
            this.pic2.Name = "pic2";
            this.tableLayoutPanel1.SetRowSpan(this.pic2, 3);
            this.pic2.Size = new System.Drawing.Size(116, 87);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 3;
            this.pic2.TabStop = false;
            // 
            // pic5
            // 
            this.pic5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.pic5, 2);
            this.pic5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic5.Location = new System.Drawing.Point(375, 161);
            this.pic5.Name = "pic5";
            this.tableLayoutPanel1.SetRowSpan(this.pic5, 3);
            this.pic5.Size = new System.Drawing.Size(116, 87);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic5.TabIndex = 6;
            this.pic5.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl1, 2);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl1.Location = new System.Drawing.Point(192, 127);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(116, 18);
            this.lbl1.TabIndex = 8;
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDayCycle
            // 
            this.lblDayCycle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDayCycle, 2);
            this.lblDayCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDayCycle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDayCycle.Location = new System.Drawing.Point(192, 3);
            this.lblDayCycle.Name = "lblDayCycle";
            this.lblDayCycle.Size = new System.Drawing.Size(116, 31);
            this.lblDayCycle.TabIndex = 14;
            this.lblDayCycle.Text = "Cycle Night";
            this.lblDayCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.tlpTable);
            this.Name = "QuestLog";
            this.Size = new System.Drawing.Size(300, 600);
            this.tlpTable.ResumeLayout(false);
            this.tlpTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlpTable;
        private Label lblTitle;
        private RichTextBox rtbDescription;
        private Label lblReward;
        private Button btnClose;
        private Button btnClosePack;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pic0;
        private PictureBox pic1;
        private PictureBox pic2;
        private PictureBox pic3;
        private PictureBox pic4;
        private PictureBox pic5;
        private Label lbl0;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Label label1;
        private Label lblDayCycle;
        private PictureBox picReward;
    }
}
