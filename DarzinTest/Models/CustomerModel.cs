using System;
using System.Collections.Generic;

namespace DarzinTest.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PurchaseModel> Purchases { get; set; }
    }
}