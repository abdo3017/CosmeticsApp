using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> CreateCategory(CategoryDTO req);

    }
}