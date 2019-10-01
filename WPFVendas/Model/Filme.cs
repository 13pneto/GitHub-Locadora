using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Filme")]
    class Filme
    {
        [Key]
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; }
        public string Nacionalidade { get; set; }
        public int Estoque { get; set; }
        public bool Status { get; set; } //true = ativo & false = inativo
        public DateTime CriadoEm { get; set; }

        public Filme() {
            Status = true;
            CriadoEm = DateTime.Now;
        }
        public Filme(string titulo, string sinopse, DateTime dataLancamento, string genero, string nacionalidade, int estoque)
        {
            Titulo = titulo;
            Sinopse = sinopse;
            DataLancamento = dataLancamento;
            Genero = genero;
            Nacionalidade = nacionalidade;
            Estoque = estoque;
        }

        
        public static bool verificaEstoque(Filme filme, int quantidade) // false = estoque insuficiente
        {
            if(filme.Estoque < quantidade)
            {
                return false;
            }
            return true;
        }

        public void BaixarEstoque(ItemFilme iff) // false = estoque insuficiente
        {
            this.Estoque = iff.Filme.Estoque - iff.Quantidade;

        }

        public void AdicionarEstoque(ItemFilme iff) // false = estoque insuficiente
        {
            this.Estoque = iff.Filme.Estoque + iff.Quantidade;
        }

        public override string ToString()
        {
            return this.Titulo;
        }

    }
}
