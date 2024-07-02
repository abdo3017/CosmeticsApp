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
        IPaymentService PaymentService { get; }
        ICardTokenService CardTokenService { get; }
        IReviewService ReviewService { get; }
        ICategoryService CategoryService { get; }
        IBrandService BrandService { get; }
        IProductService ProductService { get; }
        IAdvertisementService AdvertisementService { get; }
        IGalleryService GalleryService { get; }
        IAttributeValueService AttributeValueService { get; }
        IBaseOrderService BaseOrderService { get; }
        ISalesOrderService SalesOrderService { get; }
        IReturnOrderService ReturnOrderService { get; }
        ILocationService LocationService { get; }
        IOrderDetailsService OrderDetailsService { get; }
        IShipmentCostService ShipmentCostService { get; }
        ICustomerService CustomerService { get; }

    }
}
