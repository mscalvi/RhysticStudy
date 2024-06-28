namespace Bingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string Frase = string.Format("{0}, só questão de tempo!", txtNome.Text);
            MessageBox.Show(Frase, "Bora!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
