using TimeSheet.Domain.Model;

namespace API.DTO
{
    public class CreateProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int LeadId { get; set; }
    }
}
