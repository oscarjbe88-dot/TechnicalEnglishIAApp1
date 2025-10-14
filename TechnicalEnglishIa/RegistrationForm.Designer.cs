namespace TechnicalEnglishIa
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirtsName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoginMe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "FirtsName :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "LastName :";
            // 
            // txtFirtsName
            // 
            this.txtFirtsName.Location = new System.Drawing.Point(222, 116);
            this.txtFirtsName.Name = "txtFirtsName";
            this.txtFirtsName.Size = new System.Drawing.Size(190, 22);
            this.txtFirtsName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(499, 116);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(190, 22);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "UserName :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(352, 164);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(190, 22);
            this.txtUserName.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(352, 208);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(190, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(352, 286);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(190, 22);
            this.txtPass.TabIndex = 10;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password :";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(352, 329);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(190, 22);
            this.txtConfirmPass.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "ConfirmPassword :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(352, 248);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(190, 24);
            this.cmbGender.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(319, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 32);
            this.label8.TabIndex = 14;
            this.label8.Text = "Registration Form";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRegister.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(222, 379);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(161, 36);
            this.btnRegister.TabIndex = 15;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoginMe
            // 
            this.btnLoginMe.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoginMe.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginMe.Location = new System.Drawing.Point(421, 379);
            this.btnLoginMe.Name = "btnLoginMe";
            this.btnLoginMe.Size = new System.Drawing.Size(161, 36);
            this.btnLoginMe.TabIndex = 17;
            this.btnLoginMe.Text = "LOGIN";
            this.btnLoginMe.UseVisualStyleBackColor = false;
            this.btnLoginMe.Click += new System.EventHandler(this.btnLoginMe_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginMe);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirtsName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirtsName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoginMe;
    }
}

