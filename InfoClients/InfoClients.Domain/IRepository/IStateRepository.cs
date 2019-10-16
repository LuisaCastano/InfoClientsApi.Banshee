using InfoClients.Domain.Entities;
using System;

namespace InfoClients.Domain.IRepository
{
    public interface IStateRepository : IERepository<Guid, State>
    {
    }
}
