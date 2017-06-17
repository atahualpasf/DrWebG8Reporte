namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModEspecialidadEmpleado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Especialidads", "Empleado_Id", "dbo.Personas");
            DropIndex("dbo.Especialidads", new[] { "Empleado_Id" });
            AddColumn("dbo.Personas", "Especialidad_Id", c => c.Int());
            CreateIndex("dbo.Personas", "Especialidad_Id");
            AddForeignKey("dbo.Personas", "Especialidad_Id", "dbo.Especialidads", "Id");
            DropColumn("dbo.Especialidads", "Empleado_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Especialidads", "Empleado_Id", c => c.Int());
            DropForeignKey("dbo.Personas", "Especialidad_Id", "dbo.Especialidads");
            DropIndex("dbo.Personas", new[] { "Especialidad_Id" });
            DropColumn("dbo.Personas", "Especialidad_Id");
            CreateIndex("dbo.Especialidads", "Empleado_Id");
            AddForeignKey("dbo.Especialidads", "Empleado_Id", "dbo.Personas", "Id");
        }
    }
}
