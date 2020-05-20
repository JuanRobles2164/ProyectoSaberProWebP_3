using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoSaberProWeb.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(40, ErrorMessage = "Los nombres no pueden tener más de 40 caracteres")]
        [Display(Name ="Nombres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Los nombres no puede tener más de 40 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [ForeignKey("Ciudad")]
        [Display(Name = "Ciudad")]
        public int Ciudad_Id { get; set; }
        public Ciudad Ciudad { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Departamento> departamentos { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Competencia> competencias {get;set;}
        public DbSet<Prueba_Estudiante> pruebas_estudiantes { get;set;}
        public DbSet<Opcion> opciones {get;set;}
        public DbSet<Contexto> contexto { get; set; }
        public DbSet<Pregunta> preguntas { get; set; }
        public DbSet<Pregunta_Estudiante> preguntas_estudiantes { get;set;}
        public DbSet<Prueba> pruebas { get; set; }

        //public System.Data.Entity.DbSet<ProyectoSaberProWeb.Models.ApplicationUser> ApplicationUsers { get; set; }
        //public DbSet<> {get;set;}
    }
}