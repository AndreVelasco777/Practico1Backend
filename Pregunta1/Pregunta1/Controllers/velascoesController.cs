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
using Pregunta1.Models;

namespace Pregunta1.Controllers
{
    public class velascoesController : ApiController
    {
        private DataContext db = new DataContext();

        public object Getvelascoes()
        {
            throw new NotImplementedException();
        }

        // GET: api/velascoes
        [Authorize]
        public IQueryable<velasco> Getvelascos()
        {
            return db.velascoes;
        }

        // GET: api/velascoes/5
        [Authorize]
        [ResponseType(typeof(velasco))]
        public IHttpActionResult Getvelasco(int id)
        {
            velasco velasco = db.velascoes.Find(id);
            if (velasco == null)
            {
                return NotFound();
            }

            return Ok(velasco);
        }

        // PUT: api/velascoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvelasco(int id, velasco velasco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != velasco.velascoID)
            {
                return BadRequest();
            }

            db.Entry(velasco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!velascoExists(id))
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

        // POST: api/velascoes
        [Authorize]
        [ResponseType(typeof(velasco))]
        public IHttpActionResult Postvelasco(velasco velasco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.velascoes.Add(velasco);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = velasco.velascoID }, velasco);
        }

        // DELETE: api/velascoes/5
        [Authorize]
        [ResponseType(typeof(velasco))]
        public IHttpActionResult Deletevelasco(int id)
        {
            velasco velasco = db.velascoes.Find(id);
            if (velasco == null)
            {
                return NotFound();
            }

            db.velascoes.Remove(velasco);
            db.SaveChanges();

            return Ok(velasco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool velascoExists(int id)
        {
            return db.velascoes.Count(e => e.velascoID == id) > 0;
        }
    }
}