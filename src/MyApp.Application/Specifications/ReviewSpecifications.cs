﻿using MyApp.Application.Core.Specifications;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Specifications
{
    public static class ReviewSpecifications
    {
        
        public static BaseSpecification<Review> GetReviewById(int id)
        {
            return new BaseSpecification<Review>(x => x.Id == id);
        }
        public static BaseSpecification<Review> GetReviewsByCustomerId(int customerId)
        {
            return new BaseSpecification<Review>(x => x.CustomerId == customerId);
        }
    }
}