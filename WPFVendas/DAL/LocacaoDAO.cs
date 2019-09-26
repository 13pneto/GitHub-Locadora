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

    }
}
