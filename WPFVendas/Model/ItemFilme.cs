using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_ItemFilme")]
    class ItemFilme
    {
        [Key]
        public int IdItemFilme { get; set; }
        public Filme Filme { get; set; }
        public Locacao Locacao { get; set; }
        public int Quantidade { get; set; }

        public ItemFilme() { }

    }
}
