using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;
using Locadora.DAL;

namespace WPFVendas.DAL
{
    class ComissaoDAO
    {

        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarComissao(Comissao c)
        {
            ctx.Comissao.Add(c);
            ctx.SaveChanges();
            return true;
        }
    }
}
