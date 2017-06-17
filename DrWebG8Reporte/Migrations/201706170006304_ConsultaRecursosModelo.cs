namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultaRecursosModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(),
                        Diagnostico_Id = c.Int(),
                        Enfermedad_Id = c.Int(),
                        Historia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnosticoes", t => t.Diagnostico_Id)
                .ForeignKey("dbo.Enfermedads", t => t.Enfermedad_Id)
                .ForeignKey("dbo.Historias", t => t.Historia_Id)
                .Index(t => t.Diagnostico_Id)
                .Index(t => t.Enfermedad_Id)
                .Index(t => t.Historia_Id);
            
            CreateTable(
                "dbo.Diagnosticoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacion = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tratamiento = c.String(),
                        Recomendacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecursoHospitalarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Componentes = c.String(),
                        Posologia = c.String(),
                        Recomendaciones = c.String(),
                        Tipo = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Recipe_Id = c.Int(),
                        Consulta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.Consultas", t => t.Consulta_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Consulta_Id);
            
            CreateTable(
                "dbo.Enfermedads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Historias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Personas", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Citas", "Consulta_Id", c => c.Int());
            CreateIndex("dbo.Citas", "Consulta_Id");
            AddForeignKey("dbo.Citas", "Consulta_Id", "dbo.Consultas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "Historia_Id", "dbo.Historias");
            DropForeignKey("dbo.Citas", "Consulta_Id", "dbo.Consultas");
            DropForeignKey("dbo.RecursoHospitalarios", "Consulta_Id", "dbo.Consultas");
            DropForeignKey("dbo.Consultas", "Enfermedad_Id", "dbo.Enfermedads");
            DropForeignKey("dbo.Consultas", "Diagnostico_Id", "dbo.Diagnosticoes");
            DropForeignKey("dbo.Diagnosticoes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecursoHospitalarios", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecursoHospitalarios", new[] { "Consulta_Id" });
            DropIndex("dbo.RecursoHospitalarios", new[] { "Recipe_Id" });
            DropIndex("dbo.Diagnosticoes", new[] { "Recipe_Id" });
            DropIndex("dbo.Consultas", new[] { "Historia_Id" });
            DropIndex("dbo.Consultas", new[] { "Enfermedad_Id" });
            DropIndex("dbo.Consultas", new[] { "Diagnostico_Id" });
            DropIndex("dbo.Citas", new[] { "Consulta_Id" });
            DropColumn("dbo.Citas", "Consulta_Id");
            DropColumn("dbo.Personas", "FechaCreacion");
            DropTable("dbo.Historias");
            DropTable("dbo.Enfermedads");
            DropTable("dbo.RecursoHospitalarios");
            DropTable("dbo.Recipes");
            DropTable("dbo.Diagnosticoes");
            DropTable("dbo.Consultas");
        }
    }
}
