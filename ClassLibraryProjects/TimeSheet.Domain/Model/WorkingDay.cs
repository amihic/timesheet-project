using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Model
{
    public enum WorkStatus
    {
        FINISHED,
        UNFINISHED,
        IDLE
    }
    public class WorkingDay
    {
        public int Id { get; set; }
        public int NumberOfHours { get; set; }
        public DateTime Date { get; set; }
        public WorkStatus WorkStatus { get; set; }
    }
}
