using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Address
    {
       public string Street { get; set; }
       public string City { get; set; }
        public string State { get; set; }
       public string Zip { get; set; }
      
      public Address (string street, string city, string state, string zip){
        this.Street = street;
        this.City = city;
        this.State = state;
        this.Zip = zip;
      }
    }
}