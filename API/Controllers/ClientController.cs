using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;
using TimeSheet.Service;

namespace API.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        private readonly IMapper _mapper;

        public ClientController(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] CreateClientDTO newClientDto)
        {
            var newClient = _mapper.Map<CreateClientDTO, Client>(newClientDto);
            _clientService.CreateClient(newClient);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientDTO clientDto)
        {
            var clientToUpdate = _mapper.Map<ClientDTO, Client>(clientDto);
            _clientService.UpdateClient(clientToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            _clientService.DeleteClient(id);

            return Ok();
        }

        [HttpGet("/allClients")]
        public async Task<IActionResult> GetClientsAsync([FromQuery] SearchParamsDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsDTO, SearchParams>(searchParams);

            var clients = await _clientService.GetClientsAsync(parameters);

            var clientsToReturn = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clients);

            return Ok(clientsToReturn);
        }
    }
}
