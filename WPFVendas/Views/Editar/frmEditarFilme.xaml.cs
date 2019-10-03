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

namespace Locadora.Views.Editar
{
    /// <summary>
    /// Lógica interna para frmEditarFilme.xaml
    /// </summary>
    public partial class frmEditarFilme : Window
    {
        Filme f = new Filme();
        public frmEditarFilme()
        {
            InitializeComponent();
        }

        private void MostrarDados(Filme f)
        {
            txtDtLancamentoOLD.Text = f.DataLancamento.ToString();
            txtEstoqueOLD.Text = f.Estoque.ToString();
            txtGeneroOLD.Text = f.Genero;
            txtNacionalidadeOLD.Text = f.Nacionalidade;
            txtSinopseOLD.Text = f.Sinopse;

            if (f.Status == true)
            {
                txtStatusOLD.Text = "Ativo";
            }
            else
            {
                txtStatusOLD.Text = "Inativo";
            }
        }

        private void LimparDados()
        {
            btnAtualizar.IsEnabled = false;

            txtTituloFilmeBuscar.Clear();
            txtDtLancamentoOLD.Text = "";
            txtEstoqueOLD.Clear();
            txtGeneroOLD.Clear();
            txtNacionalidadeOLD.Clear();
            txtSinopseOLD.Clear();

            txtTituloFilmeNEW.Clear();
            txtDtLancamentoNEW.Text = "";
            txtEstoqueNEW.Clear();
            txtGeneroNEW.Clear();
            txtNacionalidadeNEW.Clear();
            txtSinopseNEW.Clear();

            txtTituloFilmeBuscar.Focus();

        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Titulo = txtTituloFilmeNEW.Text;
                f.DataLancamento = txtDtLancamentoNEW.SelectedDate.Value;
                f.Estoque = Convert.ToInt32(txtEstoqueNEW.Text);
                f.Genero = txtGeneroNEW.Text;
                f.Nacionalidade = txtNacionalidadeNEW.Text;
                f.Sinopse = txtSinopseNEW.Text;

                if (cbStatusNew.SelectedIndex == 0)
                {
                    f.Status = true;
                }   
                else
                {
                    f.Status = false;
                }

                Filme temp = new Filme();   //  Cria um filme temporario apenas para verificar duplicidade entre a alteração x banco
                temp.Titulo = f.Titulo;

                
                if (FilmeDAO.BuscarFilmePorTitulo(temp) != null && f.Titulo != txtTituloFilmeBuscar.Text) //verifica se ja existe no banco ||| E verifica se o titulo for igual, se é o mesmo objeto.
                {
                    throw new Exception("Este filme já existe, não é possivel prosseguir com a alteração. \nFavor corrigir o titulo.");
                }

                if (!(FilmeDAO.AtualizarFilme(f)))
                {
                    throw new Exception("Falha ao salvar no banco, favor entrar em contato com o suporte do sistema.");
                }

                MessageBox.Show("Filme atualizado com sucesso!");

                LimparDados();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscarFilme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Titulo = txtTituloFilmeBuscar.Text;
                f = FilmeDAO.BuscarFilmePorTitulo(f);

                if (f == null)
                {
                    throw new Exception("Filme NÃO encontrado!");
                    
                }

                btnAtualizar.IsEnabled = true; //ativa botao adicionar
                MessageBox.Show("Filme ENCONTRADO!");

                MostrarDados(f);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                f = new Filme();
            }
        }

    }
}
