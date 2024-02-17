using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace TaxCalculator.Models
{
    public class City
    {      
        public string CityName { get; set; } = "";
        public ICollection<TaxRates> TaxRates { get; set; } = new List<TaxRates>();

        public ICollection<Holidays> TollFreeDates { get; set; } = new List<Holidays>();

        public ICollection<string> TollFreeVehicles { get; set; } = new List<string>();
       
    } 

   

    
}