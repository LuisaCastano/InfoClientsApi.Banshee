using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class StateRepository : ERepository<Guid, State>, IStateRepository
    { 
        public StateRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}

