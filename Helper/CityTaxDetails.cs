using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using TaxCalculator.Models;
using System.Text.Json.Serialization;
using System.ComponentModel;


namespace TaxCalculator.Helper
{
     
    public class CityTaxDetails
    {
        public static Dictionary<string, City> dicCity = new Dictionary<string, City>();
        public static List<Models.City> cities = new List<City>();

       
    
    public static List<City> GetCityTaxRate()
    {
        // try
        // {
            using (StreamReader r = new StreamReader("City.json"))
            {
                string json = r.ReadToEnd();
                 City city = JsonSerializer.Deserialize<City>(json);

               //  City city = JsonSerializer.Deserialize<City>(File.ReadAllText("City.json"));
           cities.Add(city);
            
          
           dicCity.Add(city.CityName,city);  
             }               
            
        //}
        // catch (Exception ex)
        // {
            
        // }
        return cities;
    }
    }
    
}