using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data.Entities
{
    public class ActivityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public ClientEntity Client { get; set; }
        public ProjectEntity Project { get; set; }
        public CategoryEntity Category { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public double OverTime { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
