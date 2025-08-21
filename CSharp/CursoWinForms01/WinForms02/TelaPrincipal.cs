using WinForms02.Banco;

namespace WinForms02
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();

            AtualizarTabela();
        }

        public void AtualizarTabela()
        {
            TabelaFuncionarios.DataSource = Banco.FuncionarioDataAccess.ObterLista();
        }

        private void NovoAction(object sender, EventArgs e)
        {
            new CadastroFuncionario(this).Show();
        }

        private void EditarAction(object sender, EventArgs e)
        {
            if (TabelaFuncionarios.SelectedRows.Count > 0)
            {
                long id = Convert.ToInt64(TabelaFuncionarios.SelectedRows[0].Cells[0].Value);
                new CadastroFuncionario(this, id).Show();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para editar.");
            }
        }

        private void ExcluirAction(object sender, EventArgs e)
        {
            if (TabelaFuncionarios.SelectedRows.Count > 0)
            {
                long id = Convert.ToInt64(TabelaFuncionarios.SelectedRows[0].Cells[0].Value);
                FuncionarioDataAccess.ExcluirFuncionario(id);
                AtualizarTabela();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
            }
        }
    }
}
