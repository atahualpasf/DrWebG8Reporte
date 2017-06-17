namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCanceladaCita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "Cancelada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "Cancelada");
        }
    }
}
