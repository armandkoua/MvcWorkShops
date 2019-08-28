namespace DuraboStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.Mouvements",
                c => new
                    {
                        MouvementID = c.Int(nullable: false, identity: true),
                        DateMouvement = c.DateTime(nullable: false),
                        EntreeMagasinID = c.Int(nullable: false),
                        SortieMagasinID = c.Int(nullable: false),
                        QuantitéDemandée = c.Int(nullable: false),
                        EstApprouvee = c.Boolean(nullable: false),
                        EstRefusee = c.Boolean(nullable: false),
                        NomApprobateur = c.String(),
                        NomDemandeur = c.String(),
                    })
                .PrimaryKey(t => t.MouvementID)
                .ForeignKey("dbo.Magasins", t => t.EntreeMagasinID, cascadeDelete: false)
                .ForeignKey("dbo.Magasins", t => t.SortieMagasinID, cascadeDelete: false)
                .Index(t => t.EntreeMagasinID)
                .Index(t => t.SortieMagasinID);
            
            CreateTable(
                "dbo.Magasins",
                c => new
                    {
                        MagasinID = c.Int(nullable: false, identity: true),
                        NomMagasin = c.String(),
                        QuantitéMaximale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagasinID);
            
            CreateTable(
                "dbo.TypeMouvements",
                c => new
                    {
                        TypeMouvementID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Sens = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.TypeMouvementID);
            
            CreateTable(
                "dbo.MouvementArticles",
                c => new
                    {
                        Mouvement_MouvementID = c.Int(nullable: false),
                        Article_ArticleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mouvement_MouvementID, t.Article_ArticleID })
                .ForeignKey("dbo.Mouvements", t => t.Mouvement_MouvementID, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleID, cascadeDelete: true)
                .Index(t => t.Mouvement_MouvementID)
                .Index(t => t.Article_ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mouvements", "SortieMagasinID", "dbo.Magasins");
            DropForeignKey("dbo.Mouvements", "EntreeMagasinID", "dbo.Magasins");
            DropForeignKey("dbo.MouvementArticles", "Article_ArticleID", "dbo.Articles");
            DropForeignKey("dbo.MouvementArticles", "Mouvement_MouvementID", "dbo.Mouvements");
            DropIndex("dbo.MouvementArticles", new[] { "Article_ArticleID" });
            DropIndex("dbo.MouvementArticles", new[] { "Mouvement_MouvementID" });
            DropIndex("dbo.Mouvements", new[] { "SortieMagasinID" });
            DropIndex("dbo.Mouvements", new[] { "EntreeMagasinID" });
            DropTable("dbo.MouvementArticles");
            DropTable("dbo.TypeMouvements");
            DropTable("dbo.Magasins");
            DropTable("dbo.Mouvements");
            DropTable("dbo.Articles");
        }
    }
}
