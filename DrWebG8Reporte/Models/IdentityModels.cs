using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DrWebG8Reporte.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Centro> Centroes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Especialidad> Especialidads { get; set; }
        public DbSet<Diagnostico> Diagnosticoes { get; set; }
        public DbSet<Enfermedad> Enfermedads { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecursoHospitalario> RecursoHospitalarioes { get; set; }
        public DbSet<Almacen> Almacens { get; set; }
        public DbSet<UsoRecurso> UsoRecursoes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}