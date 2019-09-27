using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class FilmeDAO
    {
        private static Context ctx = new Context();

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
    }
}
