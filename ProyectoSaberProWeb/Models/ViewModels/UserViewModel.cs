using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser UsuarioCreacion { get; set; }
        public IEnumerable<ApplicationUser> ListaUsuarios { get; set; }
        public string Message { get; set; }
        public UserViewModel(ApplicationDbContext db)
        {
            //Para crear y listar usuarios
            Message = null;
            UsuarioCreacion = new ApplicationUser();
            ListaUsuarios = db.Users.ToList();
        }
        public UserViewModel()
        {
            //Constructor vacío por siacas xD
        }
    }
}