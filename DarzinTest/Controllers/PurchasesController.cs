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
    public class PurchasesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/purchases/5
        IQueryable<PurchaseModel> GetPurchases(int id)
        {
            return db.Purchases.Where(p => p.CustomerId == id);
        }

        // POST: api/purchases/5
        [ResponseType(typeof(PurchaseModel))]
        public async Task<IHttpActionResult> Purchase(int id, int pid)
        {
            var purchase = new PurchaseModel();
            
            db.Purchases.Add(purchase);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchase.Id }, purchase);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}