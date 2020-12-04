using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BibliotecaComunitaria;

namespace BibliotecaComunitaria.Controllers
{
    public class AutoresController : ApiController
    {
        private BibliotecaComunitariaEntities db = new BibliotecaComunitariaEntities();

        // GET: api/Autores
        public IQueryable<Autor> GetAutor()
        {
            return db.Autor;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult GetAutor(string id)
        {
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutor(string id, Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.NroDocmeno)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Autores
        [ResponseType(typeof(Autor))]
        public IHttpActionResult PostAutor(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Autor.Add(autor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AutorExists(autor.NroDocmeno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autor.NroDocmeno }, autor);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult DeleteAutor(string id)
        {
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.Autor.Remove(autor);
            db.SaveChanges();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutorExists(string id)
        {
            return db.Autor.Count(e => e.NroDocmeno == id) > 0;
        }
    }
}