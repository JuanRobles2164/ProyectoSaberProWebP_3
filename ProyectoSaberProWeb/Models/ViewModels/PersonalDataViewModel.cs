using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Models.ViewModels
{
    public class PersonalDataViewModel
    {
        public ApplicationUser UsuarioPerfil { get; set; }
        public List<SelectListItem> Ciudades { get; set; }
        public PersonalDataViewModel() { }
        public PersonalDataViewModel(ApplicationDbContext db, string id) 
        {
            UsuarioPerfil = db.Users.Find(id);
            Ciudades = new List<SelectListItem>();
            foreach (var i in db.ciudades)
            {
                Ciudades.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre});
            }
        }
    }
}