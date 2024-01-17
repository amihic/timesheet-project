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
    public class ProjectRepository : IProjectRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        private readonly IMapper _mapper;

        public ProjectRepository(IMapper mapper, TimeSheetDbContext timeSheetDbContext)
        {
            _mapper = mapper;
            _timeSheetDbContext = timeSheetDbContext;
        }
        public void CreateProject(Project project)
        {
            var projectToAdd = _mapper.Map<Project, ProjectEntity>(project);
            _timeSheetDbContext.Projects.Add(projectToAdd);
            SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var projectToDelete = _timeSheetDbContext.Projects.Find(id);

            if (projectToDelete == null)
            { 
                throw new DirectoryNotFoundException();
            }

            projectToDelete.IsDeleted = true;
            _timeSheetDbContext.Projects.Update(projectToDelete);
            SaveChanges();
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(SearchParams searchParams)
        {
            var query = _timeSheetDbContext.Projects.AsQueryable();

            if (searchParams.FirstLetter.HasValue && char.IsLetter((char)searchParams.FirstLetter))
            {
                query = query.Where(project => EF.Functions.Like(project.Name, $"{searchParams.FirstLetter}%"));
            }
            if (!string.IsNullOrEmpty(searchParams.SearchText))
            {
                query = query.Where(project => EF.Functions.Like(project.Name, $"%{searchParams.SearchText}%"));
            }

            var totalProjects = await query.CountAsync();

            var paginatedProjects = await query
                .Skip((searchParams.PageIndex - 1) * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToListAsync();

            var pagination = new Pagination<ProjectEntity>(searchParams.PageIndex, searchParams.PageSize, totalProjects, paginatedProjects);

            var projectsToReturn = _mapper.Map<IEnumerable<ProjectEntity>, IEnumerable<Project>>(pagination.Data);

            return projectsToReturn;
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            var projectToUpdate = _timeSheetDbContext.Projects.Find(project.Id);
            var projectChanges = _mapper.Map<Project, ProjectEntity>(project);

            projectToUpdate.Name = projectChanges.Name;

            _timeSheetDbContext.Projects.Update(projectToUpdate);
            SaveChanges();
        }
    }
}
