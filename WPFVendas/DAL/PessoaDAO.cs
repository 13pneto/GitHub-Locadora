
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class PessoaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();


        public static Pessoa BuscarPessoaPorCPF(Pessoa p)
        {
            return ctx.Pessoas.FirstOrDefault
                (x => x.Nome.Equals(p.Nome));
        }

        public static bool CadastrarPessoa(Pessoa p)
        {
            //if (BuscarPessoaPorCPF(p) == null)
            //{
            ctx.Pessoas.Add(p);
                ctx.SaveChanges();
                return true;
           // }
           // return false;
        }

        public static List<Locacao> ListarLocacoesPorPessoa(Pessoa c)
        {
            return ctx.Locacao.Include("Funcionario").Include("Cliente").Where(x => x.Cliente.Nome == c.Nome).ToList();
        }


    }
}
