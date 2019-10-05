namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateDevolvidaNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_Locacao", "DataDevolvida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_Locacao", "DataDevolvida", c => c.DateTime(nullable: false));
        }
    }
}
