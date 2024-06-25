using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Responses
{
    public class ExecutePaymentRes
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public ExecutePaymentResponse Data { get; set; }
    }
    public class ValidationError
    {
        public string Name { get; set; }

        public string Error { get; set; }

    }
    public class ExecutePaymentResponse 
    {
        public int InvoiceId { get; set; }

        public bool IsDirectPayment { get; set; }
        public string PaymentURL { get; set; }
        public string CustomerReference { get; set; }
        public string UserDefinedField { get; set; }
        public string RecurringId { get; set; }
    }
}
