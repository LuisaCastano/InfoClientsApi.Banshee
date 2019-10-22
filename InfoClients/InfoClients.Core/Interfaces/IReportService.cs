using InfoClients.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoClients.Core.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<VisitsCity>> VisitsByCity();
    }
}
