namespace DrWebG8Reporte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliRelMedicinaRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecursoHospitalarios", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecursoHospitalarios", new[] { "Recipe_Id" });
            DropColumn("dbo.RecursoHospitalarios", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecursoHospitalarios", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.RecursoHospitalarios", "Recipe_Id");
            AddForeignKey("dbo.RecursoHospitalarios", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
