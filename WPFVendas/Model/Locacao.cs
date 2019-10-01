using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Locacao")]
    class Locacao
    {
        [Key]
        public int IdLocacao { get; set; }
        //public Filme Filme { get; set; } //filmes
        public List<ItemFilme> Filmes { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; } //Funcionario responsavel pela locação
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; } //Data que é para devolver a locação
        public DateTime DataDevolvida { get; set; } //Data que foi devolvido a locação (pode ocorrer atrasos)
        public double Valor { get; set; }
        public bool Status { get; set; } //true = ativo & false = inativo
        public DateTime CriadoEm { get; set; }

        public Locacao()
        {
            CriadoEm = DateTime.Now;
            Status = true;
        }

        //public Locacao()
        //{
        //    CriadoEm = DateTime.Now;
        //    Status = true;
        //}

        //public Locacao(List<ItemFilme> filmes)
        //{
        //    CriadoEm = DateTime.Now;
        //    Status = true;
        //}


        //public override string ToString()
        //{
        //    return Cliente.Nome;
        //}


    }
}
