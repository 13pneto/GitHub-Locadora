using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Model;

namespace Locadora.DAL
{
    class PremioFilmeDAO
    {
        private static Context ctx = new Context();
        public static PremioFilme BuscarPremioFilme(PremioFilme pf)
        {
            //PremioFilme pfTemp = new PremioFilme();
            List<PremioFilme> ListPremioFilme = new List<PremioFilme>();

            foreach(PremioFilme pfTemp in ListPremioFilme)
            {
                if(pfTemp.Filme.Titulo == pf.Filme.Titulo)
                {
                    if(pfTemp.Premio.Descricao == pf.Premio.Descricao)
                    {
                        return pf; //Se encontrar um PF vai retornar o objeto
                    }
                }
            }
            return null; //Se o objeto não for encontrado, retorna NULL
        }

        public static void CadastrarPremioFilme(PremioFilme pf) // true = Cadastrado && false == PF Já cadastrado
        {
           // if (BuscarPremioFilme(pf) == null)
           // {
                ctx.PremioFilme.Add(pf);
                ctx.SaveChanges();
                //return true;
           // }
            //return false;
        }
    }
}
