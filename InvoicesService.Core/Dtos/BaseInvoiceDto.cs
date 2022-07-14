using InvoicesService.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoicesService.Core.Dtos
{
    public class BaseInvoiceDto
    {
        public InvoicePaymentMethods PaymentMethod { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Value must be greater than {1}")]
        public decimal Amount { get; set; }
    }
}
