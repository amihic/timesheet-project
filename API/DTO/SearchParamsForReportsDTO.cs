namespace API.DTO
{
    public class SearchParamsForReportsDTO
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        //public int? UserId { get; set; }
        public int? ClientId { get; set; }
        public int? ProjectId { get; set; }
        public int? CategoryId { get; set; }
    }
}
