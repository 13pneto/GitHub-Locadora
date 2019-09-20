using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Premio")]
    class Premio
    {

        [Key]
        public int IdPremio { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; } //true = ativo & false = inativo
        public DateTime CriadoEm { get; set; }

        public Premio() {
            CriadoEm = DateTime.Now;
            Status = true;
        }

    }
}
