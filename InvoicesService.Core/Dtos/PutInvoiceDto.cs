using System.ComponentModel.DataAnnotations;
using InvoicesService.Core.Dtos;
using InvoicesService.Core.Enums;

namespace InvoicesService.Infrastructure.Dtos
{
    public class PutInvoiceDto: BaseInvoiceDto
    {
        public InvoiceProcessingStatus InvoiceStatus { get; set; }
      
    }
}