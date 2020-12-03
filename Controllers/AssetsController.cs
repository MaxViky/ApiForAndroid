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
using ApiForAndroid.Entity;
using ApiForAndroid.Models;

namespace ApiForAndroid.Controllers
{
    public class AssetsController : ApiController
    {
        private session1Entities db = new session1Entities();

        // GET: api/Assets
        [ResponseType(typeof(List<ResponseAssets>))]
        public IHttpActionResult GetAssets()
        {
            return Ok(db.Assets.ToList().ConvertAll(p => new ResponseAssets(p)));
        }

        // GET: api/Assets/5
        [ResponseType(typeof(Assets))]
        public IHttpActionResult GetAssets(long id)
        {
            Assets assets = db.Assets.Find(id);
            if (assets == null)
            {
                return NotFound();
            }

            return Ok(assets);
        }

        // PUT: api/Assets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssets(long id, Assets assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assets.ID)
            {
                return BadRequest();
            }

            db.Entry(assets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsExists(id))
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

        // POST: api/Assets
        [ResponseType(typeof(Assets))]
        public IHttpActionResult PostAssets(Assets assets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assets.Add(assets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assets.ID }, assets);
        }

        // DELETE: api/Assets/5
        [ResponseType(typeof(Assets))]
        public IHttpActionResult DeleteAssets(long id)
        {
            Assets assets = db.Assets.Find(id);
            if (assets == null)
            {
                return NotFound();
            }

            db.Assets.Remove(assets);
            db.SaveChanges();

            return Ok(assets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsExists(long id)
        {
            return db.Assets.Count(e => e.ID == id) > 0;
        }
    }
}