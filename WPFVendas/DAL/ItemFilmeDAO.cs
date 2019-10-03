using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class ItemFilmeDAO
    {
        private static Context ctx = SingletonContext.GetInstance();



        public static List<ItemFilme> ListaFilmesLocacao(int IdLocacao)
        {
            return ctx.ItemFilme.Include("Filme").Include("Locacao").Where(x => x.IdItemFilme == IdLocacao).ToList();
        }
    }
}
