﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;
using Locadora.DAL;

namespace Locadora.DAL
{
    class ClienteDAO
    {
        //private static Context ctx = new Context();
        private static Context ctx = SingletonContext.GetInstance();

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

        public static List<Cliente> ListaClientesAtivos()
        {
            return ctx.Clientes.Where(x => x.Status == true).ToList();
        }

        public static List<Cliente> ListaClientesInativos()
        {
            return ctx.Clientes.Where(x => x.Status == false).ToList();
        }



    }


}
