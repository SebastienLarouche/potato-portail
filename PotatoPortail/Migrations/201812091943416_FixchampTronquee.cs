namespace PotatoPortail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixchampTronquee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DevisMinistere", "Specialisation", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.DevisMinistere", "DocMinistere", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DevisMinistere", "DocMinistere", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.DevisMinistere", "Specialisation", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
