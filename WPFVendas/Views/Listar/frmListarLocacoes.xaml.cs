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


        private List<dynamic> produtosGrid = new List<dynamic>();


        public frmListarLocacoes()
        {
            InitializeComponent();
            dtLocacoes.ItemsSource = ListaLocacoes;
        }
    }
}
