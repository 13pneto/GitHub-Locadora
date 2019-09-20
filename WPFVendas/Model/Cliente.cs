using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    [Table("TB_Cliente")]
    class Cliente : Pessoa
    {
        public Cliente() { }
        public Cliente(string nome, string cpf, bool status) : base(nome, cpf, status) { }

    }
}
