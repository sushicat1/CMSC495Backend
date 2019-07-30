﻿using System;
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
    public class CardsController : ApiController
    {
        private CMSC495BackendContext db = new CMSC495BackendContext();

        // GET: api/Cards
        public IQueryable<Card> GetCards()
        {
            return db.Cards;
        }

        // GET: api/Cards/5
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> GetCard(int id)
        {
            Card card = await db.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCard(int id, Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.Id)
            {
                return BadRequest();
            }

            db.Entry(card).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> PostCard(Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cards.Add(card);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> DeleteCard(int id)
        {
            Card card = await db.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            db.Cards.Remove(card);
            await db.SaveChangesAsync();

            return Ok(card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExists(int id)
        {
            return db.Cards.Count(e => e.Id == id) > 0;
        }
    }
}