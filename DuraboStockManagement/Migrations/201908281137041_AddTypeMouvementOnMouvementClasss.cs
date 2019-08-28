namespace DuraboStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeMouvementOnMouvementClasss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mouvements", "TypeMouvementID", c => c.Int(nullable: false));
            CreateIndex("dbo.Mouvements", "TypeMouvementID");
            AddForeignKey("dbo.Mouvements", "TypeMouvementID", "dbo.TypeMouvements", "TypeMouvementID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mouvements", "TypeMouvementID", "dbo.TypeMouvements");
            DropIndex("dbo.Mouvements", new[] { "TypeMouvementID" });
            DropColumn("dbo.Mouvements", "TypeMouvementID");
        }
    }
}
