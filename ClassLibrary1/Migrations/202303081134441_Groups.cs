namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Groups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Code");
        }
    }
}
