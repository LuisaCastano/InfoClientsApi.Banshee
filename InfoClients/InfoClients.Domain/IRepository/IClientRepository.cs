using InfoClients.Domain.Entities;
using System;

namespace InfoClients.Domain.IRepository
{
    public interface IClientRepository : IERepository<Guid, Client>
    {
    }
}
