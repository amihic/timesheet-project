using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;
using TimeSheet.Service;

namespace API.Controllers
{
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        private readonly IMapper _mapper;

        public ProjectController(IMapper mapper, IProjectService projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProject([FromBody] CreateProjectDTO newProjectDto)
        {
            var newProject = _mapper.Map<CreateProjectDTO, Project>(newProjectDto);
            _projectService.CreateProject(newProject);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateProject([FromBody] ProjectDTO projectDto)
        {
            var projectToUpdate = _mapper.Map<ProjectDTO, Project>(projectDto);
            _projectService.UpdateProject(projectToUpdate);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProject([FromRoute] int id)
        {
            _projectService.DeleteProject(id);

            return Ok();
        }

        [HttpGet("/allProjects")]
        public async Task<IActionResult> GetProjectsAsync([FromQuery] SearchParamsForCliCatProUseDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsForCliCatProUseDTO, SearchParams>(searchParams);

            var projects = await _projectService.GetProjectsAsync(parameters);

            var projectsToReturn = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects);

            return Ok(projectsToReturn);
        }
    }
}
