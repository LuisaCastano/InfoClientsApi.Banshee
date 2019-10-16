using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class CountryRepository : ERepository<Guid, Country>, ICountryRepository
    {
        public CountryRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}