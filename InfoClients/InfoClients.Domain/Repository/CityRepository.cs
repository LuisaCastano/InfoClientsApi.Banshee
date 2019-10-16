using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class CityRepository : ERepository<Guid, City>, ICityRepository
    {
        public CityRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}
