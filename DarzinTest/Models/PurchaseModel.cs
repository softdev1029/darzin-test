using System;
using System.Collections.Generic;

namespace DarzinTest.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public virtual CustomerModel Customer { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}