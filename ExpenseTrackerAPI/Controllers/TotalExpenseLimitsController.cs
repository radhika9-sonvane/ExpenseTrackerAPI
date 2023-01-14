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
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Controllers
{
    public class TotalExpenseLimitsController : ApiController
    {
        private ExpenseTrackerDBEntities db = new ExpenseTrackerDBEntities();

        // GET: api/TotalExpenseLimits
        public IQueryable<TotalExpenseLimit> GetTotalExpenseLimits()
        {
            return db.TotalExpenseLimits;
        }

        // GET: api/TotalExpenseLimits/5
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult GetTotalExpenseLimit(int id)
        {
            TotalExpenseLimit totalExpenseLimit = db.TotalExpenseLimits.Find(id);
            if (totalExpenseLimit == null)
            {
                return NotFound();
            }

            return Ok(totalExpenseLimit);
        }

        // PUT: api/TotalExpenseLimits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTotalExpenseLimit(int id, TotalExpenseLimit totalExpenseLimit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != totalExpenseLimit.totalexpenseid)
            {
                return BadRequest();
            }

            db.Entry(totalExpenseLimit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalExpenseLimitExists(id))
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

        // POST: api/TotalExpenseLimits
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult PostTotalExpenseLimit(TotalExpenseLimit totalExpenseLimit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TotalExpenseLimits.Add(totalExpenseLimit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = totalExpenseLimit.totalexpenseid }, totalExpenseLimit);
        }

        // DELETE: api/TotalExpenseLimits/5
        [ResponseType(typeof(TotalExpenseLimit))]
        public IHttpActionResult DeleteTotalExpenseLimit(int id)
        {
            TotalExpenseLimit totalExpenseLimit = db.TotalExpenseLimits.Find(id);
            if (totalExpenseLimit == null)
            {
                return NotFound();
            }

            db.TotalExpenseLimits.Remove(totalExpenseLimit);
            db.SaveChanges();

            return Ok(totalExpenseLimit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TotalExpenseLimitExists(int id)
        {
            return db.TotalExpenseLimits.Count(e => e.totalexpenseid == id) > 0;
        }
    }
}