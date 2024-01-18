namespace API.DTO
{
    public class CreateActivityDTO
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public double OverTime { get; set; }
    }
}
