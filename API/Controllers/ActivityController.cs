using API.DTO;
using AutoMapper;
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

        [HttpPost]
        public IActionResult CreateActivity([FromBody] CreateActivityDTO newActivityDto)
        {
            var newActivity = _mapper.Map<CreateActivityDTO, Activity>(newActivityDto);
            _activityService.CreateActivity(newActivity);

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

        [HttpGet("/allActivities")]
        public async Task<IActionResult> GetActivitiesAsync([FromQuery] SearchParamsDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsDTO, SearchParams>(searchParams);

            var activities = await _activityService.GetActivitiesAsync(parameters);

            var activitiesToReturn = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityDTO>>(activities);

            return Ok(activitiesToReturn);
        }
        //za working day
        [HttpGet("/workingDay")]
        public async Task<IActionResult> GetWorkingDayAsync([FromQuery] SearchParamsDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsDTO, SearchParams>(searchParams);

            var workingDay = await _activityService.GetWorkingDayAsync(parameters);

            var workingDayToReturn = _mapper.Map<WorkingDay, WorkingDayDTO>(workingDay);

            return Ok(workingDayToReturn);
        }

        
    }
}
