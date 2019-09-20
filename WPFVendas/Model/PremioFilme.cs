using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_PremioFilme")] //Tabela para um filme ter varios premios
    class PremioFilme
    {
        [Key]
        public int IdPremioFilme { get; set; }
        public Premio Premio { get; set; }
        public Filme Filme { get; set; }
        public bool Status { get; set; } // true = ativo & false = inativo
        public DateTime CriadoEm { get; set; }

        public PremioFilme()
        {
            CriadoEm = DateTime.Now;
            Status = true;
        }
    }
}
