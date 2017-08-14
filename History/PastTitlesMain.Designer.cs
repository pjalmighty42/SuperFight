namespace Super_Fight.History.Titles
{
    partial class PastTitlesMain
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
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbSelCard = new System.Windows.Forms.ComboBox();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstChampHistory = new System.Windows.Forms.ListView();
            this.colDefNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShowTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpponents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDecision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.PowderBlue;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(40, 584);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(270, 70);
            this.button6.TabIndex = 32;
            this.button6.Text = "<< Back";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label3.Location = new System.Drawing.Point(888, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "Title History";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(774, 584);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 70);
            this.button3.TabIndex = 29;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblSubTitle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbSelCard);
            this.panel1.Controls.Add(this.lblCardTitle);
            this.panel1.Location = new System.Drawing.Point(67, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 434);
            this.panel1.TabIndex = 30;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblSubTitle.Location = new System.Drawing.Point(269, 41);
            this.lblSubTitle.MinimumSize = new System.Drawing.Size(163, 26);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(206, 26);
            this.lblSubTitle.TabIndex = 22;
            this.lblSubTitle.Text = "Champion\'s Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label5.Location = new System.Drawing.Point(804, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Select Title";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.lstChampHistory);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(19, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 333);
            this.panel2.TabIndex = 23;
            // 
            // cbSelCard
            // 
            this.cbSelCard.BackColor = System.Drawing.Color.Silver;
            this.cbSelCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelCard.FormattingEnabled = true;
            this.cbSelCard.Location = new System.Drawing.Point(627, 39);
            this.cbSelCard.Name = "cbSelCard";
            this.cbSelCard.Size = new System.Drawing.Size(277, 28);
            this.cbSelCard.TabIndex = 22;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblCardTitle.Location = new System.Drawing.Point(17, 36);
            this.lblCardTitle.MinimumSize = new System.Drawing.Size(129, 30);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(237, 30);
            this.lblCardTitle.TabIndex = 21;
            this.lblCardTitle.Text = "Current Champion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(849, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "History Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 47);
            this.label1.TabIndex = 27;
            this.label1.Text = "Super Fight!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Champion\'s History";
            // 
            // lstChampHistory
            // 
            this.lstChampHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDefNum,
            this.colShowTitle,
            this.colOpponents,
            this.colDecision});
            this.lstChampHistory.Location = new System.Drawing.Point(20, 39);
            this.lstChampHistory.Name = "lstChampHistory";
            this.lstChampHistory.Size = new System.Drawing.Size(843, 278);
            this.lstChampHistory.TabIndex = 34;
            this.lstChampHistory.UseCompatibleStateImageBehavior = false;
            // 
            // colDefNum
            // 
            this.colDefNum.Text = "#";
            this.colDefNum.Width = 10;
            // 
            // colShowTitle
            // 
            this.colShowTitle.Text = "Show Title";
            this.colShowTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colShowTitle.Width = 30;
            // 
            // colOpponents
            // 
            this.colOpponents.Text = "Opponents";
            this.colOpponents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOpponents.Width = 30;
            // 
            // colDecision
            // 
            this.colDecision.Width = 30;
            // 
            // PastTitlesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1064, 682);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "PastTitlesMain";
            this.Text = "History - Title History";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbSelCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstChampHistory;
        private System.Windows.Forms.ColumnHeader colDefNum;
        private System.Windows.Forms.ColumnHeader colShowTitle;
        private System.Windows.Forms.ColumnHeader colOpponents;
        private System.Windows.Forms.ColumnHeader colDecision;
    }
}