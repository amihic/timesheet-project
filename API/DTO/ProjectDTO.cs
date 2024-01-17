using TimeSheet.Domain.Model;

namespace API.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Lead { get; set; }
    }
}
