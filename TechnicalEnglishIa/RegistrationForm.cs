using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TechnicalEnglishIa
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // --- DISEÑO PROFESIONAL DEL BOTÓN REGISTER ---
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 100, 200);
            btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 130, 255);

            btnRegister.Paint += (s, ev) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    btnRegister.ClientRectangle,
                    Color.FromArgb(0, 150, 255),  // color superior
                    Color.FromArgb(0, 100, 200),  // color inferior
                    90F))
                {
                    ev.Graphics.FillRectangle(brush, btnRegister.ClientRectangle);
                }

                TextRenderer.DrawText(ev.Graphics, btnRegister.Text, btnRegister.Font,
                    btnRegister.ClientRectangle, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            btnRegister.ForeColor = Color.White;
            btnRegister.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Text = "Register";
            btnRegister.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnRegister.Width, btnRegister.Height, 25, 25)
            );


            // --- DISEÑO PROFESIONAL DEL BOTÓN LOGIN ---
            btnLoginMe.FlatStyle = FlatStyle.Flat;
            btnLoginMe.FlatAppearance.BorderSize = 0;
            btnLoginMe.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 100, 200);
            btnLoginMe.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 130, 255);

            btnLoginMe.Paint += (s, ev) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    btnLoginMe.ClientRectangle,
                    Color.FromArgb(0, 150, 255),  // color superior
                    Color.FromArgb(0, 100, 200),  // color inferior
                    90F))
                {
                    ev.Graphics.FillRectangle(brush, btnLoginMe.ClientRectangle);
                }

                TextRenderer.DrawText(ev.Graphics, btnLoginMe.Text, btnLoginMe.Font,
                    btnLoginMe.ClientRectangle, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            btnLoginMe.ForeColor = Color.White;
            btnLoginMe.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);
            btnLoginMe.Cursor = Cursors.Hand;
            btnLoginMe.Text = "Login";
            btnLoginMe.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnLoginMe.Width, btnLoginMe.Height, 25, 25)
            );
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string FirstName = txtFirtsName.Text;
            string LastName = txtLastName.Text;
            string UserName = txtUserName.Text;
            string Email = txtEmail.Text;
            string Gender = cmbGender.Text;
            string Pass = txtPass.Text;
            string ConfirmPass = txtConfirmPass.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show("First Name field is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show("Last Name field is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("User Name field is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Email field is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(ConfirmPass))
            {
                MessageBox.Show("Password fields cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Pass.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar coincidencia de contraseñas
            if (ConfirmPass != Pass)
            {
                MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todo es correcto
            MessageBox.Show("User has been registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            User user = new User(FirstName,LastName,UserName,Email,Gender,Pass,ConfirmPass);
            UserManager userManager = new UserManager();

            if (userManager.AddUser(user))
            {
                MessageBox.Show("User has been Registeresd successfully");
                this.ShowLoginForm();
            }
            else
            {
                MessageBox.Show("User with this Email has already exists");
            }
        }


        // Importación de la función para bordes redondeados
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoginMe_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
