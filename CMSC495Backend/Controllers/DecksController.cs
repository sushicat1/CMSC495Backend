using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CMSC495Backend.Models;

namespace CMSC495Backend.Controllers
{
    public class DecksController : ApiController
    {
        private CMSC495BackendContext db = new CMSC495BackendContext();

        // GET: api/Decks
        public IQueryable<Deck> GetDecks()
        {
            return db.Decks;
        }

        // GET: api/Decks/5
        [ResponseType(typeof(Deck))]
        public async Task<IHttpActionResult> GetDeck(int id)
        {
            Deck deck = await db.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            return Ok(deck);
        }

        // PUT: api/Decks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeck(int id, Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deck.Id)
            {
                return BadRequest();
            }

            db.Entry(deck).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
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

        // POST: api/Decks
        [ResponseType(typeof(Deck))]
        public async Task<IHttpActionResult> PostDeck(Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Decks.Add(deck);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deck.Id }, deck);
        }

        // DELETE: api/Decks/5
        [ResponseType(typeof(Deck))]
        public async Task<IHttpActionResult> DeleteDeck(int id)
        {
            Deck deck = await db.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            db.Decks.Remove(deck);
            await db.SaveChangesAsync();

            return Ok(deck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeckExists(int id)
        {
            return db.Decks.Count(e => e.Id == id) > 0;
        }
    }
}