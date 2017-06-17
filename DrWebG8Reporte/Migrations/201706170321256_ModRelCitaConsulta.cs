namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModRelCitaConsulta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Consulta_Id", "dbo.Consultas");
            DropIndex("dbo.Citas", new[] { "Consulta_Id" });
            AddColumn("dbo.Consultas", "Cita_Id", c => c.Int());
            CreateIndex("dbo.Consultas", "Cita_Id");
            AddForeignKey("dbo.Consultas", "Cita_Id", "dbo.Citas", "Id");
            DropColumn("dbo.Citas", "Consulta_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citas", "Consulta_Id", c => c.Int());
            DropForeignKey("dbo.Consultas", "Cita_Id", "dbo.Citas");
            DropIndex("dbo.Consultas", new[] { "Cita_Id" });
            DropColumn("dbo.Consultas", "Cita_Id");
            CreateIndex("dbo.Citas", "Consulta_Id");
            AddForeignKey("dbo.Citas", "Consulta_Id", "dbo.Consultas", "Id");
        }
    }
}
