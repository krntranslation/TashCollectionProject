namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpDayOfTheWeek", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickUpDayOfTheWeek");
        }
    }
}
