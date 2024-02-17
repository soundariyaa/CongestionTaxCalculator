using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TaxCalculator.Request;



namespace TaxCalculator.Validators
{
    public class VehicleRequestValidator : AbstractValidator<CongestionTaxCalculatorRequest>
    {
        public  VehicleRequestValidator()
        {
            RuleFor(c => c.City).NotNull().NotEmpty();
            RuleFor(c => c.Vehicle).NotNull().NotEmpty();
            RuleFor(c => c.TravelDates).NotNull().NotEmpty();            
        }
    }
}