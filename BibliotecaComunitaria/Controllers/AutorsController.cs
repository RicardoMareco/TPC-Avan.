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
    public class AutorsController : Controller
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: Autors
        public ActionResult Index()
        {
            var autor = db.Autor.Include(a => a.Ciudad).Include(a => a.TipoDocumento);
            return View(autor.ToList());
        }

        // GET: Autors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }
    }
}
