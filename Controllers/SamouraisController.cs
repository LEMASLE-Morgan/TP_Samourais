using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TP_Samouraï;
using TP_Samouraï.Models;

namespace TP_Samouraï.Controllers
{
    public class SamouraisController : Controller
    {
        private Context db = new Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var samouraiVm = new SamouraiVM();
            samouraiVm.Armes = db.Armes.ToList();
            samouraiVm.ArtsMartiaux = db.ArtMartials.ToList();
            return View(samouraiVm);
        }

        // POST: Samourais/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVm)
        {
            if (ModelState.IsValid)
            {
                samouraiVm.Samourai.Arme = db.Armes.Find(samouraiVm.IdArmes);
                samouraiVm.Samourai.ArtsMartiaux = db.ArtMartials.Where(x => samouraiVm.IdArtMartiaux.Contains(x.Id)).ToList();
                db.Samourais.Add(samouraiVm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samouraiVm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            var samouraiVm = new SamouraiVM();
            samouraiVm.Armes = db.Armes.ToList();
            samouraiVm.Samourai = samourai;

            if (samourai.Arme != null)
            {
                samouraiVm.IdArmes = samourai.Arme.Id;
            }
                return View(samouraiVm);
        }

        // POST: Samourais/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                var samouraiDb = db.Samourais.Find(samouraiVM.Samourai.Id);
                samouraiDb.Force = samouraiVM.Samourai.Force;
                samouraiDb.Nom = samouraiVM.Samourai.Nom;
                samouraiVM.Armes = null;

                if (samouraiVM.IdArmes != null)
                {
                    samouraiDb.Arme = db.Armes.Find(samouraiVM.IdArmes);
            }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
