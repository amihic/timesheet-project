using TimeSheet.Domain.Model;

namespace API.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserDTO> UsersWorkingOn { get; set; }
        public ClientDTO Client { get; set; }
        public UserDTO Lead { get; set; }
    }
}
