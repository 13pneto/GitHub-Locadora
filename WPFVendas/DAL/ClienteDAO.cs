using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class ClienteDAO
    {
        private static Context ctx = new Context();

        public static Cliente BuscarClientePorCPF(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.Cpf.Equals(c.Cpf));
        }

    //    public static bool CadastrarCliente(Cliente c)
    //    {
    //        if (BuscarClientePorCPF(c) == null)
    //        {
    //            ctx.Clientes.Add(c);
    //            ctx.SaveChanges();
    //            return true;
    //        }
    //        return false;
    //    }

    }


}
