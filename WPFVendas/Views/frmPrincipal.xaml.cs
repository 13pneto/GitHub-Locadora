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
using Locadora.Views.Cadastrar;
using Locadora.Views.Locacao;
using Locadora.Views.Excluir;
using Locadora.Views.Editar;
using Locadora.Views.Listar;
using Locadora.Views.Relatorios;

namespace Locadora.Views
{
    /// <summary>
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar a janela?",
                "WPF Vendas", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void MenuItem_CadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarCliente c = new frmCadastrarCliente();
            c.ShowDialog();
        }

        private void MenuItem_CadastrarFilme_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarFilme c = new frmCadastrarFilme();
            c.ShowDialog();
        }

        private void MenuItem_CadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarFuncionario c = new frmCadastrarFuncionario();
            c.ShowDialog();
        }

        private void MenuItem_CadastrarPremio_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPremio c = new frmCadastrarPremio();
            c.ShowDialog();
        }

        private void MenuItem_CadastrarPremioFilme_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarPremioFilme c = new frmCadastrarPremioFilme();
            c.ShowDialog();
        }

        private void MenuItem_CadastrarLocacao_Click(object sender, RoutedEventArgs e)
        {
            frmLocacao l = new frmLocacao();
            l.ShowDialog();
        }

        private void MenuItem_ListarClientes_Click(object sender, RoutedEventArgs e)
        {
            frmListarClientes lc = new frmListarClientes();
            lc.ShowDialog();
        }

        private void MenuItem_ListarFilmes_Click(object sender, RoutedEventArgs e)
        {
            frmListarFilmes lf = new frmListarFilmes();
            lf.ShowDialog();
        }

        private void MenuItem_ListarFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            frmListarFuncionarios lf = new frmListarFuncionarios();
            lf.ShowDialog();
        }

        private void MenuItem_ListarPremios_Click(object sender, RoutedEventArgs e)
        {
            frmListarPremios lp = new frmListarPremios();
            lp.ShowDialog();
        }

        private void MenuItem_FilmesXQtdEstoque_Click(object sender, RoutedEventArgs e)
        {
            frmEstoqueFilmes ef = new frmEstoqueFilmes();
            ef.ShowDialog();
        }

        private void MenuItem_HistoricoLocacaoXFuncionario_Click(object sender, RoutedEventArgs e)
        {
            //frmHistoricoLocacaoXFuncionario f = new frmHistoricoLocacaoXFuncionario();
            //f.lbHistoricoLocacaoXFuncionario.Content = "Teste1\nTeste2";
            //f.ShowDialog();
        }

        private void MenuItem_HistoricoLocacaoXFilme_Click(object sender, RoutedEventArgs e)
        {
            //Preencher
        }

        private void MenuItem_ExcluirFilme_Click(object sender, RoutedEventArgs e)
        {
            frmExcluirFilme ef = new frmExcluirFilme();
            ef.ShowDialog();
        }

        private void MenuItem_DevolucaoLocacao_Click(object sender, RoutedEventArgs e)
        {
            frmDevolucaoLocacao dl = new frmDevolucaoLocacao();
            dl.ShowDialog();
        }

        private void MenuItem_EditarFilme_Click(object sender, RoutedEventArgs e)
        {
            frmEditarFilme ef = new frmEditarFilme();
            ef.ShowDialog();
        }

        private void MenuItem_HistoricoLocacaoXCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ListarLocacoes_Click(object sender, RoutedEventArgs e)
        {
            frmListarLocacoes ll = new frmListarLocacoes();
            ll.ShowDialog();
        }

        private void MenuItem_HistoricoLocacaoXCliente_Click_1(object sender, RoutedEventArgs e)
        {
            frmHistoricoLocacaoXCliente hlc = new frmHistoricoLocacaoXCliente();
            hlc.ShowDialog();
        }
    }
}
