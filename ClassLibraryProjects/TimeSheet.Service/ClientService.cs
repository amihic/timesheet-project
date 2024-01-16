using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;


        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void CreateClient(Client newClient)
        {
            _clientRepository.CreateClient(newClient);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }

        public Task<IEnumerable<Client>> GetClientsAsync(SearchParams searchParams)
        {
            return _clientRepository.GetClientsAsync(searchParams);
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }
    }
}
