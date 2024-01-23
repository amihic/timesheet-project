using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Model
{
    public class WorkingDay
    {
        public int Id { get; set; }
        public double NumberOfHours { get; set; } = 0;
        public DateTime Date { get; set; }
        public WorkStatus WorkStatus { get; set; }
    }
}
