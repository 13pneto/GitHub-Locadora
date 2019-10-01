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

namespace Locadora.Views.Relatorios
{
    /// <summary>
    /// Lógica interna para frmHistoricoLocacaoXCliente.xaml
    /// </summary>
    public partial class frmHistoricoLocacaoXCliente : Window
    {
        private List<dynamic> produtosGrid = new List<dynamic>();
        string status;

        public frmHistoricoLocacaoXCliente()
        {
            InitializeComponent();
        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            dtLocacaoXCliente.Items.Clear();
            try
            {
                Cliente c = new Cliente();
                c.Cpf = txtClienteBuscar.Text;

                c = ClienteDAO.BuscarClientePorCPF(c);

                if (c == null) //Cliente não encontrado
                {
                    throw new Exception("Cliente não cadastrado!");
                }

                lbClienteEncontrado.Content = c.Nome; //Preenche o label com nome do cliente

                List<Model.Locacao> Locacoes = PessoaDAO.ListarLocacoesPorPessoa(c); //Buscar Locações por cliente

                if(Locacoes.Count <= 0) //Verifica se há locações (lista < 0 = não há)
                {
                    throw new Exception("Não há locações para este cliente");
                }

                MessageBox.Show("Cliente encontrado!");

                foreach (Model.Locacao x in Locacoes) //Lista locações
                {
                    status = x.Status == true ? "Locado" : "Finalizado";

                    dynamic locacaoDyn = new
                    {
                        Cliente = x.Cliente.Nome,
                        Locacao_ID = Convert.ToInt32(x.IdLocacao),
                        Status = status,
                    };
                    //Preencher GRID
                    produtosGrid.Add(locacaoDyn);
                    dtLocacaoXCliente.ItemsSource = produtosGrid;
                    dtLocacaoXCliente.Items.Refresh();
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
