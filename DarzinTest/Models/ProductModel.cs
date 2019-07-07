using System;
using System.Collections.Generic;

namespace DarzinTest.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        //public virtual ICollection<PurchaseModel> Purchases { get; set; }
    }
}