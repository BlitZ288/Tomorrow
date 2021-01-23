namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zodiacsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zodiacs", "Pool", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zodiacs", "Pool");
        }
    }
}
