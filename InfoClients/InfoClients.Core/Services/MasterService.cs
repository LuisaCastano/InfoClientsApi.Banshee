using AutoMapper;
using InfoClients.Core.Dtos;
using InfoClients.Domain.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using InfoClients.Core.Interfaces;

namespace InfoClients.Core.Services
{
    public class MasterService : IMasterService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IStateRepository stateRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISalesRepresentativeRepository salesRepresentativeRepository;
        private readonly IMapper serviceMapper;
        public MasterService(ICountryRepository countryRepository
                                , IStateRepository stateRepository
                                , ICityRepository cityRepository
                                , ISalesRepresentativeRepository salesRepresentativeRepository
                                , IMapper serviceMapper)
        {
            this.countryRepository = countryRepository;
            this.stateRepository = stateRepository;
            this.cityRepository = cityRepository;
            this.salesRepresentativeRepository = salesRepresentativeRepository;
            this.serviceMapper = serviceMapper;

        }

        public async Task<IEnumerable<Country>> GetCountryAsync()
        {
            return from item in await countryRepository.GetAllAsync().ConfigureAwait(false)
                   select serviceMapper.Map<Country>(item);
        }

        public async Task<IEnumerable<State>> GetStateAsync()
        {
            return from item in await stateRepository.GetAllAsync().ConfigureAwait(false)
                   select serviceMapper.Map<State>(item);
        }

        public async Task<IEnumerable<City>> GetCityAsync()
        {
            return from item in await cityRepository.GetAllAsync().ConfigureAwait(false)
                   select serviceMapper.Map<City>(item);
        }

        public async Task<IEnumerable<SalesRepresentative>> GetSalesRepresentativesAsync()
        {
            return from item in await salesRepresentativeRepository.GetAllAsync().ConfigureAwait(false)
                   select serviceMapper.Map<SalesRepresentative>(item);
        }
    }
}
