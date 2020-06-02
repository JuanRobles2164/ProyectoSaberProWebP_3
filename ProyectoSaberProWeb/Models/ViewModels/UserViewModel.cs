using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> ListaUsuarios { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// Trae todos los usuarios que correspondan a un role
        /// </summary>
        public UserViewModel(ApplicationDbContext db, string role)
        {
            this.ListaUsuarios = getUsersByRoleId(role, db);
        }
        /// <summary>
        /// Para crear y listar todos los usuarios
        /// </summary>
        public UserViewModel(ApplicationDbContext db)
        {
            //Para crear y listar todos los usuarios
            Message = null;
            ListaUsuarios = db.Users.ToList();
        }
        /// <summary>
        /// Constructor vacío por siakas XD
        /// </summary>

        public UserViewModel()
        {

        }


        /// <summary>
        /// Trae todos los usuarios que correspondan a un Role Especificado
        /// </summary>
        private IEnumerable<ApplicationUser> getUsersByRoleId(string role, ApplicationDbContext db)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            return usuarios;
        }
        /// <summary>
        /// Trae todos los usuarios que correspondan a un Role con un ordenamiento determinado
        /// </summary>
        public UserViewModel(ApplicationDbContext db, string role, string sortOrder)
        {
            this.ListaUsuarios = getUsersByRoleId(role, db, sortOrder);
        }
        /// <summary>
        /// Trae todos los usuarios que correspondan a un Role Especificado con un ordenamiento determinado
        /// </summary>
        private IEnumerable<ApplicationUser> getUsersByRoleId(string role, ApplicationDbContext db, string sortOrder)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            switch (sortOrder)
            {
                case "Nombres":
                    usuarios.OrderBy(s => s.Nombres);
                    break;
                case "Nombres_desc":
                    usuarios.OrderByDescending(s => s.Nombres);
                    break;
                case "Apellidos":
                    usuarios.OrderBy(s => s.Apellidos);
                    break;
                case "Apellidos_desc":
                    usuarios.OrderByDescending(s => s.Apellidos);
                    break;
                case "Email":
                    usuarios.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    usuarios.OrderByDescending(s => s.Email);
                    break;
                case "Username":
                    usuarios.OrderBy(s => s.UserName);
                    break;
                case "Username_desc":
                    usuarios.OrderByDescending(s => s.UserName);
                    break;
                default:
                    usuarios.OrderBy(s => s.Id);
                    break;
            }
            return usuarios;
        }
    }
}