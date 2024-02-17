using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Response
{
    public class CongestionTaxResponse
    {
        public string City { get; set; } = string.Empty;
        public string Vehicle { get; set; } = string.Empty;
        public IEnumerable<TaxData> TaxDetails { get; set; } = new List<TaxData>();


        public int TotalTaxPayable { get; set; }
    }

    public class TaxData
    {
        public DateTime Day { get; set; }

        public int TaxPayable { get; set; }
    }
}