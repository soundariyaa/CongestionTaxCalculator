using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    public class TaxRates
    {    
        public Time TimeFrom { get; set; } = new();
        public Time TimeTo { get; set; } = new();
        public int Amount { get; set; }
    }
    
}