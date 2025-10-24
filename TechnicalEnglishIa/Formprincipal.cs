using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalEnglishIa
{
    public partial class FormPrincipal : Form
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.mymemory.translated.net/")
        };

        // 🔹 Diccionario técnico por carrera
        private readonly Dictionary<string, Dictionary<string, (string traduccion, string explicacion)>> diccionarioProfesional
            = new Dictionary<string, Dictionary<string, (string, string)>>()
            {
                ["Medicina"] = new Dictionary<string, (string, string)>()
                {
                    ["red"] = ("network", "En medicina, 'network' puede referirse a una red hospitalaria o de salud."),
                    ["célula"] = ("cell", "‘Cell’ se usa para referirse a la unidad básica de los tejidos."),
                    ["tejido"] = ("tissue", "‘Tissue’ se usa para describir un grupo de células con una función específica."),
                    ["sistema"] = ("system", "En este contexto, puede ser ‘nervous system’, ‘digestive system’, etc."),
                    ["músculo"] = ("muscle", "‘Muscle’ es el tejido que permite el movimiento del cuerpo."),
                    ["cirugía"] = ("surgery", "‘Surgery’ se refiere a un procedimiento médico que implica una operación."),
                    ["enfermedad"] = ("disease", "‘Disease’ describe una condición anormal que afecta al organismo."),
                    ["síntoma"] = ("symptom", "‘Symptom’ es una manifestación de una enfermedad o condición."),
                    ["tratamiento"] = ("treatment", "‘Treatment’ es el proceso para curar o aliviar una enfermedad."),
                    ["diagnóstico"] = ("diagnosis", "‘Diagnosis’ es la identificación de una enfermedad a partir de sus signos y síntomas.")
                },

                ["Derecho"] = new Dictionary<string, (string, string)>()
                {
                    ["caso"] = ("case", "En derecho, ‘case’ se refiere a un proceso judicial."),
                    ["sentencia"] = ("ruling", "‘Ruling’ es la decisión formal de un juez o tribunal."),
                    ["contrato"] = ("contract", "‘Contract’ es un acuerdo legal vinculante entre partes."),
                    ["acusado"] = ("defendant", "‘Defendant’ se usa para designar a la persona acusada en un juicio."),
                    ["demanda"] = ("lawsuit", "‘Lawsuit’ es una acción legal presentada ante un tribunal."),
                    ["ley"] = ("law", "‘Law’ es el conjunto de normas que rigen una sociedad."),
                    ["abogado"] = ("lawyer", "‘Lawyer’ es el profesional que asesora y representa a clientes en asuntos legales."),
                    ["testigo"] = ("witness", "‘Witness’ es la persona que da testimonio en un juicio."),
                    ["juicio"] = ("trial", "‘Trial’ es el proceso formal donde se determina la culpabilidad o inocencia."),
                    ["evidencia"] = ("evidence", "‘Evidence’ es la información presentada para probar un hecho en el tribunal.")
                },

                ["Ingeniería de Sistemas"] = new Dictionary<string, (string, string)>()
                {
                    ["red"] = ("network", "En ingeniería de sistemas, ‘network’ se refiere a una red de computadoras."),
                    ["base de datos"] = ("database", "‘Database’ es un sistema para almacenar información estructurada."),
                    ["sistema"] = ("system", "‘System’ se refiere a un conjunto de componentes interconectados."),
                    ["servidor"] = ("server", "‘Server’ es el equipo o software que proporciona servicios a otros equipos."),
                    ["algoritmo"] = ("algorithm", "‘Algorithm’ es un conjunto de instrucciones para resolver un problema."),
                    ["programa"] = ("program", "‘Program’ es un conjunto de instrucciones que ejecuta una computadora."),
                    ["usuario"] = ("user", "‘User’ es la persona que interactúa con el sistema."),
                    ["red neuronal"] = ("neural network", "‘Neural network’ es un modelo de inteligencia artificial inspirado en el cerebro humano."),
                    ["protocolo"] = ("protocol", "‘Protocol’ es un conjunto de reglas para la comunicación entre sistemas."),
                    ["código"] = ("code", "‘Code’ es el conjunto de instrucciones escritas en un lenguaje de programación.")
                },

                ["Administración de Empresas"] = new Dictionary<string, (string, string)>()
                {
                    ["empresa"] = ("company", "‘Company’ se usa para referirse a una organización de negocios."),
                    ["ingresos"] = ("revenue", "‘Revenue’ son los ingresos totales antes de gastos."),
                    ["mercado"] = ("market", "‘Market’ se refiere al entorno donde se intercambian bienes y servicios."),
                    ["inversión"] = ("investment", "‘Investment’ es el acto de destinar recursos para generar beneficios."),
                    ["beneficio"] = ("profit", "‘Profit’ es la ganancia obtenida tras deducir los costos."),
                    ["empleado"] = ("employee", "‘Employee’ es la persona contratada para trabajar en una organización."),
                    ["gestión"] = ("management", "‘Management’ se refiere al proceso de administrar recursos de manera eficiente."),
                    ["presupuesto"] = ("budget", "‘Budget’ es la planificación financiera de ingresos y gastos."),
                    ["estrategia"] = ("strategy", "‘Strategy’ es el plan de acción para alcanzar objetivos empresariales."),
                    ["liderazgo"] = ("leadership", "‘Leadership’ se refiere a la capacidad de guiar y motivar a un grupo hacia una meta común.")
                }
            };


        public FormPrincipal()
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "TechnicalEnglishIA/1.0");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.Timeout = TimeSpan.FromSeconds(20);
            AplicarEstiloFormulario();
        }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            cmbIdiomaOrigen.Items.AddRange(new string[]
            {
                "Español", "Inglés", "Francés", "Alemán", "Portugués", "Italiano"
            });
            cmbIdiomaOrigen.SelectedItem = "Español";

            cmbIdiomaDestino.Items.AddRange(new string[]
            {
                "Inglés", "Francés", "Alemán", "Portugués", "Italiano"
            });
            cmbIdiomaDestino.SelectedItem = "Inglés";

            cmbCampoProfesional.Items.AddRange(diccionarioProfesional.Keys.ToArray());
            cmbCampoProfesional.SelectedItem = "Ingeniería de Sistemas";
        }

        // ======================================================
        // 🔹 FUNCIÓN DE TRADUCCIÓN CON CONTEXTO PROFESIONAL
        // ======================================================
        private async Task<string> TraducirTexto(string texto, string origen, string destino, string campoProfesional)
        {
            try
            {
                string langPair = $"{idiomaToCode(origen)}|{idiomaToCode(destino)}";
                string url = $"get?q={Uri.EscapeDataString(texto)}&langpair={langPair}";
                var resp = await httpClient.GetAsync(url);
                string cuerpo = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    return $"❌ HTTP {(int)resp.StatusCode} - {resp.ReasonPhrase}\n{cuerpo}";

                var jobj = JObject.Parse(cuerpo);
                string traduccion = jobj["responseData"]?["translatedText"]?.ToString() ?? "Traducción no disponible";

                // ✅ Aplicar contexto profesional con Regex
                if (diccionarioProfesional.ContainsKey(campoProfesional))
                {
                    var diccionario = diccionarioProfesional[campoProfesional];
                    var explicaciones = new StringBuilder();

                    foreach (var kvp in diccionario)
                    {
                        if (texto.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var regex = new Regex(Regex.Escape(kvp.Key), RegexOptions.IgnoreCase);
                            traduccion = regex.Replace(traduccion, kvp.Value.traduccion);

                            explicaciones.AppendLine($"• {kvp.Key} → {kvp.Value.traduccion}: {kvp.Value.explicacion}");
                        }
                    }

                    if (explicaciones.Length > 0)
                    {
                        traduccion +=
                            "\r\n\r\n──────────────────────────────\r\n" +
                            "📘 Explicaciones Técnicas\r\n" +
                            "──────────────────────────────\r\n" +
                            explicaciones.ToString();
                    }
                }

                return traduccion;
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
            }
        }

        private string idiomaToCode(string idioma)
        {
            switch (idioma)
            {
                case "Español": return "es";
                case "Inglés": return "en";
                case "Francés": return "fr";
                case "Alemán": return "de";
                case "Portugués": return "pt";
                case "Italiano": return "it";
                default: return "en";
            }
        }

        private async void btnTraducir_Click(object sender, EventArgs e)
        {
            string texto = txtTextoEntrada.Text;
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Por favor, escribe un texto para traducir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idiomaOrigen = cmbIdiomaOrigen.SelectedItem.ToString();
            string idiomaDestino = cmbIdiomaDestino.SelectedItem.ToString();
            string campoProfesional = cmbCampoProfesional.SelectedItem.ToString();

            txtTraduccion.Text = "⏳ Traduciendo...";
            btnTraducir.Enabled = false;

            string traduccion = await TraducirTexto(texto, idiomaOrigen, idiomaDestino, campoProfesional);

            txtTraduccion.Text = traduccion;
            btnTraducir.Enabled = true;
        }

        // ======================================================
        // 🎨 ESTILO MODERNO DEL FORMULARIO
        // ======================================================
        private void AplicarEstiloFormulario()
        {
            this.BackColor = Color.FromArgb(233, 237, 242);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            foreach (var lbl in this.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.FromArgb(30, 50, 90);
                lbl.Font = new Font("Segoe UI Semibold", 10);
            }

            foreach (var cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.FlatStyle = FlatStyle.Flat;
                cmb.Font = new Font("Segoe UI", 10);
                cmb.BackColor = Color.White;
                cmb.ForeColor = Color.FromArgb(40, 40, 40);
            }

            foreach (var txt in this.Controls.OfType<TextBox>())
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10);
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.Multiline = true;
                txt.ScrollBars = ScrollBars.Vertical;
            }

            btnTraducir.BackColor = Color.FromArgb(0, 112, 204);
            btnTraducir.ForeColor = Color.White;
            btnTraducir.Font = new Font("Segoe UI Semibold", 11);
            btnTraducir.FlatStyle = FlatStyle.Flat;
            btnTraducir.FlatAppearance.BorderSize = 0;
            btnTraducir.Cursor = Cursors.Hand;

            btnTraducir.MouseEnter += (s, e) => btnTraducir.BackColor = Color.FromArgb(0, 130, 230);
            btnTraducir.MouseLeave += (s, e) => btnTraducir.BackColor = Color.FromArgb(0, 112, 204);
        }
    }
}
