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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;


        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void CreateProject(Project newProject)
        {
            _projectRepository.CreateProject(newProject);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }

        public Task<IEnumerable<Project>> GetProjectsAsync(SearchParams searchParams)
        {
            return _projectRepository.GetProjectsAsync(searchParams);
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }
    }
}
