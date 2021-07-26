using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop1.Models
{
    public class SellPrice
    {
        public int SellPriceId { get; set; }

        public float Price { get; set; }

        public DateTime From { get; set; }

        public DateTime Until { get; set; }

        public List<Product> Products { get; set; }
    }
}
