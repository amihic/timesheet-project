using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Model;
// p.id u.id
//
namespace TimeSheet.Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ClientEntity Client { get; set; }
        public UserEntity Lead { get; set; }
        public Boolean IsActived { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
