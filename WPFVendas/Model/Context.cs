using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Model
{
    class Context : DbContext
    {
        public Context() : base("Locadora") { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Premio> Premio { get; set; }
        public DbSet<PremioFilme> PremioFilme { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        //public ItemFilme ItemFilme { get; set; }
        public DbSet<Comissao> Comissao { get; set; }

    }
}
