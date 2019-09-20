namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovidoTableClienteEFuncionario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Filme",
                c => new
                    {
                        IdFilme = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Sinopse = c.String(),
                        DataLancamento = c.DateTime(nullable: false),
                        Genero = c.String(),
                        Nacionalidade = c.String(),
                        Estoque = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdFilme);
            
            CreateTable(
                "dbo.TB_Locacao",
                c => new
                    {
                        IdLocacao = c.Int(nullable: false, identity: true),
                        DataLocacao = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(nullable: false),
                        DataDevolvida = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Cliente_IdPessoa = c.Int(),
                        Funcionario_IdPessoa = c.Int(),
                    })
                .PrimaryKey(t => t.IdLocacao)
                .ForeignKey("dbo.TB_Cliente", t => t.Cliente_IdPessoa)
                .ForeignKey("dbo.TB_Funcionario", t => t.Funcionario_IdPessoa)
                .Index(t => t.Cliente_IdPessoa)
                .Index(t => t.Funcionario_IdPessoa);
            
            CreateTable(
                "dbo.TB_Pessoa",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_ItemFilme",
                c => new
                    {
                        IdItemFilme = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Filme_IdFilme = c.Int(),
                        Locacao_IdLocacao = c.Int(),
                    })
                .PrimaryKey(t => t.IdItemFilme)
                .ForeignKey("dbo.TB_Filme", t => t.Filme_IdFilme)
                .ForeignKey("dbo.TB_Locacao", t => t.Locacao_IdLocacao)
                .Index(t => t.Filme_IdFilme)
                .Index(t => t.Locacao_IdLocacao);
            
            CreateTable(
                "dbo.TB_Premio",
                c => new
                    {
                        IdPremio = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPremio);
            
            CreateTable(
                "dbo.TB_PremioFilme",
                c => new
                    {
                        IdPremioFilme = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Filme_IdFilme = c.Int(),
                        Premio_IdPremio = c.Int(),
                    })
                .PrimaryKey(t => t.IdPremioFilme)
                .ForeignKey("dbo.TB_Filme", t => t.Filme_IdFilme)
                .ForeignKey("dbo.TB_Premio", t => t.Premio_IdPremio)
                .Index(t => t.Filme_IdFilme)
                .Index(t => t.Premio_IdPremio);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.TB_Cliente",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_Pessoa", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_Funcionario",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false),
                        Salario = c.Double(nullable: false),
                        Comissao = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_Pessoa", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_Funcionario", "IdPessoa", "dbo.TB_Pessoa");
            DropForeignKey("dbo.TB_Cliente", "IdPessoa", "dbo.TB_Pessoa");
            DropForeignKey("dbo.TB_PremioFilme", "Premio_IdPremio", "dbo.TB_Premio");
            DropForeignKey("dbo.TB_PremioFilme", "Filme_IdFilme", "dbo.TB_Filme");
            DropForeignKey("dbo.TB_Locacao", "Funcionario_IdPessoa", "dbo.TB_Funcionario");
            DropForeignKey("dbo.TB_ItemFilme", "Locacao_IdLocacao", "dbo.TB_Locacao");
            DropForeignKey("dbo.TB_ItemFilme", "Filme_IdFilme", "dbo.TB_Filme");
            DropForeignKey("dbo.TB_Locacao", "Cliente_IdPessoa", "dbo.TB_Cliente");
            DropIndex("dbo.TB_Funcionario", new[] { "IdPessoa" });
            DropIndex("dbo.TB_Cliente", new[] { "IdPessoa" });
            DropIndex("dbo.TB_PremioFilme", new[] { "Premio_IdPremio" });
            DropIndex("dbo.TB_PremioFilme", new[] { "Filme_IdFilme" });
            DropIndex("dbo.TB_ItemFilme", new[] { "Locacao_IdLocacao" });
            DropIndex("dbo.TB_ItemFilme", new[] { "Filme_IdFilme" });
            DropIndex("dbo.TB_Locacao", new[] { "Funcionario_IdPessoa" });
            DropIndex("dbo.TB_Locacao", new[] { "Cliente_IdPessoa" });
            DropTable("dbo.TB_Funcionario");
            DropTable("dbo.TB_Cliente");
            DropTable("dbo.Produtos");
            DropTable("dbo.TB_PremioFilme");
            DropTable("dbo.TB_Premio");
            DropTable("dbo.TB_ItemFilme");
            DropTable("dbo.TB_Pessoa");
            DropTable("dbo.TB_Locacao");
            DropTable("dbo.TB_Filme");
        }
    }
}
