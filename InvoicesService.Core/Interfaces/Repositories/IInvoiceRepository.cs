using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesService.Core.Interfaces.Repositories
{
    public interface IInvoiceRepository<Invoice> 
    {
        IQueryable<Invoice> Entities { get; }

        Task<Invoice> GetByIdAsync(string invoiceNumber);
        
        Task AddAsync(Invoice entity);

        Task UpdateAsync(Invoice entity);
    }
}