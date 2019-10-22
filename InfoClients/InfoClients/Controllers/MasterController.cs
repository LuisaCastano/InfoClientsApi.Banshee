using InfoClients.Core.Dtos;
using InfoClients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace InfoClients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : Controller
    {
        private readonly IMasterService masterService;
        public MasterController(IMasterService masterService)
        {
            this.masterService = masterService;
        }
        [HttpGet("GetAllCountry")]
        [Produces(typeof(IList<Country>))]
        public async Task<IActionResult> GetAllCountryAsync()
        {
            var country = await masterService.GetCountryAsync().ConfigureAwait(false);
            if (!country?.ToList().Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(country);
        }

        [HttpGet("GetAllState")]
        [Produces(typeof(IList<State>))]
        public async Task<IActionResult> GetAllStateAsync()
        {
            var state = await masterService.GetStateAsync().ConfigureAwait(false);
            if (!state?.ToList().Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(state);
        }
        [HttpGet("GetAllCity")]
        [Produces(typeof(IList<City>))]
        public async Task<IActionResult> GetAllCityAsync()
        {
            var city = await masterService.GetCityAsync().ConfigureAwait(false);
            if (!city?.ToList().Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(city);
        }
        [HttpGet("GetAllSalesRepresentative")]
        [Produces(typeof(IList<SalesRepresentative>))]
        public async Task<IActionResult> GetAllSalesRepresentativeAsync()
        {
            var salesRepresentatives = await masterService.GetSalesRepresentativesAsync().ConfigureAwait(false);
            if (!salesRepresentatives?.ToList().Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(salesRepresentatives);
        }
    }
}