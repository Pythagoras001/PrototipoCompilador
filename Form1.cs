using com.calitha.goldparser;

namespace pAnalizadorDeCodigo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Configuramos el color de fondo y de letra del text Box del editor
            TextBoxEditor.BackColor = ColorTranslator.FromHtml("#150A2B");
            TextBoxEditor.ForeColor = ColorTranslator.FromHtml("#60c3fe");
            TextBoxEditor.Font = new Font("Consolas", 12, FontStyle.Bold);

            // Configuramos el color de fondo y de letra del text Box consola
            TextBoxConsola.BackColor = ColorTranslator.FromHtml("#b8b2ca");

            // Configuramos el color de fondo del form1
            this.BackColor = ColorTranslator.FromHtml("#0E0A17");
        }

        private void buttonAnalizar_Click(object sender, EventArgs e)
        {
            // Limpiamos la consola
            TextBoxConsola.Clear();

            // Crear la intancia MyParser generada 
            MyParser analizador = new MyParser(Application.StartupPath + "\\Gramatica1.cgt");
            analizador.Parse(TextBoxEditor.Text);

            // Muestra en pantalla la validez de la cadena
            TextBoxConsola.Text = analizador.getCadenaErrores();

            // Cambiamos el color dependiendo de la salida de la consola
            if (TextBoxConsola.Text != "Todo salio Bien")
            {
                TextBoxConsola.ForeColor = ColorTranslator.FromHtml("#ac0975");
            }
            else {
                TextBoxConsola.ForeColor = ColorTranslator.FromHtml("#060044");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpia el text Box del editor
            TextBoxEditor.Clear();
            TextBoxConsola.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
