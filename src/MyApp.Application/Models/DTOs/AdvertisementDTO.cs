using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class AdvertisementDTO
    {
        public byte[]? Img { get; set; }

        public int? TagName { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? Discount { get; set; }
    }
}
