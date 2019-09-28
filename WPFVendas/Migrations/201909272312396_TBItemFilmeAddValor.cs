namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TBItemFilmeAddValor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_ItemFilme", "Valor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_ItemFilme", "Valor");
        }
    }
}
