namespace API.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public ClientDTO Client { get; set; }
        public ProjectDTO Project { get; set; }
        public CategoryDTO Category { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public double OverTime { get; set; }
    }
}
