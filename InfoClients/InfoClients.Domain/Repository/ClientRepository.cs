using InfoClients.Domain.Entities;
using InfoClients.Domain.IRepository;
using System;

namespace InfoClients.Domain.Repository
{
    public class ClientRepository : ERepository<Guid, Client>, IClientRepository
    {
        public ClientRepository(IQueryableUnitOfWork masterContext) : base(masterContext)
        {

        }
    }
}
