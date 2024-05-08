using MyApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class SearchResultDTO
    {
        public List<SearchResult> Products = new List<SearchResult>();
        public List<SearchResult> Categories = new List<SearchResult>();
        public List<SearchResult> Brands = new List<SearchResult>();

    }
}
