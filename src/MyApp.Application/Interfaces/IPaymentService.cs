using MyApp.Application.Models.DTOs;
using Microsoft.AspNetCore.Http;

namespace MyApp.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<object> ExecutePayment(PaymentInfoDto paymentInfoDto);
    }
}