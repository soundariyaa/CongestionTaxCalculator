using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Request

{
    public class CongestionTaxCalculatorRequest
    {
        public string City { get; set; }= string.Empty;
        public string Vehicle { get; set; } = string.Empty;
        public ICollection<DateTime> TravelDates { get; set; } = new List<DateTime>();
    }
}