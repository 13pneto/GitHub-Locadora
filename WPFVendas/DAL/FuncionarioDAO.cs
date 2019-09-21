using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class FuncionarioDAO
    {
        private static Context ctx = new Context();
        public static Funcionario BuscarFuncionarioPorCPF(Funcionario f)
        {
            return ctx.Funcionarios.FirstOrDefault
                (x => x.Cpf.Equals(f.Cpf));
        }
    }
}
