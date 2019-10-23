using System;

namespace ProductApi.Models
{
    public class Product
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public long stock { get; set; }

        public override string ToString()
        {
            return base.ToString() + ": " + id.ToString();
        }
    }
}