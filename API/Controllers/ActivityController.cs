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
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        private readonly IMapper _mapper;

        public ActivityController(IMapper mapper, IActivityService activityService)
        {
            _mapper = mapper;
            _activityService = activityService;
        }

        [Authorize(Roles = "Worker")]
        [HttpPost]
        [API.CustomAuthorizationFilter.CustomAuthorizationFilter]
        public IActionResult CreateActivity([FromBody] CreateActivityDTO newActivityDto)
        {
            var loggedInUser = HttpContext.Items["UserId"] as LoggedInUser;
            
            var newActivity = _mapper.Map<CreateActivityDTO, Activity>(newActivityDto);
            _activityService.CreateActivity(newActivity, loggedInUser.Id);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateActivity([FromBody] ActivityDTO activityDto)
        {
            var activityToUpdate = _mapper.Map<ActivityDTO, Activity>(activityDto);
            _activityService.UpdateActivity(activityToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity([FromRoute] int id)
        {
            _activityService.DeleteActivity(id);

            return Ok();
        }

        [HttpGet("/reports")]
        public async Task<IActionResult> GetActivitiesAsync([FromQuery] SearchParamsForReportsDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsForReportsDTO, SearchParams>(searchParams);

            var activities = await _activityService.GetActivitiesAsync(parameters);

            var activitiesToReturn = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityDTO>>(activities);

            return Ok(activitiesToReturn);
        }

        [Authorize(Roles = "Worker, Admin")]
        [HttpGet("/workingCalendar")]
        [API.CustomAuthorizationFilter.CustomAuthorizationFilter]
        public async Task<IActionResult> GetWorkingCalendarAsync([FromQuery] SearchParamsForCalendarDTO searchParams)
        {
            var loggedInUser = HttpContext.Items["UserId"] as LoggedInUser;

            var parameters = _mapper.Map<SearchParamsForCalendarDTO, SearchParams>(searchParams);             

            parameters.UserId = loggedInUser.Id;

            var workingCalendar = await _activityService.GetWorkingCalendarAsync(parameters);

            var workingCalendarToReturn = _mapper.Map<WorkingCalendar, WorkingCalendarDTO>(workingCalendar);

            return Ok(workingCalendarToReturn);
        }
    }
}
