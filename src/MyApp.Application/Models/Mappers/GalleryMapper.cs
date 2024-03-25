using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class GalleryMapper
    {

        public static async Task<byte[]> ConvertFormFileToBarr(IFormFile file)
        {
            byte[] imageData = null;
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }

            }
            return imageData;
        }
    }
}
