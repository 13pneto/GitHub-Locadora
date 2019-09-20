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

namespace Locadora.Views.Cadastrar
{
    /// <summary>
    /// Lógica interna para frmCadastrarCliente.xaml
    /// </summary>
    public partial class frmCadastrarCliente : Window
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
            txtCriadoEm.Text = DateTime.Now.ToString();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtCriadoEm.Clear();
            txtCPF.Clear();

            txtCriadoEm.Text = DateTime.Now.ToString();
            txtNome.Focus();
        }

        private void BtnCadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                Cliente c = new Cliente();
                c.Nome = txtNome.Text;
                c.Cpf = txtCPF.Text;

                if (txtNome.Text.Equals("") || txtCPF.Text.Equals(""))
                {
                    throw new Exception("É Obrigatório preencher todos os campos");
                }

                if (ClienteDAO.BuscarClientePorCPF(c) != null)
                {
                    throw new Exception("Cliente já cadastrado!");
                }

                ValidadorCPF.validaCpf(c.Cpf);

                PessoaDAO.CadastrarPessoa(c);
                MessageBox.Show("Cliente cadastrado com sucesso");

                LimparFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
}
}
