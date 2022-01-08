using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Service
{
    public class CountryService:ICountryService
    {
        HRContext context;
        public CountryService(HRContext _hRContext)
        {
            context = _hRContext;
        }
        public List<Country> LoadAllCountries()
        {
            List<Country> countries = context.country.ToList();
            return countries;
        }

    }
}
