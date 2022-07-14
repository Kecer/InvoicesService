using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoicesService.Core.Interfaces.Repositories;
using InvoicesService.Core.Models.DatabaseModels;
using InvoicesService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvoicesService.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository<Invoice>
    {
        protected readonly InvoiceServiceDBContext _dbContext;

        public InvoiceRepository(InvoiceServiceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Invoice> Entities => _dbContext.Set<Invoice>();
        public async Task<Invoice> GetByIdAsync(string invoiceNumber)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceNumber == invoiceNumber);
        }

        public async Task AddAsync(Invoice entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice entity)
        {
             _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}