using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Core.Dtos;
using InfoClients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoClients.Api.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("GetVisitByCity")]
        [Produces(typeof(IList<VisitsCity>))]
        public async Task<IActionResult> GetVisitByCityAsync()
        {
            var visitsCity = await reportService.VisitsByCity().ConfigureAwait(false);
            if (!visitsCity?.ToList().Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(visitsCity);
        }
    }
}