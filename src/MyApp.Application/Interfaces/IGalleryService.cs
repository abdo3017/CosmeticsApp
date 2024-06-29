using Microsoft.AspNetCore.Http;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IGalleryService
    {
        Task<Gallery> CreateImg(int proId, int isCover, IFormFile file);
        void DeleteImg( int Id);
    }
}
