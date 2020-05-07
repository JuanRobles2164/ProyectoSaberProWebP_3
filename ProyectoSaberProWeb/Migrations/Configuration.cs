namespace ProyectoSaberProWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoSaberProWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProyectoSaberProWeb.Models.ApplicationDbContext";
        }

        protected override void Seed(ProyectoSaberProWeb.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(x => x.Id,
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "1", Name = "Administrador"},
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "2", Name = "Docente" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "3", Name = "Alumno" }
                );
            context.departamentos.AddOrUpdate(
                new Models.Departamento { ID = 11, Nombre = "Bogotá D.C." },
                new Models.Departamento {  ID = 13, Nombre = "Bolívar"},
                new Models.Departamento { ID = 15, Nombre = "Boyacá"},
                new Models.Departamento { ID = 17, Nombre = "Caldas"},
                new Models.Departamento { ID = 18, Nombre = "Caquetá"},
                new Models.Departamento { ID = 19, Nombre = "Cauca"},
                new Models.Departamento { ID = 20, Nombre = "Cesar"},
                new Models.Departamento { ID = 23, Nombre = "Córdoba"},
                new Models.Departamento { ID = 25, Nombre = "Cundinamarca"},
                new Models.Departamento { ID = 27, Nombre = "Chocó"},
                new Models.Departamento { ID = 41, Nombre = "Huila"},
                new Models.Departamento { ID = 44, Nombre = "La Guajira"},
                new Models.Departamento { ID = 47, Nombre = "Magdalena"},
                new Models.Departamento { ID = 5, Nombre = "Antioquia"},
                new Models.Departamento { ID = 50, Nombre = "Meta"},
                new Models.Departamento { ID = 52, Nombre = "Nariño"},
                new Models.Departamento { ID = 54, Nombre = "Norte de Santander"},
                new Models.Departamento {ID = 63, Nombre = "Quindío"},
                new Models.Departamento {ID = 66, Nombre = "Risaralda"},
                new Models.Departamento {ID = 68, Nombre = "Santander"},
                new Models.Departamento {ID = 70, Nombre = "Sucre"},
                new Models.Departamento {ID = 73, Nombre = "Tolima"},
                new Models.Departamento {ID = 76, Nombre = "Valle del Cauca"},
                new Models.Departamento {ID = 8, Nombre = "Atlántico"},
                new Models.Departamento {ID = 81, Nombre = "Arauca"},
                new Models.Departamento {ID = 85, Nombre = "Casanare"},
                new Models.Departamento {ID = 86, Nombre = "Putumayo"},
                new Models.Departamento {ID = 88, Nombre = "Archipiélago de San Andrés, Providencia y Santa Catalina"},
                new Models.Departamento {ID = 91, Nombre = "Amazonas"},
                new Models.Departamento {ID = 94, Nombre = "Guainía"},
                new Models.Departamento {ID = 95, Nombre = "Guaviare"},
                new Models.Departamento {ID = 97, Nombre = "Vaupés"},
                new Models.Departamento {ID = 99, Nombre = "Vichada"}
                );
        }
    }
}
