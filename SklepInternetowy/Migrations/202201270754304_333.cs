namespace SklepInternetowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _333 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Okładka",
                c => new
                    {
                        OkładkaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OkładkaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Okładka");
        }
    }
}
