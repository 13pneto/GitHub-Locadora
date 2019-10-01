using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Pessoa")]
    class Pessoa
    {

        [Key]
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Status { get; set; } //true = ativo, false = inativo

        public DateTime CriadoEm { get; set; }
        
        public Pessoa()
        {
            Status = true;
            CriadoEm = DateTime.Now;
        }

        public Pessoa(string nome, string cpf, bool status)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Status = status;
        }

        public override string ToString()
        {
            return this.Nome;
        }

    }
}
