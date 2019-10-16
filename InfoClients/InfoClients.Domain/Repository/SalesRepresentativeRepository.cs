using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class SalesRepresentativeRepository : ERepository<int, SalesRepresentative>, ISalesRepresentativeRepository
    {
        public SalesRepresentativeRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}
