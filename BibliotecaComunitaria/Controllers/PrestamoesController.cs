using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaComunitaria;

namespace BibliotecaComunitaria.Controllers
{
    public class PrestamoesController : Controller
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: Prestamoes
        public ActionResult Index()
        {
            var prestamo = db.Prestamo.Include(p => p.Prestador);
            return View(prestamo.ToList());
        }

        // GET: Prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.NroDocumento = new SelectList(db.Prestador, "NroDocumento", "Nombres");
            return View();
        }

        // POST: Prestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoID,NroDocumento,TipoDocumento,FechaPrestamo,FechaReal")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamo.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroDocumento = new SelectList(db.Prestador, "NroDocumento", "Nombres", prestamo.NroDocumento);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.NroDocumento = new SelectList(db.Prestador, "NroDocumento", "Nombres", prestamo.NroDocumento);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoID,NroDocumento,TipoDocumento,FechaPrestamo,FechaReal")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NroDocumento = new SelectList(db.Prestador, "NroDocumento", "Nombres", prestamo.NroDocumento);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamo.Find(id);
            db.Prestamo.Remove(prestamo);
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
