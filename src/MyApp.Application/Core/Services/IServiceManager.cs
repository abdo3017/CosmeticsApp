﻿using MyApp.Application.Interfaces;
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

        IReviewService ReviewService { get; }
        ICategoryService CategoryService { get; }
        IBrandService BrandService { get; }
        IProductService ProductService { get; }
        IAdvertisementService AdvertisementService { get; }
        IGalleryService GalleryService { get; }
        IAttributeValueService AttributeValueService { get; }
        IOrderService OrderService { get; }
        ILocationService LocationService { get; } 
        IOrderDetailsService OrderDetailsService { get; }
    }
}
