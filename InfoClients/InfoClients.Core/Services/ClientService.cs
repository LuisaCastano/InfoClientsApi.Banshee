using AutoMapper;
using InfoClients.Core.Interfaces;
using InfoClients.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Core.Services
{
    public class ClientService : Service<Guid, Domain.Entities.Client, Dtos.Client>, IClientService
    {
        public ClientService(IClientRepository respository, 
                                    IMapper serviceMapper) : base(respository ,serviceMapper)
        {

        }
    }
}
