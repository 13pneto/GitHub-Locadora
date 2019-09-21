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
    /// Lógica interna para frmCadastrarPremioFilme.xaml
    /// </summary>
    public partial class frmCadastrarPremioFilme : Window
    {
        Filme f = new Filme();
        Premio p = new Premio();

        public frmCadastrarPremioFilme()
        {
            InitializeComponent();
            {
                if (txtFilme.IsEnabled == true && txtPremio.IsEnabled == true)
                {
                    btnCadastrarPremioFilme.IsEnabled = false;
                }
            }
        }

        private void LimparFormulario()
        {
            btnBuscarPremio.IsEnabled = true;
            btnBuscarFilme.IsEnabled = true;
            txtFilme.IsEnabled = true;
            txtPremio.IsEnabled = true;

            txtFilme.Text = " ";
            txtPremio.Text = " ";

            lbFilmeEncontrado.Content = "";
            lbPremioEncontrado.Content = "";




            txtFilme.Focus();
        }

        private void BtnCadastrarPremioFilme_Click(object sender, RoutedEventArgs e) //Cadastrar Premio no Filme
        {
            try
            {
                PremioFilme pf = new PremioFilme(f, p);
                //if (PremioFilmeDAO.BuscarPremioFilme(pf) != null)
                //{
                //    throw new Exception("Este filme já possui este prêmio cadastrado!");
                //}
                PremioFilmeDAO.CadastrarPremioFilme(pf);
                MessageBox.Show("Premio '" + pf.Premio.Descricao + "' cadastrado no Filme '" + pf.Filme.Titulo + "' !");
                btnCadastrarPremioFilme.IsEnabled = false; //Não deixa clicar em cadastrar novamente
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscarFilme_Click(object sender, RoutedEventArgs e) //Buscar Filme
        {
            try
            {
                f.Titulo = txtFilme.Text;

                f = FilmeDAO.BuscarFilmePorTitulo(f);
                if (f != null) //Filme encontrado
                {
                    txtFilme.IsEnabled = false;
                    txtFilme.Text = f.Titulo;
                    lbFilmeEncontrado.Content = "Filme encontrado!";
                    btnBuscarFilme.IsEnabled = false; // Desativa botao buscar

                    if (txtPremio.IsEnabled == false)
                    {
                        btnCadastrarPremioFilme.IsEnabled = true; // ativa botão Cadastrar
                    }
                }
                else
                { //Filme não encontrado
                    txtFilme.Text = "";
                    throw new Exception("Filme NÃO encontrado!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscarPremio_Click(object sender, RoutedEventArgs e) //Buscar Premio
        {
            try
            {
                p.Descricao = txtPremio.Text;
                p = PremioDAO.BuscarPremio(p);

                if (p != null) //Premio encontrado
                {
                    txtPremio.IsEnabled = false;
                    txtPremio.Text = p.Descricao;
                    lbPremioEncontrado.Content = "Premio encontrado!";
                    btnBuscarPremio.IsEnabled = false; // Desativa botao buscar

                    if (txtFilme.IsEnabled == false)
                    {
                        btnCadastrarPremioFilme.IsEnabled = true; // ativa botão Cadastrar
                    }
                }
                else
                { //Filme não encontrado
                    txtPremio.Text = "";
                    throw new Exception("Premio não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLimparFormulario_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }
    }
}