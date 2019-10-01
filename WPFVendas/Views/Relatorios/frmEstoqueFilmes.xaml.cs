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
    /// Lógica interna para frmEstoqueFilmes.xaml
    /// </summary>
    public partial class frmEstoqueFilmes : Window
    {
        List<Filme> filmes = FilmeDAO.ListarFilmes();
        private List<dynamic> produtosGrid = new List<dynamic>();

        public frmEstoqueFilmes()
        {
            InitializeComponent();
            String status;

            foreach (Filme x in filmes)
            {
                status = x.Status == true ? "Ativo" : "Inativo";
                dynamic filmeDyn = new
                {
                    Filme = x.Titulo,
                    Estoque = Convert.ToInt32(x.Estoque),
                    Status = status,
                };
                //Preencher GRID
                produtosGrid.Add(filmeDyn);
                dtFilmesXEstoque.ItemsSource = produtosGrid;
                dtFilmesXEstoque.Items.Refresh();
            }
        }
    }
}
