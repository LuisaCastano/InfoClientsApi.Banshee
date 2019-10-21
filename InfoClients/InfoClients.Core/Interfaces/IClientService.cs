using System;

namespace InfoClients.Core.Interfaces
{
    public interface IClientService : IService<Guid, Domain.Entities.Client, Dtos.Client>
    {
    }
}
