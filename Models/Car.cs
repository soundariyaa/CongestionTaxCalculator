using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    public class Car : Vehicle
    {
        public string GetVehicleType()
        {
            return "Car";
        }
        
    }
}