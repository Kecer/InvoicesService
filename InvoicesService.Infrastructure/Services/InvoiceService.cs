using System;
using System.Linq;
using System.Threading.Tasks;
using InvoicesService.Core.Enums;
using InvoicesService.Core.Interfaces;
using InvoicesService.Core.Interfaces.Repositories;
using InvoicesService.Core.Interfaces.Services;
using InvoicesService.Core.Models.CommonModels;
using InvoicesService.Core.Models.DatabaseModels;
using InvoicesService.Infrastructure.Dtos;
using InvoicesService.Infrastructure.Extensions;

namespace InvoicesService.Infrastructure.Services
{
    public class InvoiceService: IInvoiceService
    {
        protected IInvoiceRepository<Invoice> _invoiceRepository;
        public InvoiceService(IInvoiceRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<IResult> GetById(string invoiceNumber)
        {
           var invoice = await _invoiceRepository.GetByIdAsync(invoiceNumber);
           if (invoice == null)
           {
               return Result.Fail("Invoice not found");
           }

           return Result<Invoice>.Success(invoice);
        }

        public async Task<PaginatedResult<Invoice>> ListWithPagging(InvoiceProcessingStatus status, InvoicePaymentMethods paymentMethod,string order,int pageNumber,int pageSize)
        {
            IQueryable<Invoice> query = _invoiceRepository.Entities;

            if (status>0)
            {
                query = query.Where(x=>x.InvoiceStatus == status);
            }
            if (paymentMethod>0)
            {
                query = query.Where(x => x.PaymentMethod == paymentMethod);
            }
            switch (order)
            {
                case "date_asc":
                    query = query.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.DateCreated);
                    break;
            }
            var response = await query.ToPaginatedListAsync<Invoice>(pageNumber,pageSize);

            return response;
        }

        public async Task<IResult> Create(PostInvoiceDto dto)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = dto.InvoiceNumber,
                PaymentMethod = dto.PaymentMethod,
                Amount = dto.Amount
            };

            await  _invoiceRepository.AddAsync(invoice);
            return Result.Success();
        }

        public async Task<IResult> Update(string invoiceNumber,PutInvoiceDto dto)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceNumber);
            if (invoice == null)
            {
                return Result.Fail("Invoice not found");
            }

            invoice.Amount = dto.Amount;
            invoice.InvoiceStatus = dto.InvoiceStatus;
            invoice.PaymentMethod = dto.PaymentMethod;
            invoice.DateUpdated = DateTime.UtcNow;
            await  _invoiceRepository.UpdateAsync(invoice);
            
            return Result.Success();
        }
    }
}