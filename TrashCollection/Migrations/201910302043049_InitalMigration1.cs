namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Balance", c => c.Double());
            AlterColumn("dbo.Customers", "PickupConfirmed", c => c.Boolean());
            AlterColumn("dbo.Customers", "PickUpDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickUpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickupConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "Balance", c => c.Double(nullable: false));
        }
    }
}
