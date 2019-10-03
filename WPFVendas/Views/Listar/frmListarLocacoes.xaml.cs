using Locadora.DAL;
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
using Locadora.Model;

namespace Locadora.Views.Listar
{
    /// <summary>
    /// Lógica interna para frmListarLocacoes.xaml
    /// </summary>
    public partial class frmListarLocacoes : Window
    {
        List<Model.Locacao> ListaLocacoes = LocacaoDAO.ListarLocacoesAtivas();


        private List<dynamic> locacoesGrid = new List<dynamic>();


        public frmListarLocacoes()
        {
            InitializeComponent();

            //Laço para preencher todos os ITEMFILME no GRID
            foreach (Model.Locacao x in ListaLocacoes)
            {
                dynamic locacaoDyn = new
                {
                    Id = x.IdLocacao,
                    Cliente = x.Cliente.Nome,
                    Funcionario = x.Funcionario.Nome,
                    DataLocacao = x.DataLocacao.ToString(),
                    DataDevolucao = x.DataDevolucao.ToString(),
                    DataDevolvida = x.DataDevolvida.ToString(),
                    Valor = x.Valor,
                    Status = x.Status == true ? "Ativo" : "Devolvido",
                };
                //Preencher GRID
                locacoesGrid.Add(locacaoDyn);
                dtLocacoes.ItemsSource = locacoesGrid;
                dtLocacoes.Items.Refresh();

            }
        }
    }
}
