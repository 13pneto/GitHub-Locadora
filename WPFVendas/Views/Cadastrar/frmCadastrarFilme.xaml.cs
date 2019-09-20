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
    /// Lógica interna para frmCadastrarFilme.xaml
    /// </summary>
    public partial class frmCadastrarFilme : Window
    {
        public frmCadastrarFilme()
        {
            InitializeComponent();
            txtCriadoEm.Text = DateTime.Now.ToString();
        }

        private void LimparFormulario()
        {
            txtTituloFilme.Clear();
            txtSinopseFilme.Clear();
            txtDtLançamentoFilme.Clear();
            txtGeneroFilme.Clear();
            txtNacionalidade.Clear();
            txtEstoque.Clear();
            txtCriadoEm.Clear();

            txtCriadoEm.Text = DateTime.Now.ToString();
            txtTituloFilme.Focus();
        }

        private void BtnCadastrarFilme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Filme f = new Filme();

                f.Titulo = txtTituloFilme.Text;
                f.Sinopse = txtSinopseFilme.Text;
                f.DataLancamento = Convert.ToDateTime(txtDtLançamentoFilme.Text);
                f.Genero = txtGeneroFilme.Text;
                f.Nacionalidade = txtNacionalidade.Text;
                f.Estoque = Convert.ToInt32(txtEstoque.Text);
                f.CriadoEm = Convert.ToDateTime(txtCriadoEm.Text);

                if(f.Titulo == null || f.Sinopse.Equals("") || f.DataLancamento.Equals("") 
                  || f.Genero.Equals("") || f.Nacionalidade.Equals("") || f.Estoque.Equals(""))
                {
                    throw new Exception("Todos os campos devem ser preenchidos");
                }

                if(FilmeDAO.BuscarFilmePorTitulo(f) != null)
                {
                    throw new Exception("Filme já cadastrado!");
                }

                FilmeDAO.CadastrarFilme(f);

                MessageBox.Show("Filme cadastrado!");

                LimparFormulario();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
