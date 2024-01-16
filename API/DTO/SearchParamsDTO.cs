namespace API.DTO
{
    public class SearchParamsDTO
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public char? FirstLetter { get; set; }
        public string? SearchText { get; set; }
    }
}
