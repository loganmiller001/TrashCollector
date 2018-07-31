namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoundSpellingErrorInCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AmountDue", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "AmmountDue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AmmountDue", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "AmountDue");
        }
    }
}
