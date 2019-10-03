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

namespace Locadora.Views.Excluir
{
    /// <summary>
    /// Lógica interna para frmExcluirFilme.xaml
    /// </summary>
    public partial class frmExcluirFilme : Window
    {
        public frmExcluirFilme()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtTituloFilme.Clear();
            txtTituloFilme.Focus();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Filme f = new Filme();

                f.Titulo = txtTituloFilme.Text;
                f = FilmeDAO.BuscarFilmePorTitulo(f);

                if (f == null)
                {
                    throw new Exception("Filme não encontrado!");
                }
                if(f.Status == false)
                {
                   throw new Exception("Este filme já se encontra na lista de exclusões.\n Para reativa-lo vá na opção de Editar e altere o status para 'ATIVO'");
                }

                FilmeDAO.ExcluirFilme(f);
                MessageBox.Show("Filme excluido com sucesso.");
                LimparFormulario();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
