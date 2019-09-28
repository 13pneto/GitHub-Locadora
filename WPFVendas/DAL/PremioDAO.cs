using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class PremioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();


        public static Premio BuscarPremio(Premio p)
        {
            return ctx.Premio.FirstOrDefault
                  (x => x.Descricao.Equals(p.Descricao));
        }

        public static bool CadastrarPremio(Premio p)
        {
            if (BuscarPremio(p) == null)
            {
                ctx.Premio.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
