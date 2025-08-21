using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms02.Modelos;
using System.ComponentModel.DataAnnotations;
using WinForms02.Banco;

namespace WinForms02
{
    public partial class CadastroFuncionario : Form
    {
        private TelaPrincipal telaPrincipal;
        private Funcionario func;
        public CadastroFuncionario(TelaPrincipal tela)
        {
            telaPrincipal = tela;
            InitializeComponent();
        }

        public CadastroFuncionario(TelaPrincipal tela, long Id)
        {
            telaPrincipal = tela;
            InitializeComponent();

            func = FuncionarioDataAccess.PegarFuncionario(Id);
            FuncionarioParaTela(func);
        }

        private void FuncionarioParaTela(Funcionario funcionario)
        {
            TextNome.Text = funcionario.Nome;
            TextEmail.Text = funcionario.Email;
            TextSalario.Text = funcionario.Salario.ToString();
            if (funcionario.Sexo == "M")
            {
                SexoMasculino.Checked = true;
            } else
            {
                SexoFeminino.Checked = true;
            }
            if (funcionario.TipoContrato == "CLT")
            {
                TipoClt.Checked = true;
            }
            else if (funcionario.TipoContrato == "PJ")
            {
                TipoPj.Checked = true;
            } else
            {
                TipoAutonomo.Checked = true;
            }
        }

        private void SalvarAction(object sender, EventArgs e)
        {
            decimal salario;
            Funcionario funcionario;
            if (func != null)
            {
                funcionario = func;
            } else
            {
                funcionario = new Funcionario();
                funcionario.DataCadastro = DateTime.Now;
            }

            //Carregar
            funcionario.Nome = TextNome.Text;
            funcionario.Email = TextEmail.Text;
            if (decimal.TryParse(TextSalario.Text, out salario))
            {
                funcionario.Salario = salario;
            }
            funcionario.Sexo = (SexoMasculino.Checked) ? "M" : "F";
            funcionario.TipoContrato = (TipoClt.Checked) ? "CLT" : (TipoPj.Checked) ? "PJ" : "AUT";

            //Validar
            List<ValidationResult> listErrors = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(funcionario);
            bool validado = Validator.TryValidateObject(funcionario, contexto, listErrors, true);
            if (validado)
            {
                //Salvar
                if (func != null)
                {
                    FuncionarioDataAccess.AtualizarFuncionario(funcionario);
                    telaPrincipal.AtualizarTabela();
                } else
                {
                    FuncionarioDataAccess.SalvarFuncionario(funcionario);
                    telaPrincipal.AtualizarTabela();
                }

                this.Close();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationResult erro in listErrors)
                {
                    sb.Append(erro.ErrorMessage + "\n");
                }
                MsgErro.Text = sb.ToString();
            }
        }
    }
}
