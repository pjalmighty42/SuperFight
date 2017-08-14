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
            this.cbxMatchType = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxBrands = new System.Windows.Forms.ComboBox();
            this.myListView1 = new Super_Fight.Helpers.MyListView();
            this.colRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLosses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDraws = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHasTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxMatchType
            // 
            this.cbxMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMatchType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMatchType.FormattingEnabled = true;
            this.cbxMatchType.Items.AddRange(new object[] {
            "6-Man Tag Rankings",
            "8-Man Tag Rankings",
            "Singles Rankings",
            "Tag Team Rankings"});
            this.cbxMatchType.Location = new System.Drawing.Point(113, 134);
            this.cbxMatchType.Name = "cbxMatchType";
            this.cbxMatchType.Size = new System.Drawing.Size(308, 32);
            this.cbxMatchType.Sorted = true;
            this.cbxMatchType.TabIndex = 17;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblDate.Location = new System.Drawing.Point(741, 142);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 24);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "MM/YYYY";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblCompanyName.Location = new System.Drawing.Point(870, 109);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(164, 24);
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
            this.button4.Location = new System.Drawing.Point(31, 581);
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
            this.button3.Location = new System.Drawing.Point(779, 581);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 70);
            this.button3.TabIndex = 11;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.myListView1);
            this.panel1.Location = new System.Drawing.Point(113, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 371);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label6.Location = new System.Drawing.Point(810, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "Current Rankings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 47);
            this.label4.TabIndex = 10;
            this.label4.Text = "Super Fight!";
            // 
            // cbxBrands
            // 
            this.cbxBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBrands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBrands.FormattingEnabled = true;
            this.cbxBrands.Location = new System.Drawing.Point(427, 134);
            this.cbxBrands.Name = "cbxBrands";
            this.cbxBrands.Size = new System.Drawing.Size(308, 32);
            this.cbxBrands.Sorted = true;
            this.cbxBrands.TabIndex = 18;
            // 
            // myListView1
            // 
            this.myListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRank,
            this.colNames,
            this.colWins,
            this.colLosses,
            this.colDraws,
            this.colHasTitle,
            this.colTitles});
            this.myListView1.Location = new System.Drawing.Point(23, 17);
            this.myListView1.Name = "myListView1";
            this.myListView1.ReadOnly = true;
            this.myListView1.Size = new System.Drawing.Size(804, 336);
            this.myListView1.TabIndex = 0;
            this.myListView1.UseCompatibleStateImageBehavior = false;
            // 
            // colRank
            // 
            this.colRank.Text = "#";
            this.colRank.Width = 10;
            // 
            // colNames
            // 
            this.colNames.Text = "Name";
            this.colNames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNames.Width = 25;
            // 
            // colWins
            // 
            this.colWins.Text = "W";
            this.colWins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colWins.Width = 10;
            // 
            // colLosses
            // 
            this.colLosses.Text = "L";
            this.colLosses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLosses.Width = 10;
            // 
            // colDraws
            // 
            this.colDraws.Text = "D";
            this.colDraws.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDraws.Width = 10;
            // 
            // colHasTitle
            // 
            this.colHasTitle.Text = "Titles?";
            this.colHasTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHasTitle.Width = 10;
            // 
            // colTitles
            // 
            this.colTitles.Text = "Titles Owned";
            this.colTitles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTitles.Width = 25;
            // 
            // CurrentRankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1064, 682);
            this.Controls.Add(this.cbxBrands);
            this.Controls.Add(this.cbxMatchType);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "CurrentRankings";
            this.Text = "Current Rankings";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMatchType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxBrands;
        private Helpers.MyListView myListView1;
        private System.Windows.Forms.ColumnHeader colRank;
        private System.Windows.Forms.ColumnHeader colNames;
        private System.Windows.Forms.ColumnHeader colWins;
        private System.Windows.Forms.ColumnHeader colLosses;
        private System.Windows.Forms.ColumnHeader colDraws;
        private System.Windows.Forms.ColumnHeader colHasTitle;
        private System.Windows.Forms.ColumnHeader colTitles;
    }
}