using System;

namespace DarzinTest.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}