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
using ExpenseTrackerMVC.Models;

namespace ExpenseTrackerAPI.Controllers
{
    public class ExpenseDetailsController : ApiController
    {
        private ExpenseTrackerDBEntities db = new ExpenseTrackerDBEntities();

        // GET: api/ExpenseDetails
        /*public IQueryable<ExpenseDetail> GetExpenseDetails()
        {
            return db.ExpenseDetails;
        }*/
        
        public IHttpActionResult GetExpenseDetail()
        {
            var expenses = db.ExpenseDetails.Join(db.Categories, e => e.categoryid, c => c.categoryid, (e, c) => new { e, c })
                .Select(ec => new ExpenseClass()
                {
                    expenseid = ec.e.expenseid,
                    title = ec.e.title,
                    description = ec.e.description,
                    amount = ec.e.amount,
                    name = ec.c.name,
                    date = ec.e.date,

                }).ToList();
            
            return Ok(expenses);
        }

        // GET: api/ExpenseDetails/5
        [ResponseType(typeof(ExpenseDetail))]
        public IHttpActionResult GetExpenseDetail(int id)
        {
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            if (expenseDetail == null)
            {
                return NotFound();
            }

            return Ok(expenseDetail);
        }

        // PUT: api/ExpenseDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenseDetail(int id, ExpenseDetail expenseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenseDetail.expenseid)
            {
                return BadRequest();
            }

            db.Entry(expenseDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseDetailExists(id))
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

        // POST: api/ExpenseDetails
        [ResponseType(typeof(ExpenseDetail))]
        public IHttpActionResult PostExpenseDetail(ExpenseDetail expenseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseDetails.Add(expenseDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expenseDetail.expenseid }, expenseDetail);
        }

        // DELETE: api/ExpenseDetails/5
        [ResponseType(typeof(ExpenseDetail))]
        public IHttpActionResult DeleteExpenseDetail(int id)
        {
            ExpenseDetail expenseDetail = db.ExpenseDetails.Find(id);
            if (expenseDetail == null)
            {
                return NotFound();
            }

            db.ExpenseDetails.Remove(expenseDetail);
            db.SaveChanges();

            return Ok(expenseDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseDetailExists(int id)
        {
            return db.ExpenseDetails.Count(e => e.expenseid == id) > 0;
        }
        
        
    }
}