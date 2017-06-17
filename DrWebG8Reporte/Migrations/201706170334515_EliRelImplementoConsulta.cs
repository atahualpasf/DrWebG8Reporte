namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliRelImplementoConsulta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecursoHospitalarios", "Consulta_Id", "dbo.Consultas");
            DropIndex("dbo.RecursoHospitalarios", new[] { "Consulta_Id" });
            DropColumn("dbo.RecursoHospitalarios", "Consulta_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecursoHospitalarios", "Consulta_Id", c => c.Int());
            CreateIndex("dbo.RecursoHospitalarios", "Consulta_Id");
            AddForeignKey("dbo.RecursoHospitalarios", "Consulta_Id", "dbo.Consultas", "Id");
        }
    }
}
