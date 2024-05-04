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

        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IAdvertisementService> _advertisementService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IGalleryService> _galleryService;
        private readonly Lazy<IAttributeValueService> _AttributeValueService;
        private readonly Lazy<ILocationService> _locationService;
        private readonly Lazy<IOrderDetailsService> _OrderDetailsService;
        private readonly Lazy<IBaseOrderService> _baseOrderService;
        private readonly Lazy<ISalesOrderService> _salesOrderService;
        private readonly Lazy<IReturnOrderService> _returnOrderService;
        private readonly Lazy<IShipmentCostService> _ShipmentCostService;


        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(unitOfWork));
            _advertisementService = new Lazy<IAdvertisementService>(() => new AdvertisementService(unitOfWork));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));
            _brandService = new Lazy<IBrandService>(() => new BrandService(unitOfWork));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork));
            _galleryService = new Lazy<IGalleryService>(() => new GalleryService(unitOfWork));
            _AttributeValueService = new Lazy<IAttributeValueService>(() => new AttributeValueService(unitOfWork));
            _baseOrderService = new Lazy<IBaseOrderService>(() => new BaseOrderService(unitOfWork, new ProductService(unitOfWork), new AttributeValueService(unitOfWork), new OrderDetailsService(unitOfWork), new ShipmentCostService(unitOfWork)));
            _salesOrderService = new Lazy<ISalesOrderService>(() => new SalesOrderService(unitOfWork, new ProductService(unitOfWork), new AttributeValueService(unitOfWork), new OrderDetailsService(unitOfWork), new ShipmentCostService(unitOfWork)));
            _returnOrderService = new Lazy<IReturnOrderService>(() => new ReturnOrderService(unitOfWork, new ProductService(unitOfWork), new AttributeValueService(unitOfWork), new OrderDetailsService(unitOfWork), new ShipmentCostService(unitOfWork)));
            _locationService = new Lazy<ILocationService>(() => new LocationService(unitOfWork));
            _OrderDetailsService = new Lazy<IOrderDetailsService>(() => new OrderDetailsService(unitOfWork));
            _ShipmentCostService = new Lazy<IShipmentCostService>(() => new ShipmentCostService(unitOfWork));
        }

        public IReviewService ReviewService => _reviewService.Value;
        public IAdvertisementService AdvertisementService => _advertisementService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IBrandService BrandService => _brandService.Value;
        public IProductService ProductService => _productService.Value;
        public IGalleryService GalleryService => _galleryService.Value;
        public IAttributeValueService AttributeValueService => _AttributeValueService.Value;
        public ILocationService LocationService => _locationService.Value;
        public IOrderDetailsService OrderDetailsService => _OrderDetailsService.Value;
        public IBaseOrderService BaseOrderService => _baseOrderService.Value;
        public ISalesOrderService SalesOrderService => _salesOrderService.Value;
        public IReturnOrderService ReturnOrderService => _returnOrderService.Value;

        public IShipmentCostService ShipmentCostService => _ShipmentCostService.Value;

    }
}
