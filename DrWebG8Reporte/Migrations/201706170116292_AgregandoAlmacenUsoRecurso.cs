namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoAlmacenUsoRecurso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Disponible = c.Int(nullable: false),
                        Centro_Id = c.Int(),
                        RecursoHospitalario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centroes", t => t.Centro_Id)
                .ForeignKey("dbo.RecursoHospitalarios", t => t.RecursoHospitalario_Id)
                .Index(t => t.Centro_Id)
                .Index(t => t.RecursoHospitalario_Id);
            
            CreateTable(
                "dbo.UsoRecursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Consulta_Id = c.Int(),
                        RecursoHospitalario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultas", t => t.Consulta_Id)
                .ForeignKey("dbo.RecursoHospitalarios", t => t.RecursoHospitalario_Id)
                .Index(t => t.Consulta_Id)
                .Index(t => t.RecursoHospitalario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Almacens", "RecursoHospitalario_Id", "dbo.RecursoHospitalarios");
            DropForeignKey("dbo.UsoRecursoes", "RecursoHospitalario_Id", "dbo.RecursoHospitalarios");
            DropForeignKey("dbo.UsoRecursoes", "Consulta_Id", "dbo.Consultas");
            DropForeignKey("dbo.Almacens", "Centro_Id", "dbo.Centroes");
            DropIndex("dbo.UsoRecursoes", new[] { "RecursoHospitalario_Id" });
            DropIndex("dbo.UsoRecursoes", new[] { "Consulta_Id" });
            DropIndex("dbo.Almacens", new[] { "RecursoHospitalario_Id" });
            DropIndex("dbo.Almacens", new[] { "Centro_Id" });
            DropTable("dbo.UsoRecursoes");
            DropTable("dbo.Almacens");
        }
    }
}
