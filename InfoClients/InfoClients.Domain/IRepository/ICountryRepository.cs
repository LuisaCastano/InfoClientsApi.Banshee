using InfoClients.Domain.Entities;
using System;

namespace InfoClients.Domain.IRepository
{
    public interface ICountryRepository : IERepository<Guid, Country>
    {
    }
}
