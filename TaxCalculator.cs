using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TaxCalculator.Request;
using TaxCalculator.Models;
using System.Text.Json;
using TaxCalculator.Handler;
using TaxCalculator.Handler.Implementations;
using TaxCalculator.Handler.Interfaces;
using TaxCalculator.Response;

namespace Tax.Function
{
    public class TaxCalculator
    {
        private readonly ILogger<TaxCalculator> _logger;
        private readonly ICongestionTaxCalculator _congestionTaxCalculator;

            
        public TaxCalculator(ILogger<TaxCalculator> logger,ICongestionTaxCalculator congestionTaxCalculator)
        {
            _logger = logger;
            _congestionTaxCalculator =  congestionTaxCalculator;
        }

        [Function("TaxCalculator")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {        
           // CongestionTaxResponse taxResponse;     
            try
            { 
                string reqBody = await new StreamReader(req.Body).ReadToEndAsync();
                CongestionTaxCalculatorRequest congestionTaxCalculatorRequest = JsonSerializer.Deserialize<CongestionTaxCalculatorRequest>(reqBody);

                 if(congestionTaxCalculatorRequest is null)
                 {
                    _logger.LogInformation("Request is empty");
                    return new BadRequestObjectResult("Please send valid request!");
                 }
                 
                
             CongestionTaxResponse taxResponse = await _congestionTaxCalculator.CalculateTax(congestionTaxCalculatorRequest);

             _logger.LogInformation("C# HTTP trigger function processed a request.");
             return new OkObjectResult(taxResponse);             
            }
  
           catch(Exception ex)
           {            
             _logger.LogError($"Request failed with exception. {ex.Message}");
            return new BadRequestObjectResult(ex.Message);
           }
        }
    }
}
