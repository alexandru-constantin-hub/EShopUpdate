using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop1.Models
{
    public class Model
    {

        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Product> Products { get; set; }


    }
}
