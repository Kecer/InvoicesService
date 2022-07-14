using System.Threading.Tasks;
using InvoicesService.Core.Enums;
using InvoicesService.Core.Models.CommonModels;
using InvoicesService.Core.Models.DatabaseModels;
using InvoicesService.Infrastructure.Dtos;

namespace InvoicesService.Core.Interfaces.Services
{
    public interface IInvoiceService
    {

        Task<IResult> GetById(string invoiceNumber);
        Task<PaginatedResult<Invoice>> ListWithPagging(InvoiceProcessingStatus status, InvoicePaymentMethods paymentMethod,string order, int pageNumber,int pageSize);
        
        Task<IResult> Create(PostInvoiceDto dto);

        Task<IResult> Update(string invoiceNumber,PutInvoiceDto dto);
        
        
    }
}