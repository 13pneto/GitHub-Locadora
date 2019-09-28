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
using Locadora.DAL;
using Locadora.Model;

namespace Locadora.Views.Locacao
{
    /// <summary>
    /// Lógica interna para frmDevolucaoLocacao.xaml
    /// </summary>
    public partial class frmDevolucaoLocacao : Window
    {
        private List<dynamic> produtosGrid = new List<dynamic>();
        double total = 0;

        Model.Locacao l = new Model.Locacao();

        public frmDevolucaoLocacao()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtCliente.Clear();
            txtCPFCliente.Clear();
            txtDataDevolucao.Text = "";
            txtDtLocacao.Clear();
            txtIdLocacao.Clear();

            btnBuscarLocacao.IsEnabled = true;
            btnDevolucao.IsEnabled = true;

            txtIdLocacao.Focus();
        }

        private void BtnDevolucao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                l.DataDevolvida = txtDataDevolucao.SelectedDate.Value; //Verifica se a data de devolução não é <= data de locação

                if (l.DataDevolucao.Date <= l.DataLocacao.Date)
                {
                    throw new Exception("A data de devolução NÃO pode ser MENOR ou IGUAL que a data de Locação!");
                }
                if (l.DataDevolvida > l.DataDevolucao) // Verifica se há atraso na devolução
                {
                    int diferencaData = l.DataDevolvida.Subtract(l.DataDevolucao).Days;
                    double valorMulta = LocacaoDAO.CalcularMulta(l);
                    MessageBox.Show("A locação está sendo entregue " + diferencaData + " dia(s) atrasado! \nSerá cobrado R$ " + valorMulta + " de multa.");
                    lbValorMulta.Content = valorMulta;
                }

                Filme f = FilmeDAO.VerificaInatividadeListaFilme(l.Filmes); //Verifica se na lista há filmes inativos

                if (f != null) //Se o método acima retornar um objeto Filme, ele está INATIVO.
                {
                    throw new Exception("O filme " + f.Titulo + " está inativo, não é possivel efetuar a devolução");
                }

                if (!(LocacaoDAO.InativarLocacao(l))) //Status da locação = false
                {
                    throw new Exception("Não foi possivel realizar a devolução. \nEntre em contato com o desenvolvedor");
                }

                MessageBox.Show("Devolução realizada com sucesso!");
                LimparFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void BtnBuscarLocacao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                l = LocacaoDAO.BuscarLocacaoPorId(Convert.ToInt32(txtIdLocacao.Text));

                if (l == null) //Verifica se a locação existe
                {
                    throw new Exception("Locação não encontrada");
                }

                if (l.Status == false)
                {
                    throw new Exception("Está devolução já foi efetivada"); //Verifica se a devolução já foi feita
                }

                //Preenche os campos
                txtCliente.Text = l.Cliente.Nome;
                txtCPFCliente.Text = l.Cliente.Cpf;
                txtDtLocacao.Text = l.DataLocacao.ToString();

                btnDevolucao.IsEnabled = true; //Ativa o botão

                //Laço para preencher todos os ITEMFILME no GRID
                foreach (ItemFilme x in l.Filmes)
                {
                    x.Filme.Titulo.ToLower();
                    dynamic filmeDyn = new
                    {
                        Filme = x.Filme.Titulo,
                        Valor = x.Valor,
                        Quantidade = x.Quantidade,
                        Subtotal = x.Valor * x.Quantidade
                    };
                    //Preencher GRID
                    produtosGrid.Add(filmeDyn);
                    dtFilmesLocados.ItemsSource = produtosGrid;
                    dtFilmesLocados.Items.Refresh();

                    total = total + (x.Valor * x.Quantidade); //Soma total
                }

                lbTotal.Content = total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                total = 0;
            }
        }
    }
}
