using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Model
{
    public class WorkingCalendar
    {
        public int Id { get; set; }
        public List<WorkingDay> WorkingDays { get; set; }
        public double TotalHours { get; set; }
    }
}
