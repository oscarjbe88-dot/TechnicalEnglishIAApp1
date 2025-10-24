using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Importante para el degradado
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TechnicalEnglishIa
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            string Password = txtPass.Text;

            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email Field is required");
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Password Field is required");
                return;
            }

            UserManager userManager = new UserManager();
            User user = userManager.LoginUser(Email, Password);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials, please try again");
                return;
            }

            MessageBox.Show($"Hello, {user.UserName}");

            // ✅ ABRIR EL FORMULARIO PRINCIPAL DESPUÉS DEL LOGIN EXITOSO
            this.Hide(); // Oculta el formulario de login
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.ShowDialog(); // Muestra el formulario principal (traductor)
            this.Close(); // Cierra el formulario de login cuando se cierre el principal
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // -------------------------------
        // DISEÑO ELEGANTE DEL BOTÓN LOGIN
        // -------------------------------
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // --- DISEÑO ELEGANTE DEL BOTÓN LOGIN ---
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;

            btnLogin.Paint += (s, ev) =>
            {
                // Degradado elegante azul
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    btnLogin.ClientRectangle,
                    Color.FromArgb(0, 160, 255),   // Azul claro superior
                    Color.FromArgb(0, 100, 200),   // Azul oscuro inferior
                    90F))
                {
                    ev.Graphics.FillRectangle(brush, btnLogin.ClientRectangle);
                }

                // Bordes redondeados
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radio = 25;
                    Rectangle rect = btnLogin.ClientRectangle;
                    path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                    path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                    path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                    path.CloseAllFigures();
                    btnLogin.Region = new Region(path);
                }

                // Texto centrado
                TextRenderer.DrawText(ev.Graphics, btnLogin.Text, btnLogin.Font,
                    btnLogin.ClientRectangle, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // Propiedades visuales
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI Semibold", 10, FontStyle.Regular);
            btnLogin.Text = "Login";

            // Efectos de color al pasar el mouse
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 130, 255);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 90, 200);

            // Bordes redondeados iniciales
            btnLogin.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 25, 25)
            );
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
