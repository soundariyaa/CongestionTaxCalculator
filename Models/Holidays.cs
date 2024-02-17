using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    public class Holidays
    {    
        public int Month { get; set; }

        public int[] Days { get; set; } = Array.Empty<int>();
    }
    
}