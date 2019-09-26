using Locadora.DAL;
using Locadora.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VendasConsole.Utils;

namespace Locadora.Views
{
    /// <summary>
    /// Lógica interna para frmCadastrarFuncionario.xaml
    /// </summary>
    public partial class frmCadastrarFuncionario : Window
    {
        public frmCadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNomeFunc.Clear();
            txtSalarioFunc.Clear();
            txtCPFFunc.Clear();
            txtComissaoFunc.Clear();

            txtCriadoEm.Text = DateTime.Now.ToString();
            txtNomeFunc.Focus();
        }

        private void BtnCadastrarFunc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funcionario f = new Funcionario();
                f.Nome = txtNomeFunc.Text;
                f.Cpf = txtCPFFunc.Text;
                ValidadorCPF.validaCpf(f.Cpf);

                f.Salario = Convert.ToDouble(txtSalarioFunc.Text);
                f.Comissao = Convert.ToDouble(txtComissaoFunc.Text);

                if (txtNomeFunc.Text.Equals("") || txtCPFFunc.Text.Equals("") || txtSalarioFunc.Text.Equals("") || txtComissaoFunc.Text.Equals(""))
                {
                    throw new Exception("É Obrigatório preencher todos os campos");
                }

                if (FuncionarioDAO.BuscarFuncionarioPorCPF(f) != null)
                {
                    throw new Exception("Funcionario já cadastrado!");
                }

                ValidadorCPF.validaCpf(f.Cpf);

                PessoaDAO.CadastrarPessoa(f);
                MessageBox.Show("Funcionario cadastrado com sucesso");

                LimparFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
