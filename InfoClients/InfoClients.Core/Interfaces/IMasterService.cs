using InfoClients.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoClients.Core.Interfaces
{
    public interface IMasterService
    {
        Task<IEnumerable<Country>> GetCountryAsync();
        Task<IEnumerable<State>> GetStateAsync();
        Task<IEnumerable<City>> GetCityAsync();
        Task<IEnumerable<SalesRepresentative>> GetSalesRepresentativesAsync();
    }
}
