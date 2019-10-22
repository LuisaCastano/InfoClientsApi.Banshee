using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Core.Dtos;
using InfoClients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoClients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }
 
        [HttpGet("GetAllClients")]
        [Produces(typeof(IList<Client>))]
        public async Task<IActionResult> GetAllClientClientsAsync()
        {
            var client = await clientService.GetAllAsync(includeProperties: "Country,State,City").ConfigureAwait(false);
            if(!client?.Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(client);
        }

        [HttpGet("GetClientById/{id}")]
        [Produces(typeof(Client))]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await clientService.GetAllAsync(filter: clients => clients.Id.Equals(id)).ConfigureAwait(false);
            if (!client?.Any() ?? true)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(client.FirstOrDefault()); 
        }


        [HttpPost]
        public async Task<IActionResult> CreateClient([FromForm]Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await clientService.AddAsync(client).ConfigureAwait(false);
            return new AcceptedResult();
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
