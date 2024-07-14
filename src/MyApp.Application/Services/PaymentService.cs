using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Mappers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using MyApp.Application.Helpers;
using System.Security;
using MyApp.Application.Models.Responses;

namespace MyApp.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> ExecutePayment(PaymentInfoDto paymentInfoDto)
        {
            var orderRepo = _unitOfWork.Repository<Order, int>();
            var order = await orderRepo.GetByIdAsync(paymentInfoDto.OrderId);
            var resExecute = await Execute(order?.TotalPrice ?? 1);
            var res = paymentInfoDto.Decrypt();
            var resDirect = await Direct(resExecute.Data.PaymentURL, order?.TotalPrice ?? 1, res);
            return resDirect;
        }
        private async Task<ExecutePaymentRes> Execute(decimal ivoiceValue)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Helper.PAYMENT_TOKEN);
                var response = await client.PostAsJsonAsync(Helper.PAYMENT_BASE_URL + "ExecutePayment", new
                {
                    PaymentMethodId = 20,
                    InvoiceValue = ivoiceValue
                });

                if (response == null)
                {
                    throw new Exception("Error Accured!!");
                }
                return await response.Content.ReadFromJsonAsync<ExecutePaymentRes>();

            }
        }
        private async Task<object> Direct(string url, decimal ivoiceValue, PaymentInfoDto paymentInfoDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Helper.PAYMENT_TOKEN);
                var response = await client.PostAsJsonAsync(url, new
                {
                    PaymentType = "card",
                    InvoiceValue = ivoiceValue,
                    Bypass3DS = false,
                    Card = new
                    {
                        Number = paymentInfoDto.CardNumber,
                        ExpiryMonth = paymentInfoDto.ExpiryMonth,
                        ExpiryYear = paymentInfoDto.ExpiryYear,
                        SecurityCode = paymentInfoDto.SecurityCode
                    }
                });

                if (response == null)
                {
                    throw new Exception("Error Accured!!");
                }
                return await response.Content.ReadFromJsonAsync<object>();

            }

        }

    }
}
