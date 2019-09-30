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
        private static Context ctx = SingletonContext.GetInstance();
        public static Funcionario BuscarFuncionarioPorCPF(Funcionario f)
        {
            return ctx.Funcionarios.FirstOrDefault
                (x => x.Cpf.Equals(f.Cpf));
        }

        public static double EfetivarComissao(Locacao l)
        {
            double valorComissao = l.Valor * (l.Funcionario.Comissao / 100);
            return valorComissao;
        }
    }
}
