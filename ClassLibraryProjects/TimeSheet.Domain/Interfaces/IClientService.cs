using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IClientService
    {
        void CreateClient(Client newClient);
        void UpdateClient(Client client);
        Task<IEnumerable<Client>> GetClientsAsync(SearchParams searchParams);
        void DeleteClient(int id);
    }
}
