namespace Database_Project
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rbtnadmin = new System.Windows.Forms.RadioButton();
            this.rbtnstaff = new System.Windows.Forms.RadioButton();
            this.rbtncustomer = new System.Windows.Forms.RadioButton();
            this.rbtnshipper = new System.Windows.Forms.RadioButton();
            this.linkSignup = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(649, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(605, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(606, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // emailbox
            // 
            this.emailbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailbox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailbox.Location = new System.Drawing.Point(609, 263);
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(318, 22);
            this.emailbox.TabIndex = 3;
            // 
            // passwordbox
            // 
            this.passwordbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordbox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordbox.Location = new System.Drawing.Point(609, 345);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '*';
            this.passwordbox.Size = new System.Drawing.Size(318, 22);
            this.passwordbox.TabIndex = 4;
            this.passwordbox.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(704, 427);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(10);
            this.btnLogin.Size = new System.Drawing.Size(115, 47);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(394, 611);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // rbtnadmin
            // 
            this.rbtnadmin.AutoSize = true;
            this.rbtnadmin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnadmin.ForeColor = System.Drawing.Color.White;
            this.rbtnadmin.Location = new System.Drawing.Point(609, 382);
            this.rbtnadmin.Name = "rbtnadmin";
            this.rbtnadmin.Size = new System.Drawing.Size(69, 21);
            this.rbtnadmin.TabIndex = 7;
            this.rbtnadmin.TabStop = true;
            this.rbtnadmin.Text = "Admin";
            this.rbtnadmin.UseVisualStyleBackColor = true;
            this.rbtnadmin.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbtnstaff
            // 
            this.rbtnstaff.AutoSize = true;
            this.rbtnstaff.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnstaff.ForeColor = System.Drawing.Color.White;
            this.rbtnstaff.Location = new System.Drawing.Point(781, 382);
            this.rbtnstaff.Name = "rbtnstaff";
            this.rbtnstaff.Size = new System.Drawing.Size(54, 21);
            this.rbtnstaff.TabIndex = 8;
            this.rbtnstaff.TabStop = true;
            this.rbtnstaff.Text = "Staff";
            this.rbtnstaff.UseVisualStyleBackColor = true;
            // 
            // rbtncustomer
            // 
            this.rbtncustomer.AutoSize = true;
            this.rbtncustomer.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtncustomer.ForeColor = System.Drawing.Color.White;
            this.rbtncustomer.Location = new System.Drawing.Point(684, 382);
            this.rbtncustomer.Name = "rbtncustomer";
            this.rbtncustomer.Size = new System.Drawing.Size(91, 21);
            this.rbtncustomer.TabIndex = 9;
            this.rbtncustomer.TabStop = true;
            this.rbtncustomer.Text = "Customer";
            this.rbtncustomer.UseVisualStyleBackColor = true;
            // 
            // rbtnshipper
            // 
            this.rbtnshipper.AutoSize = true;
            this.rbtnshipper.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnshipper.ForeColor = System.Drawing.Color.White;
            this.rbtnshipper.Location = new System.Drawing.Point(851, 382);
            this.rbtnshipper.Name = "rbtnshipper";
            this.rbtnshipper.Size = new System.Drawing.Size(76, 21);
            this.rbtnshipper.TabIndex = 10;
            this.rbtnshipper.TabStop = true;
            this.rbtnshipper.Text = "Shipper";
            this.rbtnshipper.UseVisualStyleBackColor = true;
            // 
            // linkSignup
            // 
            this.linkSignup.AutoSize = true;
            this.linkSignup.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSignup.LinkColor = System.Drawing.Color.White;
            this.linkSignup.Location = new System.Drawing.Point(740, 492);
            this.linkSignup.Name = "linkSignup";
            this.linkSignup.Size = new System.Drawing.Size(47, 15);
            this.linkSignup.TabIndex = 11;
            this.linkSignup.TabStop = true;
            this.linkSignup.Text = "SignUp";
            this.linkSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSignup_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(610, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1031, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 37);
            this.button1.TabIndex = 67;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1062, 606);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkSignup);
            this.Controls.Add(this.rbtnshipper);
            this.Controls.Add(this.rbtncustomer);
            this.Controls.Add(this.rbtnstaff);
            this.Controls.Add(this.rbtnadmin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.emailbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Button btnLogin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rbtnadmin;
        private System.Windows.Forms.RadioButton rbtnstaff;
        private System.Windows.Forms.RadioButton rbtncustomer;
        private System.Windows.Forms.RadioButton rbtnshipper;
        private System.Windows.Forms.LinkLabel linkSignup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

