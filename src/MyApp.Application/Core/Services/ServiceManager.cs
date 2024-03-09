using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Core.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBrandService> _brandService;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));

            _brandService = new Lazy<IBrandService>(() => new BrandService(unitOfWork));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IBrandService BrandService => _brandService.Value;
    }
}
