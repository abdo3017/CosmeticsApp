using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Core.Services
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IBrandService BrandService { get; }
    }
}
