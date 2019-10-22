using InfoClients.Core.Dtos;
using InfoClients.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using InfoClients.Core.Interfaces;
using InfoClients.Domain.IRepository;

namespace InfoClients.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly ICityRepository cityRepostitory;
        private readonly IClientRepository clientRepository;
        public ReportService(ICityRepository cityRepostitory
                             , IClientRepository clientRepository)
        {
            this.cityRepostitory = cityRepostitory;
            this.clientRepository = clientRepository;
        }

        public async Task<IEnumerable<VisitsCity>> VisitsByCity()
        {
            var visitsCity = new List<VisitsCity>();
            var cities = await cityRepostitory.GetAllAsync().ConfigureAwait(false);
            cities.ToList().ForEach(city =>
            {
                var visit = new VisitsCity
                {
                    NameCity = city.NameCity,
                    VisitsNum = VisitsCountByCity(city.Id)
                };
                visitsCity.Add(visit);
            });
            return visitsCity;
        }

        private int VisitsCountByCity(Guid cityId)
        {
            var visits = 0;
            var clientsByCity = clientRepository.GetAll(filter: clients => clients.CityId.Equals(cityId)
                    , includeProperties: "ClientVisit");

            clientsByCity.ToList().ForEach(client =>
            {
                visits += client.ClientVisit.Count;
            });
            return 0;
        }
    }
}
