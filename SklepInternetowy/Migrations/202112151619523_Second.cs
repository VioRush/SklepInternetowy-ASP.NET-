namespace SklepInternetowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DeliveryAddresses", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.DeliveryAddresses", "ApplicationUserId");
            RenameColumn(table: "dbo.DeliveryAddresses", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.DeliveryAddresses", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.DeliveryAddresses", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DeliveryAddresses", "ApplicationUserId");
            DropColumn("dbo.AspNetUsers", "DeliveryAddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DeliveryAddressId", c => c.Int(nullable: false));
            DropIndex("dbo.DeliveryAddresses", new[] { "ApplicationUserId" });
            AlterColumn("dbo.DeliveryAddresses", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DeliveryAddresses", "ApplicationUserId", c => c.String());
            RenameColumn(table: "dbo.DeliveryAddresses", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.DeliveryAddresses", "ApplicationUserId", c => c.String());
            CreateIndex("dbo.DeliveryAddresses", "ApplicationUser_Id");
        }
    }
}
