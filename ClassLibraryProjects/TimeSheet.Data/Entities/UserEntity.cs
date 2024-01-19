using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Data.Entities
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double HoursPerWeek { get; set; }
        public ICollection<ProjectEntity> ProjectsWorkingOn { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
