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
    /// Lógica interna para frmCadastrarPremio.xaml
    /// </summary>
    public partial class frmCadastrarPremio : Window
    {
        public frmCadastrarPremio()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtDescricaoPremio.Clear();

            txtDescricaoPremio.Focus();
        }

        private void BtnCadastrarPremio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Premio p = new Premio();
                p.Descricao = txtDescricaoPremio.Text;

                if (txtDescricaoPremio.Text.Equals(""))
                {
                    throw new Exception("É Obrigatório o campo DESCRIÇÃO!");
                }

                if (PremioDAO.BuscarPremio(p) != null)
                {
                    throw new Exception("Premio já está cadastrado!");
                }

                PremioDAO.CadastrarPremio(p);
                MessageBox.Show("Premio cadastrado com sucesso");

                LimparFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }

        }
    }
}
