using System.ComponentModel.DataAnnotations;
using InvoicesService.Core.Dtos;
using InvoicesService.Core.Enums;

namespace InvoicesService.Infrastructure.Dtos
{
    public class PostInvoiceDto :BaseInvoiceDto
    {
        [Required]
        public string InvoiceNumber { get; set; }
       
    }
}