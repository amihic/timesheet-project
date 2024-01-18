using TimeSheet.Domain.Model;

namespace API.DTO
{
    public class WorkingCalendarDTO
    {
        public List<WorkingDayDTO> WorkingDays { get; set; }
        public double TotalHours { get; set; }
    }
}
