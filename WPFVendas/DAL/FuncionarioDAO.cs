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

        public static List<Funcionario> ListFuncionariosAtivos()
        {
            return ctx.Funcionarios.Where(x => x.Status == true).ToList();
        }

        public static List<Funcionario> ListaFuncionariosInativos()
        {
            return ctx.Funcionarios.Where(x => x.Status == false).ToList();
        }

        public static List<Locacao> ListarLocacoesPorFuncionario(Funcionario c)
        {
            return ctx.Locacao.Include("Funcionario").Include("Cliente").Where(x => x.Funcionario.Nome == c.Nome).ToList();
        }
    }
}
