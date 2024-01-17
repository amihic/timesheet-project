using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync(SearchParams searchParams);
        void DeleteProject(int id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void SaveChanges();
    }
}
