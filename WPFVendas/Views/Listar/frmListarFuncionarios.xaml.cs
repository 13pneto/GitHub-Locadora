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

namespace Locadora.Views.Listar
{
    /// <summary>
    /// Lógica interna para frmListarFuncionarios.xaml
    /// </summary>
    public partial class frmListarFuncionarios : Window
    {
        List<Funcionario> FuncionariosAtivos = FuncionarioDAO.ListFuncionariosAtivos();
        List<Funcionario> FuncionariosInativos = FuncionarioDAO.ListaFuncionariosInativos();
        public frmListarFuncionarios()
        {
            InitializeComponent();
            dtFuncionariosAtivos.ItemsSource = FuncionariosAtivos;
            dtFUncionariosInativos.ItemsSource = FuncionariosInativos;

        }
    }
}
