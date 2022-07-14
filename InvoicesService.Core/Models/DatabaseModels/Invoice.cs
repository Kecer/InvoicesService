using System;
using System.ComponentModel.DataAnnotations;
using InvoicesService.Core.Enums;
using InvoicesService.Core.Models.BaseModels;

namespace InvoicesService.Core.Models.DatabaseModels
{
    public class Invoice:BaseModel
    {
        public string InvoiceNumber { get; set; }
        public InvoiceProcessingStatus InvoiceStatus { get; set; } = InvoiceProcessingStatus.New;
        public decimal Amount { get; set; }
        public InvoicePaymentMethods PaymentMethod { get; set; }
    }
}