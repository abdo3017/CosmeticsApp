using MyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class SearchResult
    {
        public int Key { get; set; }
        public SearchResultType Type { get; set; }
        public string Name { get; set; }
    }
}
