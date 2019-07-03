using DarzinTest.Data;
using DarzinTest.Models;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DarzinTest.Controllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/customers
        public IQueryable<CustomerModel> GetCustomers() => db.Customers;

        // GET: api/customers/5
        [ResponseType(typeof(CustomerModel))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            CustomerModel customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // GET: api/customers/5/products
        IQueryable<PurchaseModel> GetPurchases(int id)
        {
            return db.Purchases.Where(p => p.CustomerId == id);
        }

        // POST: api/customers/5/products
        [ResponseType(typeof(PurchaseModel))]
        public async Task<IHttpActionResult> Purchase(int id, int pid)
        {
            var purchase = new PurchaseModel();
            
            db.Purchases.Add(purchase);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchase.Id }, purchase);
        }

        // POST: api/customers
        [ResponseType(typeof(CustomerModel))]
        public async Task<IHttpActionResult> PostCustomer(CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/customers/5
        [ResponseType(typeof(CustomerModel))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            CustomerModel customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id) => db.Customers.Count(e => e.Id == id) > 0;
    }
}