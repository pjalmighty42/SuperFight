namespace Super_Fight.Continue.Create.Teams
{
    partial class TeamsMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamsMain));
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAsscBrand = new System.Windows.Forms.ComboBox();
            this.lbSelected = new System.Windows.Forms.ListBox();
            this.rb8ManTagTeam = new System.Windows.Forms.RadioButton();
            this.rb6ManTagTeam = new System.Windows.Forms.RadioButton();
            this.rbTagTeam = new System.Windows.Forms.RadioButton();
            this.btnRem = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbRoster = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTeamName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(781, 588);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(255, 70);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxAsscBrand);
            this.panel1.Controls.Add(this.lbSelected);
            this.panel1.Controls.Add(this.rb8ManTagTeam);
            this.panel1.Controls.Add(this.rb6ManTagTeam);
            this.panel1.Controls.Add(this.rbTagTeam);
            this.panel1.Controls.Add(this.btnRem);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lbRoster);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbTeamName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(135, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 394);
            this.panel1.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label5.Location = new System.Drawing.Point(216, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 26);
            this.label5.TabIndex = 30;
            this.label5.Text = "Select Brand";
            // 
            // cbxAsscBrand
            // 
            this.cbxAsscBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAsscBrand.Enabled = false;
            this.cbxAsscBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAsscBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAsscBrand.FormattingEnabled = true;
            this.cbxAsscBrand.Location = new System.Drawing.Point(363, 88);
            this.cbxAsscBrand.Name = "cbxAsscBrand";
            this.cbxAsscBrand.Size = new System.Drawing.Size(307, 28);
            this.cbxAsscBrand.TabIndex = 29;
            this.cbxAsscBrand.SelectedIndexChanged += new System.EventHandler(this.cbxAsscBrand_SelectedIndexChanged);
            // 
            // lbSelected
            // 
            this.lbSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelected.FormattingEnabled = true;
            this.lbSelected.ItemHeight = 20;
            this.lbSelected.Location = new System.Drawing.Point(480, 212);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(289, 144);
            this.lbSelected.Sorted = true;
            this.lbSelected.TabIndex = 28;
            this.lbSelected.SelectedIndexChanged += new System.EventHandler(this.lbSelected_SelectedIndexChanged);
            // 
            // rb8ManTagTeam
            // 
            this.rb8ManTagTeam.AutoSize = true;
            this.rb8ManTagTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb8ManTagTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb8ManTagTeam.Location = new System.Drawing.Point(523, 131);
            this.rb8ManTagTeam.Name = "rb8ManTagTeam";
            this.rb8ManTagTeam.Size = new System.Drawing.Size(164, 24);
            this.rb8ManTagTeam.TabIndex = 27;
            this.rb8ManTagTeam.TabStop = true;
            this.rb8ManTagTeam.Text = "New 8-Man Team";
            this.rb8ManTagTeam.UseVisualStyleBackColor = true;
            this.rb8ManTagTeam.CheckedChanged += new System.EventHandler(this.rb8ManTagTeam_CheckedChanged);
            // 
            // rb6ManTagTeam
            // 
            this.rb6ManTagTeam.AutoSize = true;
            this.rb6ManTagTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb6ManTagTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb6ManTagTeam.Location = new System.Drawing.Point(323, 131);
            this.rb6ManTagTeam.Name = "rb6ManTagTeam";
            this.rb6ManTagTeam.Size = new System.Drawing.Size(164, 24);
            this.rb6ManTagTeam.TabIndex = 26;
            this.rb6ManTagTeam.TabStop = true;
            this.rb6ManTagTeam.Text = "New 6-Man Team";
            this.rb6ManTagTeam.UseVisualStyleBackColor = true;
            this.rb6ManTagTeam.CheckedChanged += new System.EventHandler(this.rb6ManTagTeam_CheckedChanged);
            // 
            // rbTagTeam
            // 
            this.rbTagTeam.AutoSize = true;
            this.rbTagTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbTagTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTagTeam.Location = new System.Drawing.Point(150, 131);
            this.rbTagTeam.Name = "rbTagTeam";
            this.rbTagTeam.Size = new System.Drawing.Size(144, 24);
            this.rbTagTeam.TabIndex = 25;
            this.rbTagTeam.TabStop = true;
            this.rbTagTeam.Text = "New Tag Team";
            this.rbTagTeam.UseVisualStyleBackColor = true;
            this.rbTagTeam.CheckedChanged += new System.EventHandler(this.rbTagTeam_CheckedChanged);
            // 
            // btnRem
            // 
            this.btnRem.BackColor = System.Drawing.Color.LightBlue;
            this.btnRem.FlatAppearance.BorderSize = 0;
            this.btnRem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRem.Location = new System.Drawing.Point(368, 299);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(75, 48);
            this.btnRem.TabIndex = 24;
            this.btnRem.Text = "<<";
            this.btnRem.UseVisualStyleBackColor = false;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(368, 221);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 48);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbRoster
            // 
            this.lbRoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoster.FormattingEnabled = true;
            this.lbRoster.ItemHeight = 20;
            this.lbRoster.Location = new System.Drawing.Point(40, 193);
            this.lbRoster.Name = "lbRoster";
            this.lbRoster.Size = new System.Drawing.Size(289, 184);
            this.lbRoster.Sorted = true;
            this.lbRoster.TabIndex = 21;
            this.lbRoster.SelectedIndexChanged += new System.EventHandler(this.lbRoster_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label3.Location = new System.Drawing.Point(326, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "Add Wrestlers";
            // 
            // tbTeamName
            // 
            this.tbTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTeamName.Location = new System.Drawing.Point(363, 45);
            this.tbTeamName.Name = "tbTeamName";
            this.tbTeamName.Size = new System.Drawing.Size(307, 29);
            this.tbTeamName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(171, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "New Team Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Create New Team";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(27, 588);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(255, 70);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label7.Location = new System.Drawing.Point(879, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 31);
            this.label7.TabIndex = 28;
            this.label7.Text = "New Team";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label6.Location = new System.Drawing.Point(851, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 31);
            this.label6.TabIndex = 27;
            this.label6.Text = "Create Mode";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // TeamsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "TeamsMain";
            this.Text = "Create - Teams - Main Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbRoster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTeamName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb8ManTagTeam;
        private System.Windows.Forms.RadioButton rb6ManTagTeam;
        private System.Windows.Forms.RadioButton rbTagTeam;
        private System.Windows.Forms.ListBox lbSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAsscBrand;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}