using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Service
{
   public interface ICountryService
    {
        List<Country> LoadAllCountries();
    }
}
