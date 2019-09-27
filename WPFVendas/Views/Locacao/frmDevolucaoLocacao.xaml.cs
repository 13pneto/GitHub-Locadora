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
        Model.Locacao l = new Model.Locacao();

        public frmDevolucaoLocacao()
        {
            InitializeComponent();
        }

        private void BtnDevolucao_Click(object sender, RoutedEventArgs e)
        {


            l.DataDevolucao = txtDataDevolucao.SelectedDate.Value; //Verifica se a data de devolução não é <= data de locação

            if (l.DataDevolucao.Date <= l.DataLocacao.Date)
            {
                throw new Exception("A data de devolução NÃO pode ser MENOR que a data de Locação!");
            }

            LocacaoDAO.InativarLocacao(l);
            


        }

        private void BtnBuscarLocacao_Click(object sender, RoutedEventArgs e)
        {

            l = LocacaoDAO.BuscarLocacaoPorId(Convert.ToInt32(txtIdLocacao.Text));

            if (l == null)
            {
                throw new Exception("Locação não encontrada");
            }

            //Preenche os campos
            txtCliente.Text = l.Cliente.Nome;
            txtCPFCliente.Text = l.Cliente.Cpf;
            txtDtLocacao.Text = l.DataLocacao.ToString();

            btnDevolucao.IsEnabled = true; //Ativa o botão
        }
    }
}
