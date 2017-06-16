namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rif = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cedula = c.Int(nullable: false),
                        Telefono = c.String(),
                        Genero = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        rol = c.String(),
                        Sueldo = c.Double(),
                        TipoSangre = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Centro_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centroes", t => t.Centro_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Centro_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Especialidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Empleado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Empleado_Id)
                .Index(t => t.Empleado_Id);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaReserva = c.DateTime(nullable: false),
                        FechaConsulta = c.DateTime(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        Centro_Id = c.Int(),
                        Doctor_Id = c.Int(),
                        Paciente_Id = c.Int(),
                        Secretaria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centroes", t => t.Centro_Id)
                .ForeignKey("dbo.Personas", t => t.Doctor_Id)
                .ForeignKey("dbo.Personas", t => t.Paciente_Id)
                .ForeignKey("dbo.Personas", t => t.Secretaria_Id)
                .Index(t => t.Centro_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Secretaria_Id);
            
            CreateTable(
                "dbo.EmpleadoCentroes",
                c => new
                    {
                        Empleado_Id = c.Int(nullable: false),
                        Centro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Empleado_Id, t.Centro_Id })
                .ForeignKey("dbo.Personas", t => t.Empleado_Id, cascadeDelete: true)
                .ForeignKey("dbo.Centroes", t => t.Centro_Id, cascadeDelete: true)
                .Index(t => t.Empleado_Id)
                .Index(t => t.Centro_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "Secretaria_Id", "dbo.Personas");
            DropForeignKey("dbo.Citas", "Paciente_Id", "dbo.Personas");
            DropForeignKey("dbo.Citas", "Doctor_Id", "dbo.Personas");
            DropForeignKey("dbo.Citas", "Centro_Id", "dbo.Centroes");
            DropForeignKey("dbo.Personas", "Centro_Id", "dbo.Centroes");
            DropForeignKey("dbo.Especialidads", "Empleado_Id", "dbo.Personas");
            DropForeignKey("dbo.EmpleadoCentroes", "Centro_Id", "dbo.Centroes");
            DropForeignKey("dbo.EmpleadoCentroes", "Empleado_Id", "dbo.Personas");
            DropIndex("dbo.EmpleadoCentroes", new[] { "Centro_Id" });
            DropIndex("dbo.EmpleadoCentroes", new[] { "Empleado_Id" });
            DropIndex("dbo.Citas", new[] { "Secretaria_Id" });
            DropIndex("dbo.Citas", new[] { "Paciente_Id" });
            DropIndex("dbo.Citas", new[] { "Doctor_Id" });
            DropIndex("dbo.Citas", new[] { "Centro_Id" });
            DropIndex("dbo.Especialidads", new[] { "Empleado_Id" });
            DropIndex("dbo.Personas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Personas", new[] { "Centro_Id" });
            DropTable("dbo.EmpleadoCentroes");
            DropTable("dbo.Citas");
            DropTable("dbo.Especialidads");
            DropTable("dbo.Personas");
            DropTable("dbo.Centroes");
        }
    }
}
