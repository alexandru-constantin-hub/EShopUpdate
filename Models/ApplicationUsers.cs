using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop1.Models
{
    public class ApplicationUsers : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }    








    }
}
