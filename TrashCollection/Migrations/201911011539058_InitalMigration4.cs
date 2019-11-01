namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ZipCode");
        }
    }
}
