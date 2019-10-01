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
        public double Valor { get; set; }

        public ItemFilme() { }

        public ItemFilme(Filme f, int qtd, double valor)
        {
            this.Filme = f;
            this.Quantidade = qtd;
            this.Valor = valor;
        }

        public ItemFilme(Locacao l, Filme f, int qtd, double valor)
        {
            this.Locacao = l;
            this.Filme = f;
            this.Quantidade = qtd;
            this.Valor = valor;
            
    }

        public override string ToString()
        {
            return this.Filme.Titulo;
        }

    }
}
