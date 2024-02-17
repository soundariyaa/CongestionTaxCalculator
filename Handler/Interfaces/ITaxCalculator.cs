using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Request;
using TaxCalculator.Response;

namespace TaxCalculator.Handler.Interfaces
{
    public interface ICongestionTaxCalculator
    {
       Task<Dictionary<DateTime, int>> GetCongestionTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest);
       Task<CongestionTaxResponse> CalculateTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest);
       //Task<CongestionTaxResponse> GetCongestionTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest);
    }
}