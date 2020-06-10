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
        public List<SelectListItem> Departamentos { get; set; }
        public int CiudadId { get; set; }
        public List<SelectListItem> Ciudades { get; set; }
        public PersonalDataViewModel() { }
        public PersonalDataViewModel(ApplicationDbContext db, string id) 
        {
            Departamentos = new List<SelectListItem>();
            UsuarioPerfil = db.Users.Find(id);
            Ciudades = new List<SelectListItem>();
            foreach (var i in db.ciudades.ToList())
            {
                Ciudades.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre});
            }
            foreach (var i in db.departamentos.ToList())
            {
                Departamentos.Add(new SelectListItem() { Value = i.ID.ToString(), Text = i.Nombre});
            }
        }
    }
}