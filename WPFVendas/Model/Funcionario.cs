using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Funcionario")]
    class Funcionario : Pessoa
    {
        public double Salario { get; set; }
        public double Comissao { get; set; }

        public Funcionario() { }
        public Funcionario(string nome, string cpf, bool status, double salario, double comissao) : base(nome, cpf, status) {
            Salario = salario;
            Comissao = comissao;
        }

    }
}
