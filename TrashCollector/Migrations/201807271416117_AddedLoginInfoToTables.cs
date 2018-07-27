namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLoginInfoToTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Employees", "UserName", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Customers", "AmmountDue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AmmountDue", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "UserName");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "UserName");
        }
    }
}
