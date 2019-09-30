using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class FilmeDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static Filme BuscarFilmePorTitulo(Filme f)
        {
            f.Titulo.ToLower();
            return ctx.Filmes.FirstOrDefault
                (x => x.Titulo.Equals(f.Titulo));
        }

        public static bool CadastrarFilme(Filme f)
        {
            if (BuscarFilmePorTitulo(f) == null)
            {
                f.Titulo.ToLower();
                ctx.Filmes.Add(f);
                ctx.SaveChanges();

                //Adiciona o estoque nos filmes

                return true;
            }
            return false;
        }

        public static void BaixarEstoque(List<ItemFilme> listaFilmesLocacao)
        {
            foreach (ItemFilme iff in listaFilmesLocacao)
            {
                Filme f = iff.Filme;
                f.BaixarEstoque(iff);
                ctx.Entry(f).State = EntityState.Modified;
            }
        }

        public static void AdicionarEstoque(List<ItemFilme> listaFilmesLocacao)
        {
            foreach (ItemFilme iff in listaFilmesLocacao)
            {
                Filme f = iff.Filme;
                f.AdicionarEstoque(iff);
                ctx.Entry(f).State = EntityState.Modified;
            }
        }

        public static Filme VerificaInatividadeListaFilme(List<ItemFilme> listaFilmes)
        {
            foreach (ItemFilme iff in listaFilmes)
            {
                Filme f = iff.Filme;
                if (f.Status == false)
                {
                    return f;
                }
            }
            return null;
        }
        public static bool ExcluirFilme(Filme f)
        {
            ctx.Filmes.Remove(f);
            ctx.SaveChanges();
            return true;
        }

        public static bool AtualizarFilme(Filme f)
        {
            ctx.Entry(f).State = EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
