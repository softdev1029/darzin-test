using DarzinTest.Data;
using DarzinTest.Models;
using System.Collections.Generic;
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
        public List<ProductModel> Get(int id)
        {
            List<ProductModel> pList = new List<ProductModel>();
            var c = db.Customers.Find(id);
            foreach (PurchaseModel p in c.Purchases)
            {
                pList.Add(db.Products.Find(p.ProductId));
            }
            return pList;
        }

        // POST: api/purchases/5
        [ResponseType(typeof(PurchaseModel))]
        public async Task<IHttpActionResult> PostPurchase(int id, ProductModel product)
        {
            var purchase = new PurchaseModel();
            purchase.CustomerId = id;
            purchase.ProductId = product.Id;
            
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