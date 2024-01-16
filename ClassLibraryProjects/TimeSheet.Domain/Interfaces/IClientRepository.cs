using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(SearchParams searchParams);
        void DeleteClient(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void SaveChanges();
    }
}
