using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Locadora.Model
{
    [Table("TB_Comissao")]
    class Comissao
    {
        [Key]
        public int IdComissao { get; set; }
        public Locacao Locacao { get; set; }
        public double ValorComissao { get; set; }
        public bool Status { get; set; }
        public DateTime CriadoEm { get; set; }

        public Comissao()
        {
            Status = true;
            CriadoEm = DateTime.Now;
            ValorComissao = (Locacao.Valor * Locacao.Funcionario.Comissao) / 100;
        }

        public Comissao(Locacao l)
        {
            this.Locacao = l;
            Status = true;
            CriadoEm = DateTime.Now;
            this.ValorComissao = (l.Valor * l.Funcionario.Comissao) / 100;
        }
    }
}
