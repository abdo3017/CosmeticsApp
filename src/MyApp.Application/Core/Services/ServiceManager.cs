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
        private readonly Lazy<IAdvertisementService> _advertisementService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IGalleryService> _galleryService;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _advertisementService = new Lazy<IAdvertisementService>(() => new AdvertisementService(unitOfWork));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));
            _brandService = new Lazy<IBrandService>(() => new BrandService(unitOfWork));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork));
            _galleryService = new Lazy<IGalleryService>(() => new GalleryService(unitOfWork));
        }

        public IAdvertisementService AdvertisementService => _advertisementService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IBrandService BrandService => _brandService.Value;
        public IProductService ProductService => _productService.Value;
        public IGalleryService GalleryService => _galleryService.Value;
    }
}
