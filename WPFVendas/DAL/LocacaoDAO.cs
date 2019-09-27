using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class LocacaoDAO
    {
        private static Context ctx = new Context();



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
            return ctx.Locacao.FirstOrDefault
                (x => x.IdLocacao.Equals(idLocacao));
        }

        public static bool InativarLocacao(Locacao l)

        {
            Filme f = new Filme();

            ctx.Locacao.FirstOrDefault
             (x => x.IdLocacao.Equals(l.IdLocacao));

            if (ctx.Locacao != null)
            {
                ctx.Locacao.Attach(l);
                ctx.SaveChanges();

                //Adiciona o estoque
                foreach (ItemFilme iff in l.Filmes)
                {
                    f.AdicionarEstoque(iff);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
