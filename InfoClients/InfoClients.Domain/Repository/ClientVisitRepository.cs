using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class ClientVisitRepository : ERepository<int, ClientVisit>, IClientVisitRepository
    {
        public ClientVisitRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}

