using API.DTO;
using API.PDF;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

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

        [Authorize(Roles = "Worker, Admin")]
        [HttpPost]
        [API.CustomAuthorizationFilter.CustomAuthorizationFilter]
        public IActionResult CreateActivity([FromBody] CreateActivityDTO newActivityDto)
        {
            var loggedInUser = HttpContext.Items["UserId"] as LoggedInUser;
            
            var newActivity = _mapper.Map<CreateActivityDTO, Activity>(newActivityDto);
            _activityService.CreateActivity(newActivity, loggedInUser.Id);

            return Ok();
        }

        [Authorize(Roles = "Worker, Admin")]
        [HttpPut]
        public IActionResult UpdateActivity([FromBody] ActivityDTO activityDto)
        {
            var activityToUpdate = _mapper.Map<ActivityDTO, Activity>(activityDto);
            _activityService.UpdateActivity(activityToUpdate);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteActivity([FromRoute] int id)
        {
            _activityService.DeleteActivity(id);

            return Ok();
        }

        [Authorize(Roles = "Worker, Admin")]
        [HttpGet("/reports")]
        public async Task<IActionResult> GetReportsAsync([FromQuery] SearchParamsForReportsDTO searchParams)
        {
            var loggedInUser = HttpContext.Items["UserId"] as LoggedInUser;

            var parameters = _mapper.Map<SearchParamsForReportsDTO, SearchParams>(searchParams);

            parameters.UserId = loggedInUser.Id;

            var activities = await _activityService.GetActivitiesAsync(parameters);

            var activitiesToReturn = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityDTO>>(activities);

            return Ok(activitiesToReturn);
        }

        [Authorize(Roles = "Worker, Admin")]
        [HttpGet("/pdf")]
        public async Task<IActionResult> GetPDFReportsAsync([FromQuery] SearchParamsForReportsDTO searchParams)
        {
            var loggedInUser = HttpContext.Items["UserId"] as LoggedInUser;

            var parameters = _mapper.Map<SearchParamsForReportsDTO, SearchParams>(searchParams);

            parameters.UserId = loggedInUser.Id;//ne mora da bude za ulogovanog

            var activities = await _activityService.GetActivitiesAsync(parameters);

            var outputPath = "D:/TimeSheetReportsPDF";

            PdfGenerator pdfGenerator = new PdfGenerator();
            pdfGenerator.GeneratePdf(activities, outputPath);

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
