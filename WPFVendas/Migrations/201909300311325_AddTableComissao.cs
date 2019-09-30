namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableComissao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Comissao",
                c => new
                    {
                        IdComissao = c.Int(nullable: false, identity: true),
                        ValorComissao = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Locacao_IdLocacao = c.Int(),
                    })
                .PrimaryKey(t => t.IdComissao)
                .ForeignKey("dbo.TB_Locacao", t => t.Locacao_IdLocacao)
                .Index(t => t.Locacao_IdLocacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_Comissao", "Locacao_IdLocacao", "dbo.TB_Locacao");
            DropIndex("dbo.TB_Comissao", new[] { "Locacao_IdLocacao" });
            DropTable("dbo.TB_Comissao");
        }
    }
}
