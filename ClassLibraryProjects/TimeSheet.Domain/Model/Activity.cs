using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public int UserId  { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Project Project { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Time {  get; set; }
        public double OverTime { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
