using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Service
{
    public class CityService :ICityService
    {
        HRContext context;
        public CityService(HRContext _hRContext)
        {
            context = _hRContext;
        }
        public List<City> LoadAllCities()
        {
            List<City> cities = context.city.ToList();
            return cities;
        }

        public List<City> LoadCityCountry(int id)
        {
            List<City> cities = context.city.Where(c => c.Country_id == id).ToList();
            return cities;
        }

    }
}
