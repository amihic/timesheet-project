using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Helpers
{
    public class SearchParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; }
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public SearchParams()
        {
            PageIndex = 1; 
            PageSize = 5;
        }
        
        public char? FirstLetter { get; set; } 
        public string? SearchText { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set;}
        public int? ClientId { get; set; }
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }
        public int? CategoryId { get; set; }

    }
}
