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
    public class ComentariosController : Controller
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComentarioID,Mail,Comentario1")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(comentario);
        }

    }
}
