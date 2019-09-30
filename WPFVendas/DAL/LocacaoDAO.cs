using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;
using WPFVendas.DAL;

namespace Locadora.DAL
{
    class LocacaoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();



        public static bool CadastrarLocacao(Locacao l)
        {
            //if (BuscarFilmePorTitulo(f) == null)
            //{

            ctx.Locacao.Add(l);
            ctx.SaveChanges();
            return true;
            //}
            //return false;
        }

        public static Locacao BuscarLocacaoPorId(int idLocacao)
        {
            return ctx.Locacao.Include("Cliente").Include("Funcionario")
                .Include("Filmes.Filme").FirstOrDefault
               (x => x.IdLocacao.Equals(idLocacao));
        }

        public static bool InativarLocacao(Locacao l)

        {
            if (l != null)
            {
                l.Status = false; //inativando locação
                ctx.Entry(l).State = EntityState.Modified;

                FilmeDAO.AdicionarEstoque(l.Filmes); //Voltar estoque dos produtos
                Comissao c = new Comissao(l);
                ComissaoDAO.CadastrarComissao(c);
                
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double CalcularMulta(Locacao l)
        {
            int diferencaData = l.DataDevolvida.Subtract(l.DataDevolucao).Days;
            double valorMulta = 1.00;
            double total = 0;

            total = (valorMulta * diferencaData);
            return total;
        }

    }
}
