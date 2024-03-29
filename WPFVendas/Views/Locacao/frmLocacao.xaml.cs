﻿using Locadora.DAL;
using Locadora.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
using VendasConsole.Utils;

namespace Locadora.Views.Locacao
{
    /// <summary>
    /// Lógica interna para frmLocacao.xaml
    /// </summary>
    public partial class frmLocacao : Window
    {
        private List<dynamic> produtosGrid = new List<dynamic>();
        Filme f = new Filme();
        Cliente c = new Cliente();
        Funcionario func = new Funcionario();
        double total = 0;
        List<ItemFilme> filmesAdicionados = new List<ItemFilme>();
        Model.Locacao l = new Model.Locacao();

        public frmLocacao()
        {
            InitializeComponent();
        }

        private void DtaFilmesLocar_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LimparFormulario()
        {
            txtCliente.Clear();
            txtClienteNome.Clear();
            txtFilmeProcurar.Clear();
            txtFuncionario.Clear();
            txtFuncionarioNome.Clear();
            txtQuantidadeLocar.Clear();
            txtValor.Clear();
            dtDevolucao.SelectedDate = null;
            dtLocacao.SelectedDate = null;

                dtaFilmesLocar.Items.Clear();
                dtaFilmesLocar.Items.Refresh();

            txtCliente.Focus();

        }

        private void BtnBuscarFilme_Click(object sender, RoutedEventArgs e)
        {
            f = new Filme();
            try
            {
                f.Titulo = txtFilmeProcurar.Text;
                f = FilmeDAO.BuscarFilmePorTitulo(f);

                if (f == null)
                {
                    MessageBox.Show("Filme NÃO encontrado!");
                }

                if (f.Status == false)
                {
                    throw new Exception("O Filme está inativo! \nNão será possível locar este filme.");
                }

                btnAdicionar.IsEnabled = true; //ativa botao adicionar
                MessageBox.Show("Filme ENCONTRADO!");
                lbFilmeSelecionado.Content = f.Titulo + "\nEstoque: " + f.Estoque.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnBuscarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            func = new Funcionario();
            try
            {
                func.Cpf = txtFuncionario.Text;
                ValidadorCPF.validaCpf(func.Cpf);

                func = FuncionarioDAO.BuscarFuncionarioPorCPF(func);
                if (func != null) //Funcionario encontrado
                {
                    MessageBox.Show("Funcionario Encontrado!");
                    txtFuncionarioNome.Text = func.Nome;
                    txtFuncionario.IsEnabled = false;
                    btnBuscarFuncionario.IsEnabled = false;
                }
                else
                { //Funcionario não encontrado
                    txtFuncionario.Text = "";
                    throw new Exception("FUNCIONARIO NÃO encontrado!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            c = new Cliente();
            try
            {
                c.Cpf = txtCliente.Text;
                ValidadorCPF.validaCpf(c.Cpf);

                c = ClienteDAO.BuscarClientePorCPF(c);
                if (c != null) //Cliente encontrado
                {
                    MessageBox.Show("Cliente Encontrado!");
                    txtClienteNome.Text = c.Nome;
                    txtCliente.IsEnabled = false;
                    btnBuscarCliente.IsEnabled = false;
                    btnAdicionar.IsEnabled = false;

                }
                else
                { //Cliente não encontrado
                    txtCliente.Text = "";
                    throw new Exception("CLIENTE NÃO encontrado!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void BtnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            txtCliente.Text = "";
            txtClienteNome.Text = "Nome do Cliente";
            btnBuscarCliente.IsEnabled = true;
            txtCliente.IsEnabled = true;
            txtCliente.Focus();
        }

        private void BtnNovoFuncionario_Click(object sender, RoutedEventArgs e)
        {
            txtFuncionario.Text = "";
            txtFuncionarioNome.Text = "Nome do Funcionário";
            btnBuscarFuncionario.IsEnabled = true;
            txtFuncionario.IsEnabled = true;
            txtFuncionario.Focus();
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!(Filme.verificaEstoque(f, Convert.ToInt32(txtQuantidadeLocar.Text)))) //verificar estoque
                {
                    throw new Exception("Estoque insuficiente! Estoque atual do produto: " + f.Estoque);
                }

                dynamic filmeDyn = new
                {
                    Quantidade = txtQuantidadeLocar.Text,
                    ValorUnitario = txtValor.Text,
                    Filme = f.Titulo,
                    Genero = f.Genero,
                    Estoque = f.Estoque.ToString(),
                    Subtotal = Convert.ToDouble(txtValor.Text) * Convert.ToInt32(txtQuantidadeLocar.Text),
                };

                total += Convert.ToDouble(txtValor.Text) * Convert.ToInt32(txtQuantidadeLocar.Text);

                lbTotal.Content = (total);
                ItemFilme iff = new ItemFilme();
                iff.Valor = Convert.ToDouble(txtValor.Text);
                iff.Filme = f;

                if (filmesAdicionados.Count <= 0) { filmesAdicionados.Add(iff); f = new Filme(); }


                foreach (ItemFilme x in filmesAdicionados)
                {
                    if (f.IdFilme == x.Filme.IdFilme)
                    {
                        throw new Exception("Produto está adicionado na lista!");
                    }
                }

                if (f.Titulo != null)
                {
                    filmesAdicionados.Add(iff); //se o objeto FILME for nulo, significa que já passou do primeiro produto. SE for != null NÃO é mais o 1° produto, então adiciona outro na lista
                }
                iff.Quantidade = Convert.ToInt32(txtQuantidadeLocar.Text);
                //filmesAdicionados.Add(iff);

                produtosGrid.Add(filmeDyn);
                dtaFilmesLocar.ItemsSource = produtosGrid;
                dtaFilmesLocar.Items.Refresh();

                txtValor.Clear();
                txtQuantidadeLocar.Clear();
                txtFilmeProcurar.Clear();
                txtFilmeProcurar.Focus();

                f = new Filme();
                btnAdicionar.IsEnabled = false;
                btnLocar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                total = 0;
            }
        }

        private void BtnLocar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemFilme iff = new ItemFilme();

                l.Cliente = c;
                l.DataLocacao = dtLocacao.SelectedDate.Value;
                l.DataDevolucao = dtDevolucao.SelectedDate.Value;
                l.Filmes = filmesAdicionados;
                l.Funcionario = func;
                l.DataDevolucao = dtDevolucao.SelectedDate.Value;
                l.Valor = Convert.ToDouble(lbTotal.Content);

                if (l.Cliente.Status == false)
                {
                    throw new Exception("O Cliente está inativo. \nNão é possivel realizar a locação.");
                }
                if (l.Funcionario.Status == false)
                {
                    throw new Exception("O funcionário está inativo. \nNão é possivel realizar a locação.");
                }

                double comissaoFuncionario = FuncionarioDAO.EfetivarComissao(l); //Retorna o valor da comissão daquela venda

                LocacaoDAO.CadastrarLocacao(l);

                //BAIXAR ESTOQUE PRODUTOS
                FilmeDAO.BaixarEstoque(filmesAdicionados);
                MessageBox.Show("Locação realizada!");

                LimparFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
