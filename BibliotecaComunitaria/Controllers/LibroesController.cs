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
    public class LibroesController : Controller
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: Libroes
        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Editorial);
            return View(libro.ToList());
        }

        // GET: Libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libroes/Create
        public ActionResult Create()
        {
            ViewBag.NroDocumento = new SelectList(db.Autor, "NroDocmeno", "NombreFantasia");
            ViewBag.EditorialID = new SelectList(db.Editorial, "EditorialID", "NombreEditorial");
            return View();
        }

        // POST: Libroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibroID,NroDocumento,TipoDocumento,Titulo,Edicion,EditorialID,FechaPublicacion,CantidadEjemplares,CantidadDisponible")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroDocumento = new SelectList(db.Autor, "NroDocmeno", "NombreFantasia", libro.NroDocumento);
            ViewBag.EditorialID = new SelectList(db.Editorial, "EditorialID", "NombreEditorial", libro.EditorialID);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.NroDocumento = new SelectList(db.Autor, "NroDocmeno", "NombreFantasia", libro.NroDocumento);
            ViewBag.EditorialID = new SelectList(db.Editorial, "EditorialID", "NombreEditorial", libro.EditorialID);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibroID,NroDocumento,TipoDocumento,Titulo,Edicion,EditorialID,FechaPublicacion,CantidadEjemplares,CantidadDisponible")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NroDocumento = new SelectList(db.Autor, "NroDocmeno", "NombreFantasia", libro.NroDocumento);
            ViewBag.EditorialID = new SelectList(db.Editorial, "EditorialID", "NombreEditorial", libro.EditorialID);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
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
