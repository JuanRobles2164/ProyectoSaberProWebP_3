using Microsoft.AspNet.Identity;
using ProyectoSaberProWeb.Models;
using ProyectoSaberProWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    public class DocenteController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Docente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Docente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Docente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Docente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Docente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Docente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Docente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PersonalData()
        {
            var id = User.Identity.GetUserId();
            PersonalDataViewModel pdvm = new PersonalDataViewModel(db, id);
            return View(pdvm);
        }
        [HttpPost]
        public ActionResult PersonalData(PersonalDataViewModel pdvm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdvm).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pdvm);
        }
    }
}
