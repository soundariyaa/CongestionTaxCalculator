using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Handler.Interfaces;
using TaxCalculator.Models;
using TaxCalculator.Request;
using TaxCalculator.Response;
using TaxCalculator.Helper;

namespace TaxCalculator.Handler.Implementations
{
    public class CongestionTaxCalculator : CongestionTaxCalculatorBase,ICongestionTaxCalculator
    {
        // private readonly CityTaxDetails _cityTaxDetails;
        // public CongestionTaxCalculator (CityTaxDetails cityTaxDetails)
        // {
        //     _cityTaxDetails = cityTaxDetails;
        // }
         public async Task<CongestionTaxResponse> CalculateTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest)
        {
            // Add: fluent validation
            var taxAmountByDates = await  GetCongestionTax(congestionTaxCalculatorRequest);

            return new CongestionTaxResponse
            {
                City = congestionTaxCalculatorRequest.City,
                Vehicle = congestionTaxCalculatorRequest.Vehicle,
                TotalTaxPayable = taxAmountByDates.Values.Sum(),
                TaxDetails = taxAmountByDates.Select(i => new TaxData { Day = i.Key, TaxPayable = i.Value })
            };
        }

        public async Task<Dictionary<DateTime, int>> GetCongestionTax(CongestionTaxCalculatorRequest congestionTaxCalculatorRequest)
        {
            string getCityName = congestionTaxCalculatorRequest.City;
            var cityDic = CityTaxDetails.GetCityTaxRate();
            City cityDetails = CityTaxDetails.dicCity[getCityName]; 
             
        Dictionary<DateTime, int> calculatedTaxDetails = GetCongestionTaxByDates(
                                                            congestionTaxCalculatorRequest.Vehicle,
                                                            congestionTaxCalculatorRequest.TravelDates,
                                                            cityDetails.TollFreeVehicles,
                                                            cityDetails.TollFreeDates,
                                                            cityDetails.TaxRates);
        return calculatedTaxDetails;
        }


        private Dictionary<DateTime, int> GetCongestionTaxByDates(string vehicle,
        ICollection<DateTime> dates,
        ICollection<string> tollFreeVehicles,
        ICollection<Holidays> tollFreeDates,
        ICollection<TaxRates> taxRates)
    {
        Dictionary<DateTime, int> taxByDates = new Dictionary<DateTime, int>();
        DateTime intervalStart = dates.First();
        int tempFee = 0;

        taxByDates.Add(intervalStart.Date, tempFee);

        int perDayTotalFee = 0;

        foreach (DateTime date in dates)
        {
            TimeSpan ts = date - intervalStart;

            // get time difference between last date and current item
            double minutes = ts.TotalMinutes;

            int nextFee = GetTollFee(date, vehicle, tollFreeVehicles, tollFreeDates, taxRates);

            CalculateTax(taxByDates, ref intervalStart, ref tempFee, ref perDayTotalFee, date, minutes, nextFee);
        }

        return taxByDates;
    }

    private void CalculateTax(Dictionary<DateTime, int> perDayTax, 
        ref DateTime intervalStart,
        ref int tempFee, 
        ref int perDayTotalFee,
        DateTime date, 
        double minutes,
        int nextFee)
    {
        if (minutes <= 60)
        {
            // if same day
            if (nextFee >= tempFee)
            {
                perDayTotalFee = perDayTotalFee - tempFee + nextFee;
                tempFee = nextFee;
                CalculatePerDayTax(date, perDayTotalFee, perDayTax);
                //intervalStart = date;
            }
        }
        else
        {
            // check if different days
            perDayTotalFee = GetTaxIfDifferentDate(intervalStart, perDayTotalFee, date);

            tempFee = nextFee;
            perDayTotalFee = perDayTotalFee + nextFee;
            CalculatePerDayTax(date, perDayTotalFee, perDayTax);
            //intervalStart = date;
        }
        intervalStart = date;
    }

    private int GetTaxIfDifferentDate(DateTime intervalStart, int perDayTotalFee, DateTime date)
    {
        //TimeSpan totalTime = date - intervalStart;
        
        if (date.Day > intervalStart.Day) perDayTotalFee = 0;
       
        return perDayTotalFee;
    }

    private int CalculatePerDayTax(DateTime currentDate, 
        int total,
        Dictionary<DateTime, int> perDayTax)
    {
        // if per day tax amount is greater than 60
        if (total > 60) total = 60;

        // set total against date
        perDayTax[currentDate.Date] = total;

        return total;
    }
    }
}