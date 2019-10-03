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

namespace Locadora.Views
{
    /// <summary>
    /// Lógica interna para frmHistoricoLocacaoXFuncionario.xaml
    /// </summary>
    public partial class frmHistoricoLocacaoXFuncionario : Window
    {
        private List<dynamic> locacoes = new List<dynamic>();
        public frmHistoricoLocacaoXFuncionario()
        {
            InitializeComponent();
        }

        private void BtnBuscarFuncionario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBuscarFuncionario_Click_1(object sender, RoutedEventArgs e)
        {
            double totalLiberado = 0;
            double totalBloqueado = 0;

            dtLocacaoXFuncionario.Items.Clear();
            try
            {
                Funcionario  f = new Funcionario();
                f.Cpf = txtFuncionarioBuscar.Text;

                f = FuncionarioDAO.BuscarFuncionarioPorCPF(f); //busca funcionario

                if (f == null) //Funcionario não encontrado
                {
                    throw new Exception("Funcionario não cadastrado!");
                }

                lbFuncionarioEncontrado.Content = f.Nome; //Preenche o label com nome do Funcionario

                List<Model.Locacao> Locacoes = FuncionarioDAO.ListarLocacoesPorFuncionario(f); //Buscar Locações por cliente

                if (Locacoes.Count <= 0) //Verifica se há locações (lista < 0 = não há)
                {
                    throw new Exception("Não há locações para este Funcionario");
                }

                MessageBox.Show("Funcionario encontrado!");

                foreach (Model.Locacao x in Locacoes) //Lista locações
                {
                    String comissao = "";

                    if (x.Status == false) // Verifica se a devolução já foi feito, e soma a comissao liberada
                    {
                        comissao = Convert.ToString((x.Valor * x.Funcionario.Comissao) / 100);
                        totalLiberado += (x.Valor * x.Funcionario.Comissao) / 100;
                    }
                    else
                    {
                        comissao = "Aguardando Devolução";
                        totalBloqueado += (x.Valor * x.Funcionario.Comissao) / 100;
                    }

                    dynamic locacaoDyn = new
                    {
                        Locacao_ID = x.IdLocacao,
                        Cliente = x.Cliente.Nome,
                        Estoque = Convert.ToInt32(x.IdLocacao),
                        DataLocacao = x.DataLocacao.ToString(),
                        DataDevolucao = x.DataDevolucao.ToString(),
                        Status = x.Status == false ? "Pago/Devolvido" : "Aguardando Devolução",
                        Comissao = "R$ " + comissao,                    
                    };
                    //Preencher GRID
                    locacoes.Add(locacaoDyn);
                    dtLocacaoXFuncionario.ItemsSource = locacoes;
                    dtLocacaoXFuncionario.Items.Refresh();
                }

                lbTotalComissaoReceber.Content = totalBloqueado.ToString("C2");
                lbTotalComissaoRecebido.Content = totalLiberado.ToString("C2");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
