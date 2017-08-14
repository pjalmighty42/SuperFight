namespace Super_Fight.Continue.Ranking
{
    partial class CurrentRankings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentRankings));
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRankings = new System.Windows.Forms.DataGridView();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLosses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDraws = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxBrands = new System.Windows.Forms.ComboBox();
            this.cbxSpec = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblCompanyName.Location = new System.Drawing.Point(870, 109);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(166, 26);
            this.lblCompanyName.TabIndex = 15;
            this.lblCompanyName.Text = "Company Name";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(31, 600);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(255, 70);
            this.button4.TabIndex = 14;
            this.button4.Text = "<< Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(779, 600);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 70);
            this.button3.TabIndex = 11;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label6.Location = new System.Drawing.Point(810, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "Current Rankings";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.dgvRankings);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxBrands);
            this.panel1.Controls.Add(this.cbxSpec);
            this.panel1.Location = new System.Drawing.Point(86, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 439);
            this.panel1.TabIndex = 13;
            // 
            // dgvRankings
            // 
            this.dgvRankings.AllowUserToAddRows = false;
            this.dgvRankings.AllowUserToDeleteRows = false;
            this.dgvRankings.AllowUserToOrderColumns = true;
            this.dgvRankings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRankings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRank,
            this.colName,
            this.colTitles,
            this.colWins,
            this.colLosses,
            this.colDraws});
            this.dgvRankings.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvRankings.Location = new System.Drawing.Point(15, 80);
            this.dgvRankings.Name = "dgvRankings";
            this.dgvRankings.ReadOnly = true;
            this.dgvRankings.Size = new System.Drawing.Size(859, 342);
            this.dgvRankings.TabIndex = 21;
            // 
            // colRank
            // 
            this.colRank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRank.FillWeight = 10F;
            this.colRank.HeaderText = "Rnk #";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.FillWeight = 30F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colTitles
            // 
            this.colTitles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitles.FillWeight = 30F;
            this.colTitles.HeaderText = "Titles";
            this.colTitles.Name = "colTitles";
            this.colTitles.ReadOnly = true;
            // 
            // colWins
            // 
            this.colWins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWins.FillWeight = 10F;
            this.colWins.HeaderText = "Wins";
            this.colWins.Name = "colWins";
            this.colWins.ReadOnly = true;
            // 
            // colLosses
            // 
            this.colLosses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLosses.FillWeight = 10F;
            this.colLosses.HeaderText = "Losses";
            this.colLosses.Name = "colLosses";
            this.colLosses.ReadOnly = true;
            // 
            // colDraws
            // 
            this.colDraws.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDraws.FillWeight = 10F;
            this.colDraws.HeaderText = "Draws";
            this.colDraws.Name = "colDraws";
            this.colDraws.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(339, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "By Brand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "By Specalization";
            // 
            // cbxBrands
            // 
            this.cbxBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBrands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBrands.FormattingEnabled = true;
            this.cbxBrands.Location = new System.Drawing.Point(343, 34);
            this.cbxBrands.Name = "cbxBrands";
            this.cbxBrands.Size = new System.Drawing.Size(308, 32);
            this.cbxBrands.Sorted = true;
            this.cbxBrands.TabIndex = 18;
            this.cbxBrands.SelectedIndexChanged += new System.EventHandler(this.cbxBrands_SelectedIndexChanged);
            // 
            // cbxSpec
            // 
            this.cbxSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSpec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSpec.FormattingEnabled = true;
            this.cbxSpec.Items.AddRange(new object[] {
            "6-Man Tag Team",
            "8-Man Tag Team",
            "Singles",
            "Tag Team"});
            this.cbxSpec.Location = new System.Drawing.Point(15, 34);
            this.cbxSpec.Name = "cbxSpec";
            this.cbxSpec.Size = new System.Drawing.Size(308, 32);
            this.cbxSpec.Sorted = true;
            this.cbxSpec.TabIndex = 17;
            this.cbxSpec.SelectedIndexChanged += new System.EventHandler(this.cbxSpec_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // CurrentRankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1064, 682);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "CurrentRankings";
            this.Text = "Current Rankings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxBrands;
        private System.Windows.Forms.ComboBox cbxSpec;
        private System.Windows.Forms.DataGridView dgvRankings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLosses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDraws;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}