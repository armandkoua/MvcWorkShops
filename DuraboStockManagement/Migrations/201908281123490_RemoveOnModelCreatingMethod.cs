namespace DuraboStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOnModelCreatingMethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooperatives",
                c => new
                    {
                        CooperativeID = c.Int(nullable: false, identity: true),
                        NomCooperative = c.String(),
                    })
                .PrimaryKey(t => t.CooperativeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cooperatives");
        }
    }
}
