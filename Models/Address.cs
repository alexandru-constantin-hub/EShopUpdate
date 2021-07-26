using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop1.Models
{
    public class Address
    {

        public int AddressId { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int BuldingNumber { get; set; }
        public int AppNumber { get; set; }
        public int PostalCode { get; set; }
        public string Province { get; set; }
        public string Locality { get; set; }
        public bool isInvoiceAddress { get; set; }
        public bool isDeliveryAddress { get; set; }

        public List<ApplicationUsers> ApplicationUsers { get; set; }







    }
}
