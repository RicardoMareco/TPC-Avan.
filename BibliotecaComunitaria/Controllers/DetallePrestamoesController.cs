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
    public class DetallePrestamoesController : Controller
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: DetallePrestamoes
        public ActionResult Index()
        {
            var detallePrestamo = db.DetallePrestamo.Include(d => d.Libro).Include(d => d.Prestamo);
            return View(detallePrestamo.ToList());
        }

        // GET: DetallePrestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePrestamo detallePrestamo = db.DetallePrestamo.Find(id);
            if (detallePrestamo == null)
            {
                return HttpNotFound();
            }
            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Create
        public ActionResult Create()
        {
            ViewBag.LibroID = new SelectList(db.Libro, "LibroID", "NroDocumento");
            ViewBag.PrestamoID = new SelectList(db.Prestamo, "PrestamoID", "NroDocumento");
            return View();
        }

        // POST: DetallePrestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoID,DetallePrestamoID,FechaVencimiento,FechaDevolucion,CantidadEjemplares,LibroID,Estado")] DetallePrestamo detallePrestamo)
        {
            if (ModelState.IsValid)
            {
                db.DetallePrestamo.Add(detallePrestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libro, "LibroID", "NroDocumento", detallePrestamo.LibroID);
            ViewBag.PrestamoID = new SelectList(db.Prestamo, "PrestamoID", "NroDocumento", detallePrestamo.PrestamoID);
            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePrestamo detallePrestamo = db.DetallePrestamo.Find(id);
            if (detallePrestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LibroID = new SelectList(db.Libro, "LibroID", "NroDocumento", detallePrestamo.LibroID);
            ViewBag.PrestamoID = new SelectList(db.Prestamo, "PrestamoID", "NroDocumento", detallePrestamo.PrestamoID);
            return View(detallePrestamo);
        }

        // POST: DetallePrestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoID,DetallePrestamoID,FechaVencimiento,FechaDevolucion,CantidadEjemplares,LibroID,Estado")] DetallePrestamo detallePrestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePrestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LibroID = new SelectList(db.Libro, "LibroID", "NroDocumento", detallePrestamo.LibroID);
            ViewBag.PrestamoID = new SelectList(db.Prestamo, "PrestamoID", "NroDocumento", detallePrestamo.PrestamoID);
            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePrestamo detallePrestamo = db.DetallePrestamo.Find(id);
            if (detallePrestamo == null)
            {
                return HttpNotFound();
            }
            return View(detallePrestamo);
        }

        // POST: DetallePrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePrestamo detallePrestamo = db.DetallePrestamo.Find(id);
            db.DetallePrestamo.Remove(detallePrestamo);
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
