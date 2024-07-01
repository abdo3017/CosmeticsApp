using MyApp.Application.Helpers;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Mappers
{
    public static class PaymentInfoMapper
    {
        public static PaymentInfoDto Decrypt(this PaymentInfoDto paymentInfo)
        {
            return new PaymentInfoDto
            {
                OrderId = paymentInfo.OrderId,
                CardNumber = EncryptionHelper.DecryptData(EncryptionHelper.GenerateSymmetricKey(), Convert.FromBase64String(paymentInfo.CardNumber)),
                ExpiryMonth = EncryptionHelper.DecryptData(EncryptionHelper.GenerateSymmetricKey(),Convert.FromBase64String(paymentInfo.ExpiryMonth)),
                ExpiryYear = EncryptionHelper.DecryptData(EncryptionHelper.GenerateSymmetricKey(),Convert.FromBase64String(paymentInfo.ExpiryYear)),
                SecurityCode = EncryptionHelper.DecryptData(EncryptionHelper.GenerateSymmetricKey(),Convert.FromBase64String(paymentInfo.SecurityCode)),
            };
        }
    }
}
