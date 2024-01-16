using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        private readonly IMapper _mapper;

        public ClientRepository(IMapper mapper, TimeSheetDbContext timeSheetDbContext)
        {
            _mapper = mapper;
            _timeSheetDbContext = timeSheetDbContext;
        }
        public void CreateClient(Client client)
        {
            Country country = new Country();
            country.Name = client.Name;
            Client nClient = new Client();
            nClient.Country = country;
            nClient.Name = client.Name;
            nClient.Address = client.Address;
            nClient.City = client.City;
            nClient.PostalCode = client.PostalCode;

            var clientToAdd = _mapper.Map<Client, ClientEntity>(nClient);
            _timeSheetDbContext.Clients.Add(clientToAdd);
            SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var clientToDelete = _timeSheetDbContext.Clients.Find(id);
            clientToDelete.IsDeleted = true;
            _timeSheetDbContext.Clients.Update(clientToDelete);
            SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(SearchParams searchParams)
        {
            var query = _timeSheetDbContext.Clients.AsQueryable();

            if (searchParams.FirstLetter.HasValue && char.IsLetter((char)searchParams.FirstLetter))
            {
                query = query.Where(client => EF.Functions.Like(client.Name, $"{searchParams.FirstLetter}%"));
            }
            if (!string.IsNullOrEmpty(searchParams.SearchText))
            {
                query = query.Where(client => EF.Functions.Like(client.Name, $"%{searchParams.SearchText}%"));
            }

            var totalClients = await query.CountAsync();

            var paginatedClients = await query
                .Skip((searchParams.PageIndex - 1) * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToListAsync();

            var pagination = new Pagination<ClientEntity>(searchParams.PageIndex, searchParams.PageSize, totalClients, paginatedClients);

            var clientsToReturn = _mapper.Map<IEnumerable<ClientEntity>, IEnumerable<Client>>(pagination.Data);

            return clientsToReturn;
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            var clientToUpdate = _timeSheetDbContext.Clients.Find(client.Id);
            var clientChanges = _mapper.Map<Client, ClientEntity>(client);

            clientToUpdate.Name = clientChanges.Name;

            _timeSheetDbContext.Clients.Update(clientToUpdate);

            SaveChanges();
        }
    }
}
